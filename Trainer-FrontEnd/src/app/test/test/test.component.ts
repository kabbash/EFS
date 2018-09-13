import { Component, OnInit } from '@angular/core';
import { TestService } from 'src/app/shared/services/test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  movies = [];
  constructor(private testService: TestService) { }

  ngOnInit() {
    this.testService.getAll().subscribe(data => {
      this.movies = data;
    })
  }

}
