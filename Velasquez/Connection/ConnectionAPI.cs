using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velasquez.Models;

namespace Velasquez.Connection
{
    public class ConnectionAPI
    {
        //METODO QUE RETORNA A LISTA DE CLIENTES
        public static async Task<List<Cliente>> GetListCliente()
        {
            try
            {
                string UrlCliente = string.Format("http://www.mocky.io/v2/598b16291100004705515ec5");
                HttpClient http = new HttpClient();
                string json = await http.GetStringAsync(UrlCliente);


                List<Cliente> ListaDeClientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
                http.Dispose();
                return ListaDeClientes;

            }
            catch (Exception)
            {
                return null;
            }
        }


        //METODO QUE RETORNA O HITORICO DOS CLIENTES
        public static async Task<List<Historico>> GetHistorico()
        {
            try
            {
                string UrlHistorico = string.Format("http://www.mocky.io/v2/5bc88c3b320000730059ffca");
                HttpClient http = new HttpClient();
                string json = await http.GetStringAsync(UrlHistorico);

                List<Historico> ListaDeHistoricos = JsonConvert.DeserializeObject<List<Historico>>(json);
                http.Dispose();
                return ListaDeHistoricos;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
