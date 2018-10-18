using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velasquez.Models
{
    public class Historico
    {
        public Guid Codigo { get; set; }
        public string Data { get; set; }
        public string Cliente { get; set; }
        public List<Produto> Itens { get; set; }
        public double ValorTotal { get; set; }

        public Historico(Guid codigo, string data, string cliente, List<Produto> itens, double valortotal)
        {
            Codigo = codigo;
            Data = data;
            Cliente = cliente;
            Itens = itens;
            ValorTotal = valortotal;
        }


        public override string ToString()
        {
            return "CLIENTE: "
                + Cliente
                + ", Data da Compra: "
                + Data
                + ", Total: "
                + ValorTotal.ToString()
                ;
        }
    }
}
