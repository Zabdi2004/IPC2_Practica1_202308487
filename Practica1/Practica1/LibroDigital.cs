using System;
using System.Collections.Generic;
using System.Text;
using Material;

namespace Digital
{
    public class LibroDigital : MaterialBiblioteca 
    {
        private int tamañoArchivo; // en MB
        public LibroDigital(string titulo, string autor, int tamañoArchivo) : base(titulo, autor)
        {
            this.tamañoArchivo = tamañoArchivo;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tamaño del archivo: {tamañoArchivo} MB");
            Console.WriteLine("Tiempo máximo de préstamo: 3 días");
        }
    }
}
