using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lançamento_Vertical
{
    class Program
    {
        static void Main()
        {
            LV();
        }

        // ------------------------------------------------------------------------------------ //
        // ------------------------------------------------------------------------------------ //
        static void LV()
        {
            int W = 0, W1 = 0, Op = 0, Op1 = 0;
            double Ang = 0, Ve = 0;
            Console.SetWindowSize(60, 30);                // Controle do tamanho da janela
            Console.Title = "lançamento Vertical 1.0";    // Titulo
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Lacamento vertical                    ....");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Digite na ordem: Angulo de tiro e \n Velocidade Angular");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Iniciar");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n 9 - Main Menu\n 0 - Exit");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                Op = Convert.ToInt32(Console.ReadLine());
                switch (Op)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(" Lacamento vertical                    ....");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" Angulo     [graus]: ");
                            Ang = Convert.ToInt32(Console.ReadLine());
                            Console.Write(" Velocidade   [m/s]: ");
                            Ve = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ------------------------------------------");
                            LancamentoVertical(Ve, Ang);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(" 1 - Repetir");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("\n 9 - Main Menu\n 0 - Exit");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" Codigo: ");
                            Op1 = Convert.ToInt32(Console.ReadLine());
                            switch (Op1)
                            {
                                case 1:
                                    W1 = 1;
                                    break;

                                case 9:
                                    Main();
                                    break;

                                case 0:
                                    Environment.Exit(0);
                                    break;
                            }
                        } while (W1 == 0);
                        W1 = 0;
                        break;

                    case 9:
                        Main();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ---------------------------------------------- //
        // ---------------------------------------------- //
        public static void LancamentoVertical(double A, double B)
        {
            double Angulo = 0, VelocidadeInicial = 0, Amax = 0, Atmax = 0, G = 9.78, VeloX, VeloY, AngX, VeloXY;
            double Hmax = 0, AAtmax = 0, Y = 0, X = 0;
            int TempoTotalX = 0, TempoTotalY = 0, i;
            double[] LanceY = new double[5];
            double[] LanceX = new double[5];
            VelocidadeInicial = A;
            Angulo = B;
            AngX = (Angulo * 3.141592653589793384626433832795028841971693993751) / 180;
            VeloX = Math.Cos(AngX) * VelocidadeInicial;
            VeloY = Math.Sin(AngX) * VelocidadeInicial;
            VeloXY = Math.Sqrt(Math.Pow(VeloY, 2) + Math.Pow(VeloX, 2));
            Amax = Math.Pow(A, 2) / G;
            Atmax = (VeloY * VeloY) / (2 * G);
            TempoTotalX = Convert.ToInt32(Amax / VeloX);
            TempoTotalY = Convert.ToInt32(((VeloY / G) + (Math.Sqrt(2 * Atmax / G))));
            Hmax = ((Math.Pow(Math.Sin(AngX), 2)) * (VelocidadeInicial * 2)) / 2 * G;
            AAtmax = (VelocidadeInicial * 2) * (Math.Sin(2 * AngX) / G);
            X = 0;
            LanceX[0] = X;
            Y = (Math.Tan(AngX) * X) - ((G / ((2 * (VelocidadeInicial * VelocidadeInicial)) * ((Math.Pow(Math.Cos(AngX), 2)))) * (X * X)));
            LanceY[0] = Y;
            X = (Amax / 4);
            LanceX[1] = X;
            Y = (Math.Tan(AngX) * X) - ((G / ((2 * (VelocidadeInicial * VelocidadeInicial)) * ((Math.Pow(Math.Cos(AngX), 2)))) * (X * X)));
            LanceY[1] = Y;
            X = Amax / 2;
            LanceX[2] = X;
            Y = (Math.Tan(AngX) * X) - ((G / ((2 * (VelocidadeInicial * VelocidadeInicial)) * ((Math.Pow(Math.Cos(AngX), 2)))) * (X * X)));
            LanceY[2] = Y;
            X = ((Amax / 2) + (Amax / 4));
            LanceX[3] = X;
            Y = (Math.Tan(AngX) * X) - ((G / ((2 * (VelocidadeInicial * VelocidadeInicial)) * ((Math.Pow(Math.Cos(AngX), 2)))) * (X * X)));
            LanceY[3] = Y;
            X = Amax;
            LanceX[4] = X;
            Y = (Math.Tan(AngX) * X) - ((G / ((2 * (VelocidadeInicial * VelocidadeInicial)) * ((Math.Pow(Math.Cos(AngX), 2)))) * (X * X)));
            LanceY[4] = Y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Angulo em Radianos: " + AngX);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Coseno de Ang [rad]: " + Math.Cos(AngX));
            Console.WriteLine(" Seno   de Ang [rad]: " + Math.Sin(AngX));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Velocidade em X [m/s]: " + Math.Round(VeloX, 2));
            Console.WriteLine(" Velocidade em Y [m/s]: " + Math.Round(VeloY, 2));
            Console.WriteLine(" Velocidade   XY [m/s]: " + Math.Round(VeloXY, 2));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Tempo total em X [s]: " + TempoTotalX);
            Console.WriteLine(" Tempo total em Y [s]: " + TempoTotalY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Alcanse Maximo X [m]: " + Math.Round(Amax, 2));
            Console.WriteLine(" Altura  Maxima Y [m]: " + Math.Round(Atmax, 2));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Alcanse Maximo [m]: " + Math.Round(Hmax, 2));
            Console.WriteLine(" Altura  Maxima [m]: " + Math.Round(AAtmax, 2));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (i = 0; i < 5; i++)
            {
                Console.WriteLine(" X: [" + Math.Round(LanceX[i], 2) + "]\t - Y: [" + Math.Round(LanceY[i], 2) + "]");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        // ---------------------------------------------- //
        // ---------------------------------------------- //
    }
}
