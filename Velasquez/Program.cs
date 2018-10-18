using System;
using System.Collections.Generic;
using System.Linq;
using Velasquez.Connection;
using Velasquez.Models;
using System.Threading;
using Velasquez.Interface;

namespace Velasquez
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 0;

            while (op != 5)
            {
                Tela.MostrarMenu();                 //CHAMA O MENU

                op = int.Parse(Console.ReadLine());
                Console.Clear();
         
                switch (op)
                {
                    case 1:
                        Tela.ClientePorValorAsync();                        
                        break;

                    case 2:                        
                        Tela.ClienteMaiorCompra();
                        break;

                    case 3:
                        Tela.ClientesMaisFieis();
                        break;

                    case 4:
                        Tela.Recomendacao();              
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("--------------------Volte Sempre!--------------------");
                        Console.WriteLine("");
                        Console.WriteLine("Pressione uma tecla para Sair...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("--------------------Opção Inválida!--------------------");
                        Console.WriteLine("");
                        Console.WriteLine("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }    
    }
 }

