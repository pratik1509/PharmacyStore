import { Component, TemplateRef, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material';
import { DataAccessService } from '../../../services/data-access.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  displayedColumns: string[] = ['doctorName', 'address', 'actions'];
  public dataSource = new MatTableDataSource();

  public paging: any = {};

  constructor(public dataAccess: DataAccessService, private dialog: MatDialog) {}
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

  deleteDialog(templateRef: TemplateRef<any>, doctorId: string): void {
    const dialogRef = this.dialog.open(templateRef);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.dataAccess.post('Doctor/Delete?id=' + doctorId, {}).subscribe((data: any) => {
          this.paging.page = 0;
          this.getAllDoctors();
        });
      }
    });
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
