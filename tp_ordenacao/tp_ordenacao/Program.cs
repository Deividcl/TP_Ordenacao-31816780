using System;
using System.Diagnostics;

namespace tp_ordenacao
{
    class Program
    {
        static void Vetores(int[] crescente, int[] decrescente, int[] aleatorio)
        {
            //Vetor Crescente
            for (int i = 0; i <= crescente.Length - 1; i++)
            {
                crescente[i] = i + 1;
            }
            //Vetor decrescente
            for (int i = decrescente.Length - 1; i >= 1; i--)
            {
                decrescente[i] = i + 1;
            }
            //Vetor Aleatorio
            for (int i = 0; i <= aleatorio.Length - 1; i++)
            {
                aleatorio[i] = RandomNumber(0, 10000);
            }
        }

        public static void Main()
        {
            int[] crescente;
            int[] decrescente;
            int[] aleatorio;
            bool sair = false;

            do
            {
                Console.Clear();
                // O comando Stopwatch calcula o tempo que o programa leu o metodo.
                Console.Write("\n\t\t\t Selecione qual opção de ordenação que você gostaria de usar:\n\n" +
                "\t\t\t\t\t\t 1 = BubbleSort\n" +
                "\t\t\t\t\t\t 2 = InsertionSort\n" +
                "\t\t\t\t\t\t 3 = SelectionSort\n" +
                "\t\t\t\t\t\t 4 = MergeSort\n" +
                "\t\t\t\t\t\t 5 = QuickSort\n" +
                "\n\n Insira um numero:\n");

                Stopwatch timer = new Stopwatch();
                bool bubble = false;
                bool insertion = false;
                bool selection = false;
                bool merge = false;
                bool quick = false;

                var menu = Console.ReadKey();
                Console.WriteLine("\n");

                if (bubble = menu.KeyChar == '1')
                {
                    crescente = new int[100000];
                    decrescente = new int[100000];
                    aleatorio = new int[100000];
                    Vetores(crescente, decrescente, aleatorio);

                    //Start começa a ler o tempo.
                    timer.Start();
                    bubbleSort(crescente);
                    bubbleSort(decrescente);
                    bubbleSort(aleatorio);

                    //Indica onde vai parar de ler o tempo .
                    timer.Stop();

                    //declara o tempo que levou para decorrer o bubblesort
                    TimeSpan tempoBubble = timer.Elapsed;

                    Console.WriteLine("\t" + tempoBubble.TotalMinutes);

                    Console.WriteLine("\nO tempo gasto na ordenação por BubbleSort foi de : \n\n\t{0} Minutos, \n\t{1} Segundo \n\t{2} Milésimos ", "\n" +tempoBubble.Minutes, tempoBubble.Seconds, tempoBubble.Milliseconds);

                    timer.Reset();
                }
                else if (insertion = menu.KeyChar == '2')
                {
                    crescente = new int[100000];
                    decrescente = new int[100000];
                    aleatorio = new int[100000];
                    Vetores(crescente, decrescente, aleatorio);

                    timer.Start();
                    InsertionSort(crescente);
                    InsertionSort(decrescente);
                    InsertionSort(aleatorio);
                    timer.Stop();

                    TimeSpan tempoInsertion = timer.Elapsed;
                    Console.WriteLine("\t" + tempoInsertion.TotalMinutes);
                    Console.WriteLine("\nO tempo gasto na ordenação por InsertionSort foi de: \n\t{0} Minutos, \n\t{1} Segundo \n\t{2} Milésimos \n", tempoInsertion.Minutes, tempoInsertion.Seconds, tempoInsertion.Milliseconds);
                    timer.Reset();
                }

                else if (selection = menu.KeyChar == '3')
                {
                    crescente = new int[100000];
                    decrescente = new int[100000];
                    aleatorio = new int[100000];
                    Vetores(crescente, decrescente, aleatorio);

                    timer.Start();
                    SelectionSort(crescente);
                    SelectionSort(decrescente);
                    SelectionSort(aleatorio);
                    timer.Stop();

                    TimeSpan tempoSelection = timer.Elapsed;
                    Console.WriteLine("\t" + tempoSelection.TotalMinutes);
                    Console.WriteLine("\nO tempo gasto na ordenação por SelectionSort foi de: \n\t{0} Minutos, \n\t{1} Segundo \n\t{2} Milésimos ", tempoSelection.Minutes, tempoSelection.Seconds, tempoSelection.Milliseconds);
                    timer.Reset();
                }

                else if (merge = menu.KeyChar == '4')
                {
                    crescente = new int[100000];
                    decrescente = new int[100000];
                    aleatorio = new int[100000];
                    Vetores(crescente, decrescente, aleatorio);

                    timer.Start();
                    MergeSort(crescente, crescente[0], (crescente.Length - 1));
                    MergeSort(decrescente, (decrescente.Length - 1), decrescente[0]);
                    MergeSort(aleatorio, aleatorio[0], (aleatorio.Length - 1));
                    timer.Stop();

                    TimeSpan tempoMerge = timer.Elapsed;
                    Console.WriteLine("\t" + tempoMerge.TotalMinutes);
                    Console.WriteLine("\nO tempo gasto na ordenação por MergeSort foi de: \n\t{0} Minutos, \n\t{1} Segundo \n\t{2} Milésimos  \n", tempoMerge.Minutes, tempoMerge.Seconds, tempoMerge.Milliseconds);
                    timer.Reset();
                }

                else if (quick = menu.KeyChar == '5')
                {
                    crescente = new int[100000];
                    decrescente = new int[100000];
                    aleatorio = new int[100000];
                    Vetores(crescente, decrescente, aleatorio);

                    timer.Start();
                    QuickSort(crescente, crescente[0], (crescente.Length - 1));
                    QuickSort(decrescente, (decrescente.Length - 1), decrescente[0]);
                    QuickSort(aleatorio, aleatorio[0], (aleatorio.Length - 1));
                    timer.Stop();

                    TimeSpan tempoQuick = timer.Elapsed;
                    Console.WriteLine("\t" + tempoQuick.TotalMinutes);
                    Console.WriteLine("\nO tempo gasto na ordenação por QuickSort foi de:  \n\t{0} Minutos, \n\t{1} Segundo \n\t{2} Milésimos ", "\n\t" + tempoQuick.Minutes, tempoQuick.Seconds, tempoQuick.Milliseconds);
                    timer.Reset();
                }

                else if (menu.KeyChar > 5)
                Console.WriteLine("Insira um numero;\n\n");
                Console.Write("\nDigite 'X' para retornar ao menu!");

                var finalizar = Console.ReadKey();
                sair = finalizar.KeyChar == 'X' || finalizar.KeyChar == 'x';
                Console.WriteLine("\n");
            } while (sair);
            Console.ReadKey();
        }

