import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
@Component({
  selector: 'app-weatherforecast',
  templateUrl: './weatherforecast.component.html',
  styleUrls: ['./weatherforecast.component.css']
})
export class WeatherforecastComponent implements OnInit {

  weatherforecasts: any;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getWeathers();
  }
  getWeathers() {
    this.http.get('http://localhost:5000/weatherforecast').subscribe(response => {
      this.weatherforecasts = response;
    }, error => {
      console.log(error);
    });
  }

}
