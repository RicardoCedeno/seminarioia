import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Message } from '../../models/message';


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
      this.procesarMensaje(this.nuevoMensaje)
      this.nuevoMensaje = ''; // limpiar el textarea
    }
  }
  procesarMensaje(mensaje: string) {
    const hoy = new Date();
    const fecha = new Date(hoy.getFullYear(), hoy.getMonth(), hoy.getDate());
    const mensajeEnviar: Message = { campoId: '1', fromUser: true, messageCategory: 'na', sentMessage: [mensaje], sentMessageDatetime: fecha }

    
  }
}
