import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PlayerComponent } from './components/player/player.component';
import { DummyComponent } from './components/dummy/dummy.component';
import { WordComponent } from './components/word/word.component';
import { SpaceComponent } from './components/space/space.component';
import { LetterComponent } from './components/letter/letter.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    PlayerComponent,
    DummyComponent,
    WordComponent,
    SpaceComponent,
    LetterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
