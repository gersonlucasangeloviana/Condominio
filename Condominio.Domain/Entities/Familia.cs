using GestaoCondominio.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoGestaoCondominio.Domain.Entities
{
    [Table("Familia")]
    public class Familia
    {
        [Key]
        [Column("Id")]
        public int FamiliaId { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Nome { get; set; }

        [Display(Name = "Condomínio")]
        [Column("Id_Condominio")]
        public int CondominioId { get; set; }

        [ForeignKey(nameof(CondominioId))]
        public Condominio Condominio { get; set; }

        public int Apartamento { get; set; }

        public Familia()
        {

        }
    }
}
