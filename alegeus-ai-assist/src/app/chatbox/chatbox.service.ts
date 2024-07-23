import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ChatboxService {
    constructor(private httpClient: HttpClient) {}

    private API_URL = 'https://localhost:51032/';

    public postQuestion(request: string): Observable<string> {
        return this.httpClient.post<string>(this.API_URL + 'cobra-participant-open-enrollment-chat', { message: request });
    }
}
