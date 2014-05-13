using Dengue.Models.Outra;
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
            this.Envelhecer();
            bool houveInteracao = false;
            if (this.MosquitoFemea.Estagio == Estagio.Adulto && this.MosquitoFemea.Ativo == true)
            {
                List<Entidade> entidadesProximas;
                AmbienteManager ambiente = new AmbienteManager(Singleton.GetInstance());
                entidadesProximas = ambiente.GetEntidadesProximas(this.MosquitoFemea, 1);
                foreach (var personagem in entidadesProximas)
                {
                    if (personagem is Agente && houveInteracao == false)
                    {
                        this.Fugir(personagem as Agente);
                        houveInteracao = true;
                    }
                    else if (personagem is Pessoa && this.MosquitoFemea.ComFome == true && houveInteracao == false)
                    {
                        this.Picar(personagem as Pessoa);
                        houveInteracao = true;
                    }
                    else if (personagem is MosquitoMacho && this.MosquitoFemea.ComFome == false && houveInteracao == false)
                    {
                        this.Acasalar(personagem as MosquitoMacho);
                        houveInteracao = true;
                    }
                }
                if (houveInteracao == false)
                {
                    for (int nivel = 2; nivel <= 3; nivel++)
                    {
                        entidadesProximas = ambiente.GetEntidadesProximas(this.MosquitoFemea, nivel);
                        foreach (var personagem in entidadesProximas)
                        {
                            if (personagem is Agente && houveInteracao == false)
                            {
                                this.Fugir(personagem as Agente);
                                houveInteracao = true;
                            }
                            else if (personagem is Pessoa && this.MosquitoFemea.ComFome == true && houveInteracao == false)
                            {
                                this.Perseguir(personagem as Pessoa);
                                houveInteracao = true;
                            }
                            else if (personagem is MosquitoMacho && this.MosquitoFemea.ComFome == false && houveInteracao == false)
                            {
                                this.Perseguir(personagem as MosquitoMacho);
                                houveInteracao = true;
                            }
                        }
                    }
                }
                if (houveInteracao == false)
                {
                    new EntidadeManager(this.MosquitoFemea).Vagar(ambiente.GetPosicoesProximasVazias(this.MosquitoFemea));
                }
            }
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

        /// <summary>
        /// Torna o mosquito mais velho e eventualmente o mata
        /// </summary>
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
        /// Pica uma pessoa e tenta transmitir a dengue
        /// </summary>
        /// <param name="pessoa">Pessoa que será picada</param>
        public void Picar(Pessoa pessoa)
        {
            new PessoaManager(pessoa).SerPicada(this.MosquitoFemea.TipoDengue);
            this.MosquitoFemea.ComFome = false;
        }

        /// <summary>
        /// Reproduz o mosquito
        /// </summary>
        /// <param name="mosquitoMacho">MosquitoMacho parceiro para o acasalamento</param>
        public void Acasalar(MosquitoMacho mosquitoMacho)
        {
            if (this.MosquitoFemea.TipoDengue == TipoDengue.Nenhuma && mosquitoMacho.TipoDengue == TipoDengue.Nenhuma)
            {
                mosquitoMacho.TipoDengue = this.MosquitoFemea.TipoDengue;
                this.PorOvos(mosquitoMacho, TipoDengue.Nenhuma);
            }
            else if (this.MosquitoFemea.TipoDengue == TipoDengue.Nenhuma)
            {
                this.MosquitoFemea.TipoDengue = mosquitoMacho.TipoDengue;
                this.PorOvos(mosquitoMacho, mosquitoMacho.TipoDengue);
            }
            else if (mosquitoMacho.TipoDengue == TipoDengue.Nenhuma)
            {
                mosquitoMacho.TipoDengue = this.MosquitoFemea.TipoDengue;
                this.PorOvos(mosquitoMacho, this.MosquitoFemea.TipoDengue);
            }
            else
            {
                TipoDengue tipoDengue = Util.GetRandom(2) % 2 == 0 ? mosquitoMacho.TipoDengue : this.MosquitoFemea.TipoDengue;
                this.PorOvos(mosquitoMacho, tipoDengue);
            }
            this.MosquitoFemea.ComFome = true;
        }

        /// <summary>
        /// Põe ovos no mapa
        /// </summary>
        /// <param name="parceiro">Parceiro para reprodução</param>
        /// <param name="dengueHereditaria">Tipo de dengue dos filhotes</param>
        public void PorOvos(MosquitoMacho parceiro, TipoDengue dengueHereditaria)
        {
            AmbienteManager ambiente = new AmbienteManager(Singleton.GetInstance());
            List<Point> posicoes = ambiente.GetPosicoesProximasVazias(this.MosquitoFemea);
            List<Entidade> entidades = new List<Entidade>();
            foreach (var posicao in posicoes)
            {
                //Gera um sexo aleatório: masculino ou feminino
                bool macho = Util.GetRandom(2) % 2 == 0 ? true : false;
                //Cria um personagem de acordo com o sexo
                Mosquito personagem = macho == true ? (Mosquito)new MosquitoMacho(posicao, Estagio.Ovo, dengueHereditaria) : (Mosquito)new MosquitoFemea(posicao, Estagio.Ovo, dengueHereditaria);
                entidades.Add(personagem);
            }
            ambiente.AdicionarEntidades(entidades);
        }

        /// <summary>
        /// Foge de agentes
        /// </summary>
        /// <param name="agente">Agente do qual fugir</param>
        /// <returns></returns>
        public bool Fugir(Entidade entidade)
        {
            return new EntidadeManager(this.MosquitoFemea).MoverPara(entidade, false);
        }

        /// <summary>
        /// Persegue uma outra entidade, sendo ela mosquito ou pessoa
        /// </summary>
        /// <param name="entidade">Entidade que deve ser perseguida</param>
        /// <returns></returns>
        public bool Perseguir(Entidade entidade)
        {
            return new EntidadeManager(this.MosquitoFemea).MoverPara(entidade);
        }
    }
}