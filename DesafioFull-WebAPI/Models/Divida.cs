using System.Collections.Generic;

namespace DesafioFull_WebAPI.Models
{
    public class Divida
    {
        public Divida()
        {
        }
        public Divida(int id, int numero, string devedor, string cPF, decimal juros, decimal multa, int plano)
        {
            this.Id = id;
            this.Numero = numero;
            this.Devedor = devedor;
            this.CPF = cPF;
            this.Juros = juros;
            this.Multa = multa;
            this.Plano = plano;

        }
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Devedor { get; set; }
        public string CPF { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public int Plano { get; set; }
        public IEnumerable<Parcela> Parcelas { get; set; }

    }
}