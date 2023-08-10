import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopByCategoryComponent } from './shop-by-category.component';

describe('ShopByCategoryComponent', () => {
  let component: ShopByCategoryComponent;
  let fixture: ComponentFixture<ShopByCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShopByCategoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShopByCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
