using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Aluno> Alunos { get; set; }

        public Disciplina(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Alunos = new List<Aluno>();
        }

        public bool MatricularAluno(Aluno aluno)
        {
            if (Alunos.Count < 15 && !Alunos.Contains(aluno))
            {
                Alunos.Add(aluno);
                return true;
            }
            return false;
        }

        public bool DesmatricularAluno(Aluno aluno)
        {
            return Alunos.Remove(aluno);
        }
    }
}
