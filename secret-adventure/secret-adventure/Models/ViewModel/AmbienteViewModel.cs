using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace secret_adventure.Models.ViewModel
{
    public class AmbienteViewModel
    {
        [DisplayName("Linhas")]
        [Required(ErrorMessage = "Você deve preencher o número de linhas do ambiente!")]
        public int Linhas { get; set; }
        [DisplayName("Colunas")]
        [Required(ErrorMessage = "Você deve preencher o número de colunas do ambiente!")]
        public int Colunas { get; set; }
        [DisplayName("Número de Mosquitos")]
        [Required(ErrorMessage = "Você deve preencher o número de Mosquitos!")]
        public int NumeroMosquitos { get; set; }
        [DisplayName("Número de Pessoas")]
        [Required(ErrorMessage = "Você deve preencher o número de Pessoas!")]
        public int NumeroPessoas { get; set; }
        [DisplayName("Número de Agentes")]
        [Required(ErrorMessage = "Você deve preencher o número de Agentes!")]
        public int NumeroAgentes { get; set; }
    }
}