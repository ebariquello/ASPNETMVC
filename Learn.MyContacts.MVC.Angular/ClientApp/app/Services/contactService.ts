import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/toPromise';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ContactModel } from '../components/models/contactmodel';

@Injectable()
export class ContactService {
    myAppUrl: string = "";
    headers: Headers;
    options: RequestOptions;
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getContacts() {
        return this._http.get(this.myAppUrl + "/api/contact/ListContacts")
            .map((response: Response) => {
                return response.json()
            })
            .catch(this.handleError);
    }

    getContactByID(id: number) {
        //this.headers = new Headers({ 'content-type': 'application/json' });
        //this.options = new RequestOptions({ headers: this.headers });
        //, this.options)
        return this._http.get(this.myAppUrl + "/api/contact/GetContact/" + id)
            .map((response: Response) => {
              
                return response.json()
            })
            .catch(this.handleError);
      
      
    }

  

    saveContact(contact) {
        return this._http.post(this.myAppUrl + 'api/Contact/Create', contact)
            .map((response: Response) => {
                return response.json()
            })
            .catch(this.handleError)
    }

    updateContact(contact) {
        return this._http.put(this.myAppUrl + 'api/Contact/Edit', contact)
            .map((response: Response) => {
                return response.json()
            })
            .catch(this.handleError);
    }

    deleteContact(id: number) {
        return this._http.delete(this.myAppUrl + "api/Contact/Delete/" + id)
            .map((response: Response) => {
                return response.json()
            })
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Opps!! Server error');
    }  
}