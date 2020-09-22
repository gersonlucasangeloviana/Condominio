using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoGestaoCondominio.Domain.Entities
{
    [Table("Morador")]
    public class Morador
    {
        [Key]
        [Column("Id")]
        public int MoradorId { get; set; }

        [Display(Name = "Família")]
        [Column("Id_Familia")]
        public int FamiliaId { get; set; }

        [ForeignKey(nameof(FamiliaId))]
        public Familia Familia { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Nome { get; set; }

        [Display(Name = "Quantidade de Bichos de Estimação")]
        public int QuantidadeBichosEstimacao { get; set; }

        public Morador()
        {

        }
    }
}
