using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoCondominio.Domain.Entities
{
    [Table("Condominio")]
    public class Condominio
    {
        [Key]
        [Column("Id")]
        public int CondominioId { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Bairro { get; set; }
        public Condominio()
        {

        }
    }
}
