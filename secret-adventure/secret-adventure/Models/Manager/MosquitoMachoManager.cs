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
    public class MosquitoMachoManager : IManager, IMosquitoManager
    {
        private MosquitoMacho MosquitoMacho;

        /// <summary>
        /// Cria um novo gerenciador de Mosquito Macho
        /// </summary>
        /// <param name="mosquitoMacho">Mosquito que será gerenciado</param>
        public MosquitoMachoManager(MosquitoMacho mosquitoMacho)
        {
            this.MosquitoMacho = mosquitoMacho;
        }

        /// <summary>
        /// Executa as ações do mosquito
        /// </summary>
        public void Agir()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Move os mosquitos para uma outra posição
        /// </summary>
        /// <param name="novaPosicao">Nova posição</param>
        public void Mover(Point novaPosicao)
        {
            new EntidadeManager(this.MosquitoMacho).Mover(novaPosicao);
        }

        /// <summary>
        /// Desativa o mosquito
        /// </summary>
        public void Morrer()
        {
            new EntidadeManager(this.MosquitoMacho).Morrer();
        }

        /// <summary>
        /// Deixa o mosquito velho
        /// </summary>
        public void Envelhecer()
        {
            // Verifica se o mosquito é adulto
            if (this.MosquitoMacho.Estagio == Estagio.Adulto)
            {
                // Se não estiver sem rodadas
                if (this.MosquitoMacho.TempoDeVida != 0)
                {
                    // Diminui o tempo de vida
                    this.MosquitoMacho.TempoDeVida--;
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
                switch (this.MosquitoMacho.Estagio)
                {
                    case Estagio.Ovo:
                        this.MosquitoMacho.TempoDeVida--;
                        this.MosquitoMacho.Estagio = Estagio.Pupa;
                        break;
                    case Estagio.Pupa:
                        this.MosquitoMacho.TempoDeVida--;
                        this.MosquitoMacho.Estagio = Estagio.Larva;
                        break;
                    case Estagio.Larva:
                        this.MosquitoMacho.TempoDeVida--;
                        this.MosquitoMacho.Estagio = Estagio.Adulto;
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