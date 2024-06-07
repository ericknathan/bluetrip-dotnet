using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bluetrip.Models;

[Table("EVENTO")]
public class EventoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EventoId { get; set; }

    [Required]
    [StringLength(100)]
    public String Nome { get; set; }

    [Required]
    [StringLength(512)]
    public String Descricao { get; set; }

    [Required]
    public Double Preco { get; set; }

    [Required]
    public String UrlImagem { get; set; }

    [Required]
    [Column(TypeName = "DATE")]
    public DateTime DataInicio { get; set; }

    [Required]
    [Column(TypeName = "DATE")]
    public DateTime DataFim { get; set; }

    [ForeignKey("PontoTuristico")]
    public int PontoTuristicoId { get; set; }
    
    public PontoTuristicoModel PontoTuristico { get; set; }

    public ICollection<AgendamentoModel> Agendamentos { get; set; } = new List<AgendamentoModel>();
}
