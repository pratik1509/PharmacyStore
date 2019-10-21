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
  public medicineCommodityForm: FormGroup;
  constructor(private router: Router, private route: ActivatedRoute, public dataAccess: DataAccessService) {}

  ngOnInit() {
    const medicineCommodityId = this.route.snapshot.params.id;
    this.medicineCommodityForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      commodity: new FormControl('', [Validators.required])
    });
    this.dataAccess.get('MedicineCommodity/get?id=' + medicineCommodityId).subscribe((data: any) => {
      this.medicineCommodityForm.patchValue({
        id: medicineCommodityId,
        commodity: data.data.commodity
      });
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.medicineCommodityForm.controls[controlName].hasError(errorName);
  };

  public onCancel = () => {
    this.router.navigate(['/medicinecommodity/list']);
  };

  public update = medicineCommodityFormValue => {
    const medicineCommodityUpdatePayload = {
      id: medicineCommodityFormValue.id,
      commodity: medicineCommodityFormValue.commodity
    };
    if (this.medicineCommodityForm.valid) {
      this.dataAccess.post('MedicineCommodity/Update', medicineCommodityUpdatePayload).subscribe((data: any) => {
        this.router.navigate(['/medicinecommodity/list']);
      });
    }
  };
}
