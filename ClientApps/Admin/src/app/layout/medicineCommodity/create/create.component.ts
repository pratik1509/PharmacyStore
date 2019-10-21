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
  public medicineCommodityForm: FormGroup;
  constructor(private router: Router, public dataAccess: DataAccessService) {}

  ngOnInit() {
    this.medicineCommodityForm = new FormGroup({
      commodity: new FormControl('', [Validators.required])
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.medicineCommodityForm.controls[controlName].hasError(errorName);
  };

  public onCancel = () => {
    this.router.navigate(['/medicinecommodity/list']);
  };

  public create = medicineCommodityFormValue => {
    const medicineCommodityCreatePayload = {
      commodity: medicineCommodityFormValue.commodity
    };
    if (this.medicineCommodityForm.valid) {
      this.dataAccess.post('MedicineCommodity/Create', medicineCommodityCreatePayload).subscribe((data: any) => {
        this.router.navigate(['/medicinecommodity/list']);
      });
    }
  };
}
