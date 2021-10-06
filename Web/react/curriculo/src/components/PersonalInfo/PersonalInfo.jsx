import React from "react";
import "./PersonalInfo.css";
import "primeicons/primeicons.css";
function PersonalInfo(props) {
  return (
    <div>
      <div className="background">
        <span className="name d-flex column">
          <strong> JESSICA </strong>
          <strong> RIBEIRO </strong>
        </span>

        
      </div>

      <div className="info d-flex column">
        <div>
          <i className="pi pi-phone"> </i>
          <span className="info_item">(48) 9999-4494</span>
        </div>
        <div>
          <i className="pi pi-link"> </i>
          <span className="info_item">jessicaribeiros.com.br</span>
        </div>
        <div>
          <i className="pi pi-inbox"> </i>
          <span className="info_item">jessica@email.com.br</span>
        </div>
        <div>
          <i className="pi pi-home"> </i>
          <span className="info_item">Av. Rosário, 5, Curitiba - PR</span>
        </div>
      </div>
    </div>
  );
}

export default PersonalInfo;
