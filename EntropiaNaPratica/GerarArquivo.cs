using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntropiaNaPratica
{
    class GerarArquivo
    {
        private int mega = (int)Math.Pow(2, 20);
        private Random rand = new Random();

        public void CompletarAleatorio()
        {

            //Recebe valores inteiros de 0 a 255                       
            byte[] unsChar = new byte[mega * 10];
            rand.NextBytes(unsChar);
            using (BinaryWriter writer = new BinaryWriter(File.Open("arquivo.txt", FileMode.Create)))
            {
                //poderia usar GetUpperBound(0) na iteração
                for (int i = 0; i < unsChar.Length; i++)
                {
                    //Console.WriteLine("{0}: {1}", i, unsChar[i]);
                    writer.Write(unsChar[i]);
                }
                Console.WriteLine("Fim");
            }
        }
    }
}
