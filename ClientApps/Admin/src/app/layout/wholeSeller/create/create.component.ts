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
      wholeSellerName: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required])
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.wholeSellerForm.controls[controlName].hasError(errorName);
  };

  public onCancel = () => {
    this.router.navigate(['/wholeSeller/list']);
  };

  public create = wholeSellerFormValue => {
    let wholeSellerCreatePayload = { wholeSellerName: wholeSellerFormValue.wholeSellerName, address: wholeSellerFormValue.address };
    if (this.wholeSellerForm.valid) {
      this.dataAccess.post('WholeSeller/Create', wholeSellerCreatePayload).subscribe((data: any) => {
        this.router.navigate(['/wholeSeller/list']);
      });
    }
  };
}
