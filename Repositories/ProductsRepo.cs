using Newtonsoft.Json;
using ProtoDevDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDevDemo.Repositories
{
    public class ProductsRepo
    {
        public async Task<List<Producto>> RetornaPDD()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var client = new HttpClient(handler);

            var response = await client.GetAsync("http://127.0.0.1:5000/placasDeDesarrollo");
            var responseJson = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseJson);
            Console.WriteLine(responseJson);
            var pDD = JsonConvert.DeserializeObject<List<Producto>>(responseJson);

            return pDD;
        }

        public async Task<List<Producto>> RetornaSBC()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var client = new HttpClient(handler);

            var response = await client.GetAsync("http://127.0.0.1:5000/singleBoardComputers");
            var responseJson = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseJson);
            Console.WriteLine(responseJson);
            var sBC = JsonConvert.DeserializeObject<List<Producto>>(responseJson);

            return sBC;
        }

        public async Task<List<Producto>> RetornaIntegrado()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var client = new HttpClient(handler);

            var response = await client.GetAsync("http://127.0.0.1:5000/circuitosIntegrados");
            var responseJson = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseJson);
            Console.WriteLine(responseJson);
            var integrado = JsonConvert.DeserializeObject<List<Producto>>(responseJson);

            return integrado;
        }

        public async Task<List<Producto>> RetornaAccesorio()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var client = new HttpClient(handler);

            var response = await client.GetAsync("http://127.0.0.1:5000/accesorios");
            var responseJson = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseJson);
            Console.WriteLine(responseJson);
            var accesorio = JsonConvert.DeserializeObject<List<Producto>>(responseJson);

            return accesorio;
        }

        public async Task<List<Producto>> RetornaVarios()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var client = new HttpClient(handler);

            var response = await client.GetAsync("http://127.0.0.1:5000/varios");
            var responseJson = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseJson);
            Console.WriteLine(responseJson);
            var varios = JsonConvert.DeserializeObject<List<Producto>>(responseJson);

            return varios;
        }



    }
}