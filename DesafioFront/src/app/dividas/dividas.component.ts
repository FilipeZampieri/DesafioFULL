import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Divida } from '../Models/Divida';
import { DividaService } from './divida.service';

@Component({
  selector: 'app-dividas',
  templateUrl: './dividas.component.html',
  styleUrls: ['./dividas.component.css']
})
export class DividasComponent implements OnInit {

  public dividas!: Divida[];
  public titulo = "Dividas";
  public dividaSelecionada: Divida | undefined | null;
  public dividaForm!: FormGroup;


  constructor(private fb: FormBuilder,
    private dividaService: DividaService) {
    this.criarForm();
    }

    ngOnInit() {
      this.carregarDividas();
    }
    carregarDividas(){
      this.dividaService.getAll().subscribe(
        (dividas: Divida[]) =>{
          this.dividas = dividas;
        },
        (erro: any) =>{
         console.log(erro);
        }
      )
    }

    dividaNovo(){
     this.dividaSelecionada = new Divida();
     this.dividaForm?.patchValue(this.dividaSelecionada);
   }

   dividaSelect(divida: Divida){
     this.dividaSelecionada = divida;
     this.dividaForm?.patchValue(divida);
   }

   voltar(){
     this.dividaSelecionada = null;

   }

   criarForm(){
     this.dividaForm = this.fb.group({
       id:[''],
       numero!: ['', Validators.required],
       devedor!: ['', Validators.required],
       cpf!: ['', Validators.required],
       juros!: ['', Validators.required],
       multa!: ['', Validators.required],
       plano!: ['', Validators.required],
     });
   }
   dividaSubmit(){
     this.salvarDivida(this.dividaForm.value);
   }
   deletarDivida(id :number){
     this.dividaService.delete(id).subscribe(
       (retorno: any) =>{
         console.log(retorno);
         this.carregarDividas();
       },
       (erro: any) =>{
        console.log(erro);
       }
     );
   }
   salvarDivida(divida: Divida){
     if(divida.id === 0) {
       this.dividaService.post(divida).subscribe(
         (retorno: Divida) =>{
           console.log(retorno);
           this.carregarDividas();
         },
         (erro: any) =>{
          console.log(erro);
         }
       );
     } else{
       this.dividaService.put(divida).subscribe(
         (retorno: Divida) =>{
           console.log(retorno);
           this.carregarDividas();
         },
         (erro: any) =>{
          console.log(erro);
         }
       );
     }
   }
}
