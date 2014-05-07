using secret_adventure.Models.Base;
using secret_adventure.Models.Interface;
using secret_adventure.Models.Other;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Manager
{
    public class MosquitoFemeaManager : IManager, IMosquitoManager
    {
        private MosquitoFemea MosquitoFemea;

        /// <summary>
        /// Inicia um novo gerenciador de mosquito fêmea
        /// </summary>
        /// <param name="mosquitoFemea"></param>
        public MosquitoFemeaManager(MosquitoFemea mosquitoFemea)
        {
            this.MosquitoFemea = mosquitoFemea;
        }

        /// <summary>
        /// Executa as ações do mosquito
        /// </summary>
        public void Agir()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Move o mosquito fêmea para outra posicação
        /// </summary>
        /// <param name="novaPosicao">Nova posição</param>
        public void Mover(Point novaPosicao)
        {
            new EntidadeManager(this.MosquitoFemea).Mover(novaPosicao);
        }

        /// <summary>
        /// Desativa o mosquito fêmea
        /// </summary>
        public void Morrer()
        {
            new EntidadeManager(this.MosquitoFemea).Morrer();
        }

        public void Envelhecer()
        {
            // Verifica se o mosquito é adulto
            if (this.MosquitoFemea.Estagio == Estagio.Adulto)
            {
                // Se não estiver sem rodadas
                if (this.MosquitoFemea.TempoDeVida != 0)
                {
                    // Diminui o tempo de vida
                    this.MosquitoFemea.TempoDeVida--;
                }
                else // Se estiver sem rodadas
                {
                    // Morreu :(
                    this.Morrer();
                }
            }
            else // Se não é adulto, envelhece o mosquito
            {
                // Envelhece de acordo com a idade
                switch (this.MosquitoFemea.Estagio)
                {
                    case Estagio.Ovo:
                        this.MosquitoFemea.TempoDeVida--;
                        this.MosquitoFemea.Estagio = Estagio.Pupa;
                        break;
                    case Estagio.Pupa:
                        this.MosquitoFemea.TempoDeVida--;
                        this.MosquitoFemea.Estagio = Estagio.Larva;
                        break;
                    case Estagio.Larva:
                        this.MosquitoFemea.TempoDeVida--;
                        this.MosquitoFemea.Estagio = Estagio.Adulto;
                        break;
                }
            }
        }

        /// <summary>
        /// Foge de agentes
        /// </summary>
        /// <param name="agente">Agente do qual fugir</param>
        /// <returns></returns>
        public bool Fugir(Agente agente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Persegue uma outra entidade, sendo ela mosquito ou pessoa
        /// </summary>
        /// <param name="entidade">Entidade que deve ser perseguida</param>
        /// <returns></returns>
        public bool Perseguir(Entidade entidade)
        {
            throw new NotImplementedException();
        }
    }
}