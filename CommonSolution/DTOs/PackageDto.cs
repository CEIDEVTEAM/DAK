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
        [DisplayName("Id Paquete")]
        public int Id { get; set; }
        public bool Paid { get; set; }
        [DisplayName("Fecha Recepción")]
        public DateTime Date { get; set; }
        [DisplayName("Id Expedición")]
        public int? IdExpedition { get; set; }
        [DisplayName("Estatus")]
        public int StatusCode { get; set; }
        [DisplayName("Cod. Trackeo")]
        public string TrackingNumber { get; set; }

        [Remote(action: "ValidateRemitent", controller: "Package", ErrorMessage = "El Cliente (remitente) no existe")]
        [Required(ErrorMessage = "Remitente Requerido")]
        [DisplayName("Remitente")]
        public string IdClient { get; set; }

        [Remote("ValidateRecipient", "Package", ErrorMessage = "El Cliente (destinatario) no existe")]
        [Required(ErrorMessage = "Destinatario Requerido")]
        [DisplayName("Destinatario")]
        public string IdRecipient { get; set; }

        public int IdSender { get; set; }
        public int IdReciever { get; set; }
        [DisplayName("Dirección Destino")]
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [DisplayName("Distancia")]
        public int Distance { get; set; }
        [DisplayName("Altura")]
        public double? Height { get; set; }
        [DisplayName("Ancho")]
        public double? Width { get; set; }
        [DisplayName("Peso")]
        public double? Weight { get; set; }
        [DisplayName("Largo")]
        public double? Length { get; set; }
        public string Type { get; set; }
        [DisplayName("Precio")]
        public double? Price { get; set; }
        [DisplayName("Id Zona de Entrega")]
        public int IdDeliveryArea { get; set; }
        [DisplayName("Id Ciudad")]
        public int IdCity { get; set; }
        [DisplayName("Método Pago")]
        public string PaymentMethod { get; set; }
    }
}
