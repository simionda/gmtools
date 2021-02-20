import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TavernDetailComponent } from './tavern-detail.component';

describe('TavernDetailComponent', () => {
  let component: TavernDetailComponent;
  let fixture: ComponentFixture<TavernDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TavernDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TavernDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
