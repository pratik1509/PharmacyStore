import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DataAccessService } from '../../../services/data-access.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  public wholeSellerForm: FormGroup;
  constructor(private router: Router, private route: ActivatedRoute, public dataAccess: DataAccessService) {}

  ngOnInit() {
    debugger;
    const wholeSellerId = this.route.snapshot.params.id;
    this.wholeSellerForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      contactPersonNo: new FormControl('', [Validators.required]),
      drugLicenseNo: new FormControl('', [Validators.required]),
      cstNo: new FormControl('', [Validators.required]),
      gstinNo: new FormControl('', [Validators.required]),
      tinNo: new FormControl('', [Validators.required]),
      vatNo: new FormControl('', [Validators.required])
    });

    this.dataAccess.get('WholeSeller/get?id=' + wholeSellerId).subscribe((data: any) => {
      this.wholeSellerForm.patchValue({
        id: wholeSellerId,
        name: data.data.name,
        address: data.data.address,
        contactPersonNo: data.data.contactPersonNo,
        drugLicenseNo: data.data.address,
        cstNo: data.data.address,
        gstinNo: data.data.gstinNo,
        tinNo: data.data.tinNo,
        vatNo: data.data.vatNo
      });
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.wholeSellerForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/wholeseller/list']);
  }

  public update = wholeSellerFormValue => {
    const wholeSellerCreatePayload = {
      id: wholeSellerFormValue.id,
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
      this.dataAccess.post('Wholeseller/Update', wholeSellerCreatePayload).subscribe((data: any) => {
        this.router.navigate(['/wholeseller/list']);
      });
    }
  }
}
