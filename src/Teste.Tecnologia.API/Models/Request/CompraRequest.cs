using System.ComponentModel.DataAnnotations;

namespace Teste.Tecnologia.API.Models.Request
{
    public class CompraRequest
    {
        [Required, MinLength(2)]
        public string NumeroVenda { get; set; }

        [Required]
        public DateOnly DataVenda { get; set; }

        [Required]
        public string ClienteId { get; set; }

        [Required]
        public string CodigoLoja { get; set; }

        [Required]
        public List<ItemCompraRequest> Itens { get; set; }
    }
}
