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
        [Required(ErrorMessage = "Você deve preencher o número de mosquitos!")]
        public int NumeroMosquitos { get; set; }
        [DisplayName("Número de pessoas")]
        [Required(ErrorMessage = "Você deve preencher o número de pessoas!")]
        public int NumeroPessoas { get; set; }
        [DisplayName("Número de Agente")]
        [Required(ErrorMessage = "Você deve preencher o número de agente!")]
        public int NumeroAgentes { get; set; }
    }
}