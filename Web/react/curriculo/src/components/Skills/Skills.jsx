import React from "react";
import "./Skills.css";

function Skills() {
  return (
    <div class="skills d-flex column">
      <span class="section_title">HABILIDADES</span>

      <div class="skills_item d-flex column">
        <span class="item_label">
          <strong>PROATIVIDADE</strong>
        </span>
        <div class="bar1"> </div>
      </div>

      <div class="skills_item d-flex column">
        <span class="item_label">
          <strong>CRIATIVIDADE</strong>
        </span>
        <div class="bar1"> </div>
      </div>

      <div class="skills_item d-flex column">
        <span class="item_label">
          <strong>COLABORAÇÃO</strong>
        </span>
        <div class="bar1"> </div>
      </div>

      <div class="skills_item d-flex column">
        <span class="item_label">
          <strong>ORGANIZAÇÃO</strong>
        </span>
        <div class="bar1"> </div>
      </div>
    </div>
  );
}

export default Skills;
