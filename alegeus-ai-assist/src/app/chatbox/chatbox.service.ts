import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { IChatEntry } from './chat-entry.interface';

@Injectable({
    providedIn: 'root'
})
export class ChatboxService {
    constructor(private httpClient: HttpClient) {}

    private API_URL = 'https://localhost:51032/';
    private chatEntries: IChatEntry[] = [{ question: '', response: 'Greetings! How may I assist you today?'}];
    private showSpinner = new Subject<void>();
    public showSpinner$ = this.showSpinner.asObservable();
    private hideSpinner = new Subject<void>();
    public hideSpinner$ = this.hideSpinner.asObservable();
    private selectedUser = 'Admin';
    private clearChat = new Subject<void>();
    public clearChat$ = this.clearChat.asObservable();

    public toggleClearChat(): void {
        this.clearChat.next();
    }

    public toggleShowSpinner(): void {
        this.showSpinner.next();
    }

    public toggleHideSpinner(): void {
        this.hideSpinner.next();
    }

    public getSelectedUser(): string {
        return this.selectedUser;
    }

    public setSelectedUser(user: string): void {
        this.selectedUser = user;
    }

    public postQuestion(request: string): Observable<string> {
        if (this.selectedUser == 'COBRA Participant') {
            return this.httpClient.post(this.API_URL + 'cobra-participant-open-enrollment-chat', { message: request }, {responseType: 'text'});
        } else {
            return this.httpClient.post(this.API_URL + 'wca-chat', { message: this.selectedUser + ': ' + request }, {responseType: 'text'});
        }        
    }

    public clearSession(): Observable<any> {
        if (this.selectedUser == 'COBRA Participant') {
            return this.httpClient.post(this.API_URL + 'cobra-participant-open-enrollment-chat', null);
        } else {
            return this.httpClient.post(this.API_URL + 'wca-chat', null);
        }        
    }

    public getChatEntries(): IChatEntry[] {
        return this.chatEntries;
    }

    public pushNewChatEntry(entry: IChatEntry): void {
        this.chatEntries.push(entry);
    }
}
