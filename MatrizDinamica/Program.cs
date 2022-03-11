init:
int sum = 0, sum1 = 0, valorMaximo = int.MinValue, valorMinimo = int.MaxValue;
Console.WriteLine("Por favor ingrese el tamaño de la matriz cuadrada: ");

if (int.TryParse(Console.ReadLine(), out int numeroMatriz))
{
    Console.WriteLine($"\nHa creado una matriz cuadrada de: {numeroMatriz} x {numeroMatriz}");
    int[,] matriz = new int[numeroMatriz, numeroMatriz];
    Random rd = new Random();

    Parallel.For(0, matriz.GetLength(0), i =>
    {
        numeroMatriz = numeroMatriz - 1;
        Parallel.For(0, matriz.GetLength(1), j =>
        {
            matriz[i, j] = rd.Next(1, 100);
            if (valorMaximo <= matriz[i, j]) valorMaximo = matriz[i, j];
            if (valorMinimo >= matriz[i, j]) valorMinimo = matriz[i, j];
            if (i == j) sum1 = sum1 + matriz[i, j];
            if (j == numeroMatriz) sum = sum + matriz[i, j];
        });
    });

    Console.WriteLine($"\nSuma diagonal 1: {sum}");
    Console.WriteLine($"Suma diagonal 2: {sum1}\n");
    Console.WriteLine($"Valor máximo: {valorMaximo}");
    Console.WriteLine($"Valor mínimo: {valorMinimo}\n");
    Console.Write("Desea volver a empezar => si/no: ");
    string respuesta = Console.ReadLine();
    if (respuesta == "si")
    {
        Console.Clear();
        goto init;
    }

}
else
{
    Console.WriteLine("*******************************************************");
    Console.WriteLine("=> ERROR: Ingrese un valor númerico.");
    Console.WriteLine("*******************************************************");
    goto init;
}
