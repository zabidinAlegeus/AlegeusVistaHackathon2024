import { Component } from '@angular/core';
import { FormControl, UntypedFormControl } from '@angular/forms';
import { ChatboxService } from '../chatbox/chatbox.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-submit',
  templateUrl: './submit.component.html',
  styleUrls: ['./submit.component.css']
})
export class SubmitComponent {
  constructor(private chatboxService: ChatboxService) { }

  public submitControl = new UntypedFormControl([]);

  public async onSubmit(): Promise<void> {
    const question = this.submitControl.value as string;
    let response = await firstValueFrom(this.chatboxService.postQuestion(question));

    //TODO: 
    //1. post the user's question in the chatbox component 
    //2. send an event notifitying the chatbox that there is a new response
    //3. push that response to the chatbox

  }
}
