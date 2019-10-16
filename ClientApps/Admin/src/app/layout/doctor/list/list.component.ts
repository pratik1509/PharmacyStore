import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material';
import { DataAccessService } from '../../../services/data-access.service';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  displayedColumns: string[] = ['doctorName', 'address'];
  public dataSource = new MatTableDataSource();

  public paging: any = {};

  constructor(public dataAccess: DataAccessService) {}
  ngOnInit() {
    this.getAllDoctors();
  }

  public getAllDoctors = () => {
    this.dataAccess.post('Doctor/GetAllWithPagging', this.paging).subscribe((data: { data: { data: []; paging: {} } }) => {
      this.dataSource.data = data.data.data;
      this.paging = data.data.paging;
    });
  }
  public getPaginatorData(event: PageEvent): PageEvent {
    this.paging.pageSize = event.pageSize;
    this.paging.page = event.pageIndex + 1;
    this.getAllDoctors();
    return event;
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
