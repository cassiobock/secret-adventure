using secret_adventure.Models.Base;
using secret_adventure.Models.Etc;
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
            this.Envelhecer();
            bool houveInteracao = false;
            if (this.MosquitoMacho.Estagio == Estagio.Adulto && this.MosquitoMacho.Ativo == true)
            {
                List<Entidade> entidadesProximas;
                AmbienteManager ambiente = new AmbienteManager(Singleton.GetInstance());
                entidadesProximas = ambiente.GetEntidadesProximas(this.MosquitoMacho, 1);
                foreach (var personagem in entidadesProximas)
                {
                    if (personagem is Agente && houveInteracao == false)
                    {
                        this.Fugir(personagem as Agente);
                        houveInteracao = true;
                    }
                    else if (personagem is MosquitoFemea && houveInteracao == false)
                    {
                        this.Acasalar(personagem as MosquitoFemea);
                        houveInteracao = true;
                    }
                }
                if (houveInteracao == false)
                {
                    for (int nivel = 2; nivel <= 3; nivel++)
                    {
                        entidadesProximas = ambiente.GetEntidadesProximas(this.MosquitoMacho, nivel);
                        foreach (var personagem in entidadesProximas)
                        {
                            if (personagem is Agente && houveInteracao == false)
                            {
                                this.Fugir(personagem as Agente);
                                houveInteracao = true;
                            }
                            else if (personagem is MosquitoFemea && houveInteracao == false && ((MosquitoFemea)personagem).ComFome == false)
                            {
                                this.Perseguir(personagem as MosquitoFemea);
                                houveInteracao = true;
                            }
                        }
                    }
                }
                if (houveInteracao == false)
                {
                    new EntidadeManager(this.MosquitoMacho).Vagar(ambiente.GetPosicoesProximasVazias(this.MosquitoMacho));
                }
            }
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
        /// Reproduz o mosquito
        /// </summary>
        /// <param name="mosquitoFemea"></param>
        public void Acasalar(MosquitoFemea mosquitoFemea)
        {
            if (mosquitoFemea.ComFome == false)
            {
                new MosquitoFemeaManager(mosquitoFemea).Acasalar(this.MosquitoMacho);
            }
        }

        /// <summary>
        /// Foge de agentes
        /// </summary>
        /// <param name="agente">Agente do qual fugir</param>
        /// <returns></returns>
        public bool Fugir(Entidade entidade)
        {
            return new EntidadeManager(this.MosquitoMacho).MoverPara(entidade, false);
        }

        /// <summary>
        /// Persegue uma outra entidade, sendo ela mosquito ou pessoa
        /// </summary>
        /// <param name="entidade">Entidade que deve ser perseguida</param>
        /// <returns></returns>
        public bool Perseguir(Entidade entidade)
        {
            return new EntidadeManager(this.MosquitoMacho).MoverPara(entidade);
        }
    }
}