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
  public doctorForm: FormGroup;
  constructor(private router: Router, private route: ActivatedRoute, public dataAccess: DataAccessService) {}

  ngOnInit() {
    const doctorId = this.route.snapshot.params.id;
    this.doctorForm = new FormGroup({
      doctorId: new FormControl('', [Validators.required]),
      doctorName: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required])
    });
    this.dataAccess.get('Doctor/get?id=' + doctorId).subscribe((data: any) => {
      this.doctorForm.patchValue({
        doctorId: doctorId,
        doctorName: data.data.doctorName,
        address: data.data.address
      });
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.doctorForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/doctor/list']);
  }

  public update = doctorFormValue => {
    const doctorUpdatePayload = {
      doctorId: doctorFormValue.doctorId,
      doctorName: doctorFormValue.doctorName,
      address: doctorFormValue.address
    };
    if (this.doctorForm.valid) {
      this.dataAccess.post('Doctor/Update', doctorUpdatePayload).subscribe((data: any) => {
        this.router.navigate(['/doctor/list']);
      });
    }
  }
}
