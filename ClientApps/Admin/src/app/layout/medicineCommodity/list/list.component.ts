import { Component, TemplateRef, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material';
import { DataAccessService } from '../../../services/data-access.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  displayedColumns: string[] = ['commodity', 'actions'];
  public dataSource = new MatTableDataSource();

  public paging: any = {};

  constructor(public dataAccess: DataAccessService, private dialog: MatDialog, private snackBar: MatSnackBar) {}
  ngOnInit() {
    this.getAllMedicineCommoditys();
  }

  public getAllMedicineCommoditys = () => {
    this.dataAccess.get('MedicineCommodity/GetAll').subscribe((data: any) => {
      this.dataSource.data = data.data;
    });
  };
  public getPaginatorData(event: PageEvent): PageEvent {
    this.paging.pageSize = event.pageSize;
    this.paging.page = event.pageIndex + 1;
    this.getAllMedicineCommoditys();
    return event;
  }

  deleteDialog(templateRef: TemplateRef<any>, medicineCommodityId: string): void {
    // this.snackBar.open('testte', null, {
    //   duration: 2000
    // });
    const dialogRef = this.dialog.open(templateRef);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.dataAccess.post('MedicineCommodity/Delete?id=' + medicineCommodityId, {}).subscribe((data: any) => {
          this.paging.page = 0;
          this.getAllMedicineCommoditys();
        });
      }
    });
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
