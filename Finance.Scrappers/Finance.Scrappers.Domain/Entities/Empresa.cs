using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Scrappers.Domain.Entities
{
    public class Empresa : Entity
    {
        public string RazaoSocial { get; private set; }
        public string NomePregao { get; private set; }
        public int CodigoCVM { get; private set; }

        public List<string> CodigosNegociacao { get; private set; }

        protected Empresa()
        {
            Id = Guid.NewGuid();
            this.CodigosNegociacao = new List<string>();
        }

        public Empresa(string razaoSocial, string nomePregao, int codigoCVM, List<string> codigosNegociacao) : this()
        {
            RazaoSocial = razaoSocial;
            NomePregao = nomePregao;
            CodigoCVM = codigoCVM;
            this.CodigosNegociacao.AddRange(codigosNegociacao);
        }
    }
}
