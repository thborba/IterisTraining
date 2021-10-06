/* eslint-disable no-unused-vars */
import React, { useState } from "react";
import FormationCardModel from "../../models/FormationCardModel";
import FormationCard from "../FormationCard/FormationCard";
import "./Formation.css";

function Formation(props) {
  let educationList = [];
  educationList.push(
    new FormationCardModel(
        "TÉCNICO EM INFORMÁTICA",
        "2014 - 2018",
        "Gestão de sistemas computacionais visando suporte ao usuário"
      ),
      new FormationCardModel(
        "ENSINO MÉDIO",
        "LIDER DE PROJETO | 2012 - 2013",
        "Aluno destaque em dois anos subsequentes, em feira de ciências. Participante do Grêmio Estudantil. Bolsista integral por mérito sobre desempenho"
      )
  );

  let experienceList = [];
  experienceList.push(
    new FormationCardModel(
        "GRÊMIO ESTUDANTIL",
        "SECRETÁRIA DO GRÊMIO | 2014 - 2018",
        "Execução de diretrizes propostas pela administração, intermediações de aquisições."
      ),
      new FormationCardModel(
        "3 HORAS DE CIÊNCIAS INTERNAS",
        "LIDER DE PROJETO | 2012 - 2013",
        "Participação na criação de estratégias de administração de serviços, promovendo aprimoramento."
      ),
      new FormationCardModel(
        "PARTICIPAÇÃO EM EMPRESA JUNIOR",
        "LIDER DE PROJETO | 2010 - 2012",
        "Experiência no desenvolvimento de estratégias de mercado, avaliando na análise de metas."
      ),

  );
  const list = props.id === "education" ? educationList : experienceList;
  return (
    <div className="formation d-flex column">
      <span className="section_title">{props.title}</span>
      {list.map((item, i) => (
        <FormationCard key={i} model={item} />
      ))}
    </div>
  );
}

export default Formation;
