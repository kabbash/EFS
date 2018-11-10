import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AchievementsComponent } from 'src/app/home/home/achievements/achievements.component';
import { HeroPanerComponent } from 'src/app/home/home/hero-paner/hero-paner.component';
import { KnowYourCoachComponent } from 'src/app/home/home/know-your-coach/know-your-coach.component';
import { OpinionsOfTraineesComponent } from 'src/app/home/home/opinions-of-trainees/opinions-of-trainees.component';
import { WhatWaitingComponent } from 'src/app/home/home/what-waiting/what-waiting.component';
import { WhyEFSComponent } from 'src/app/home/home/why-efs/why-efs.component';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations: [HomeComponent, AchievementsComponent, HeroPanerComponent, KnowYourCoachComponent,
    OpinionsOfTraineesComponent, WhatWaitingComponent, WhyEFSComponent]
})
export class HomeModule { }
