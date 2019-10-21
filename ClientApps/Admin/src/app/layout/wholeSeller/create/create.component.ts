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
  public wholeSellerForm: FormGroup;
  constructor(private router: Router, public dataAccess: DataAccessService) {}

  ngOnInit() {
    this.wholeSellerForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      contactPersonNo: new FormControl('', [Validators.required]),
      drugLicenseNo: new FormControl('', [Validators.required]),
      cstNo: new FormControl('', [Validators.required]),
      gstinNo: new FormControl('', [Validators.required]),
      tinNo: new FormControl('', [Validators.required]),
      vatNo: new FormControl('', [Validators.required])
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.wholeSellerForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/wholeseller/list']);
  }

  public create = wholeSellerFormValue => {
    const wholeSellerCreatePayload = {
      name: wholeSellerFormValue.name,
      address: wholeSellerFormValue.address,
      contactPersonNo: wholeSellerFormValue.contactPersonNo,
      drugLicenseNo: wholeSellerFormValue.drugLicenseNo,
      cstNo: wholeSellerFormValue.address,
      gstinNo: wholeSellerFormValue.gstinNo,
      tinNo: wholeSellerFormValue.tinNo,
      vatNo: wholeSellerFormValue.vatNo
    };
    if (this.wholeSellerForm.valid) {
      this.dataAccess.post('WholeSeller/Create', wholeSellerCreatePayload).subscribe((data: any) => {
        this.router.navigate(['/wholeseller/list']);
      });
    }
  }
}
