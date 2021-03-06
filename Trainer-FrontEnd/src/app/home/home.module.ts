import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { Routes, RouterModule } from '@angular/router';
import { AchievementsComponent } from './home/achievements/achievements.component';
import { HeroPanerComponent } from './home/hero-paner/hero-paner.component';
import { KnowYourCoachComponent } from './home/know-your-coach/know-your-coach.component';
import { OpinionsOfTraineesComponent } from './home/opinions-of-trainees/opinions-of-trainees.component';
import { WhatWaitingComponent } from './home/what-waiting/what-waiting.component';
import { WhyEFSComponent } from './home/why-efs/why-efs.component';
import { SharedModule } from '../shared/shared.module';
import { CountToModule } from 'angular-count-to';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  }
];

@NgModule({
  imports: [
    SharedModule,
    CountToModule.forRoot(),
    RouterModule.forChild(routes)],

  exports: [RouterModule],
  declarations: [HomeComponent, AchievementsComponent, HeroPanerComponent, KnowYourCoachComponent,
    OpinionsOfTraineesComponent, WhatWaitingComponent, WhyEFSComponent]
})
export class HomeModule { }
