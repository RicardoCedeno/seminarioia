import { inject, Injectable } from '@angular/core';
import { Message } from '../models/message';
import { Observable } from 'rxjs';
import { Response } from '../models/responseDto';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  url: string = "https://localhost:7128/Message";
  http = inject(HttpClient)
  constructor() { }

  sendMessageToSigco(message: Message): Observable<Response<Message>>{
    return this.http.post<Response<Message>>(`${this.url}/SendMessageToSigco`, message);
  }
}
