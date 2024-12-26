using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Disciplina> Disciplinas { get; set; }

        public Curso(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Disciplinas = new List<Disciplina>();
        }

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            if (Disciplinas.Count < 12)
            {
                Disciplinas.Add(disciplina);
                return true;
            }
            return false;
        }

        public Disciplina PesquisarDisciplina(int id)
        {
            return Disciplinas.Find(d => d.Id == id);
        }

        public bool RemoverDisciplina(Disciplina disciplina)
        {
            if (disciplina.Alunos.Count == 0)
            {
                return Disciplinas.Remove(disciplina);
            }
            return false;
        }
    }
}
