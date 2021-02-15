import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Npc } from '../npc-list/npc';

@Component({
  selector: 'app-npc',
  templateUrl: './npc.component.html',
  styleUrls: ['./npc.component.css']
})
export class NpcComponent implements OnInit {

  public npc: Npc;

  constructor(httpClient: HttpClient, @Inject("BASE_URL") baseurl: string, private route: ActivatedRoute, private router: Router) {
    var npcName: string;

    npcName = this.route.snapshot.paramMap.get('npcName');
    
    httpClient.get<Npc>(baseurl + 'api/npcs/' + npcName).subscribe(result => {
      this.npc = result;
    }, error => console.error(error));
  }

  ngOnInit() {

  }
}
