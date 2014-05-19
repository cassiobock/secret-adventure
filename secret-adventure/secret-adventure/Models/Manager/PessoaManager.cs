using Dengue.Models.Outra;
using secret_adventure.Models.Base;
using secret_adventure.Models.Etc;
using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Manager
{
    public class PessoaManager : IManager
    {
        private Pessoa Pessoa;

        /// <summary>
        /// Cria um novo gerenciador de pessoas
        /// </summary>
        /// <param name="pessoa">Pessoa que será gerencia</param>
        public PessoaManager(Pessoa pessoa)
        {
            this.Pessoa = pessoa;
        }

        /// <summary>
        /// Executa as ações da pessoa
        /// </summary>
        public void Agir()
        {
            this.Curar();
            if (this.Pessoa.Ativo == true)
            {
                bool houveInteracao = false;
                List<Entidade> entidadesProximas;
                AmbienteManager ambiente = new AmbienteManager(Singleton.GetInstance());
                for (int nivel = 1; nivel <= 3; nivel++)
                {
                    entidadesProximas = ambiente.GetEntidadesProximas(this.Pessoa, nivel);
                    foreach (var entidade in entidadesProximas)
                    {
                        if (entidade is Mosquito && houveInteracao == false)
                        {
                            this.Fugir(entidade as Mosquito);
                            houveInteracao = true;
                        }
                    }
                }
                if (houveInteracao == false)
                {
                    new EntidadeManager(this.Pessoa).Vagar(ambiente.GetPosicoesProximasVazias(this.Pessoa));
                }
            }
        }

        /// <summary>
        /// Desativa a pessoa
        /// </summary>
        public void Morrer()
        {
            new EntidadeManager(this.Pessoa).Morrer();
        }

        /// <summary>
        /// Move o personagem
        /// </summary>
        /// <param name="novaPosicao"></param>
        public void Mover(Point novaPosicao)
        {
            new EntidadeManager(this.Pessoa).Mover(novaPosicao);
        }

        /// <summary>
        /// Deixa a pessoa doente e adiciona o tipo de dengue a lista de doenças contraidas
        /// </summary>
        /// <param name="tipoDengue"></param>
        private void PegarDengue(TipoDengue tipoDengue)
        {
            // Se for dengue Hemorragica, gera random de 0 a 1, se for par, a pessoa irá morrer. Impar não morre
            if (tipoDengue == TipoDengue.Hemorragica && Util.GetRandom(2) % 2 == 0 ? true : false)
            {
                //Mata a pessoa
                this.Morrer();
            }
            this.Pessoa.DenguesContraidas.Add(tipoDengue); // Adiciona o tipo de dengue aos tipos de dengue já contraídos
            this.Pessoa.Saudavel = false; // Adoece a pessoa
            this.Pessoa.RodadasDoente = 8;
        }

        /// <summary>
        /// Permite que pessoa seja picada
        /// </summary>
        /// <param name="tipoDengue">Tipo de dengue do mosquito</param>
        /// <returns>True se ficou doente ou false se ficou saldavel</returns>
        public bool SerPicada(TipoDengue tipoDengue)
        {
            // Verifica se já pegou dengue e se está saudável
            if (this.Pessoa.DenguesContraidas.Count(s => s == tipoDengue) == 0 && this.Pessoa.Saudavel == true)
            {
                // Chama o método responsável por adoecer a pessoa
                this.PegarDengue(tipoDengue);
                return true; // Retorna true se pegou a doença
            }
            else
            {
                return false; // Retorna false se não pegou dengue
            }
        }

        /// <summary>
        /// Cura a pessoa doente
        /// </summary>
        public void Curar()
        {
            if (this.Pessoa.Saudavel == false)
            {
                switch (this.Pessoa.RodadasDoente)
                {
                    // Se já passou 8 rodadas, torna a pessoa saudavel
                    case 0:
                        this.Pessoa.Saudavel = true;
                        break;
                    default: // Diminui o número de rodadas doente
                        this.Pessoa.RodadasDoente--;
                        break;
                }
            }
        }

        /// <summary>
        /// Foge de uma entidade
        /// </summary>
        /// <param name="entidade">Entidade da qual fugir</param>
        /// <returns></returns>
        public bool Fugir(Entidade entidade)
        {
            return new EntidadeManager(this.Pessoa).MoverPara(entidade, false);
        }
    }
}
