import React, { useState } from "react";
import BlogPostModel from "../../models/BlogPostModel";
import BlogPost from "../BlogPost";
import "./BlogPage.css";

function BlogPage() {
  let listaDePostagens = [];
  listaDePostagens.push(
    new BlogPostModel(
      "Primeira postagem!",
      "https://www.weblink.com.br/blog/wp-content/uploads/2019/06/O-Que-e-Um-Blog.png",
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi a tortor eu  odio pellentesque ullamcorper. Duis non ipsum mauris. Nullam dolor dui"
    ),
    new BlogPostModel(
      "Segunda postagem!",
      "https://viagemeturismo.abril.com.br/wp-content/uploads/2016/12/13-copy-o61.jpg?quality=70&strip=info&w=1024",
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi a tortor eu  odio pellentesque ullamcorper. Duis non ipsum mauris. Nullam dolor dui"
    ),
    new BlogPostModel(
      "Terceira postagem!",
      "https://blog.hotmart.com/blog/2017/09/criar-um-blog.png",
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi a tortor eu  odio pellentesque ullamcorper. Duis non ipsum mauris. Nullam dolor dui"
    )
  );

  const [lista, setLista] = useState(listaDePostagens);

  const [novoTitulo, setNovoTitulo] = useState("");
  const [novaUrl, setNovaUrl] = useState("");
  const [novoTexto, setNovoTexto] = useState("");

  function clickNovoPost() {
    const nova = new BlogPostModel(novoTitulo, novaUrl, novoTexto);
    // o concat gera uma lista nova
    // assim criamos uma lista nova e passarmos para o set
    // só atualizar o lista não notifica o React
    const novaLista = lista.concat(nova);
    setLista(novaLista);
  }
  return (
    <div class="paginaPostagens">
      <fieldset>
        <legend>Nova postagem</legend>
        <input
          type="text"
          value={novoTitulo}
          placeholder="Titulo"
          onChange={(event) => {
            setNovoTitulo(event.target.value);
          }}
        />
        <input
          type="url"
          value={novaUrl}
          placeholder="Url da imagem"
          onChange={(event) => {
            setNovaUrl(event.target.value);
          }}
        />
        <textarea
          placeholder="Texto principal"
          value={novoTexto}
          onChange={(event) => {
            setNovoTexto(event.target.value);
          }}
        ></textarea>
        <button onClick={clickNovoPost}>Criar nova postagem</button>
      </fieldset>
      {lista.map((item, i) => (
        <BlogPost key={i} post={item} />
      ))}
    </div>
  );
}
export default BlogPage;
