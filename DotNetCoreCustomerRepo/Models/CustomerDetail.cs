using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCustomerRepo.Models
{
    public class CustomerDetail
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CustomerName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CustomerAddress { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CustomerState { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string CustomerCardNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string CustomerCardExpiryDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(3)")]
        public string CustomerCVV { get; set; }
        
    }
}
