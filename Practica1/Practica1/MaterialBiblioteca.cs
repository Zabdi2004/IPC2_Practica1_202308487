using System;
using System.Collections.Generic;
using System.Text;

namespace Material
{
    public abstract class MaterialBiblioteca
    {
        private string titulo;
        private string autor;
        private bool disponible;
        private int codigoUnico;

        public MaterialBiblioteca(string titulo, string autor)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.disponible = true; // Por defecto, el material está disponible
            this.codigoUnico = new Random().Next(1000, 9999); // Genera un código único aleatorio
        }

        //getters y setters
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }

        public int CodigoUnico { get { return codigoUnico; } }



        // Métodos para prestar y devolver el material y para mostrar la información del material

        public virtual void Prestar()
        {
            if (disponible)
            {
                disponible = false;
                Console.WriteLine($"El material '{titulo}' ha sido prestado.");
            }
            else
            {
                Console.WriteLine($"El material '{titulo}' no está disponible para prestar.");
            }
        }

        public void Devolver()
        {
            if (!disponible)
            {
                disponible = true;
                Console.WriteLine($"El material '{titulo}' ha sido devuelto.");
            }
            else
            {
                Console.WriteLine($"El material '{titulo}' ya está disponible en la biblioteca.");
            }
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Disponible: {(disponible ? "Sí" : "No")}");
            Console.WriteLine($"Código Único: {codigoUnico}");
        }
    }
}
