using secret_adventure.Models.Base;
using secret_adventure.Models.Etc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Manager
{
    public class AgenteManager : IManager
    {
        private Agente Agente;

        /// <summary>
        /// Cria um novo gerenciador de agente
        /// </summary>
        /// <param name="agente"></param>
        public AgenteManager(Agente agente)
        {
            this.Agente = agente;
        }

        /// <summary>
        /// Move o agente para uma nova posição
        /// </summary>
        /// <param name="novaPosicao">Nova posição</param>
        public void Mover(Point novaPosicao)
        {
            new EntidadeManager(this.Agente).Mover(novaPosicao);
        }

        /// <summary>
        /// Executa as ações do agente
        /// </summary>
        public void Agir()
        {
            bool houveInteracao = false;
            List<Entidade> entidadesProximas;
            AmbienteManager ambiente = new AmbienteManager(Singleton.GetInstance());
            entidadesProximas = ambiente.GetEntidadesProximas(this.Agente, 1);
            foreach (var entidade in entidadesProximas)
            {
                if (entidade is Mosquito && houveInteracao == false)
                {
                    this.MatarMosquito(entidade as Mosquito);
                    houveInteracao = true;
                }
            }
            if (houveInteracao == false)
            {
                for (int nivel = 2; nivel <= 3; nivel++)
                {
                    entidadesProximas = ambiente.GetEntidadesProximas(this.Agente, nivel);
                    foreach (var personagem in entidadesProximas)
                    {
                        if (personagem is Mosquito && houveInteracao == false)
                        {
                            this.Perseguir(personagem);
                            houveInteracao = true;
                        }
                    }
                }
            }
            if (houveInteracao == false)
            {
                new EntidadeManager(this.Agente).Vagar(ambiente.GetPosicoesProximasVazias(this.Agente));
            }
        }

        /// <summary>
        /// Desativa o agente
        /// </summary>
        public void Morrer()
        {
            new EntidadeManager(this.Agente).Morrer();
        }

        /// <summary>
        /// Persegue uma entidade
        /// </summary>
        /// <param name="entidade">Entidade que deve ser perseguida</param>
        /// <returns></returns>
        public bool Perseguir(Entidade entidade)
        {
            return new EntidadeManager(this.Agente).MoverPara(entidade);
        }

        /// <summary>
        /// Mata um mosquito
        /// </summary>
        /// <param name="mosquito"></param>
        public void MatarMosquito(Mosquito mosquito)
        {
            new EntidadeManager(mosquito).Morrer();
        }
    }
}