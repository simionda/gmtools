import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Place } from '../places-list/place';

@Component({
  selector: 'app-place-detail',
  templateUrl: './place-detail.component.html',
  styleUrls: ['./place-detail.component.css']
})
export class PlaceDetailComponent implements OnInit {
  public place: Place;

  constructor(httpClient: HttpClient, @Inject("BASE_URL") baseUrl: string, private route: ActivatedRoute, private router: Router) {
    var placeName: string;

    placeName = this.route.snapshot.paramMap.get('placeName');

    httpClient.get<Place>(baseUrl + 'api/settlements/' + placeName).subscribe(result => {
      this.place = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}
