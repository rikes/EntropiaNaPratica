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
        private TimeSpan ts;
        private long temp = 0;
        
        public void ArquivoAleatorio()
        {

            //Recebe valores inteiros de 0 a 255                       
            byte[] unsChar = new byte[mega * 10];
            rand.NextBytes(unsChar);
            using (BinaryWriter writer = new BinaryWriter(File.Open("arquivoAleatorio.txt", FileMode.Create)))
            {
                stopWatch.Start();
                //poderia usar GetUpperBound(0) na iteração
                for (int i = 0; i < unsChar.Length; i++)
                {
                    //Console.WriteLine("{0}: {1}", i, unsChar[i]);
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
            //Recebe valores inteiros de 0 a 255                       
            byte[] unsChar = new byte[mega * 10];
            rand.NextBytes(unsChar);
            using (BinaryWriter writer = new BinaryWriter(File.Open("arquivoAleartorioRestrito.txt", FileMode.Create)))
            {
                stopWatch.Start();
                //poderia usar GetUpperBound(0) na iteração
                for (int i = 0; i < unsChar.Length; i++)
                {
                    //Console.WriteLine("{0}: {1}", i, range);
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
               //Recebe valores inteiros de 0 a 255                       
            byte[] unsChar = new byte[mega*10];
            rand.NextBytes(unsChar);
            using (BinaryWriter writer = new BinaryWriter(File.Open("arquivoNaoAlearto.txt", FileMode.Create)))
            {
                stopWatch.Start();
                //poderia usar GetUpperBound(0) na iteração
                for (int i = 0; i < unsChar.Length; i++)
                {
                    //50% de chance de aparecer
                    if (unsChar[i] < 125)
                    {
                        writer.Write(unsChar[i]);
                    }
                    //20% de chance de aparecer
                    if (unsChar[i] >= 125 && unsChar[i] <= 175)
                    {
                        writer.Write(unsChar[i]);
                    }
                    //30% de chance de aparecer
                    if (unsChar[i] > 175 )
                    {
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
