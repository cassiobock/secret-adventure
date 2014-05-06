using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using secret_adventure.Models.Manager;
using secret_adventure.Models;
using System.Drawing;
using secret_adventure.Models.Base;

namespace secret_adventure.Tests
{
    [TestClass]
    public class AgenteTest
    {
        [TestMethod]
        public void AgenteDeveSeMoverParaOutraPosicao()
        {
            Point posicaoOriginal = new Point(0, 1);
            Point novaPosicao = new Point(0, 2);
            Agente agente = new Agente(posicaoOriginal);
            AgenteManager manager = new AgenteManager(agente);

            manager.Mover(novaPosicao);

            Assert.AreNotEqual(posicaoOriginal, agente.Posicao);
        }

        [TestMethod]
        public void AgenteDeveMatarMosquitoMacho()
        {
            MosquitoMacho mosquito = new MosquitoMacho(new Point(1, 2));
            Agente agente = new Agente(new Point(1, 1));
            AgenteManager manager = new AgenteManager(agente);

            manager.MatarMosquito(mosquito);

            Assert.IsFalse(mosquito.Ativo);
        }

        [TestMethod]
        public void AgenteDeveMatarMosquitoFemea()
        {
            MosquitoFemea mosquito = new MosquitoFemea(new Point(1, 2));
            Agente agente = new Agente(new Point(1, 1));
            AgenteManager manager = new AgenteManager(agente);

            manager.MatarMosquito(mosquito);

            Assert.IsFalse(mosquito.Ativo);
        }
    }
}
