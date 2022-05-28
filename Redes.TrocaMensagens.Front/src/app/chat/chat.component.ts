import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { UsuarioModel } from '../model/usuarios.model';
import { ChatService } from '../services/chat.service';
import { MensagemModel } from '../model/mensagem.model';
import { NbToastrService } from '@nebular/theme';
import { EnviarMensagemModel } from '../model/enviarMensagem.model';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ChatComponent implements OnInit {
  usuarioModel: UsuarioModel;
  mensagemModel: MensagemModel;
  abrirMessenger: boolean = false;
  userId: any;

  constructor(private chatService: ChatService, private toastr: NbToastrService) {
  }

  ngOnInit() {
    // interval(5000).subscribe(() => {
    //   this.preencheUsuariosOnline();
    // });
    this.preencheUsuariosOnline();
  };
  enviarMensagem(event: any) {
    let model: EnviarMensagemModel = {
      userIdDestinatario: this.userId,
      mensagem: event.message
    }
    this.chatService.enviarMensagem(model).subscribe(() => {
      this.toastr.success('Mensagem enviada com sucesso');
    }, error => {
      this.toastr.danger(`Erro ao tentar carregar a mensagem: ${error}`);
    });
 }
  abrirChat($event: any) {
    this.chatService.getMensagemUserIdPadrao().subscribe((mensagem: MensagemModel) => {
      console.log(mensagem);
      this.mensagemModel = mensagem;
      this.abrirMessenger = true;
      this.userId = $event.userId;
    }, error => {
      this.toastr.danger(`Erro ao tentar carregar a mensagem: ${error}`);
    });
  }
  preencheUsuariosOnline() {
    this.chatService.getTodosUsuarios().subscribe((_usuario: UsuarioModel) => {
      this.usuarioModel = _usuario;
    }, error => {
      this.toastr.danger(`Erro ao tentar Usuario: ${error}`);
    });
  }
}

