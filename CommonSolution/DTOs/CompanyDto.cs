using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class CompanyDto : ClientDto
    {
        public int IdClient { get; set; }

        [StringLength(20, ErrorMessage = "El RUT no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "El RUT es requerido")]
        [DisplayName("RUT")]
        public string Rut { get; set; }

        [StringLength(30, ErrorMessage = "La Razón Social no puede superar los 30 caracteres")]
        [Required(ErrorMessage = "La Razón Social es requerida")]
        [DisplayName("Razón Social")]
        public string BusinessName { get; set; }
    }
}
