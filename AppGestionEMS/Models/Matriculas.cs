using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Matriculas
    {
        public int Id { get; set; }
        public Cursos Curso { get; set; }
        public GrupoClases Grupo { get; set; }
        public int GrupoId { get; set; }
        public  string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}