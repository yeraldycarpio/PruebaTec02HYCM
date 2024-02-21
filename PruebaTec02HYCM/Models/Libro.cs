using System;
using System.Collections.Generic;

namespace PruebaTec02HYCM.Models
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? GeneroLite { get; set; }
        public string? Descripcion { get; set; }
        public int? AutorId { get; set; }

        public virtual Autore? Autor { get; set; }
    }
}
