using MVC_Cursos;

namespace MVC_Cursos
{
    internal class Program
    {
        static Escola escola = new Escola();
        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                MostrarMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        sair = true;
                        break;

                    case "1":
                        AdicionarCurso();
                        break;

                    case "2":
                        PesquisarCurso();
                        break;

                    case "3":
                        RemoverCurso();
                        break;

                    case "4":
                        AdicionarDisciplina();
                        break;

                    case "5":
                        PesquisarDisciplina();
                        break;

                    case "6":
                        RemoverDisciplina();
                        break;

                    case "7":
                        MatricularAluno();
                        break;

                    case "8":
                        RemoverAluno();
                        break;

                    case "9":
                        PesquisarAluno();
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Adicionar curso");
            Console.WriteLine("2 - Pesquisar curso");
            Console.WriteLine("3 - Remover curso");
            Console.WriteLine("4 - Adicionar disciplina no curso");
            Console.WriteLine("5 - Pesquisar disciplina");
            Console.WriteLine("6 - Remover disciplina do curso");
            Console.WriteLine("7 - Matricular aluno na disciplina");
            Console.WriteLine("8 - Remover aluno da disciplina");
            Console.WriteLine("9 - Pesquisar aluno");
            Console.Write("Opção: ");
        }

        static void AdicionarCurso()
        {
            if (escola.Cursos.Count >= 5)
            {
                Console.WriteLine("Limite de cursos atingido.");
                return;
            }

            Console.Write("Digite o ID do curso: ");
            int idCurso = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição do curso: ");
            string descricaoCurso = Console.ReadLine();
            Curso curso = new Curso(idCurso, descricaoCurso);

            if (escola.AdicionarCurso(curso))
                Console.WriteLine("Curso adicionado com sucesso.");
            else
                Console.WriteLine("Erro ao adicionar curso.");

            Console.ReadLine();
        }

        static void PesquisarCurso()
        {
            Console.Write("Digite o ID do curso: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = escola.PesquisarCurso(idCurso);

            if (curso != null)
            {
                Console.WriteLine($"Curso: {curso.Descricao}");
                Console.WriteLine("Disciplinas:");
                foreach (var disciplina in curso.Disciplinas)
                {
                    Console.WriteLine($"- {disciplina.Descricao}");
                }
            }
            else
            {
                Console.WriteLine("Curso não encontrado.");
            }
            Console.ReadLine();
        }

        static void RemoverCurso()
        {
            Console.Write("Digite o ID do curso para remoção: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = escola.PesquisarCurso(idCurso);

            if (curso != null && escola.RemoverCurso(curso))
                Console.WriteLine("Curso removido com sucesso.");
            else
                Console.WriteLine("Erro ao remover curso. Verifique se o curso possui disciplinas associadas.");

            Console.ReadLine();
        }

        static void AdicionarDisciplina()
        {
            Console.Write("Digite o ID do curso para adicionar a disciplina: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = escola.PesquisarCurso(idCurso);

            if (curso != null)
            {
                Console.Write("Digite o ID da disciplina: ");
                int idDisciplina = int.Parse(Console.ReadLine());
                Console.Write("Digite a descrição da disciplina: ");
                string descricaoDisciplina = Console.ReadLine();
                Disciplina disciplina = new Disciplina(idDisciplina, descricaoDisciplina);

                if (curso.AdicionarDisciplina(disciplina))
                    Console.WriteLine("Disciplina adicionada ao curso.");
                else
                    Console.WriteLine("Erro ao adicionar disciplina. Limite de disciplinas atingido.");
            }
            else
            {
                Console.WriteLine("Curso não encontrado.");
            }

            Console.ReadLine();
        }

        static void PesquisarDisciplina()
        {
            Console.Write("Digite o ID da disciplina: ");
            int idDisciplina = int.Parse(Console.ReadLine());

            foreach (var curso in escola.Cursos)
            {
                Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
                if (disciplina != null)
                {
                    Console.WriteLine($"Disciplina: {disciplina.Descricao}");
                    Console.WriteLine("Alunos matriculados:");
                    foreach (var aluno in disciplina.Alunos)
                    {
                        Console.WriteLine($"- {aluno.Nome}");
                    }
                    break;
                }
            }

            Console.ReadLine();
        }

        static void RemoverDisciplina()
        {
            Console.Write("Digite o ID da disciplina para remoção: ");
            int idDisciplina = int.Parse(Console.ReadLine());

            foreach (var curso in escola.Cursos)
            {
                Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
                if (disciplina != null)
                {
                    if (curso.RemoverDisciplina(disciplina))
                        Console.WriteLine("Disciplina removida com sucesso.");
                    else
                        Console.WriteLine("Não é possível remover a disciplina, pois existem alunos matriculados.");
                    break;
                }
            }

            Console.ReadLine();
        }

        static void MatricularAluno()
        {
            Console.Write("Digite o ID do aluno: ");
            int idAluno = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do aluno: ");
            string nomeAluno = Console.ReadLine();
            Aluno aluno = new Aluno(idAluno, nomeAluno);

            Console.Write("Digite o ID da disciplina para matrícula: ");
            int idDisciplina = int.Parse(Console.ReadLine());

            foreach (var curso in escola.Cursos)
            {
                Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
                if (disciplina != null)
                {
                    if (disciplina.MatricularAluno(aluno))
                        Console.WriteLine("Aluno matriculado com sucesso.");
                    else
                        Console.WriteLine("Erro ao matricular aluno. Verifique se a disciplina está cheia.");
                    break;
                }
            }

            Console.ReadLine();
        }

        static void RemoverAluno()
        {
            Console.Write("Digite o ID do aluno: ");
            int idAluno = int.Parse(Console.ReadLine());

            Console.Write("Digite o ID da disciplina para remoção do aluno: ");
            int idDisciplina = int.Parse(Console.ReadLine());

            foreach (var curso in escola.Cursos)
            {
                Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
                if (disciplina != null)
                {
                    var aluno = disciplina.Alunos.FirstOrDefault(a => a.Id == idAluno);
                    if (aluno != null && disciplina.DesmatricularAluno(aluno))
                        Console.WriteLine("Aluno removido da disciplina com sucesso.");
                    else
                        Console.WriteLine("Erro ao remover aluno. Aluno não encontrado ou erro desconhecido.");
                    break;
                }
            }

            Console.ReadLine();
        }

        static void PesquisarAluno()
        {
            Console.Write("Digite o ID do aluno: ");
            int idAluno = int.Parse(Console.ReadLine());
            bool alunoEncontrado = false;

            foreach (var curso in escola.Cursos)
            {
                foreach (var disciplina in curso.Disciplinas)
                {
                    var aluno = disciplina.Alunos.FirstOrDefault(a => a.Id == idAluno);
                    if (aluno != null)
                    {
                        if (!alunoEncontrado)
                        {
                            Console.WriteLine($"Aluno: {aluno.Nome}");
                            alunoEncontrado = true;
                        }
                        Console.WriteLine($"- {disciplina.Descricao}");
                    }
                }
            }

            if (!alunoEncontrado)
                Console.WriteLine("Aluno não encontrado.");

            Console.ReadLine();
        }
    }
}