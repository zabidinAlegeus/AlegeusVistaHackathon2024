import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ChatboxService } from '../chatbox/chatbox.service';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {
  constructor(private chatboxService: ChatboxService) { }

  public users = ['Admin', 'KyleReese', 'JohnConnor', 'SarahConnor', 'COBRA Participant'];
  public userControl = new FormControl('');

  public ngOnInit(): void {
    this.userControl.setValue('Admin');

    this.userControl?.valueChanges.subscribe((value) => {
      this.chatboxService.setSelectedUser(value as string);
    });
  }
}
