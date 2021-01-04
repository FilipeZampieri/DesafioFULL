export class parcela {
  constructor() {
    this.id = 0;
    this.numero = 0;
    this.dataVencimento = new Date();
    this.valor = 0;
    this.dividaId = 0;
  }
  id!: number;
  numero!: number;
  dataVencimento!: Date;
  valor!: number;
  dividaId!: number;
}
