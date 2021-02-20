export interface Place {
  name: string;
  size: string;
  raceRelations: string;
  ruler: string;
  rulersStatus: string;
  notableTraits: string;
  knownFor: string;
  calamity: string;
  buildings: Building[];
}

export interface Building {
  description: string;
}
