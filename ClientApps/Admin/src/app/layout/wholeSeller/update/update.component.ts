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
    const wholeSellerId = this.route.snapshot.params.id;
    this.wholeSellerForm = new FormGroup({
      wholeSellerId: new FormControl('', [Validators.required]),
      wholeSellerName: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required])
    });
    this.dataAccess.get('WholeSeller/get?id=' + wholeSellerId).subscribe((data: any) => {
      this.wholeSellerForm.patchValue({
        wholeSellerId: wholeSellerId,
        wholeSellerName: data.data.wholeSellerName,
        address: data.data.address
      });
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.wholeSellerForm.controls[controlName].hasError(errorName);
  };

  public onCancel = () => {
    this.router.navigate(['/wholeSeller/list']);
  };

  public update = wholeSellerFormValue => {
    const wholeSellerUpdatePayload = {
      wholeSellerId: wholeSellerFormValue.wholeSellerId,
      wholeSellerName: wholeSellerFormValue.wholeSellerName,
      address: wholeSellerFormValue.address
    };
    if (this.wholeSellerForm.valid) {
      this.dataAccess.post('WholeSeller/Update', wholeSellerUpdatePayload).subscribe((data: any) => {
        this.router.navigate(['/wholeSeller/list']);
      });
    }
  };
}
