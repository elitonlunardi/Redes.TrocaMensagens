import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { UsuarioInfo, UsuarioModel } from '../model/usuarios.model';
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
  usuarioLogado: UsuarioInfo;
  messages: any[] = [];
  abrirMessenger: boolean = false;
  userId = undefined;
  username = undefined;

  constructor(private chatService: ChatService, private toastr: NbToastrService) {
  }

  ngOnInit() {
    this.usuarioModel = {
      usuarios: new Array()
    }
    interval(5000).subscribe(() => {
      this.obterUsuarioLogado();
      this.preencheUsuariosOnline();
      if (this.userId !== undefined) {
        this.chatService.getMensagemUserIdPadrao().subscribe((mensagem: MensagemModel) => {
          if (mensagem.mensagem !== '') {
            this.preencheMessage(mensagem.mensagem,false,this.username);
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
    this.username = this.usuarioModel.usuarios.find(x => x.userId == this.userId)?.username
    this.chatService.enviarMensagem(model).subscribe(() => {
      this.toastr.success('Mensagem enviada com sucesso');
      this.chatService.getMensagemUserIdPadrao().subscribe((mensagem: MensagemModel) => {
        this.preencheMessage(model.mensagem,true,this.usuarioLogado.username);
      });
    }, error => {
      this.toastr.danger(`${error.error}`);
    });
  }
  abrirChat($event: any) {
    this.abrirMessenger = false;
    this.messages = [];
    this.chatService.getMensagemUserIdPadrao().subscribe((mensagem: MensagemModel) => {
      this.abrirMessenger = true;
      this.userId = $event;
    }, error => {
      this.toastr.danger(`${error.error}`);
    });
  }
  preencheUsuariosOnline() {
    this.chatService.getTodosUsuarios().subscribe((_usuario: UsuarioModel) => {
      this.usuarioModel = _usuario;
    }, error => {
      this.toastr.danger(`${error.error}`);
    });
  }

  obterUsuarioLogado(){
    this.chatService.obterUsuarioLogado().subscribe((_usuario: UsuarioInfo) => {
      this.usuarioLogado = _usuario;
    })
  }

  preencheMessage(mensagem: any,reply: boolean, nomeUsuario: any){
    let message = {
      text: mensagem,
      customMessageData: [],
      reply: reply,
      date: new Date(),
      user: {
        name: nomeUsuario,
        avatar: 'https://i.gifer.com/no.gif'
      },
    }


    this.messages.push(message);
  }
}

