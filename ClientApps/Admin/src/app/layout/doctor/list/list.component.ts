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
  constructor() {}

  ngOnInit() {}
}
