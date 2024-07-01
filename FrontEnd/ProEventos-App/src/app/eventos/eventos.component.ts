import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  larguraImagem: number = 150;
  margemImagem: number = 2;
  mostrarImagem: boolean = true;
  filtroLista: string = '';



  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  public getEventos(): void{

     this.http.get('https://localhost:7282/api/eventos').subscribe(
       response => this.eventos = response,
       error => console.log(error)
    )
  }

}
