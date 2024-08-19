﻿using System;
using vylexAPI.Models;

namespace vylexAPI.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int Estrelas { get; set; }
        public string Comentario { get; set; }
        public DateTime DataHora { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int EstudanteId { get; set; }
        public Estudante Estudante { get; set; }
    }
}
