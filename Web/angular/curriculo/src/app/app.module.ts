import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PersonalInfoComponent } from './components/personal-info/personal-info.component';
import { ReferencesComponent } from './components/references/references.component';
import { SkillsComponent } from './components/skills/skills.component';
import { ProfileComponent } from './components/profile/profile.component';
import { EducationComponent } from './components/education/education.component';
import { ExperiencesComponent } from './components/experiences/experiences.component';
import { ItemComponent } from './components/item/item.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonalInfoComponent,
    ReferencesComponent,
    SkillsComponent,
    ProfileComponent,
    EducationComponent,
    ExperiencesComponent,
    ItemComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
