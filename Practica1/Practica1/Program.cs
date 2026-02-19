using System;
using Material;
using Fisico;
using Digital;
using Gestion;
using System.Collections.Generic;


class Program
    {
    static GestionMaterial ListaMateriales = new GestionMaterial(); //Instancia de la clase GestionMaterial para manejar los materiales de la biblioteca
    static void Main(string[] args)
    {
        int op; //Variable para la opción del menú

        do
        {
            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Menú de la Biblioteca ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("1. Registrar Material");
            Console.WriteLine("2. Mostrar Materiales");
            Console.WriteLine("3. Gestionar Materiales");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            while (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Entrada inválida. Ingrese un número.");
            }

            switch (op)
            {
                case 1:
                    Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Registrar Material ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
                    RegistrarMaterial();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Materiales Registrados ~ ~ ~ ~ ~ ~ ~ ~");
                    Console.WriteLine("");                   
                    ListaMateriales.MostrarTodosLosMateriales();

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Gestionar Materiales ~ ~ ~ ~ ~ ~ ~ ~ ~");
                    GestionarMateriales();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                    break;
            }
        } while (op != 4);
    }

    // Método para registrar un nuevo material (libro físico o digital)
    static void RegistrarMaterial()
    {
        Console.Clear(); //Limpiar consola para que se vea más ordenado
        Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Registrar Material ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
        Console.WriteLine("");
        Console.WriteLine("1. Libro Fisico");
        Console.WriteLine("2. Libro Digital");
        Console.WriteLine("3. Regresar al Menu Principal");
        Console.Write("Seleccione el tipo de material a registrar: ");

        int opTipoMaterial;

        while (!int.TryParse(Console.ReadLine(), out opTipoMaterial) || opTipoMaterial < 1 || opTipoMaterial > 3)
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
            Console.Write("Seleccione el tipo de material a registrar: ");
        }

        string? titulo, autor;
        int numeroEjemplar;

        switch (opTipoMaterial)
        {
            case 1:
                Console.WriteLine("");
                Console.WriteLine(" ~ ~ ~ ~ ~ ~ ~ ~ Registrar Libro Fisico ~ ~ ~ ~ ~ ~ ~ ~ ~ ");

                Console.Write("Ingrese el título del libro: ");
                titulo = Console.ReadLine();

                Console.Write("Ingrese el autor del libro:  ");
                autor = Console.ReadLine();

                // Validar que el título y el autor no estén vacíos o nulos
                if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
                {
                    Console.WriteLine("Error: El título y el autor no pueden estar vacíos.");
                    return;
                }

                Console.Write("Ingrese el número de ejemplar: ");
                // Validar que el número de ejemplar sea un entero positivo
                //TryParse devuelve false si la entrada no es un número entero válido, o si es menor o igual a 0
                //TryParse también evita que el programa se caiga si el usuario ingresa algo que no es un número, como texto o caracteres especiales
                //Me recuerda mucho al try-catch de java :c
                while (!int.TryParse(Console.ReadLine(), out numeroEjemplar) || numeroEjemplar <= 0)
                {
                    Console.WriteLine("Número de ejemplar inválido. Ingrese un numero entero positivo.");
                    Console.Write("Ingrese el numero de ejemplar: ");
                }

                // Usar el operador '!' porque hemos validado que no son null ni whitespace
                // ! indica que el valor no es null, lo cual es seguro en este caso debido a las validaciones anteriores
                LibroFisico libroFisico = new LibroFisico(titulo!, autor!, numeroEjemplar);
                ListaMateriales.AgregarMaterial(libroFisico);

                Console.WriteLine($"Libro físico '{libroFisico.Titulo}' registrado exitosamente con código único: {libroFisico.CodigoUnico}");
                Console.WriteLine("Días de préstamo permitidos: 7");
                break;

            case 2:

                Console.WriteLine("");
                Console.WriteLine(" ~ ~ ~ ~ ~ ~ ~ ~ Registrar Libro Digital ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
                Console.Write("Ingrese el título del libro: ");
                titulo = Console.ReadLine();
                Console.Write("Ingrese el autor del libro:  ");
                autor = Console.ReadLine();

                // Validar que el título y el autor no estén vacíos o nulos *2
                if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
                {
                    Console.WriteLine("Error: El título y el autor no pueden estar vacíos.");
                    return;
                }

                Console.Write("Ingrese el tamaño del archivo (MB): ");
                double tamanoArchivo;
                while (!double.TryParse(Console.ReadLine(), out tamanoArchivo) || tamanoArchivo <= 0)
                {
                    Console.WriteLine("Tamaño de archivo inválido. Ingrese un numero positivo.");
                    Console.Write("Ingrese el tamaño del archivo (MB): ");
                }

                LibroDigital libroDigital = new LibroDigital(titulo!, autor!, tamanoArchivo);
                ListaMateriales.AgregarMaterial(libroDigital);

                Console.WriteLine(" Libro digital registrado exitosamente con código único: " + libroDigital.CodigoUnico);
                Console.WriteLine(" Días de préstamo permitidos: 3");

                break;

            case 3:
                return; // Regresar al menú principal

        }
    }

    static void GestionarMateriales()
    {
        Console.Clear();
        Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Gestionar Materiales ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
        Console.WriteLine("");
        Console.WriteLine("1. Prestar Material");
        Console.WriteLine("2. Devolver Material");
        Console.WriteLine("3. Consultar Material");
        Console.WriteLine("4. Regresar al Menu Principal");
        Console.Write("Seleccione una opción: ");
        int opGestion;

        while (!int.TryParse(Console.ReadLine(), out opGestion) || opGestion < 1 || opGestion > 3)
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
            Console.Write("Seleccione una opción: ");
        }

        switch (opGestion)
        {
            case 1:
                Console.WriteLine("");
                Console.WriteLine(" ~ ~ ~ ~ ~ ~ ~ ~ Prestar Material ~ ~ ~ ~ ~ ~ ~ ~ ~ ");

                if (ListaMateriales.ObtenerCantidad() == 0)
                {
                    Console.WriteLine("No hay materiales registrados en la biblioteca para prestar.");
                    return;
                }

                GestionMaterial disponibles = ListaMateriales.ObtenerMaterialesDisponibles();
                
                if (disponibles.ObtenerCantidad() == 0)
                {
                    Console.WriteLine("No hay materiales disponibles para prestar en este momento.");
                    return;
                }

                Console.WriteLine("Materiales disponibles para préstamo:");

                for (int i = 0; i < disponibles.ObtenerCantidad(); i++)
                {
                    // ObtenerMaterial puede devolver null; declarar como nullable y comprobar antes de usar.
                    MaterialBiblioteca? material = disponibles.ObtenerMaterial(i);

                    if (material == null)
                    {
                        // Si por alguna razón hay un hueco nulo, simplemente continuar.
                        continue;
                    }

                    // Mostrar información del material disponible (método virtual definido en la firma).
                    material.MostrarInformacion();
                    Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
                }
                Console.WriteLine("");
                Console.WriteLine("Ingrese el código único del material que desea prestar: ");
                string? codigoPrestar = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(codigoPrestar))
                {
                    Console.WriteLine("Error: El código único no puede estar vacío.");
                    return;
                }

                MaterialBiblioteca? materialPrestado = ListaMateriales.PrestarMaterial(codigoPrestar);

                if (materialPrestado != null) 
                {
                    Console.WriteLine("Material prestado exitosamente: ");
                    materialPrestado.MostrarInformacion();

                    // Recordatorio de los plazos de préstamo según el tipo de material
                    if (materialPrestado is LibroFisico)
                    {
                        Console.WriteLine("Recuerde que el plazo de préstamo para libros físicos es de 7 días.");
                    }
                    else if (materialPrestado is LibroDigital)
                    {
                        Console.WriteLine("Recuerde que el plazo de préstamo para libros digitales es de 3 días.");
                    }
                }

                break;
            case 2:
                
                Console.Clear();
                Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Devolver Material ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
                Console.WriteLine("");

                if (ListaMateriales.ObtenerCantidad() == 0)
                {
                    Console.WriteLine("No hay materiales registrados en la biblioteca para devolver.");
                    return;
                }

                GestionMaterial prestados = ListaMateriales.ObtenerMaterialesPrestados();

                if (prestados.ObtenerCantidad() == 0)
                {
                    Console.WriteLine("No hay materiales prestados para devolver en este momento.");
                    return;
                }

                Console.WriteLine("Materiales actualmente prestados: ");

                for (int i = 0; i < prestados.ObtenerCantidad(); i++)
                {
                    MaterialBiblioteca? material = prestados.ObtenerMaterial(i);
                    if (material == null)
                    {
                        continue;
                    }
                    material.MostrarInformacion();
                }

                Console.WriteLine("");
                Console.WriteLine("Ingrese el código único del material que desea devolver: ");
                string? codigoDevolver = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(codigoDevolver)) 
                {   
                    Console.WriteLine("Error: El código único no puede estar vacío.");
                    return;
                }

                MaterialBiblioteca? materialDevuelto = ListaMateriales.DevolverMaterial(codigoDevolver);
                if (materialDevuelto != null)
                {
                    Console.WriteLine("Material devuelto exitosamente: ");
                    materialDevuelto.MostrarInformacion();
                }

                break;

            case 3:
                Console.Clear();
                Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ Consultar Material ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
                Console.WriteLine("");

                if (ListaMateriales.ObtenerCantidad() == 0)
                {
                    Console.WriteLine("No hay materiales registrados en la biblioteca para consultar.");
                    return;
                }

                // Mostrar una lista de todos los materiales registrados con titulo y código único para facilitar la consulta
                ListaMateriales.MostrarTitulosYCodigos();

                Console.WriteLine("Ingrese el código único del material que desea consultar: ");
                string? codigoConsultar = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(codigoConsultar))
                {
                    Console.WriteLine("Error: El código único no puede estar vacío.");
                    return;
                }

                MaterialBiblioteca? materialConsultado = ListaMateriales.BuscarMaterialPorCodigo(codigoConsultar);
                if (materialConsultado != null)
                {
                    Console.WriteLine("Información del material consultado: ");
                    materialConsultado.MostrarInformacion();
                }
                else
                {
                    Console.WriteLine("No se encontró ningún material con el código único proporcionado.");
                }

                break;

            case 4:
                return; // Regresar al menú principal
        }
    }

}