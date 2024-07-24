import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, UntypedFormControl } from '@angular/forms';
import { ChatboxService } from '../chatbox/chatbox.service';
import { firstValueFrom, Subscription } from 'rxjs';
import { MatInput } from '@angular/material/input';

@Component({
  selector: 'app-submit',
  templateUrl: './submit.component.html',
  styleUrls: ['./submit.component.css']
})
export class SubmitComponent implements OnDestroy {
  constructor(private chatboxService: ChatboxService) { }

  public submitControl = new UntypedFormControl([]);
  public responseSubscription: Subscription | undefined;
  @Input() public chatContentControl: FormControl = new FormControl();

  public ngOnDestroy(): void {
    this.responseSubscription?.unsubscribe();
  }

  public onSubmit(): void {
    this.chatboxService.toggleShowSpinner();
    const question = this.submitControl.value as string;
    this.responseSubscription = this.chatboxService.postQuestion(question).subscribe(data => {
      this.chatboxService.toggleHideSpinner();
      this.chatboxService.pushNewChatEntry({ question: question, response: data});
      this.submitControl.setValue(null);
    });
  }
}
