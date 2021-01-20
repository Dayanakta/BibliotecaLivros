import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Component({
  selector: 'app-config.service',
  templateUrl: './config.service.component.html',
  styleUrls: ['./config.service.component.css']
})

@Injectable()
export class ConfigService {
  constructor(private http: HttpClient) { }

  options: {
    headers?: HttpHeaders | { [header: string]: string | string[] },
    observe?: 'body' | 'events' | 'response',
    params?: HttpParams | { [param: string]: string | string[] },
    reportProgress?: boolean,
    responseType?: 'arraybuffer' | 'blob' | 'json' | 'text',
    withCredentials?: boolean,
  }

  configUrl = 'https://localhost:44354/Books';

  getConfig() {
    return this.http.get(this.configUrl);
  }

}


