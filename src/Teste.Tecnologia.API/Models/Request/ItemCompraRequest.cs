using System.ComponentModel.DataAnnotations;

namespace Teste.Tecnologia.API.Models.Request
{
    public class ItemCompraRequest
    {
        [Required, MinLength(5)]
        public string CodigoProduto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }
    }
}
