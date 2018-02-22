import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  records: any;
  recordId: number;
  type: string;
  id: number;
  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient) {
  }
  ngOnInit() {
    this.type = this.route.snapshot.params['type'];
    this.id = this.route.snapshot.params['id'];
    this.initData();
  }

  initData() {
    this.http.get('/api/' + this.type +'/' + this.id +'/details/' ).subscribe(data => {
      this.records = data;
    });
  }

  addRecord() {
    if (this.recordId) {
      this.http.put('/api/' + this.type, { groupId: this.recordId, id: this.id }).subscribe(() => {
        this.records.push({Id: this.recordId});
        this.recordId = null;
      });
    }
  }

  deleteRecord(parentId) {
    this.http.put('/api/' + this.type, { groupId: parentId, id: this.id }).subscribe(() => {
      this.records = this.records.filter(r => r.Id !== parentId);
    });
  }

}
