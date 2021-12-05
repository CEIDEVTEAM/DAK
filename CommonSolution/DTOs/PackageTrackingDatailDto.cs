using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class PackageTrackingDatailDto: IDto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Id del Paquete")]
        public int IdPackage { get; set; }
        [DisplayName("Fecha")]
        public DateTime DateTime { get; set; }
        [DisplayName("Ubicación")]
        public string Ubication { get; set; }
        [DisplayName("Id Estado")]
        public int? StatusCode { get; set; }
        [DisplayName("Numero de seguimiento")]
        public string trackingNumber { get; set; }

    }
}
