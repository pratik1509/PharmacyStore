import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
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
    let doctorId = this.route.snapshot.params.id;
    this.dataAccess.get('Doctor/get?id=' + doctorId).subscribe((data: any) => {
      this.doctorForm = new FormGroup({
        doctorId: new FormControl(doctorId, [Validators.required]),
        doctorName: new FormControl(data.data.doctorName, [Validators.required]),
        address: new FormControl(data.data.address, [Validators.required])
      });
    }); 
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.doctorForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.router.navigate(['/doctor/list']);
  }

  public update = (doctorFormValue) => {
    let doctorUpdatePayload = { doctorId: doctorFormValue.doctorId, doctorName: doctorFormValue.doctorName, address: doctorFormValue.address};
    if (this.doctorForm.valid) {
      this.dataAccess.post('Doctor/Update', doctorUpdatePayload).subscribe((data: any) => {
        this.router.navigate(['/doctor/list']);
      });
    }
  }
}
