using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bluetrip.Models;

[Table("PONTOTURISTICO")]
public class PontoTuristicoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PontoTuristicoId { get; set; }

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
    [StringLength(15)]
    public String? Telefone { get; set; }

    [Required]
    [StringLength(50)]
    public String Categoria { get; set; }

    [ForeignKey("EnderecoId")]
    public int EnderecoId { get; set; }

    public EnderecoModel Endereco { get; set; }

    public ICollection<EventoModel> Eventos { get; set; } = new List<EventoModel>();
}
