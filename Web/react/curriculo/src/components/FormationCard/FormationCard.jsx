/* eslint-disable no-unused-vars */
import React, { useState } from "react";
import "./FormationCard.css";
function FormationCard(props) {
  const [card, setCard] = useState(props.model);

  return (
    <div class="card d-flex column">
      <span class="card_title">
        <strong>{card.title}</strong>
      </span>
      <span class="card_period"> {card.period} </span>
      <span class="card_description"> {card.description} </span>
    </div>
  );
}

export default FormationCard;
