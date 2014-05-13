using secret_adventure.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secret_adventure.Models.Interface
{
    interface IMosquitoManager
    {
        void Agir();
        void Envelhecer();
        bool Fugir(Entidade entidade);
        bool Perseguir(Entidade entidade);
    }
}
