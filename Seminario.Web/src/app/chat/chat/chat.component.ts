import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-chat',
  imports: [FormsModule, CommonModule],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.scss'
})
export class ChatComponent {
  mensajes: string[] = [];
  nuevoMensaje: string = '';

  enviarMensaje() {
    if (this.nuevoMensaje.trim() !== '') {
      this.mensajes.push(this.nuevoMensaje.trim());
      this.nuevoMensaje = ''; // limpiar el textarea
    }
  }
}
