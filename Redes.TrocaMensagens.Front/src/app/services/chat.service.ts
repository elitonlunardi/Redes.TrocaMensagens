import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioModel } from '../model/usuarios.model';


@Injectable({
    providedIn: 'root'
})
export class ChatService {
    baseUrl = "https://localhost:7283/Chat/";
    constructor(private http: HttpClient) { }

    getTodosUsuarios(): Observable<UsuarioModel> {
        return this.http.get<UsuarioModel>(`${this.baseUrl}GetTodosUsuarios`);
    }
}