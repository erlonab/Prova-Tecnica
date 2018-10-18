using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Velasquez.Connection;
using Velasquez.Models;

namespace Velasquez.Interface
{
    public class Tela
    {
        // MENU DE OPÇOES
        public static void MostrarMenu()
        {
            Console.WriteLine("1 - Liste os clientes ordenados pelo maior valor total em compras: ");
            Console.WriteLine("2 - Mostre o cliente com maior compra única no último ano (2016): ");
            Console.WriteLine("3 - Liste os clientes mais fiéis: ");
            Console.WriteLine("4 - Recomende um vinho para um determinado cliente a partir do histórico de compras: ");
            Console.WriteLine("5 - Sair: ");
            Console.WriteLine(" ");
        }
        
        //METODOS REFERENTE AS OPÇÕES 
        public static async Task ClientePorValorAsync()
        {
            List<Cliente> listaCliente = await ConnectionAPI.GetListCliente();  //RETORNA A LISTA DE CLIENTES
            List<Historico> listaHistorico = await ConnectionAPI.GetHistorico(); //RETORNA O HISTORICO DOS CLIENTES

            double total = 0;
            List<Cliente> listaAux = new List<Cliente>();
            Cliente cltAux = new Cliente();

            Console.WriteLine("--------------------Lista Ordenada de Clientes Por Valor Total--------------------");
            Console.WriteLine("");

            foreach (var cliente in listaCliente)                      //VARRE A LISTA DE CLIENTES CADASTRADOS
            {
                total = 0;
                cltAux = null;

                foreach (var historico in listaHistorico)        //VARRE O HISTOTICO DE COMPRAS

                    if (historico.Cliente == cliente.Cpf)           //COMPARA SE O HISTORICO É DO CLIENTE PROCURADO        
                    {

                        total = total + historico.ValorTotal;   //SOMA AS COMPRAS                                     
                        cltAux = cliente;
                        cltAux.Total = total;

                    }
                listaAux.Add(cltAux);                           //JOGA NUMA LISTA AUXILIAR

            }

            listaAux = listaAux.OrderByDescending(o => o.Total).ToList();  //ORDENA A LISTA POR TOTAL

            listaAux.ForEach(Console.WriteLine);
            Console.WriteLine("");
            Console.WriteLine("Selecione a nova opção: ");
        }
        public static async Task ClienteMaiorCompra()
        {

            List<Cliente> listaCliente = await ConnectionAPI.GetListCliente();  //RETORNA A LISTA DE CLIENTES
            List<Historico> listaHistorico = await ConnectionAPI.GetHistorico(); //RETORNA O HISTORICO DOS CLIENTES
            List<Historico> listaHistAux = new List<Historico>();

            Console.WriteLine("--------------------Cliente Com Maior Compra Única no Último Ano (2016).--------------------");
            Console.WriteLine("");

            foreach (var historico in listaHistorico)              //VARRE A LISTA DE HISTORICO
            {

                if (historico.Data.Contains("2016"))               //VERIFICA SE A DATA CONTEM O ANO 2016
                {
                    listaHistAux.Add(historico);                   //ADICIONA TODOS COM O ANO DE 2016 NA LISTA AUXILIAR
                }
            }

            listaHistAux = listaHistAux.OrderByDescending(o => o.ValorTotal).ToList();  //ORDENA A LISTA POR TOTAL EM ORDEM DECRES.

            foreach (var cliente in listaCliente)                      //VARRE A LISTA DE CLIENTES
            {
                if (cliente.Cpf == listaHistAux[0].Cliente)             //TESTA SE É O MESMO DO TOPO DA LISTA PARA PEGAR OS DADOS
                {
                    Console.WriteLine("Id: " + cliente.Id + ", Nome: " + cliente.Nome);
                    Console.WriteLine("Total da Compra: " + listaHistAux[0].ToString());
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Selecione a nova opção: ");
        }
        public static async Task ClientesMaisFieis()
        {

            List<Cliente> listaCliente = await ConnectionAPI.GetListCliente();  //RETORNA A LISTA DE CLIENTES
            List<Historico> listaHistorico = await ConnectionAPI.GetHistorico(); //RETORNA O HISTORICO DOS CLIENTES
            List<Historico> listaHistAux = new List<Historico>();

            Console.WriteLine("--------------------Clientes Mais Fiéis--------------------");
            Console.WriteLine("");

            int cont = 0;
            foreach (var cliente in listaCliente)                   //VARRE A LISTA DE CLIENTES
            {
                cont = 0;
                foreach (var historico in listaHistorico)           //VARRE A LISTA DE HISTORICO
                {
                    if (cliente.Cpf == historico.Cliente)           //COMPARA SE É O MESMO E SOMA A QUANTIDADE DE COMPRAS
                    {
                        cont++;
                    }
                }
                Console.WriteLine(cliente + ", Comprou: " + cont + " vezes.");
            }

            Console.WriteLine("");
            Console.WriteLine("Selecione a nova opção: ");
        }
        public static async Task Recomendacao()
        {
            List<Cliente> listaCliente = await ConnectionAPI.GetListCliente();  //RETORNA A LISTA DE CLIENTES
            List<Historico> listaHistorico = await ConnectionAPI.GetHistorico(); //RETORNA O HISTORICO DOS CLIENTES

            Console.WriteLine("--------------------Recomendações de Vinhos--------------------");
            Console.WriteLine("");
                    
            List<Produto> ListaProdutos = new List<Produto>();

            foreach (var cliente in listaCliente)               //VARRE A LISTA DE CLIENTES
            {
                ListaProdutos = null;
                foreach (var historico in listaHistorico)           //VARRE A LISTA DE HISTORICO
                {
                    if (cliente.Cpf == historico.Cliente)           //COMPRA SE SÃO O MESMO E ADD NA NOVA LISTA OS ITENS JÁ COMPRADOS PELO CLIENTE
                    {                                               //PARA FAZER A RECOMENDAÇÃO
                        ListaProdutos = historico.Itens;
                    }
                }
                Console.WriteLine("Cliente: " + cliente.Cpf);
                ListaProdutos.ForEach(Console.WriteLine);
                Console.WriteLine(" ");
            }
            Console.WriteLine("");
            Console.WriteLine("Selecione a nova opção: ");

        }
    }
}