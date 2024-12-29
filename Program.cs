Console.WriteLine("Boas Vindas ao ByteBank ");


void TestaArrayInt()
{
    int [] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"O tamanho do array é {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"Índice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"A média de idade é {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}a  Palavra: ");
        arrayDePalavras[i] = Console.ReadLine()!;

    }
    Console.WriteLine("Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (var palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra {busca} encontrada !");
            break;
        }
       
    }
}

//TestaBuscarPalavra();
//TestaArrayInt();

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9,0);
amostra.SetValue(1.8,1);
amostra.SetValue(7.1,2);
amostra.SetValue(10,3);
amostra.SetValue(6.9,4);

void TestaMediana(Array array)
{
    if ((array == null)|| (array.Length == 0))
    {
        Console.WriteLine("Array vazio ou nulo.");
    }
    
    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio]: 
                                    (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana é igual a {mediana}");
                                    
}

TestaMediana(amostra);