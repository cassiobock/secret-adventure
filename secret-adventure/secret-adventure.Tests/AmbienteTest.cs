using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using secret_adventure.Models.Base;
using secret_adventure.Models;
using secret_adventure.Models.Manager;
using System.Collections.Generic;
using System.Drawing;
using secret_adventure.Models.Factory;
using secret_adventure.Models.Other;

namespace secret_adventure.Tests
{
    [TestClass]
    public class AmbienteTest
    {
        Ambiente ambiente = new Ambiente(2, 2, 1, 1, 1);

        [TestMethod]
        public void AmbienteDeveSerDoTamanhoCorreto()
        {
            int quantidadeDePosicoes = ambiente.Linhas * ambiente.Colunas;

            Assert.AreEqual(quantidadeDePosicoes, 4);
        }

        [TestMethod]
        public void AmbienteDeveTerNumeroCorretoDeEntidades()
        {
            int quantidadeDePosicoes = ambiente.Entidades.Count;

            Assert.AreEqual(quantidadeDePosicoes, 3);
        }

        [TestMethod]
        public void AmbienteDeveRetornarUmaMatrizComQuantidadeDeLinhasCorretas()
        {
            Entidade[,] entidades = new AmbienteManager(ambiente).GetMatriz();

            int linhas = entidades.GetLength(0);

            Assert.AreEqual(ambiente.Linhas, linhas);
        }

        [TestMethod]
        public void AmbienteDeveRetornarUmaMatrizComQuantidadeDeColunasCorretas()
        {
            Entidade[,] entidades = new AmbienteManager(ambiente).GetMatriz();

            int colunas = entidades.GetLength(1);

            Assert.AreEqual(ambiente.Linhas, colunas);
        }

        [TestMethod]
        public void AmbienteDeveRetornarQuantidadeDeMosquitoCorreta()
        {
            Entidade[,] entidades = new AmbienteManager(ambiente).GetMatriz();

            int quantidadeDeEntidades = 0;
            for (int linha = 0; linha < entidades.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < entidades.GetLength(1); coluna++)
                {
                    if (entidades[linha, coluna] is Entidade)
                    {
                        quantidadeDeEntidades++;
                    }
                }
            }

            Assert.AreEqual(quantidadeDeEntidades, ambiente.Entidades.Count);
        }

        [TestMethod]
        public void AmbienteDeveRetornarListaDeEntidadesProximas()
        {
            List<Entidade> entidades = new AmbienteManager(ambiente).GetEntidadesProximas(ambiente.Entidades.First(), 1);

            bool localizou = ambiente.Entidades.Contains(entidades.FirstOrDefault());

            Assert.IsTrue(localizou);
        }

        [TestMethod]
        public void AmbienteDeveRetornarUmaPosicaoVazia()
        {
            List<Point> posicoesVazias = new AmbienteManager(ambiente).GetPosicoesVazias(ambiente.Entidades.First());

            bool posicaoEstaVazia = ambiente.Entidades.Where(m => m.Posicao == posicoesVazias.First()).Count() == 0 ? true : false;

            Assert.IsTrue(posicaoEstaVazia);
        }

        [TestMethod]
        public void AmbienteDeveAdicionarNovasEntidades()
        {
            List<Entidade> entidadeQueSeraoAdicionadas = new List<Entidade>()
            {
                EntidadeFactory.CriaTipoPersonagem(TipoClasse.Pessoa, new AmbienteManager(ambiente).GetPosicoesVazias(ambiente.Entidades.First()).First())
            };

            new AmbienteManager(ambiente).AdicionarEntidades(entidadeQueSeraoAdicionadas);
            new AmbienteManager(ambiente).Processar();

            Assert.IsTrue(ambiente.Entidades.Contains(entidadeQueSeraoAdicionadas.First()));
        }

        [TestMethod]
        public void AmbienteDeveRemoverEntidadesDesativadas()
        {
            Entidade entidade = ambiente.Entidades.First();
            
            new EntidadeManager(entidade).Morrer();
            new AmbienteManager(ambiente).Processar();
            bool entidadeFoiRemovida = ambiente.Entidades.Contains(entidade);

            Assert.IsFalse(entidadeFoiRemovida);
        }
    }
}
