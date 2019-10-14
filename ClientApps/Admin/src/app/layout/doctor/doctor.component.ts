import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { DataAccessService } from '../../services/data-access.service';
@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.scss']
})


export class DoctorComponent implements OnInit {
  displayedColumns: string[] = ['doctorName', 'address'];
  public dataSource = new MatTableDataSource(); 

  constructor(public dataAccess: DataAccessService) {}
  ngOnInit() {
    this.getAllDoctors();
  }

  public getAllDoctors = () => {
    this.dataAccess.getDoctors()
      .subscribe((data: { data: { data: [] } }) => {
        this.dataSource.data = data.data.data;
      });
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}

