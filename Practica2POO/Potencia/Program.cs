using System;
using System.Collections.Generic;
//Hola! Implemente POO, ya que en clases menciono que debía ser todo con POO, así que refactorice el código.
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Calcular una potencia");
            Console.WriteLine("2. Calcular la serie de Fibonacci");
            Console.WriteLine("3. Resolver la Torre de Hanoi");
            Console.WriteLine("4. Resolver el MCD");
            Console.WriteLine("5. Resolver el factorial");

            int opcion = int.Parse(Console.ReadLine());

            OperacionMatematica operacion = null; //Null porque no hago referencia algún objeto dentro del tipo OperacionMatematica

            switch (opcion)
            {
                case 1:
                    operacion = new CalcularPotencia(); //Llamados
                    break;
                case 2:
                    operacion = new Fibonacci();
                    break;
                case 3:
                    operacion = new TorreDeHanoi();
                    break;
                case 4:
                    operacion = new MCD();
                    break;
                case 5:
                    operacion = new Factorial();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Seleccione una opción válida.");
                    Console.ReadKey();
                    continue;
            }
            // Llamar al método RealizarOperacion de la clase concreta dependiendo a nuestros casos.    
            operacion.RealizarOperacion();
        }
    }
}

//Utilizo la clase abstracta, a la cual le asignare a cada clase para heredar el metodo en común
abstract class OperacionMatematica
{
    public abstract void RealizarOperacion();
}
// El doble punto significa una herencia de clases
class CalcularPotencia : OperacionMatematica
{
    public override void RealizarOperacion()
    {
        Console.Clear();
        Console.Write("Ingrese el número base: ");
        double numeroBase = double.Parse(Console.ReadLine());
        Console.Write("Ingrese el exponente de la potencia: ");
        int exponente = int.Parse(Console.ReadLine());
        double resultado = Math.Pow(numeroBase, exponente);
        Console.WriteLine("El resultado es: " + resultado);
        Console.ReadKey();
    }
}

class Fibonacci : OperacionMatematica
{
    public override void RealizarOperacion()
    {
        Console.Clear();
        Console.Write("Ingrese el número: ");
        int n = int.Parse(Console.ReadLine());
        List<int> fibonacciNumbers = CalcularFibonacci(n);
        Console.WriteLine("La serie Fibonacci es: ");
        foreach (int num in fibonacciNumbers)
        {
            Console.Write(num + ", ");
        }
        Console.ReadKey();
    }

    //Uso de Lista y encapsulamiento
    private List<int> CalcularFibonacci(int n)
    {
        List<int> NumerosFibonacci = new List<int>();
        for (int pos = 0; pos <= n; pos++)
        {
            int fibonacciNumber = PosicionFibonacci(pos);
            NumerosFibonacci.Add(fibonacciNumber);
        }
        return NumerosFibonacci;
    }

    private int PosicionFibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        return PosicionFibonacci(n - 1) + PosicionFibonacci(n - 2);
    }
}

class TorreDeHanoi : OperacionMatematica
{
    public override void RealizarOperacion()
    {
        Console.Clear();
        Console.Write("Ingrese el número de discos en la Torre de Hanoi: ");
        int discos = int.Parse(Console.ReadLine());
        ResolverTorreHanoi(discos, 'A', 'B', 'C');
        Console.WriteLine("Discos: " + discos + " ");
        Console.WriteLine("Total de movimientos: " + totalmovimientos);
        Console.ReadLine();
    }

    private int totalmovimientos = 0;

    private void ResolverTorreHanoi(int n, char origen, char destino, char auxiliar)
    {
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 desde el triángulo {origen} al triángulo {destino}");
            totalmovimientos++;
        }
        else
        {
            ResolverTorreHanoi(n - 1, origen, auxiliar, destino);
            Console.WriteLine($"Mover disco {n} desde el triángulo {origen} al triángulo {destino}");
            totalmovimientos++;
            ResolverTorreHanoi(n - 1, auxiliar, destino, origen);
        }
    }
}

class MCD : OperacionMatematica
{
    public override void RealizarOperacion()
    {
        Console.Clear();
        Console.Write("Ingrese el primer número: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el segundo número: ");
        int num2 = int.Parse(Console.ReadLine());
        int resultado = ResolverMCD(num1, num2);
        Console.WriteLine($"El resultado es: {resultado}");
        Console.ReadKey();
    }

    private int ResolverMCD(int num1, int num2)
    {
        if (num2 == 0)
        {
            return num1;
        }
        else
        {
            return ResolverMCD(num2, num1 % num2);
        }
    }
}

class Factorial : OperacionMatematica
{
    public override void RealizarOperacion()
    {
        Console.Clear();
        Console.Write("Ingrese el número: ");
        int numero = int.Parse(Console.ReadLine());
        double resultado = CalcularFactorial(numero);
        Console.WriteLine($"El factorial de {numero} es: {resultado}");
        Console.ReadKey();
    }

    private double CalcularFactorial(int numero)
    {
        if (numero == 0)
        {
            return 1;
        }
        else
        {
            return numero * CalcularFactorial(numero - 1);
        }
    }
}
