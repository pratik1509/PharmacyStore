import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataAccessService } from '../../../services/data-access.service';



@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  public doctorForm: FormGroup;
  constructor(private router: Router, public dataAccess: DataAccessService) {}

  ngOnInit() {
    this.doctorForm = new FormGroup({
      doctorName: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required])
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.doctorForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/doctor/list']);
  }

  public create = (doctorFormValue) => {
    debugger
    let doctorCreatePayload = { doctorName: doctorFormValue.doctorName, address: doctorFormValue.address};
    if (this.doctorForm.valid) {
      this.dataAccess.post('Doctor/Create', doctorCreatePayload).subscribe((data: any) => {
        this.router.navigate(['/doctor/list']);
      });
    }
  }
}
