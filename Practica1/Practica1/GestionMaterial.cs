using System;
using System.Collections.Generic;
using System.Text;
using Material;

namespace Gestion
{
    public class GestionMaterial
    {
        private MaterialBiblioteca[] materiales;
        private int cantidad;

        //Tamaño fijo para el array de materiales = 100

        //constructor
        public GestionMaterial()
        {
            materiales = new MaterialBiblioteca[100];
            cantidad = 0;
        }

        //Método para obtener la cantidad de materiales en la biblioteca
        public int ObtenerCantidad()
        {
            return cantidad;
        }

        // Método para obtener los materiales disponibles en la biblioteca
        public GestionMaterial ObtenerMaterialesDisponibles()
        {
            GestionMaterial disponibles = new GestionMaterial();

            for (int i = 0; i < cantidad; i++)
            {
                if (materiales[i].Disponible)
                {
                    disponibles.AgregarMaterial(materiales[i]);
                }
            }
            return disponibles;
        }

        // Método para obtener los materiales prestados en la biblioteca
        public GestionMaterial ObtenerMaterialesPrestados()
        {
            GestionMaterial prestados = new GestionMaterial();
            for (int i = 0; i < cantidad; i++)
            {
                if (!materiales[i].Disponible)
                {
                    prestados.AgregarMaterial(materiales[i]);
                }
            }
            return prestados;
        }


        //Método para agregar un nuevo material a la biblioteca

        public void AgregarMaterial(MaterialBiblioteca material)
        {
            if (cantidad < materiales.Length)
            {
                materiales[cantidad] = material;
                cantidad++;
                //Console.WriteLine("Material agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pueden agregar más materiales. Capacidad máxima alcanzada.");
            }
        }

        // Método para mostrar la información de todos los materiales en la biblioteca
        public void MostrarTodosLosMateriales()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay materiales registrados en la biblioteca.");
                return;
            }
            Console.WriteLine("Materiales registrados en la biblioteca:");
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Material {i + 1}:");
                materiales[i].MostrarInformacion();
                Console.WriteLine();
            }
        }

        // Método para buscar un material por su código único
        public MaterialBiblioteca? BuscarMaterialPorCodigo(string codigoUnico)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (materiales[i].CodigoUnico == codigoUnico)
                {
                    return materiales[i];
                }
            }
            Console.WriteLine($"No se encontró ningún material con el código único: {codigoUnico}");
            return null;
        }

        // Método para prestar un material por su código único
        public MaterialBiblioteca? PrestarMaterial(string codigoUnico)
        {
            MaterialBiblioteca? material = BuscarMaterialPorCodigo(codigoUnico);
            if (material != null)
            {
                material.Prestar();
                return material;
            }
            return null;
        }

        // Método para devolver un material por su código único
        public MaterialBiblioteca? DevolverMaterial(string codigoUnico)
        {
            MaterialBiblioteca? material = BuscarMaterialPorCodigo(codigoUnico);
            if (material != null)
            {
                material.Devolver();
                return material;
            }
            return null;
        }


        //Método para ver la información de un material específico por su código único
        public void VerInformacionMaterial(string codigoUnico)
        {
            MaterialBiblioteca? material = BuscarMaterialPorCodigo(codigoUnico);
            if (material != null)
            {
                material.MostrarInformacion();
            }
        }

        // Método para Obtener Material Por su indice en el array
        public MaterialBiblioteca? ObtenerMaterial(int indice)
        {
            if (indice >= 0 && indice < cantidad)
            {
                return materiales[indice];
            }
            Console.WriteLine($"Índice fuera de rango. No se encontró ningún material en el índice: {indice}");
            return null;
        }

        //Método para mostrar el titulo y codigo de cada material registrado en la biblioteca
        public void MostrarTitulosYCodigos()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay materiales registrados en la biblioteca.");
                return;
            }
            Console.WriteLine("Materiales registrados en la biblioteca:");
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Título: {materiales[i].Titulo}, Código Único: {materiales[i].CodigoUnico}");
            }
        }
    }
}
