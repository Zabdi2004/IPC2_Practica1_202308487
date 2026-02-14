using System;
using Material;
using Fisico;
using Digital;
using System.Collections.Generic;


class Program
    {
    static void Main(string[] args)
    {
        int op; //Variable para la opción del menú

        do 
        { 
            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Menú de la Biblioteca ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("1. Registrar Material");
            Console.WriteLine("2. Mostrar Materiales");
            Console.WriteLine("3. Gestionar Materiales");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            while (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Entrada inválida. Ingrese un número.");
            }

            switch (op)
            {
                case 1:
                    Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Registrar Material ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
                    break;
                case 2:
                    Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Materiales Registrados ~ ~ ~ ~ ~ ~ ~ ~");
                    break;
                case 3:
                    Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Gestionar Materiales ~ ~ ~ ~ ~ ~ ~ ~ ~");
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                    break;
            }
        } while (op != 0);
    }
}