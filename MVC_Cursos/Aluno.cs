using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Curso CursoMatriculado { get; set; } 
        public List<Disciplina> DisciplinasMatriculadas { get; set; } 
        public Aluno(int id, string nome)
        {
            Id = id;
            Nome = nome;
            DisciplinasMatriculadas = new List<Disciplina>();
        }

        public bool PodeMatricular(Curso curso)
        {
            if (CursoMatriculado != null)
                return false;

            if (DisciplinasMatriculadas.Count >= 6)
                return false;

            return true; 
        }

        public void MatricularEmCurso(Curso curso)
        {
            CursoMatriculado = curso;
        }

        public bool MatricularEmDisciplina(Disciplina disciplina)
        {
            if (DisciplinasMatriculadas.Count < 6 && !DisciplinasMatriculadas.Contains(disciplina))
            {
                DisciplinasMatriculadas.Add(disciplina);
                return true;
            }
            return false;
        }

        public bool DesmatricularDeDisciplina(Disciplina disciplina)
        {
            return DisciplinasMatriculadas.Remove(disciplina);
        }
    }
}
