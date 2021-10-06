
let firstCard, secondCard, lockBoard = false, flipped = false;
const cardList = document.getElementsByClassName("card");

for (var cell of list)
    cell.addEventListener('click', onClick);

function onClick(event) {
    if (!flipped) {
        flipped = true;
        firstCard = event.target;
        return;
    } else {
        secondCard = event.target;
        lockBoard = true;
        checkEquals();
    }
}

function checkEquals(){
    if (firstCard.value === secondCard.value) {
        disableEventListener();
        return true;
    }
    return false;
}

function disableEventListener(){
    firstCard.removeEventListener('click', onClick);
    secondCard.removeEventListener('click', onClick);
}


function shuffle() {
    for (card in cardList) 
        card.style.order = Math.floor(Math.random() * 16)
    
}


