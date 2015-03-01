using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace EntropiaNaPratica
{
    class GerarArquivo
    {
        private int mega = (int)Math.Pow(2, 20);
        private Random rand = new Random();
        private Stopwatch stopWatch = new Stopwatch();        
        private long temp = 0;
        
        public void ArquivoAleatorio()
        {

            //Reserva 10mb em um array de bytes                                    
            byte[] unsChar = new byte[mega * 10];
            //Prenche o vetor com valores de 0 a 255
            rand.NextBytes(unsChar);
            using (BinaryWriter writer = new BinaryWriter(File.Open("arquivoAleatorio.txt", FileMode.Create)))
            {
                stopWatch.Start();
                //poderia usar GetUpperBound(0) na iteração
                for (int i = 0; i < unsChar.Length; i++)
                {
                    writer.Write(unsChar[i]);
                }
                stopWatch.Stop();
                temp = stopWatch.ElapsedMilliseconds;
                Console.WriteLine("Fim \nTempo de Execução {0} Milisegundos", temp);
                stopWatch.Reset();
            }
        }
        public void ArquivoAleatorioRestrito()
        {                      
            byte[] unsChar = new byte[mega*10];
            using (BinaryWriter writer = new BinaryWriter(File.Open("arquivoAleartorioRestrito.txt", FileMode.Create)))
            {
                stopWatch.Start();
                //poderia usar GetUpperBound(0) na iteração
                for (int i = 0; i < unsChar.Length; i++)
                {
                    unsChar[i] = (byte)rand.Next(0, 26);
                    //Console.WriteLine(unsChar[i]);
                    writer.Write(unsChar[i]);
                }
                stopWatch.Stop();
                temp = stopWatch.ElapsedMilliseconds;
                Console.WriteLine("Fim \nTempo de Execução {0} Milisegundos", temp);
                stopWatch.Reset();
            }
        }
        public void ArquivoNaoAleatorio()
        {   
            byte[] unsChar = new byte[mega*10];
            using (BinaryWriter writer = new BinaryWriter(File.Open("arquivoNaoAlearto.txt", FileMode.Create)))
            {
                stopWatch.Start();
                //poderia usar GetUpperBound(0) na iteração
                
                for (int i = 0; i < unsChar.Length; i++)
                {
                    unsChar[i] = (byte)rand.Next(1, 12);
                    //50% de chance de aparecer (primos)
                    if (EhPrimo(unsChar[i]))
                    {
                        writer.Write(unsChar[i]);
                    }
                    //40% de chance de aparecer, pares não primos
                    else if (unsChar[i] % 2 == 0)
                    {
                        writer.Write(unsChar[i]);
                    }
                    //10% de chance de aparecer.. 9!
                    else if(unsChar[i] == unsChar[i]) {
                        writer.Write(unsChar[i]);
                    }
                }
                stopWatch.Stop();
                temp = stopWatch.ElapsedMilliseconds;
                Console.WriteLine("Fim \nTempo de Execução {0} Milisegundos", temp);
                stopWatch.Reset();
            }
        }
        private bool EhPrimo(byte valor)
        {
            int cont = 0;
            if (valor == 1) return false;
            if (valor == 2) return true;
            
            for (int i = 3; i <= valor; i+=2)
			{
                if (valor % i == 0) cont++;                
			}
            if ((valor % 2 != 0) && (valor % valor == 0) && (cont == 2 )) return true;
            
            return false;
        }
    }
}
