
/**
* Executa o submit do formulário da página
* @param {Event} event Evento de submit
*/
const onSubmit = (event) => {
event.preventDefault();
const submitedValue = {
  nome: event.target.nome.value,
  tipo: event.target.tipo.value,
};

addListItem(submitedValue);
};

/**
* Consulta dados na API
* @returns {Promise<{ tipo: number; nome: string }[]>} Lista de submissões
*/
const getData = () => 
fetch('https://it3-web-default-rtdb.firebaseio.com/submissoes.json')
  .then(response => response.json())
  .catch(err => console.error(err));

/**
* Adiciona item na lista do html
* @param {{ tipo: number; nome: string }} item 
*/
const addListItem = (item) => {
const ulEl = document.querySelector(".submits ul");
const liEl = document.createElement("li");
liEl.innerText = `${item.nome} - Tipo: ${item.tipo}`;
ulEl.appendChild(liEl);
} 

/**
* Adiciona lista de submits consultada
*/
const addSubmits = async () => {
const result = await getData();

result.forEach(addListItem);
}

/**
* executa após carregamento do conteúdo do DOM
*/
const onLoad = () => {
const footerEl = document.querySelector(".footer p");
const formEl = document.querySelector("form");

if (footerEl)
  footerEl.innerHTML += ` - ${new Date().getFullYear()}`;

if (formEl)
  formEl.addEventListener("submit", onSubmit);

addSubmits();
};

document.addEventListener("DOMContentLoaded", onLoad);
