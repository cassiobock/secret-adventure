using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using secret_adventure.Models.Base;
using secret_adventure.Models;
using secret_adventure.Models.Manager;

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
    }
}
