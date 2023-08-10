import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadeseosComponent } from './listadeseos.component';

describe('ListadeseosComponent', () => {
  let component: ListadeseosComponent;
  let fixture: ComponentFixture<ListadeseosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListadeseosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListadeseosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
