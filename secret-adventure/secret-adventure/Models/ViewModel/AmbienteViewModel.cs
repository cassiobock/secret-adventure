using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.ViewModel
{
    public class AmbienteViewModel
    {
        [DisplayName("Linhas")]
        public int Linhas { get; set; }
        [DisplayName("Colunas")]
        public int Colunas { get; set; }
        [DisplayName("Número de Mosquitos")]
        public int NumeroMosquitos { get; set; }
        [DisplayName("Número de pessoas")]
        public int NumeroPessoas { get; set; }
        [DisplayName("Número de Agente")]
        public int NumeroAgentes { get; set; }
    }
}