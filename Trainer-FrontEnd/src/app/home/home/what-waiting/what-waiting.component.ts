import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-what-waiting',
  templateUrl: './what-waiting.component.html',
  styleUrls: ['./what-waiting.component.css']
})
export class WhatWaitingComponent implements OnInit {

  animation = false;

  constructor() { }

  ngOnInit() {

    // setInterval(() => {
    //   this.animation = !this.animation;
    // }, 1500);
  }

}
