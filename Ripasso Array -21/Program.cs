using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ripasso_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dichiarazioni
            int[] array = new int[100];                                                 // Dichiarazione matrice di tipo intero 'array'
            int c;                                                                      // Dichiarazione variabili di tipo intero 'c'
            int dim = 0;                                                                // Dichiarazione variabile di tipo intero 'dim'
            int scelta;                                                                 // Dichiarazione variabile di tipo intero 'scelta'

            // Elaborazione
            // Struttura menù
            do                                                                          // Esegui..
            {
                // Stampa opzioni
                Console.Clear();
                Console.WriteLine("1 - Aggiungi elemento");                             // Stampa opzione 1
                Console.WriteLine("2 - Stampa elementi caricati");                      // Stampa opzione 2
                Console.WriteLine("0 - Uscita");                                        // Stampa opzione 0
                Console.Write("Inserisci la scelta: ");                                 // Scelta opzione
                scelta = int.Parse(Console.ReadLine());                                 // Input variabile 'scelta'
                // Esecuzione opzione
                switch (scelta)
                {
                    case 1:
                        Console.Write("Inserisci elemento:");                           // Stampa 'Inserisci elemento:'
                        c = int.Parse(Console.ReadLine());                              // Input variabile 'c'
                        if (Aggiunta(c, array, ref dim) == true)
                        {
                            Console.WriteLine("Elemento inserito correttamente!");      // Stampa 'Elemento inserito correttamente!'
                        }
                        else
                        {
                            Console.WriteLine("Array pieno!");                          // Stampa 'Array pieno!'
                        }
                        break;
                    case 2:
                        for (int i = 0; i < dim; i++)
                        {
                            Console.WriteLine(array[i]);                                // Stampa array
                        }
                        break;
                }
                Console.ReadLine();
            } while (scelta != 0);                                                      // ...mentre variabile 'scelta' diversa da 0
        }
        // Aggiungere in coda un elemento all'array (interi)
        static bool Aggiunta(int c, int[] array, ref int index)
        {
            bool inserito = true;
            if (index < array.Length)                                                   // Controllare se abbiamo raggiunto la dimensione massima           
            {
                array[index] = c;                                                       // Aggiungere l'elemento
                index++;                                                                // Incremento indice
            }
            else                                                                        // Altrimenti
            {
                inserito = false;                                                       // Assegnazione 'false' alla variabile 'inserito'
            }
            return inserito;
        }
    }
}
