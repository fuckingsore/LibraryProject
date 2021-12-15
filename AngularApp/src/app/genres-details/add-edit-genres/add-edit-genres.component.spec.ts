import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditGenresComponent } from './add-edit-genres.component';

describe('AddEditGenresComponent', () => {
  let component: AddEditGenresComponent;
  let fixture: ComponentFixture<AddEditGenresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditGenresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditGenresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
