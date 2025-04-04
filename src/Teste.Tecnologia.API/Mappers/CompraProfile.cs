using AutoMapper;
using Teste.Tecnologia.API.Models.Request;
using Teste.Tecnologia.API.Models.Response;
using Teste.Tecnologia.Domain.Entities;

namespace Teste.Tecnologia.API.Mappers;

public class CompraProfile : Profile
{
    public CompraProfile()
    {
        CreateMap<ItemCompraRequest, ItemCompra>();
        CreateMap<CompraRequest, Compra>();

        CreateMap<ItemCompra, ItemCompraResponse>();
        CreateMap<Compra, CompraResponse>();
        CreateMap<Compra, CompraDetalheResponse>();
    }
}
