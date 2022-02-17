using System;
using System.Threading;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!

            // Primeiramente iremos encontrar as bombas escondidas no mapa.

            int[,] MatrizAchaBombas = new int[9,9];

            // Percorrendo a Matriz MatrizAchaBombas. (Matriz 9x9)       
            
            for (var i=0; i<9; i++)
            {
                for (var j=0; j<9; j++)
                {
                    campoMinado.Abrir(i+1, j+1); // Abrindo o campo atual para verificar se há uma bomba

                    if (campoMinado.JogoStatus == 2) // Caso encontrada uma bomba (GameOver)
                    {
                        MatrizAchaBombas[i, j] = 1; // Guarda a posição da bomba
                        campoMinado = new CampoMinado(); // Roda novamente pulando o campo que contem a bomba
                    }
                }
            }

            MostraCampo(MatrizAchaBombas);  
        }

        public static void MostraCampo(int[,] MatrizAchaBombas)
        {
            var campoMinado = new CampoMinado();

            for (var i=0; i<9; i++)
            {
                for (var j=0; j<9; j++)
                {
                    if(MatrizAchaBombas[i, j] != 1) // Abrindo somente as casas onde não foi encontrado as bombas
                    {
                        Console.Clear();

                        campoMinado.Abrir(i+1, j+1);

                        Console.WriteLine("Inicio do Jogo.");

                        Console.WriteLine("===========\n");

                        Console.WriteLine(campoMinado.Tabuleiro);

                        Console.WriteLine("\nAguarde...");

                        Thread.Sleep(55);
                    }
                }
                
            }

            if(campoMinado.JogoStatus == 1) // Jogo vencido!
            {
                Console.WriteLine("\nParabéns! Você passou pelo Campo Minado sem pisar em nenhuma bomba. ");
            }

        }

    }
}

