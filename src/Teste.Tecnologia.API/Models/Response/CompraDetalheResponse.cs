
namespace Teste.Tecnologia.API.Models.Response
{
    public class CompraDetalheResponse : CompraResponse
    {
        public List<ItemCompraResponse> Itens { get; set; }
    }
}
