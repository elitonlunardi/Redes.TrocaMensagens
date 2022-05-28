import {  Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UsuarioModel } from '../model/usuarios.model';
import { ChatService } from '../services/chat.service';
import { interval } from 'rxjs';
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ChatComponent implements OnInit  {
  usuarioModel: UsuarioModel;

  ususariosSelecionados:UsuarioModel;

  constructor(private chatService: ChatService, private toastr: ToastrService) { 
  }

  ngOnInit() {
    // interval(5000).subscribe(() => {
    //   this.preencheUsuariosOnline();
    // });
    this.preencheUsuariosOnline();
  };
    
  abrirChat($event: any){
    console.log($event);
  }
 preencheUsuariosOnline() {
  this.chatService.getTodosUsuarios().subscribe((_usuario: UsuarioModel) => {
      this.usuarioModel = _usuario;
  }, error => {
    this.toastr.error(`Erro ao tentar Usuario: ${error}`);
  });
}
}

