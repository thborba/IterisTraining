
import { Injectable, Input } from '@angular/core';
import { LetterModel } from '../letter-model';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private wordList = [{ categoria: "Ramo de Atuação", palavra: "Administração" }, { categoria: "Animal", palavra: "Elefante" }, { categoria: "Pais", palavra: "Emirados Arabes Unidos" }];
  private maxErrors = 7;
  private errors = 0;
  private hits = 0;
  private word: string;
  private previousWord: string;

  public letters: Array<LetterModel> = [];
  public isHidden = [true, true, true, true, true, true]
  public typedLetters: Array<string> = [];
  public hint: string;

  constructor() {
    let aux = Math.floor(Math.random() * 3);
    this.word = this.wordList[aux].palavra;
    this.hint = this.wordList[aux].categoria;
    this.previousWord = this.word;

    for(let i = 0; i < this.word.length; i++){
      let item = new LetterModel();
      item.letter = this.word[i];
      item.value = '';
      this.letters.push(item);
    }
  }

  public newPlay(input: string) {
    input = input.toUpperCase();
    if (this.typedLetters.includes(input)) {
      alert("Você já tentou essa letra");
      return;
    }

    if(input == ' '){
      alert("Espaço não vale")
      return;
    }

    this.typedLetters.push(input);
    this.typedLetters.push(' ');
    let hitsTemp = this.hits;
    for (let i = 0; i <= this.word.length; i++) {
      if (this.word[i]) {
        if (input === this.word[i].toUpperCase()) {
          this.letters[i].value = this.word[i].toUpperCase();
          this.hits++;
        }
      }
    }

    if (this.hits <= hitsTemp) {
      if (this.errors < 6)
        this.isHidden[this.errors] = false;

      this.errors++;
    }

    this.checkEnd();
  }

  public checkEnd(): void {
    if (this.errors >= this.maxErrors) {
      alert("perdeu");
      // buttonSubmit.removeEventListener('click', newPlay);
    }
    if (this.hits === this.word.length) {
      alert("ganhou");
      // buttonSubmit.removeEventListener('click', newPlay);
    }
  }
  public reloadGame(): void {

    this.isHidden = [true, true, true, true, true, true];
    this.errors = 0;
    this.hits = 0;
    this.typedLetters = [];

    while (this.word === this.previousWord) {
      let aux = Math.floor(Math.random() * 3);
      this.word = this.wordList[aux].palavra;
      this.hint = this.wordList[aux].categoria;
    }

    this.previousWord = this.word;
  }


}
