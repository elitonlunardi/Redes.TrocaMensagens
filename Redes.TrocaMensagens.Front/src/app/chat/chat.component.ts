import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UsuarioModel } from '../model/usuarios.model';
import { ChatService } from '../services/chat.service';
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ChatComponent implements OnInit {
  usuarioModel: UsuarioModel;

  ususariosSelecionados:UsuarioModel;

  constructor(private chatService: ChatService, private toastr: ToastrService) { 
  }

  ngOnInit() {
    this.preencheUsuariosOnline();
  }
  
 preencheUsuariosOnline() {
  this.chatService.getTodosUsuarios().subscribe((_usuario: UsuarioModel) => {
    if(_usuario === undefined){
      console.log('retornou undefined por isso deu pau')
    }
      this.usuarioModel = _usuario;
  }, error => {
    this.toastr.error(`Erro ao tentar Usuario: ${error}`);
  });
}
}

