import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioInfo, UsuarioModel } from '../model/usuarios.model';
import { MensagemModel } from '../model/mensagem.model';
import { EnviarMensagemModel } from '../model/enviarMensagem.model';


@Injectable({
    providedIn: 'root'
})
export class ChatService {
    baseUrl = "https://localhost:7283/Chat/";
    constructor(private http: HttpClient) { }

    getTodosUsuarios(): Observable<UsuarioModel> {
        return this.http.get<UsuarioModel>(`${this.baseUrl}GetTodosUsuarios`);
    }
    getMensagemUserIdPadrao(): Observable<MensagemModel>{
        return this.http.get<MensagemModel>(`${this.baseUrl}GetMensagemUserIdPadrao`);
    }
    enviarMensagem(model: EnviarMensagemModel): Observable<any>{
        return this.http.post(`${this.baseUrl}EnviarMensagem`, model);
    }
    obterUsuarioLogado(): Observable<UsuarioInfo>{
        return this.http.get<UsuarioInfo>(`${this.baseUrl}ObterUsuarioAplicacaoPadrao`);
    }
}