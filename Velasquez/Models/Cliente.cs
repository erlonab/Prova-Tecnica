using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velasquez.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public double Total { get; set; }


        public Cliente(int id, string nome, string cpf, double total)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Total = total;
        }

        public Cliente()
        {

        }

        public override string ToString()
        {
            return "ID: "
                + Id.ToString()
                + ", NOME: "
                + Nome
                 + ", CPF: "
                + Cpf
                + ", Total: "
                + Total.ToString()
                ;
        }
    }
}
