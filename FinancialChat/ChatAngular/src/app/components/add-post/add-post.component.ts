import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Post } from '../../Post';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {
  @Output() onAddPost: EventEmitter<Post> = new EventEmitter
  message!: string;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    if (!this.message) {
      return;
    }  

    const newPost: Post = {
      dateTime: '',
      userId: '',
      userName: '',
      roomId: 0,
      roomName: '',
      message: this.message
    }

    this.onAddPost.emit(newPost);

    this.message = '';
  }
}
