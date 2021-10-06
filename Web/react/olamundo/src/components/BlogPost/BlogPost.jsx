import React, { useState } from "react";
import "./BlogPost.css";
/**
 * BlogPost Component
 * @param {post:BlogPostModel} props
 * @returns
 */
function BlogPost(props) {

  const [contador, setContador] = useState(0);
  const [post, setPost] = useState(props.post);

  function shareClickCallBack() {
    setContador(contador + 1);
  }
  function checkboxChangeBack(event) {
    const novoValorExibirImagem = !post.exibirImagem;
    // verifique o que acontece se não chamarmos o setPost
    // é um erro comum, que você vai fazer bastante
    // precisamos informar a atualização, para o react renderizar novamente
    // https://developer.mozilla.org/pt-BR/docs/Web/JavaScript/Reference/Operators/Spread_syntax
    setPost({ ...post, exibirImagem: novoValorExibirImagem });
  }
  let imgTag = <div></div>;
  if (post.exibirImagem) {
    imgTag = <img src={post.imagem} alt={post.titulo} />;
  }


  return (
    <article className="blogPost">
      <h2>{post.titulo}</h2>
      <div>
        <input
          type="checkbox"
          defaultChecked={post.exibirImagem}
          onChange={checkboxChangeBack}
        />{" "}
        Exibir imagem?
      </div>
      {imgTag}
      <p>{post.texto}</p>
      <button class="share" onClick={shareClickCallBack}>
        Compartilhar!
      </button>
      <div>{contador}</div>
    </article>
  );
}
export default BlogPost;
