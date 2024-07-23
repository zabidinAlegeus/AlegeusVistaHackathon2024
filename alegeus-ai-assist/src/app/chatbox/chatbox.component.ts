import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-chatbox',
  templateUrl: './chatbox.component.html',
  styleUrls: ['./chatbox.component.css']
})
export class ChatboxComponent implements OnInit {  
  constructor(private changeDetectorRef: ChangeDetectorRef) {

  }
  @Input() public chatContentControl: FormControl = new FormControl();
  public showChat = true!

  public ngOnInit(): void {
    this.chatContentControl.valueChanges.subscribe(data => {
      this.showChat = false;      
      this.showChat = true;
      this.changeDetectorRef.detectChanges();
    });
  }
}
