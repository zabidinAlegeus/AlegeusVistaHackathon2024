import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ChatboxService {
    constructor(private httpClient: HttpClient) {}

    private API_URL = '';

    public postQuestion(request: string): Observable<string> {
        return this.httpClient.post<string>(this.API_URL, request);
    }
}
