using System;

namespace Revisao
{
  class Program
  {
    static void Main(string[] args)
    {
      //cria vetor alunos do tipo Aluno

      Aluno[] alunos = new Aluno[5];
      var indiceAlunos = 0;

      string opcaoUsuario = OpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {

        switch (opcaoUsuario)
        {

          case "1":

            Console.WriteLine("Informe o nome do aluno: ");

            Aluno aluno = new Aluno();
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Digite a nota do aluno: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
            {

              aluno.Nota = nota;

            }
            else
            {

              throw new ArgumentException("Valor da nota deve ser decimal!");

            }

            alunos[indiceAlunos] = aluno;

            indiceAlunos++;

            break;

          case "2":

            foreach (var a in alunos)
            {

              if (!string.IsNullOrEmpty(a.Nome))
              {

                Console.WriteLine($"ALUNO = {a.Nome} - NOTA = {a.Nota}");

              }
            }

            break;

          case "3":

            decimal media = 0;
            int qtdeAlunos = 0;
            Conceito conceito;

            for (int i = 0; i < alunos.Length; i++)
            {
              if (!string.IsNullOrEmpty(alunos[i].Nome))
              {

                media += alunos[i].Nota;
                qtdeAlunos++;

              }
            }

            media /= qtdeAlunos;

            if (media < 2)
            {

              conceito = Conceito.E;

            }
            if (media < 4)
            {

              conceito = Conceito.D;

            }
            if (media < 6)
            {

              conceito = Conceito.C;

            }
            if (media < 8)
            {

              conceito = Conceito.B;

            }
            else
            {

              conceito = Conceito.A;

            }

            Console.WriteLine($"MÉDIA = {media} - CONCEITO = {conceito}");

            break;

          default:

            throw new ArgumentOutOfRangeException();

        }
        opcaoUsuario = OpcaoUsuario();
      }
    }

    private static string OpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada: ");
      Console.WriteLine("1 - Inserir novo aluno");
      Console.WriteLine("2 - Listar alunos");
      Console.WriteLine("3 - Calcular média geral");
      Console.WriteLine("X: - Sair");

      Console.WriteLine();

      string opcao = Console.ReadLine();
      Console.WriteLine();
      return opcao;
    }
  }
}
