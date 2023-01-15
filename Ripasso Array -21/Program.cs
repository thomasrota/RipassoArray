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
            int c, p;                                                                   // Dichiarazione variabili di tipo intero 'c' e 'p'
            int dim;                                                                    // Dichiarazione variabile di tipo intero 'dim'
            int scelta;                                                                 // Dichiarazione variabile di tipo intero 'scelta'

            // Elaborazione
            // Ciclo controllo input variabile 'dim'
            do                                                                          // Esegui...
            {
                Console.Write("Inserire lunghezza iniziale dell'array (0 < x < 15): "); // Stampa 'Inserire lunghezza dell'array (0 < x < 100):'
                dim = Convert.ToInt32(Console.ReadLine());                              // Input variabile 'dim'
                if (dim > array.Length)                                                 // Se 'dim' maggiore della lunghezza dell'array
                {
                    Console.Clear();                                                    // Pulizia contenuto console
                    Console.Write("Input non valido!");                                 // Stampa 'Input non valido'
                    Thread.Sleep(1000);                                                 // Pausa 1 secondo
                    Console.Clear();                                                    // Pulizia contenuto console
                }
            } while (dim <= 0 || dim > 15);                                             // ...mentre 'dim' è minore-uguale a zero o maggiore lunghezza array
            // Ciclo inserimento valori inziali array
            for (int i = 0; i < dim; i++)                                               // Ciclo
            {
                Console.Write($"Inserire elemento in posizione {i}: ");                 // Stampa 'Inserire elemento in posizione {i}:'
                c = Convert.ToInt32(Console.ReadLine());                                // Input variabile 'c'
                array[i] = c;                                                           // Inserimento valori nell'array
            }
            // Struttura menù
            do                                                                          // Esegui...
            {
                // Stampa opzioni
                Console.Clear();                                                        // Pulizia contenuto console
                Console.WriteLine("1 - Aggiungi elemento\n2 - Stampa elementi caricati\n3 - Stampa stringa HTML\n4 - Ricerca elemento\n5 - Elimina elemento\n6 - Aggiungi elemento alla posizione desiderata\n0 - Uscita");         // Stampa messaggi selezione casi
                Console.WriteLine();                                                    // A capo
                Console.Write("Inserisci la scelta: ");                                 // Scelta opzione
                scelta = Convert.ToInt32(Console.ReadLine());                           // Input variabile 'scelta'
                // Esecuzione opzioni
                switch (scelta)                                                         // Selezione casi in base al valore della variabile 'scelta'
                {
                    default:                                                            // Se 'scelta' non corrisponde a nessun valore dei casi
                        Console.WriteLine("Opzione non valida!");                       // Stampa 'Opzione non valida!'
                        break;                                                          // Interrompi esecuzione
                    case 1:                                                             // Se 'scelta' uguale ad 1
                        Console.Write("Inserisci elemento da aggiungere in coda: ");    // Stampa 'Inserisci elemento da inserire in coda:'
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
                            Console.Write(array[i] + " ");                              // Stampa array
                        }
                        break;                                                          // Interrompere esecuzione
                    case 3:                                                             // Se 'scelta' uguale a 3
                        break;                                                          // Interrompere esecuzione
                    case 4:                                                             // Se 'scelta' uguale a 4
                        Console.Write("Inserire elemento da ricercare: ");                              // Stampa 'Inserire elemento da ricercare:'
                        c = Convert.ToInt32(Console.ReadLine());                                        // Input variabile 'c'
                        if (Ricerca(c, array) == -1)                                                    // Se chiamata funzione 'Ricerca' restituisce '-1'
                        {
                            Console.WriteLine("Numero non trovato!");                                   // Stampa 'Numero non trovato!'
                        }
                        else                                                                            // Altrimenti
                        {
                            Console.WriteLine("Numero trovato in posizione " + Ricerca(c, array));      // Stampa 'Numero trovato in posizione ' + resituzione valore funzione 'Ricerca'
                        }
                        break;                                                          // Interrompere esecuzione
                    case 5:                                                             // Se 'scelta' uguale a 5
                        break;                                                          // Interrompere esecuzione
                    case 6:                                                                                 // Se 'scelta' uguale a 6
                        Console.Write("Inserire posizione nella quale inserire l'elemento: ");              // Stampa 'Inserire elemento da ricercare:'
                        p = Convert.ToInt32(Console.ReadLine());                                            // Input variabile 'p'
                        Console.Write("Inserire elemento: ");                                               // Stampa 'Inserire elemento:'
                        c = Convert.ToInt32(Console.ReadLine());                                            // Input variabile 'c'
                        if (InserimentoInPosizione(c, p, array) == true)                                    // Se chiamata funzione 'InserimentoInPosizione' restituisce 'true'
                        {
                            Console.WriteLine($"Elemento {c} inserito correttamente in posizione {p}!");    // Stampa 'Elemento {c} inserito correttamente in posizione {p}!'
                        }
                        else                                                                                // Altrimenti
                        {
                            Console.Write("Errore!\nElemento non inserito correttamente.");                 // Stampa 'Errore!\nElemento non inserito correttamente.'
                        }
                        break;                                                                              // Interrompere esecuzione
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
        static int Ricerca(int c, int[] array)                                          // Funzione 'Ricerca' che va a ricercare elementi nell'array
        {
            int risultatoricerca = 0;                                                   // Assegnazione variabile 'risultatoricerca'
            for (int i = 0; i < array.Length; i++)                                      // Ciclo
            {
                if (array[i] == c)                                                      // Se indice array uguale a 'c'
                {
                    risultatoricerca = i;                                               // Assegna alla variabile 'risultato ricerca' il valore dell' indice
                    break;                                                              // Interrompere esecuzione
                }
                else                                                                    // Altrimenti
                {
                    risultatoricerca = -1;                                              // Assegnazione variabile 'risultatoricerca' il valore '-1'
                }
            }
            return risultatoricerca;                                                    // Resituzione 'risultatoricerca'
        }
        // Cancellazione di un elemento dell'array

        // Inserimento di un valore in una posizione dell'array
        static bool InserimentoInPosizione(int c, int p, int[] array)                   // Funzione 'InserimentoInPosizione' che inserisce un elemento in una determinata posizione
        {
            bool inserito = false;                                                      // Dichiarazione variabile di tipo booleano 'inserito'
            if (p < array.Length)                                                       // Se 'p' minore della lunghezza dell'array
            {
                for (int i = array.Length -1; i > p; i--)
                {
                    array[i] = array[i - 1];
                }
                array[p] = c;                                                           // Inserimento variabile 'c' nell'array
                inserito = true;                                                        // Assegnazione 'true' alla variabile 'inserito'
            }
            return inserito;                                                            // Restituzione variabile 'inserito'
        }
    }
}
