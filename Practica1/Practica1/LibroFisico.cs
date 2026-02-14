using System;
using System.Collections.Generic;
using System.Text;
using Material;

namespace Fisico
{
    public class LibroFisico : MaterialBiblioteca
    {
        private int numeroEjemplar;

        public LibroFisico(string titulo, string autor, int numeroEjemplar): base(titulo, autor)
        { 
            this.numeroEjemplar = numeroEjemplar;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Número de ejemplar: {numeroEjemplar}");
            Console.WriteLine("Tiempo máximo de préstamo: 7 días");
        }

    }

}
