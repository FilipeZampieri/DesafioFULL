export class Divida {
  constructor() {
    this.id = 0;
    this.numero = 0;
    this.devedor = '';
    this.cpf = '';
    this.juros = 0;
    this.multa = 0;
    this.plano = 0;

  }
  id!: number;
  numero!: number;
  devedor!: string;
  cpf!: string;
  juros!: number;
  multa!: number;
  plano!: number;
}
