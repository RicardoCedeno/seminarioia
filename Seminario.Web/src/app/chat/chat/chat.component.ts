import { CommonModule } from '@angular/common';
import { Component, inject, ElementRef, ViewChild, } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Message } from '../../models/message';
import { ChatService } from '../../services/chat.service';


@Component({
  selector: 'app-chat',
  imports: [FormsModule, CommonModule],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.scss'
})
export class ChatComponent {
  @ViewChild('chatContainer') chatContainer!: ElementRef<HTMLDivElement>;
  chatService = inject(ChatService)
  mensajes: { texto: string, fromUser: boolean }[] = [];
  nuevoMensaje: string = '';

  enviarMensaje() {
    if (this.nuevoMensaje.trim() !== '') {
      this.mensajes.push({ texto: this.nuevoMensaje.trim(), fromUser: true });
      this.procesarMensaje(this.nuevoMensaje)
      this.nuevoMensaje = ''; // limpiar el textarea
      this.scrollToBottom(); // 👈 después de agregar el mensaje
    }
  }
  procesarMensaje(mensaje: string) {
    const hoy = new Date();
    const fecha = new Date(hoy.getFullYear(), hoy.getMonth(), hoy.getDate());

    const mensajeEnviar: Message = {
      campoId: '1',
      fromUser: true,
      messageCategory: 'na',
      sentMessage: [mensaje],
      sentMessageDatetime: fecha
    };

    this.chatService.sendMessageToSigco(mensajeEnviar).subscribe({
      next: (res) => {
        if (res.isSuccessful && res.errors.length === 0 && res.data && res.data.sentMessage?.length > 0) {
          console.log("data ", res.data);

          // ✅ Agregar mensajes del backend al historial
          for (const msg of res.data.sentMessage) {
            this.mensajes.push({ texto: msg, fromUser: false });
          }
        } else {
          console.log("ocurrió un error");
        }
      },
      error: (err) => {
        console.log("error ", err);
      },
      complete: () =>{
        this.scrollToBottom(); // 👈 después de recibir respuesta
      }
    });
  }

private scrollToBottom(): void {
  try {
    setTimeout(() => {
      const element = this.chatContainer.nativeElement;
      element.scrollTo({
        top: element.scrollHeight,
        behavior: 'smooth'
      });
    }, 100); // pequeño retraso para asegurar que el mensaje ya se pintó
  } catch (err) {
    console.warn('No se pudo hacer scroll:', err);
  }
}



}
