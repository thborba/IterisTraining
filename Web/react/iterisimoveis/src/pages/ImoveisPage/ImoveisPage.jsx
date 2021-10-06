import React, { useEffect, useState } from "react";
import { getImoveis } from "../../services/imovelApiService";
import ImovelCard from "../../components/ImovelCard";
import "./ImoveisPage.css";

function ImoveisPage() {
  const [listaImoveis, setListaImoveis] = useState([]);

  // O array vazio no useEffect indica que somente deve ser executando uma vez
  useEffect(() => {
    getImoveis().then((data) => {
      setListaImoveis(data);
    });
  }, []);

  return (
    <div>
      <h1> Página de Imóveis! </h1>
      <div className="listaImoveis">
        {listaImoveis.map((item, i) => {
          return (
            <div key={i} className="listaImoveis__imovelCard">
              <ImovelCard imovel={item} />
            </div>
          );
        })}
      </div>
    </div>
  );
}
export default ImoveisPage;
