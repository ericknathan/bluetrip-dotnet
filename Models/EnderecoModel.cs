using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bluetrip.Models;

[Table("ENDERECO")]
public class EnderecoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EnderecoId { get; set; }

    [Required]
    [StringLength(100)]
    public String Rua { get; set; }

    [Required]
    [StringLength(100)]
    public String Cidade { get; set; }

    [Required]
    [StringLength(9)]
    public String Cep { get; set; }

    [Required]
    [StringLength(2)]
    public String Estado { get; set; }

    [Required]
    [StringLength(100)]
    public String Bairro { get; set; }

    [Required]
    [StringLength(10)]
    public String Numero { get; set; }

    [StringLength(100)]
    public String? Complemento { get; set; }
}
