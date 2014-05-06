using Microsoft.VisualStudio.TestTools.UnitTesting;
using secret_adventure.Models;
using secret_adventure.Models.Manager;
using secret_adventure.Models.Other;
using System.Drawing;

namespace secret_adventure.Test
{
    [TestClass]
    public class PessoaTest
    {
        [TestMethod]
        public void PessaoDevePegarDengue()
        {
            Pessoa pessoa = new Pessoa(new Point(1, 2));
            PessoaManager manager = new PessoaManager(pessoa);

            bool pegouDengue = manager.SerPicada(TipoDengue.Classica);

            Assert.IsTrue(pegouDengue);
        }
        [TestMethod]
        public void PessoaNaoDevePegarDengueQueJaTeve()
        {
            Pessoa pessoa = new Pessoa(new Point(1, 2));
            PessoaManager manager = new PessoaManager(pessoa);

            manager.SerPicada(TipoDengue.Classica);
            bool pegouDengueQueJaTeve = manager.SerPicada(TipoDengue.Classica);

            Assert.IsFalse(pegouDengueQueJaTeve);
        }

        [TestMethod]
        public void PessoaDeveMorrer()
        {
            Pessoa pessoa = new Pessoa(new Point(1, 2));
            PessoaManager manager = new PessoaManager(pessoa);

            manager.InternalMorrer();
            
            Assert.IsFalse(pessoa.Ativo);
        }

    }
}
