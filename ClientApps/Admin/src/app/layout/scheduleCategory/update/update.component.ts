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
  public scheduleCategoryForm: FormGroup;
  constructor(private router: Router, private route: ActivatedRoute, public dataAccess: DataAccessService) {}

  ngOnInit() {
    const scheduleCategoryId = this.route.snapshot.params.id;
    this.scheduleCategoryForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      category: new FormControl('', [Validators.required])
    });
    this.dataAccess.get('ScheduledCategory/get?id=' + scheduleCategoryId).subscribe((data: any) => {
      this.scheduleCategoryForm.patchValue({
        id: scheduleCategoryId,
        category: data.data.category
      });
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.scheduleCategoryForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/schedulecategory/list']);
  }

  public update = scheduleCategoryFormValue => {
    const scheduleCategoryUpdatePayload = {
      id: scheduleCategoryFormValue.id,
      category: scheduleCategoryFormValue.category
    };
    if (this.scheduleCategoryForm.valid) {
      this.dataAccess.post('ScheduledCategory/Update', scheduleCategoryUpdatePayload).subscribe((data: any) => {
        this.router.navigate(['/schedulecategory/list']);
      });
    }
  }
}
