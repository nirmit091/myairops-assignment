import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { map, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class RegistrationService {
    private baseUrl: string = `${environment.apiUrl}`;
    constructor(private _http: HttpClient) {
    }

    GenerateRegistrationData(data: any): Observable<any> {
        const headers=new HttpHeaders({'Content-Type':'application/json'});
        return this._http.post(`${this.baseUrl}/registration`, JSON.stringify(data),{headers:headers});
        //return this._http.get(`https://localhost:44391/api/Surveyor/Login/nirmit.shah91%40gmail.com/Test123%40`, {headers:headers});
    }
}