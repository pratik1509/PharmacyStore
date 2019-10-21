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
  public scheduleCategoryForm: FormGroup;
  constructor(private router: Router, public dataAccess: DataAccessService) {}

  ngOnInit() {
    this.scheduleCategoryForm = new FormGroup({
      category: new FormControl('', [Validators.required])
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.scheduleCategoryForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/schedulecategory/list']);
  }

  public create = scheduleCategoryFormValue => {
    const scheduleCategoryCreatePayload = {
      category: scheduleCategoryFormValue.category
    };
    if (this.scheduleCategoryForm.valid) {
      this.dataAccess.post('ScheduledCategory/Create', scheduleCategoryCreatePayload).subscribe((data: any) => {
        this.router.navigate(['/schedulecategory/list']);
      });
    }
  }
}
