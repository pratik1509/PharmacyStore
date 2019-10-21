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
  public medicineCategoryForm: FormGroup;
  constructor(private router: Router, private route: ActivatedRoute, public dataAccess: DataAccessService) {}

  ngOnInit() {
    const medicineCategoryId = this.route.snapshot.params.id;
    this.medicineCategoryForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      category: new FormControl('', [Validators.required])
    });
    this.dataAccess.get('MedicineCategory/get?id=' + medicineCategoryId).subscribe((data: any) => {
      this.medicineCategoryForm.patchValue({
        id: medicineCategoryId,
        category: data.data.category
      });
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.medicineCategoryForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/medicinecategory/list']);
  }

  public update = medicineCategoryFormValue => {
    const medicineCategoryUpdatePayload = {
      id: medicineCategoryFormValue.id,
      category: medicineCategoryFormValue.category
    };
    if (this.medicineCategoryForm.valid) {
      this.dataAccess.post('MedicineCategory/Update', medicineCategoryUpdatePayload).subscribe((data: any) => {
        this.router.navigate(['/medicinecategory/list']);
      });
    }
  }
}
