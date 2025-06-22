using System;

const int MAX = 10;
int[] pesos = new int[MAX];
char[] sexos = new char[MAX];
string[] categorias = new string[MAX];
int contador = 0;

char tecla;










Menu:
Console.Clear();
Console.WriteLine("1. Adicionar urso");
Console.WriteLine("2. Tabela de Frequencias");
Console.WriteLine("3. Histograma");

ConsoleKeyInfo keyInfo = Console.ReadKey();
tecla = keyInfo.KeyChar;

switch (tecla)
{
    case '1':
        {

            if (contador >= MAX)
            {
                Console.WriteLine("\nLimite máximo de ursos atingido!");
                Console.ReadKey();
                goto Menu;
            }



            Console.Clear();
            Console.WriteLine("Informe o peso: (1 a 250kg):");
            int peso = Convert.ToInt32(Console.ReadLine());

            if (peso <= 0 || peso > 250 )
            {
                goto Menu;
            }


            Console.WriteLine("Informe o sexo (M/F): ");
            keyInfo = Console.ReadKey();
            char sexo = char.ToUpper(keyInfo.KeyChar);

            string categoria;



            if (peso > 0 && peso <= 50)
                categoria = "Muito Leve";
            else if (peso <= 100)
                categoria = "Leve";
            else if (peso <= 150)
                categoria = "Medio";
            else if (peso <= 200)
                categoria = "Pesado";
            else if (peso <= 250)
                categoria = "Muito Pesado";
            else
                categoria = "";

            pesos[contador] = peso;
            sexos[contador] = sexo;
            categorias[contador] = categoria;
            contador++;

            Console.WriteLine($"\nUrso adicionado: Peso = {peso}, Sexo = {sexo}");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();

            goto Menu;

        }

    case '2':

        {
            Console.Clear();
            Console.WriteLine("Tabela de Frequências dos Ursos:\n");

            if (contador == 0)
            {
                Console.WriteLine("Nenhum urso cadastrado.");
                Console.ReadKey();
                goto Menu;
            }


            string[] categoriasPossiveis = { "Muito Leve", "Leve", "Medio", "Pesado", "Muito Pesado" };


            Console.WriteLine($"{"Categoria",-10} {"Ursos",5} {"Ursos(%)",8} {"Machos",6} {"Machos(%)",9} {"Fêmeas",6} {"Fêmeas(%)",9}");
            Console.WriteLine(new string('-', 65));

            int totalMachos = 0;
            int totalFemeas = 0;

            foreach (string cat in categoriasPossiveis)
            {
                int totalCategoria = 0;
                int machos = 0;
                int femeas = 0;

                for (int i = 0; i < contador; i++)
                {
                    if (categorias[i] == cat)
                    {
                        totalCategoria++;
                        if (sexos[i] == 'M')
                            machos++;
                        else if (sexos[i] == 'F')
                            femeas++;
                    }
                }

                totalMachos += machos;
                totalFemeas += femeas;

                double percUrsos = (double)totalCategoria / contador * 100;
                double percMachos = (double)machos / contador * 100;
                double percFemeas = (double)femeas / contador * 100;


                string catAbrev = cat switch
                {
                    "Muito Leve" => "ML",
                    "Leve" => "L",
                    "Medio" => "M",
                    "Pesado" => "P",
                    "Muito Pesado" => "MP",
                    _ => cat
                };

                Console.WriteLine($"{catAbrev,-10} {totalCategoria,5} {percUrsos,8:0}% {machos,6} {percMachos,9:0}% {femeas,6} {percFemeas,9:0}%");
            }

            Console.WriteLine(new string('-', 65));

            double percTotalMachos = (double)totalMachos / contador * 100;
            double percTotalFemeas = (double)totalFemeas / contador * 100;

            Console.WriteLine($"{"Total",-10} {contador,5} {"100%",8} {totalMachos,6} {percTotalMachos,9:0}% {totalFemeas,6} {percTotalFemeas,9:0}%");

            Console.WriteLine("\nPressione qualquer tecla para voltar.");
            Console.ReadKey();
            goto Menu;
        }
        case '3':
{
    Console.Clear();

    if (contador == 0)
    {
        Console.WriteLine("Nenhum urso cadastrado.");
        Console.ReadKey();
        goto Menu;
    }

    string[] categoriasPossiveis = { "Muito Leve", "Leve", "Medio", "Pesado", "Muito Pesado" };

    // Função para desenhar histograma
    void DesenharHistograma(string titulo, Func<int, bool> filtro)
    {
        Console.WriteLine($"\n----- Ursos {titulo} -----");
        Console.WriteLine("   +...10...20...30...40...50...60...70...80...90..100");

        foreach (string cat in categoriasPossiveis)
        {
            int totalNaCategoria = 0;

            for (int i = 0; i < contador; i++)
            {
                if (categorias[i] == cat && filtro(i))
                {
                    totalNaCategoria++;
                }
            }

            double perc = (double)totalNaCategoria / contador * 100;
            int qtdeAsteriscos = (int)Math.Round(perc / 2); // Cada * representa 2%

            string linha = new string('*', qtdeAsteriscos);

            string catAbrev = cat switch
            {
                "Muito Leve" => "ML",
                "Leve" => "L",
                "Medio" => "M",
                "Pesado" => "P",
                "Muito Pesado" => "MP",
                _ => cat
            };

            Console.WriteLine($"{catAbrev,-3}|{linha}");
        }
    }

    
    DesenharHistograma("Machos", i => sexos[i] == 'M');


    DesenharHistograma("Fêmeas", i => sexos[i] == 'F');

    
    DesenharHistograma("(todos)", i => true);

    Console.WriteLine("\nPressione qualquer tecla para voltar.");
    Console.ReadKey();
    goto Menu;
}

}

    
  
    