        static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static void bubbleSort(int[] Vetor)
        {
            int aux = 0;
            for (int i = 0; i < Vetor.Length; i++)
            {
                for (int j = 0; j < Vetor.Length - 1; j++)
             {
                  if (Vetor[j] > Vetor[j + 1])
                 { 
                    aux = Vetor[j + 1];
                    Vetor[j + 1] = Vetor[j];
                    Vetor[j] = aux;
                 }
             }
            }
        }
        
        static void InsertionSort(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 1; i < n; ++i)
            {
                int aux = vetor[i];
                int j = i - 1;

              while (j >= 0 && vetor[j] > aux)
               {
                 vetor[j + 1] = vetor[j];
                 j = j - 1;
               }
                 vetor[j + 1] = aux;
            }
        }
        
        static void SelectionSort(int[] Vetor)
        {
         int menor, i, j, aux;
         for (i = 0; i < Vetor.Length - 1; i++)
         {
              menor = i;
              for (j = i; j < Vetor.Length; j++)
             {
                if (Vetor[j] < Vetor[menor])
                    menor = j;
                aux = Vetor[menor];
                Vetor[menor] = Vetor[i];
                Vetor[i] = aux;
             }
         }
        }
        
        public static void MergeSort(int[] vetor, int primeiro, int ultimo)
        {
            if (primeiro < ultimo)
            {
                int meio = (primeiro + ultimo) / 2;

                MergeSort(vetor, primeiro, meio);
                MergeSort(vetor, meio + 1, ultimo);

                int[] leftArray = new int[meio - primeiro + 1];
                int[] rightArray = new int[ultimo - meio];
                               
                Array.Copy(vetor, primeiro, leftArray, 0, meio - primeiro + 1);
                Array.Copy(vetor, meio + 1, rightArray, 0, ultimo - meio);

                int i = 0;
                int j = 0;
                for (int x = primeiro; x < ultimo + 1; x++)
                {
                    if (i == leftArray.Length)
                    {
                        vetor[x] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        vetor[x] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i] <= rightArray[j])
                    {
                        vetor[x] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        vetor[x] = rightArray[j];
                        j++;
                    }
                }
            }
        }
        
        static public void QuickSort(int[] vetor, int primeiro, int ultimo)
        {
            int menor, maior, meio, intermedio, aux;
            menor = primeiro;
            maior = ultimo;
            meio = (menor + maior) / 2;
            intermedio = vetor[meio];

            while (menor <= maior)
            {
                while (vetor[menor] < intermedio)
                    menor++;
                while (vetor[maior] > intermedio)
                    maior--;

                if (menor < maior)
                {
                    aux = vetor[menor];
                    vetor[menor++] = vetor[maior];
                    vetor[maior--] = aux;
                }
                else
                {
                    if (menor == maior)
                    {
                        menor++;
                        maior--;
                    }
                }
            }
            if (maior > primeiro)
                QuickSort(vetor, primeiro, maior);
            if (menor < ultimo)
                QuickSort(vetor, menor, ultimo);
        }
    }
}