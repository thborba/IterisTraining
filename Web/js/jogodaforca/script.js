const divWord = document.querySelector(".word");
const buttonSubmit = document.querySelector(".player-button");
const typedLettersDiv = document.querySelector(".player-typedLetters");
const newGameButton = document.querySelector(".player-newGame");
const divHint = document.querySelector(".hint");

const dummyBody = ["head", "body", "rightArm", "leftArm", "rightLeg", "leftLeg"]
const maxErrors = 7;

let errors = 0, hits = 0;
let wordList, word, previousWord, hint, typedLetters = [];

const getData = () =>
    fetch('https://it3-forca-default-rtdb.firebaseio.com/conteudo.json')
        .then(response => response.json())
        .catch(err => console.error(err));

(async () => {
    buttonSubmit.addEventListener("click", newPlay);
    newGameButton.addEventListener("click", reloadGame)
    wordList = await getData();
    let aux = Math.floor(Math.random() * 3);
    word = wordList[aux].palavra.trim();
    hint = wordList[aux].categoria.trim();
    previousWord = word;
    appendWord();
})();

function appendWord() {

    for (let i = 0; i <= word.length; i++) {
        let newDiv = document.createElement('div');
        newDiv.id = i;
        if (word[i] === ' ')
            newDiv.classList.add("space");
        else
            newDiv.classList.add("letter");

        divWord.insertAdjacentElement("beforeend", newDiv);
    }

    divHint.innerHTML += "Dica: " + hint;
}

function newPlay() {
    let input = document.getElementById("digit").value.toUpperCase();

    if (typedLetters.includes(input)) {
        alert("Você já tentou essa letra");
        return;
    }

    typedLetters.push(input);
    typedLettersDiv.innerHTML += " " + input;
    let hitsTemp = hits;
    for (let i = 0; i <= word.length; i++) {
        if (word[i]) {
            if (input === word[i].toUpperCase()) {
                let div = document.getElementById(i);
                div.innerHTML = word[i].toUpperCase();
                hits++;
            }
        }
    }

    if (hits <= hitsTemp) {
        if (errors < 6)
            document.getElementById(dummyBody[errors]).hidden = false;
        errors++;
    }

    checkEnd();
}

function checkEnd() {
    if (errors >= maxErrors) {
        alert("perdeu");
        buttonSubmit.removeEventListener('click', newPlay);
    }
    if (hits === word.length) {
        alert("ganhou");
        buttonSubmit.removeEventListener('click', newPlay);
    }
}

function reloadGame() {
    for (let i = 0; i <= word.length; i++)
        divWord.removeChild(document.getElementById(i));

    for (let i = 0; i < 6; i++)
        document.getElementById(dummyBody[i]).hidden = true;

    errors = 0;
    hits = 0;
    typedLetters = [];
    divHint.innerHTML = " ";
    typedLettersDiv.innerHTML = " ";

    while (word === previousWord) {
        let aux = Math.floor(Math.random() * 3);
        word = wordList[aux].palavra;
        hint = wordList[aux].categoria;
    }

    previousWord = word;
    buttonSubmit.addEventListener('click', newPlay);
    appendWord();
}
