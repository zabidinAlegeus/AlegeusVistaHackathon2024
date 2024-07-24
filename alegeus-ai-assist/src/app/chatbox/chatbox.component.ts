import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { IChatEntry } from './chat-entry.interface';
import { ChatboxService } from './chatbox.service';

@Component({
  selector: 'app-chatbox',
  templateUrl: './chatbox.component.html',
  styleUrls: ['./chatbox.component.css']
})
export class ChatboxComponent implements OnInit { 
  constructor(private chatboxService: ChatboxService) {}
  
  public chatEntries: IChatEntry[] = [];
  public showSpinner = false;
  
  public ngOnInit(): void {
    this.chatEntries = this.chatboxService.getChatEntries();
    this.chatboxService.showSpinner$.subscribe(() => this.showSpinner = true);
    this.chatboxService.hideSpinner$.subscribe(() => this.showSpinner = false);
  }
}
