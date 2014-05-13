using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secret_adventure.Models
{
    public interface IManager
    {
        void Mover(Point novaPosicao);
        void Agir();
        void Morrer();
    }
}
