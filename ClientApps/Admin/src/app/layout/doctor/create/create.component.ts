import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';



@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  public ownerForm: FormGroup;
  constructor() {}

  ngOnInit() {
    this.ownerForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      dateOfBirth: new FormControl(new Date()),
      address: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.ownerForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    //this.location.back();
  }

  public createOwner = (ownerFormValue) => {
    if (this.ownerForm.valid) {
      //this.executeOwnerCreation(ownerFormValue);
    }
  }
}
