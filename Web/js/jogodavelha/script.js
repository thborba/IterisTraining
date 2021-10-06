
let player = "X";
let winner = null;
let draw = false;
const list = document.getElementsByClassName("cell");

for (var cell of list)
    cell.addEventListener('click', onClick);

function onClick(event) {
    if (winner || draw)
        reload();
    else if (!event.target.classList.contains('X') && !event.target.classList.contains('O')) {
        event.target.innerHTML = player.toString();
        event.target.classList.add(player.toString());
        player = (player == "X" ? "O" : "X");
        checkEnd();
    }
}

function checkEquals(n1, n2, n3) {

    c1 = document.getElementById(n1);
    c2 = document.getElementById(n2);
    c3 = document.getElementById(n3);

    if (c1.classList.contains("X") && c2.classList.contains("X") && c3.classList.contains("X")) {
        winner = "X";
        return true;
    } else if (c1.classList.contains("O") && c2.classList.contains("O") && c3.classList.contains("O")) {
        winner = "O";
        return true;
    } else
        return false;

}

function isFull() {
    for (var cell of list)
        if (!cell.classList.contains("X") && !cell.classList.contains("O"))
            return false;

    return true;

}

function checkEnd() {
    if (checkEquals(1, 2, 3) || checkEquals(4, 5, 6) || checkEquals(7, 8, 9) ||
        checkEquals(1, 4, 7) || checkEquals(2, 5, 8) || checkEquals(3, 6, 9) ||
        checkEquals(1, 5, 9) || checkEquals(3, 5, 7)) {
        alert(winner + " venceu");
    }
    else if (isFull()) {
        alert("empatou");
        draw = true;
    }
}

function reload() {
    for (var cell of list) {
        cell.innerHTML = "";
        cell.classList.remove('O');
        cell.classList.remove('X');
    }
    winner = null;
    draw = false;
    player = "X";
}


