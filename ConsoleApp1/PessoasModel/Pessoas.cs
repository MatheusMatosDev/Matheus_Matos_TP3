using System;

namespace PessoasModel
{
   public class Pessoas
    {
        public Pessoas()
        {

        }
        public string Nome { get; set; }

        public string SegundoNome { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string nomeCompleto { get { return $"{Nome} {SegundoNome}"; } }

        public Pessoas(string nome, string segundonome, DateTime dataNiver)
        {
            Nome = nome;
            SegundoNome = segundonome;
            DataDeNascimento = dataNiver.Date;



        }

       
    }

    
        
}

