import { Component, Inject} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Npc } from './Npc';

@Component({
  selector: 'app-npc-list',
  templateUrl: './npc-list.component.html',
  styleUrls: ['./npc-list.component.css']
})
export class NpcListComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    http.get<Npc[]>(baseUrl + 'api/npcs').subscribe(result => {
      this.NpcList = result;
    }, error => console.error(error)); 
  }

  public NpcList: Npc[];
  
  public createNpc() {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    this.http.post<Npc>(this.baseUrl + 'api/npcs/', "", httpOptions).subscribe(result => {
      this.router.navigate(["/npcs", result.name]);
    });
  }
}
