import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { UsuarioModel } from '../model/usuarios.model';
import { ChatService } from '../services/chat.service';
import { MensagemModel } from '../model/mensagem.model';
import { NbToastrService } from '@nebular/theme';
import { EnviarMensagemModel } from '../model/enviarMensagem.model';
import { interval } from 'rxjs';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  usuarioModel: UsuarioModel;
  mensagem: MensagemModel[];
  abrirMessenger: boolean = false;
  userId = undefined;

  constructor(private chatService: ChatService, private toastr: NbToastrService) {
  }

  ngOnInit() {
    this.mensagem = [];
    this.usuarioModel = {
      usuarios: new Array()
    }
    interval(5000).subscribe(() => {
      this.preencheUsuariosOnline();
      if (this.userId !== undefined) {
        this.chatService.getMensagemUserIdPadrao().subscribe((mensagem: MensagemModel) => {
          if (mensagem.mensagem !== '') {
            this.mensagem.push(mensagem);
          }
        });
      }
    });

  };
  enviarMensagem(event: any) {
    let model: EnviarMensagemModel = {
      userIdDestinatario: this.userId,
      mensagem: event.message
    }
    this.chatService.enviarMensagem(model).subscribe(() => {
      this.toastr.success('Mensagem enviada com sucesso');
      this.chatService.getMensagemUserIdPadrao().subscribe((mensagem: MensagemModel) => {
        this.mensagem.push(mensagem);
      });
    }, error => {
      this.toastr.danger(`${error.error}`);
    });
  }
  abrirChat($event: any) {
    this.mensagem = [];
    this.chatService.getMensagemUserIdPadrao().subscribe((mensagem: MensagemModel) => {
      this.abrirMessenger = true;
      this.userId = $event;
      this.mensagem.push(mensagem);
    }, error => {
      this.toastr.danger(`${error.error}`);
    });
  }
  preencheUsuariosOnline() {
    this.chatService.getTodosUsuarios().subscribe((_usuario: UsuarioModel) => {
      this.usuarioModel = _usuario;
    }, error => {
      console.log(error)
      this.toastr.danger(`${error.error}`);
    });
  }
}

