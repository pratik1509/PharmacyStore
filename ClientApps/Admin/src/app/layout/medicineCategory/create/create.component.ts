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
  public medicineCategoryForm: FormGroup;
  constructor(private router: Router, public dataAccess: DataAccessService) {}

  ngOnInit() {
    this.medicineCategoryForm = new FormGroup({
      category: new FormControl('', [Validators.required])
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.medicineCategoryForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/medicinecategory/list']);
  }

  public create = medicineCategoryFormValue => {
    const medicineCategoryCreatePayload = {
      category: medicineCategoryFormValue.category
    };
    if (this.medicineCategoryForm.valid) {
      this.dataAccess.post('MedicineCategory/Create', medicineCategoryCreatePayload).subscribe((data: any) => {
        this.router.navigate(['/medicinecategory/list']);
      });
    }
  }
}
