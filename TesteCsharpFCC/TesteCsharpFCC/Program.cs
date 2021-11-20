using System;

namespace TesteCsharpFCC
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Jogo da Forca");
            Console.WriteLine();

            Console.Write("Insira a Palavra a ser descoberta: ");
            string palavraEscolhida = Console.ReadLine();
            Console.WriteLine();

            int tentativas = 10;
            int contador = 0;
            bool palavraCompleta = false;
            string palavraDescoberta = criaVetor(palavraEscolhida);

            while (contador < tentativas && !palavraCompleta)

            {
                Console.Write("Insira uma letra: ");
                char letraEscolhida = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();

                if (palavraEscolhida.Contains(letraEscolhida))
                {
                    int[] posix = posixLetraEmPalavra(palavraEscolhida, letraEscolhida);
                    palavraDescoberta = substituiPelaLetra(palavraDescoberta, letraEscolhida, posix);
                    Console.WriteLine(palavraDescoberta);

                    if (palavraEscolhida == palavraDescoberta)
                    {
                        palavraCompleta = true;
                    }
                }
                else
                {
                    contador++;
                    int tentativasRestantes = tentativas - contador;
                    string tr = Convert.ToString(tentativasRestantes);
                    Console.WriteLine();
                    Console.WriteLine(palavraDescoberta);
                    Console.WriteLine("Você só tem " + tr + " tentativas");

                }
            }

            if (palavraCompleta)
            {
                Console.WriteLine();
                Console.WriteLine("Você venceu");
                Console.WriteLine();
                Console.WriteLine(palavraDescoberta);

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Você perdeu");
                Console.WriteLine();
                Console.WriteLine(palavraDescoberta);
                Console.WriteLine();
                Console.WriteLine("A palavra é: " + palavraEscolhida);

            }
        }

        static string criaVetor(string palavra)
        {
            char[] charVetor = palavra.ToCharArray();

            for (int i = 0; i<charVetor.Length; i++)
            {
                charVetor[i] = '_';
            }

            string charStr = new string(charVetor);

            return charStr;
        }


        static int quantidadeLetraEmPalavra(string palavra, char letra)
        {
            char[] charLetras = palavra.ToCharArray();
            int quantidade = 0;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (charLetras[i] == letra)
                {
                    quantidade++;
                }
            }

            return quantidade;
        }

        static int[] posixLetraEmPalavra(string palavra, char letra)
        {
            char[] charLetras = palavra.ToCharArray();
            int[] vetorIndice = new int[quantidadeLetraEmPalavra(palavra, letra)];
            int idx = 0;
            
            for (int i = 0; i<palavra.Length; i++)
            {
                if (charLetras[i] == letra)
                {
                    vetorIndice[idx] = i;
                    idx++;
                }
            }

            return vetorIndice;
        }

        static string substituiPelaLetra(string underline, char letra, int[] posix)
        {
            char[] charLetras = underline.ToCharArray();

            for (int i = 0; i < posix.Length; i++)
            {
                charLetras[posix[i]] = letra;
            }

            string charStr = new string(charLetras);

            return charStr;
        }

    }
}
