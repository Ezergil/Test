import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import 'rxjs/add/operator/filter';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ListComponent implements OnInit, OnDestroy {
  records: any;
  subscribeObject: any;
  recordName: string;
  type: string;
  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient) {
    this.subscribeObject = router.events.filter(e => e instanceof NavigationEnd).subscribe(e => {
      this.type = this.route.snapshot.params['type'];
      this.initData();
    });
  }
  ngOnInit() {

  }

  ngOnDestroy() {
    this.subscribeObject.unsubscribe();
  }

  initData() {
    this.http.get('/api/' + this.type).subscribe(data => {
      this.records = data;
    });
  }

  addRecord() {
    if (this.recordName) {
      this.http.post('/api/' + this.type, { name: this.recordName }).subscribe((data) => {
        this.records.push(data);
        this.recordName = null;
      });
    }
  }

  deleteRecord(id) {
    this.http.delete('/api/' + this.type + '?id=' + id).subscribe(() => {
      this.records = this.records.filter(r => r.Id !== id);
    });
  }

}
