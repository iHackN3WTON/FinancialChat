import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from '../Post';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private currentURL = window.location.href
  // If it's running ins dev server uses json-server otherwise formal API
  private apiUrl =  this.currentURL.substring(0, 21) === 'http://localhost:4200' ? 'http://localhost:5000/posts' : (<HTMLInputElement>document.getElementById('apiurl')).value;
  
  constructor(private http: HttpClient) { }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.apiUrl)
  }
}
