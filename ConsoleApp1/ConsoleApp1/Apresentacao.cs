using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using BancoDeDadosArquivo;
using PessoasModel;


namespace GerenciadorDeAniversarios
{
    class Apresentacao
    {
        private static void EscreverNaTela(string texto)
        {
            Console.WriteLine(texto);
        }
        public static void MenuPrincipal()
        {
            EscreverNaTela("Gerenciador de Aniversários");
            EscreverNaTela("selecione uma das opções abaixo:");
            EscreverNaTela("1- Pesquisar pessoas");
            EscreverNaTela("2- Adicionar nova pessoa");
            EscreverNaTela("3- Sair");

            char escolha = Console.ReadLine().ToCharArray()[0];

            switch (escolha)
            {
                case '1': PesquisarPessoas(); break;
                case '2': AdicionarPessoa(); break;
                case '3': EscreverNaTela("voce saiu"); break;
                default: EscreverNaTela("opção inexistente"); MenuPrincipal(); break;

            }

        }
       public  static void AdicionarPessoa()
        {
            EscreverNaTela("Qual o nome da pessoa?");
            string nome = Console.ReadLine();

            EscreverNaTela("Qual o segundo nome da pessoa?");
            string segundonome = Console.ReadLine();


            EscreverNaTela("qual data de nascimento?");
            var date = Console.ReadLine();
            DateTime data = DateTime.Parse(date).Date;

            EscreverNaTela("Os dados estao corretos?");
            EscreverNaTela($"Nome: {nome}");

            EscreverNaTela($"Data: {date}");

            var pessoa = new Pessoas(nome, segundonome, data);

            BancoDeDadosEmArquivo.Salvar(pessoa);

            EscreverNaTela("Se estiver correto pressione  a tecla s ");

            char verificacao = Console.ReadLine().ToCharArray()[0];
            switch (verificacao)
            {
                case 's': BancoDeDadosEmArquivo.Salvar(pessoa); EscreverNaTela("Cadastrado com sucesso"); ; break;

                default: EscreverNaTela("Entao escreva os dados novamente  "); AdicionarPessoa(); break;

            }
            EscreverNaTela("Pressionae qualquer tecla para ir para o menuPrincipal");
            Console.ReadKey();



            LimparTela();
            MenuPrincipal();

        }
        private static void LimparTela() //Limpar o console
        {
            Console.Clear();
        }
        static void PesquisarPessoas()
        {
            LimparTela();
            ExibirFiltro();
        }
        static void ExibirFiltro()
        {
            EscreverNaTela("1- pesquisar pelo nome");
            EscreverNaTela("2- listar todas as pessoas");


            char escolha = Console.ReadLine().ToCharArray()[0];

            switch (escolha)
            {
               // case '1': PesquisarPeloNome(); break;
                case '2': ListarTodasPessoas(); break;


            }
            
            static void ListarTodasPessoas()
            {
                foreach (var pessoa in BancoDeDadosEmArquivo.BuscarTodosOsAniversarios())
                {

                    EscreverNaTela($"Nome: {pessoa.Nome} \nSegundoNome: {pessoa.SegundoNome} \nData de Aniversario  {String.Format("{0:dd/MM/yyyy}", pessoa.DataDeNascimento)} \nDias para o proximo niver  ");


                }
            }
           // static void PesquisarPeloNome()
            //{
              //  EscreverNaTela("digite o nome da pessoa q deseja encontrar");
                //string name = Console.ReadLine();
               // foreach (var pessoa in BancoDeDados.BuscarPessoasCadastradas())
                //{
                  //  if (pessoa.Nome == name)
                   // {
                   //     EscreverNaTela($"Nome: {pessoa.Nome} \nCpf: {pessoa.Cpf} \nData de Aniversario  {String.Format("{0:dd/MM/yyyy}", pessoa.DataDeNascimento)} \nDias para o proximo niver {pessoa.TempoParaNiver()}");
                   // }
                   // else
                    //{
                      //  EscreverNaTela("nome não encontrado, Pressione qualquer tecla para pesquisar novamente o nome");
                        //Console.ReadKey();
                        //PesquisarPeloNome();
                    //}

               // }
           // }
            //public int tempoparaniver()
            //{
            //    datetime hoje = datetime.today;
            //    datetime aniversario;
            //    if (hoje.month < datadenascimento.month || (hoje.month == datadenascimento.month && hoje.day <= datadenascimento.day))
            //    {
            //        aniversario = new datetime(hoje.year, datadenascimento.month, datadenascimento.day);
            //    }
            //    else
            //    {
            //        aniversario = new datetime(hoje.year + 1, datadenascimento.month, datadenascimento.day);

            //    }
            //    return aniversario.subtract(hoje).days;

            //}
        }
           

    }
}

