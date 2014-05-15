using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.ViewModel
{
    public class PessoaViewModel
    {
        private Pessoa Pessoa;

        public PessoaViewModel()
        {
            throw new NotSupportedException();
        }

        public PessoaViewModel(Pessoa pessoa)
        {
            this.Pessoa = pessoa;
        }

        public string Id
        {
            get { return this.Pessoa.Id; }
        }
        public string Posicao
        {
            get { return this.Pessoa.Posicao.ToString(); }
        }

        public string Ativo
        {
            get { return this.Pessoa.Ativo.ToString(); }
        }
        public string TipoEntidade
        {
            get { return this.Pessoa.TipoEntidade.ToString(); }
        }
        public string Saudavel
        {
            get { return this.Pessoa.Saudavel.ToString(); }
        }

        public List<string> DenguesContraidas
        {
            get
            {
                List<String> dengues = new List<string>();
                foreach (TipoDengue tipoDengue in this.Pessoa.DenguesContraidas)
                {
                    dengues.Add(tipoDengue.ToString());
                }
                return dengues;
            }
        }

        public int RodadasDoente
        {
            get { return this.Pessoa.RodadasDoente; }
        }
    }
}