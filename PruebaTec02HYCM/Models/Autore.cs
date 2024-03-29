﻿using System;
using System.Collections.Generic;

namespace PruebaTec02HYCM.Models
{
    public partial class Autore
    {
        public Autore()
        {
            Libros = new HashSet<Libro>();
            Libros2s = new HashSet<Libros2>();
        }

        public int AutorId { get; set; }
        public string? Nombre { get; set; }
        public string? Nacionalidad { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
        public virtual ICollection<Libros2> Libros2s { get; set; }
    }
}
