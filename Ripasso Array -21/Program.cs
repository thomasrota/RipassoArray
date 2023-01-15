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
            int dim;                                                                    // Dichiarazione variabile di tipo intero 'dim'
            int scelta;                                                                 // Dichiarazione variabile di tipo intero 'scelta'

            // Elaborazione
            // Ciclo controllo input variabile 'dim'
            do                                                                          // Esegui...
            {
                Console.Write("Inserire lunghezza dell'array (0 < x < 100): ");         // Stampa 'Inserire lunghezza dell'array (0 < x < 100):'
                dim = Convert.ToInt32(Console.ReadLine());                              // Input variabile 'dim'
                if (dim > array.Length)                                                 // Se 'dim' maggiore della lunghezza dell'array
                {
                    Console.Clear();                                                    // Pulizia contenuto console
                    Console.Write("Input non valido!");                                 // Stampa 'Input non valido'
                    Thread.Sleep(1000);                                                 // Pausa 1 secondo
                    Console.Clear();                                                    // Pulizia contenuto console
                }
            } while (dim > array.Length);                                               // ...mentre 'dim' maggiore lunghezza array
            // Struttura menù
            do                                                                          // Esegui...
            {
                // Stampa opzioni
                Console.Clear();                                                        // Pulizia contenuto console
                Console.SetCursorPosition(2, 0);                                        // Posizionamento cursore alle coordinate 2, 0
                Console.WriteLine("1 - Aggiungi elemento");                             // Stampa opzione 1
                Console.SetCursorPosition(2, 1);                                        // Posizionamento cursore alle coordinate 2, 1
                Console.WriteLine("2 - Stampa elementi caricati");                      // Stampa opzione 2
                Console.SetCursorPosition(2, 2);                                        // Posizionamento cursore alle coordinate 2, 2
                Console.WriteLine("3 - Stampa stringa HTML");                           // Stampa opzione 3
                Console.SetCursorPosition(2, 3);                                        // Posizionamento cursore alle coordinate 2, 3
                Console.WriteLine("4 - Ricerca elemento");                              // Stampa opzione 4
                Console.SetCursorPosition(2, 4);                                        // Posizionamento cursore alle coordinate 2, 4
                Console.WriteLine("5 - Elimina elemento");                              // Stampa opzione 5
                Console.SetCursorPosition(2, 5);                                        // Posizionamento cursore alle coordinate 2, 5
                Console.WriteLine("6 - Aggiungi elemento alla posizione desiderata");   // Stampa opzione 6
                Console.SetCursorPosition(2, 6);                                        // Posizionamento cursore alle coordinate 2, 6
                Console.WriteLine("0 - Uscita");                                        // Stampa opzione 0
                Console.WriteLine();                                                    // A capo
                Console.Write("Inserisci la scelta: ");                                 // Scelta opzione
                scelta = Convert.ToInt32(Console.ReadLine());                           // Input variabile 'scelta'
                // Esecuzione opzioni
                switch (scelta)
                {
                    case 1:                                                             // Se 'scelta' uguale ad 1
                        Console.Write("Inserisci elemento: ");                          // Stampa 'Inserisci elemento:'
                        c = Convert.ToInt32(Console.ReadLine());                        // Input variabile 'c'
                        if (Aggiunta(c, array, ref dim) == true)                        // Se chiamata funzione 'Aggiunta' restituisce 'true'
                        {
                            Console.WriteLine("Elemento inserito correttamente!");      // Stampa 'Elemento inserito correttamente!'
                        }
                        else                                                            // ...altrimenti...
                        {
                            Console.WriteLine("Array pieno!");                          // Stampa 'Array pieno!'
                        }
                        break;                                                          // Interrompere esecuzione
                    case 2:                                                             // Se 'scelta' uguale ad 2
                        for (int i = 0; i < dim; i++)                                   // Ciclo stampa array
                        {
                            Console.Write(array[i] + ", ");                             // Stampa array
                        }
                        break;                                                          // Interrompere esecuzione
                    case 3:                                                             // Se 'scelta' uguale a 3
                        break;                                                          // Interrompere esecuzione
                    case 4:                                                             // Se 'scelta' uguale a 4
                        Console.Write("Inserire elemento da ricercare: ");              // Stampa 'Inserire elemento da ricercare:'
                        c = Convert.ToInt32(Console.ReadLine());                        // Input variabile 'c'
                        if (Ricerca(c, array) == -1)                                    // Se chiamata funzione 'Ricerca' restituisce '-1'
                        {
                            Console.WriteLine("Numero non trovato!");                   // Stampa 'Numero non trovato!'
                        }
                        else                                                            // Altrimenti
                        {
                            Console.WriteLine("Numero trovato in posizione " + Ricerca(c, array));       // Stampa 'Numero trovato in posizione ' + resituzione valore funzione 'Ricerca'
                        }
                        break;                                                          // Interrompere esecuzione
                }
                Console.ReadKey();                                                      // Attesa un'azione da parte dell'utente prima di continuare l'esecuzione
            } while (scelta != 0);                                                      // ...mentre variabile 'scelta' è diversa da 0
        }
        // Aggiungere in coda un elemento all'array (interi)
        static bool Aggiunta(int c, int[] array, ref int index)                         // Funzione 'Aggiunta' che va ad aggiungere elementi all'array
        {
            bool inserito = true;                                                       // Dichiarazione variabile di tipo booleano 'inserito'
            if (index < array.Length)                                                   // Se è stata raggiunta la dimensione massima dell'array           
            {
                array[index] = c;                                                       // Aggiungere l'elemento
                index++;                                                                // Incremento indice
            }
            else                                                                        // ...altrimenti...
            {
                inserito = false;                                                       // Assegnazione 'false' alla variabile 'inserito'
            }
            return inserito;                                                            // Restiruire 'inserito'
        }
        // Visualizzazione dell'array che restituisca la stringa in HTML
        // Ricerca un numero all'interno dell'array, la funzione deve restituire la posizione dell'elemento se lo trova, -1 se non lo trova
        static int Ricerca(int c, int[] array)
        {
            int risultatoricerca = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == c)
                {
                    risultatoricerca = i;
                    break;
                }
                else
                {
                    risultatoricerca = -1;
                }
            }
            return risultatoricerca;
        }
        // Cancellazione di un elemento dell'array
        // Inserimento di un valore in una posizione dell'array
    }
}
