import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Place } from './place';

@Component({
  selector: 'app-places-list',
  templateUrl: './places-list.component.html',
  styleUrls: ['./places-list.component.css']
})
export class PlacesListComponent  {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    http.get<Place[]>(baseUrl + 'api/settlements').subscribe(result => {
      this.PlacesList = result;
    }, error => console.error(error));
  }

  public PlacesList: Place[];

  public createPlace() {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    this.http.post<Place>(this.baseUrl + 'api/settlements/', "", httpOptions).subscribe(result => {
      this.router.navigate(["/places", result.name])
    });
  }
}
