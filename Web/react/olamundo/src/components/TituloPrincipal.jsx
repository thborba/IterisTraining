import React, { useState, useEffect } from "react";

function TituloPrincipal(props) {
  // ?? - usar o props.titulo se houver valor, se não usa o "Olá, mundo!"
  const [titulo, setTitulo] = useState(props.titulo ?? "Olá, mundo!");
  
  //Toda vez que o valor do titulo mudar, execute este código
  useEffect(() => { console.log("O titulo mudou!")}, [titulo]);

  function clickCallBack(event) {
    alert("Obrigado por clicar em mim! :)");
  }

  function inputChangeCallBack(event) {
    setTitulo(event.target.value);
  }

  return (
    <div>
      <h1 onClick={clickCallBack}>{titulo}</h1>
      <input
        type="text"
        name="name"
        value={titulo}
        onChange={inputChangeCallBack}
      />
    </div>
  );
}

export default TituloPrincipal;
