using secret_adventure.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.Etc
{
    public class Singleton
    {
        private static Ambiente Ambiente;

        public static void SetInstance(Ambiente t)
        {
            Ambiente = t;
        }

        public static Ambiente GetInstance()
        {
            return Ambiente;
        }
    }
}