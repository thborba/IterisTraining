import React, { Component } from "react";

class OutroTitulo extends Component {
  render() {
    let titulo = "Olá, componente com classe!";
    if (this.props.titulo) {
      titulo = this.props.titulo;
    }
    return <h1>{titulo}</h1>;
  }
}
export default OutroTitulo;