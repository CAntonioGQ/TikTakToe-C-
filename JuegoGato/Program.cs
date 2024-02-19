using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoGato
{
    class Program
    {
        // Arreglo bidimensional para el tablero
        static int[,] tablero = new int[3, 3]; //3 Filas 3 columnas
        static char[] simbolo = { ' ', 'O', 'X' }; //Arreglo udidimensional con un espacio, O y X

    


    
        static void Main(string[] args)
        {
            bool terminado = false;


            //Dibujar Tablero
            DibujarTablero();
            Console.WriteLine("Jugar 1 = O\nJugador2 = X");

            do
            {
                // Turno jugador 1
                PreguntarPosicion(1); //Envia el valor de a la funciona preguntar posicion

                // Dibujar la casilla del jugador 1
                DibujarTablero();

                // Comprobar si ha ganado el jugador 1
                terminado = ComprobarGanador();

                if (terminado == true)
                {
                    Console.WriteLine("el juegador 1 ha ganado!");
                }
                else //De lo contrario comprobar si hubo empate
                {
                    terminado = ComprobarEmpate();
                    if (terminado == true)
                    {
                        Console.WriteLine("Esto es un empate!");
                    }

                    // Si jugador 1 no ganó ni hubo empate, esturno del jugador 2
                    else
                    {
                        PreguntarPosicion(2); // Turno jugador 2
                        // Dibujar casilla del jugador 2:
                        DibujarTablero();
                        //Comprobar si ha ganado la partida el jugador 2
                        terminado = ComprobarGanador();
                        if (terminado == true)
                        {
                            Console.WriteLine("El jugador 2 ha ganado!");
                        }

                    }
                }

                 // Repetir hasta 3 en linea o empate
            } while (terminado == false); /* Mientras el juego no haya terminado ser seguira 
                                             repitiendo el ciclo */

        } // Cierre de main

        static void DibujarTablero()
        {
            int fila = 0;
            int columna  = 0;

            Console.WriteLine(); //Espacio dentro del tablero
            Console.WriteLine("-------------"); // Primera linea horizontal
            for(fila = 0; fila < 3; fila++)
            {
                Console.Write("|"); //Dibujar la primera linea vertical
                for (columna = 0; columna < 3; columna++)
                {
                    Console.Write(" {0} |", simbolo[tablero[fila,columna]]); //Asigna un espacio, O u X

                }
                Console.WriteLine();
                Console.WriteLine("-------------"); // Dibujar las lineas horizontales
            }
        }

        // Pregunta donde escribir y lo dibujar en el tablero
        static void PreguntarPosicion(int jugador) // 1= Jugador 1, 2= Jugador 2
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);
                //Pedir el numero de fila
                do
                {
                    Console.Write("Selecciona la fila 1 a 3: ");
                    fila = Convert.ToInt32(Console.ReadLine());

                } while ((fila <1) || (fila >3)); // Si fila es menor que 1 o Mayor que 3 se repite el ciclo

                // Pedimos el numero de columna 
                do
                {
                    Console.Write("Selecciona la columna 1 a 3: ");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((columna < 1) || (columna > 3)); // Si columna es menor que 1 o Mayor que 3 se repite el ciclo

                if (tablero[fila - 1, columna - 1] != 0)
                    Console.WriteLine("Casilla Ocupada");
            } while (tablero[fila - 1, columna -1] !=0);

            // Si todo es correcto, se le asigna al jugador
            tablero[fila - 1, columna - 1] = jugador;
        }

        // Devuelve el valor de true si hay 3 en linea (Si hay un ganador)
        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool ticTacToe = false;


            //Si en alguna FILA son todas iguales y no son vacías:
            for(fila = 0; fila < 3; fila++)
            {
                if(    (tablero[fila, 0] == tablero[fila, 1])
                    && (tablero[fila, 0] == tablero[fila, 2])
                    && (tablero[fila, 0] != 0)              )
                {
                    ticTacToe = true;
                }
            }

            //Si en alguna COLUMNA son todas iguales y no son vacías:

            for (columna = 0; columna < 3; columna++)
            {
                if(    (tablero[0, columna] == tablero[1, columna])
                    && (tablero[0, columna] == tablero[1, columna])
                    && (tablero[0, columna] != 0))
                {
                    ticTacToe = true;
                }
                
            }
            //Si en alguna DIAGONAL son todas iguales y no son vacías:
            if (    (tablero[0, 0] == tablero[1, 1])
                && (tablero[0, 0] == tablero[2, 2])
                && (tablero[0, 0] != 0))
                {
                ticTacToe=true;
                }

            if(    (tablero[0, 2] == tablero[1, 1])
                && (tablero[0, 2] == tablero[2, 0])
                && (tablero[0, 2] != 0)           )
            {
                ticTacToe = true;
            }

            return ticTacToe;
        }

        // Devuelve "true" si hay empate
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for(fila=0; fila<3; fila++)
            {
                for (columna = 0;  columna < 3; columna++)
                {
                    if (tablero[fila,columna] == 0) // Si se encuentra una sola casilla vacia, aun se puede jugar
                    {
                        hayEspacio = true;
                    }
                }
            }
            return !hayEspacio;  /*Si el ciclo anterior nos regresa un "true",
                                   significa que si hay espacio se tiene que regresar
                                   a una negacion de true para que la condicion de empate 
                                   no se cumpla en la funcion main */
        }
    }
}
