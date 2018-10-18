using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velasquez.Models
{
    public class Produto
    {
        public string IdProduto { get; set; }
        public string Variedade { get; set; }
        public string Pais { get; set; }
        public string Categoria { get; set; }
        public string Safra { get; set; }
        public double Preco { get; set; }

        public override string ToString()
        {
            return "Variedade: "
                + Variedade
                 + ", Pais: "
                + Pais
                + ", Categoria: "
                + Categoria
                + ", Safra: "
                + Safra
                + ", Preco: "
                + Preco.ToString();
                ;
        }
    }

    
}
