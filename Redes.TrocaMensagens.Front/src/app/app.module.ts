import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChatComponent } from './chat/chat.component';
import {ListboxModule} from 'primeng/listbox';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    ChatComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ListboxModule,
  ],
  exports: [
    ListboxModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
