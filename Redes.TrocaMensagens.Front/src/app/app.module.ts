import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChatComponent } from './chat/chat.component';
import {ListboxModule} from 'primeng/listbox';
import { FormsModule } from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { NbThemeModule, NbLayoutModule, NbCardModule, NbListModule, NbUserModule, NbToastrModule, NbChatModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';

@NgModule({
  declarations: [
    AppComponent,
    ChatComponent,

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    ListboxModule,
    HttpClientModule,
    NbToastrModule.forRoot(),
    NbThemeModule.forRoot({ name: 'dark' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbListModule,
    NbCardModule,
    NbUserModule,
    NbChatModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
