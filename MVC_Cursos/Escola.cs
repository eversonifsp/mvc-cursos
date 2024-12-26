using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    public class Escola
    {
        public List<Curso> Cursos { get; set; }

        public Escola()
        {
            Cursos = new List<Curso>();
        }

        public bool AdicionarCurso(Curso curso)
        {
            if (Cursos.Count < 5)
            {
                Cursos.Add(curso);
                return true;
            }
            return false;
        }

        public Curso PesquisarCurso(int id)
        {
            return Cursos.Find(c => c.Id == id);
        }

        public bool RemoverCurso(Curso curso)
        {
            if (curso.Disciplinas.Count == 0)
            {
                return Cursos.Remove(curso);
            }
            return false;
        }
    }
}
