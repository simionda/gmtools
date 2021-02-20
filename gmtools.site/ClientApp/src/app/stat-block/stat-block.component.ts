import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-stat-block',
  templateUrl: './stat-block.component.html',
  styleUrls: ['./stat-block.component.css']
})
export class StatBlockComponent implements OnInit {

  constructor() {
    this.stats.push(new stat("STR", 9));
    this.stats.push(new stat("DEX", 10));
    this.stats.push(new stat("CON", 11));
    this.stats.push(new stat("INT", 12));
    this.stats.push(new stat("WIS", 7));
    this.stats.push(new stat("CHR", 8));

  }

  ngOnInit(): void {
  }

  public stats: stat[] = [];

  
}

class stat {
  name: string;
  score: number;
  modifier: string;

  constructor(name: string, score: number) {
    this.name = name;
    this.score = score;
    this.modifier = this.calcModifier(score);
  }

  private calcModifier(score: number): string {
    var modifier: number = Math.floor((score - 10) / 2);
    return (score > 11 ? "+" : "") + modifier.toString();
  }
}
