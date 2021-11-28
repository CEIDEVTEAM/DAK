using CommonSolution.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class PackageDto : IDto
    {
        public int Id { get; set; }
        public bool Paid { get; set; }
        public DateTime Date { get; set; }
        public int? IdExpedition { get; set; }
        public int StatusCode { get; set; }
        public string TrackingNumber { get; set; }

        [Remote(action: "ValidateRemitent", controller: "Package", ErrorMessage = "El Cliente (remitente) no existe")]
        [Required(ErrorMessage = "Remitente Requerido")]
        [DisplayName("Remitente")]
        public string IdClient { get; set; }

        [Remote("ValidateRecipient", "Package", ErrorMessage = "El Cliente (destinatario) no existe")]
        [Required(ErrorMessage = "Destinatario Requerido")]
        [DisplayName("Destinatario")]
        public string IdRecipient { get; set; }


        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Distance { get; set; }

        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Weight { get; set; }
        public double? Length { get; set; }
        public string Type { get; set; }
        public int IdZona { get; set; }

    }
}
