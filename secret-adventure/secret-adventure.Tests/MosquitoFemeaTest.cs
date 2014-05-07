using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using secret_adventure.Models.Base;
using secret_adventure.Models.Manager;

namespace secret_adventure.Tests
{
    [TestClass]
    public class MosquitoFemeaTest
    {
        [TestMethod]
        public void MosquitoDeveSeMover()
        {
            Point posicaoOriginal = new Point(1, 1);
            Point novaPosicao = new Point(1, 2);
            MosquitoFemea mosquito = new MosquitoFemea(posicaoOriginal);
            MosquitoFemeaManager manager = new MosquitoFemeaManager(mosquito);

            manager.Mover(novaPosicao);

            Assert.AreNotEqual(mosquito.Posicao, posicaoOriginal);
        }

        [TestMethod]
        public void MosquitoDeveMorrer()
        {
            MosquitoFemea mosquito = new MosquitoFemea(new Point(1, 2));
            MosquitoFemeaManager manager = new MosquitoFemeaManager(mosquito);

            manager.Morrer();

            Assert.IsFalse(mosquito.Ativo);
        }

        [TestMethod]
        public void MosquitoDeveFicarMaisVelho()
        {
            MosquitoFemea mosquito = new MosquitoFemea(new Point(1, 2));
            MosquitoFemeaManager manager = new MosquitoFemeaManager(mosquito);
            int rodadasAntes = mosquito.TempoDeVida;

            manager.Envelhecer();

            Assert.IsTrue(rodadasAntes > mosquito.TempoDeVida);
        }
    }
}
