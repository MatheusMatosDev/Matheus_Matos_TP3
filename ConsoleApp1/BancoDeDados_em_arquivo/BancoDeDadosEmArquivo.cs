using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PessoasModel;

namespace BancoDeDadosArquivo
{
    public class BancoDeDadosEmArquivo
    {
       
        private static string obterNomeArquivo()
        {
            var pastaDesktop = Environment.SpecialFolder.Desktop;

            string localDaPastaDesktop = Environment.GetFolderPath(pastaDesktop);

            string nomeDoArquivo = @"\dadosDosAniversariantes.txt";

            return localDaPastaDesktop + nomeDoArquivo;
        }
        public static void Salvar(Pessoas pessoa)
        {
            bool pessoaJaExiste = false;
            if (pessoaJaExiste == false)
            {
                string nomeDoArquivo = obterNomeArquivo();

                string formato = $"{pessoa.Nome},{pessoa.SegundoNome},{pessoa.DataDeNascimento.ToString()}\n";

                File.AppendAllText(nomeDoArquivo, formato);
            }

        }
        public static IEnumerable<Pessoas> BuscarTodosOsAniversarios()
        {
            var nomeDoArquivo = obterNomeArquivo();

            string resultado = File.ReadAllText(nomeDoArquivo);
            string[] pessoas = resultado.Split('\n');

            List<Pessoas> pessoasList = new List<Pessoas>();

            for (int i = 0; i < pessoas.Length - 1; i++)
            {
                string[] dadosDasPessoas = pessoas[i].Split(',');


                string Nome = dadosDasPessoas[0];
                string segundoNome = dadosDasPessoas[1];
                DateTime dataDeNascimento = Convert.ToDateTime(dadosDasPessoas[2]);

               Pessoas aniversario = new Pessoas(Nome, segundoNome, dataDeNascimento);
                pessoasList.Add(aniversario);

            }

            return pessoasList;

        }

    }

}
