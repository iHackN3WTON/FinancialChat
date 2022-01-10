import { Component, NgZone, OnInit, } from '@angular/core';
import { PostService } from '../../services/post.service'
import { Post } from '../../Post';

declare const sendMessage: any;

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  posts: Post[] = [];
  private chatId =  (<HTMLInputElement>document.getElementById('chatroomid')).value;

  constructor(private ngZone: NgZone, private postService: PostService) {}

  ngOnInit(): void {
    (window as any)['angularComponentReference'] = { component: this, zone: this.ngZone, loadAngularFunction: (timeDate: string, userName: string, message: string) => this.addPost(timeDate, userName, message), };

    this.postService.getPosts().subscribe((posts) => (this.posts = posts));
  }

  addPost(dateTime: string, userName: string, message: string) {
    if (this.posts.length >= 50) {
       this.posts = this.posts.filter((p) => p.id !== this.posts[0].id);
    }

    const newPost: Post = {
      id: Math.max.apply(Math, this.posts.map((p) => p.id!)) + 1,
      dateTime: dateTime,
      userId: (<HTMLInputElement>document.getElementById('userid')).value,
      userName: userName,
      roomId: parseInt((<HTMLInputElement>document.getElementById('chatroomid')).value),
      roomName: (<HTMLInputElement>document.getElementById('chatroomname')).value,
      message: message
    }

    this.posts.push(newPost);
  }

  addNewPost(post: Post) {
    post.id = Math.max.apply(Math, this.posts.map((p) => p.id!)) + 1;
    post.dateTime = new Date().toISOString();;
    post.roomId = parseInt((<HTMLInputElement>document.getElementById('chatroomid')).value);
    post.roomName = (<HTMLInputElement>document.getElementById('chatroomname')).value;
    post.userId = (<HTMLInputElement>document.getElementById('userid')).value;
    post.userName = (<HTMLInputElement>document.getElementById('displayname')).value;

    if (this.posts.length >= 50) {
      this.posts = this.posts.filter((p) => p.id !== this.posts[0].id);
    }

    sendMessage(post.message);
  }
}
