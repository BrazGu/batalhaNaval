using System;
using System.Collections.Generic;

namespace BatalhaNaval
{
    class Program
    {
        static void Main(string[] args)
        {
            //OBSERVAÇÃO: PROGRAMA CODIFICADO NO VISUAL STUDIO 2022

            string res;
            OpenMenu();
            Console.ReadLine();
            Console.Clear();

            do
            {
                StartMatch();
                Console.WriteLine();
                Console.Write("Deseja sortear novamente? (s/n)");
                res = Console.ReadLine().ToLower();
                Console.Clear();
            } while (res == "s");
            Console.WriteLine("Programa encerrado.");


            Console.ReadKey();
        }

        public static void OpenMenu()
        {
            Console.WriteLine(@"
            .______        ___   .___________.    ___       __       __    __       ___      
            |   _  \      /   \  |           |   /   \     |  |     |  |  |  |     /   \     
            |  |_)  |    /  ^  \ `---|  |----`  /  ^  \    |  |     |  |__|  |    /  ^  \    
            |   _  <    /  /_\  \    |  |      /  /_\  \   |  |     |   __   |   /  /_\  \   
            |  |_)  |  /  _____  \   |  |     /  _____  \  |  `----.|  |  |  |  /  _____  \  
            |______/  /__/     \__\  |__|    /__/     \__\ |_______||__|  |__| /__/     \__\ 
                                                                                 
            .__   __.      ___   ____    ____  ___       __                                  
            |  \ |  |     /   \  \   \  /   / /   \     |  |                                 
            |   \|  |    /  ^  \  \   \/   / /  ^  \    |  |                                 
            |  . `  |   /  /_\  \  \      / /  /_\  \   |  |                                 
            |  |\   |  /  _____  \  \    / /  _____  \  |  `----.                            
            |__| \__| /__/     \__\  \__/ /__/     \__\ |_______|                                                     
            ");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("       Clique em qualquer tecla para iniciar...");
        }

        public static void StartMatch()
        {
            List<Embarcacoes> listaEmbarcacoes = new List<Embarcacoes>();
            listaEmbarcacoes.Add(new Embarcacoes() { nome = "PORTA-AVIÕES", qtd = 1, espaco = 5 });
            listaEmbarcacoes.Add(new Embarcacoes() { nome = "CRUZADOR", qtd = 2, espaco = 4 });
            listaEmbarcacoes.Add(new Embarcacoes() { nome = "DESTROYER", qtd = 3, espaco = 3 });
            listaEmbarcacoes.Add(new Embarcacoes() { nome = "SUBMARINO", qtd = 3, espaco = 2 });

            bool encontrou = false;
            int pos;
            Random rnd = new Random();

            String[] tabuleiro = new string[60];

            for (int i = 0; i < tabuleiro.Length; i++)
            {
                tabuleiro[i] = "*";
            }

            foreach (Embarcacoes embarcacao in listaEmbarcacoes)
            {
                for (int i = 0; i < embarcacao.qtd; i++)
                {
                    pos = rnd.Next(0, tabuleiro.Length - embarcacao.espaco);
                    encontrou = ValidatePosition(pos, embarcacao.espaco, tabuleiro);

                    do
                    {
                        pos = rnd.Next(0, tabuleiro.Length - embarcacao.espaco);
                        encontrou = ValidatePosition(pos, embarcacao.espaco, tabuleiro);
                    } while (encontrou);

                    for (int j = 0; j < embarcacao.espaco; j++)
                    {
                        tabuleiro[pos + j] = embarcacao.nome[0].ToString();
                    }

                }
            }
            CreateTable(tabuleiro);
        }

        public static void CreateTable(string[] tabuleiro)
        {
            Console.WriteLine("Tabuleiro:");
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(tabuleiro[i] + " ");
            }
            Console.WriteLine();
            for (int i = 10; i < 20; i++)
            {
                Console.Write(tabuleiro[i] + " ");
            }
            Console.WriteLine();
            for (int i = 20; i < 30; i++)
            {
                Console.Write(tabuleiro[i] + " ");
            }
            Console.WriteLine();
            for (int i = 30; i < 40; i++)
            {
                Console.Write(tabuleiro[i] + " ");
            }
            Console.WriteLine();
            for (int i = 40; i < 50; i++)
            {
                Console.Write(tabuleiro[i] + " ");
            }
            Console.WriteLine();
            for (int i = 50; i < 60; i++)
            {
                Console.Write(tabuleiro[i] + " ");
            }
            Console.WriteLine();
        }

        public static bool ValidatePosition(int pos, int espaco, string[] tabuleiro)
        {
            bool res = false;

            for (int i = 0; i < espaco; i++)
            {
                if (tabuleiro[pos + i] != "*") res = true;
            }

            return res;
        }

        public class Embarcacoes
        {
            public int espaco { get; set; }
            public int qtd { get; set; }
            public string nome { get; set; }
        }
    }
}
