using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntropiaNaPratica
{
    class Program
    {
        static void Main(string[] args)
        {
            GerarArquivo gera = new GerarArquivo();
            gera.CompletarAleatorio();
            Console.ReadKey();

        }
    }
}
