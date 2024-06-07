using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bluetrip.Models;

[Table("TURISTA")]
public class TuristaModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TuristaId { get; set; }

    [Required]
    [StringLength(100)]
    public String Nome { get; set; }

    [Required]
    [StringLength(15)]
    public String Telefone { get; set; }

    [Required]
    [StringLength(100)]
    public String Email { get; set; }

    [Required]
    [StringLength(100)]
    public String Senha { get; set; }

    public ICollection<AgendamentoModel> Agendamentos { get; set; } = new List<AgendamentoModel>();

}
