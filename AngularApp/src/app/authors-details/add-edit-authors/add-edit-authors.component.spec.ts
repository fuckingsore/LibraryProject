import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAuthorsComponent } from './add-edit-authors.component';

describe('AddEditAuthorsComponent', () => {
  let component: AddEditAuthorsComponent;
  let fixture: ComponentFixture<AddEditAuthorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditAuthorsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAuthorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
