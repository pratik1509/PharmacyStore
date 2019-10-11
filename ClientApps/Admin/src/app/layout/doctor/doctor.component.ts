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
  dataSource: any;
  constructor(public dataAccess: DataAccessService) {}
  ngOnInit() {
    this.dataSource = new MatTableDataSource();
    this.dataSource.data = this.dataAccess.getDoctors();
    this.dataAccess.getDoctors().subscribe((data: { data: { data: [] } }) => {
      this.dataSource = new MatTableDataSource();
      this.dataSource.data = data;
    });
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
