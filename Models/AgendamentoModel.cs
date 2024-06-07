using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bluetrip.Models;

[Table("AGENDAMENTO")]
public class AgendamentoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AgendamentoId { get; set; }

    [Required]
    public DateTime Data { get; set; }

    [Required]
    public int QuantidadePessoas { get; set; }

    [ForeignKey("Evento")]
    public int EventoId { get; set; }
    public EventoModel Evento { get; set; }

    [ForeignKey("Turista")]
    public int TuristaId { get; set; }
    public TuristaModel Turista { get; set; }
}
