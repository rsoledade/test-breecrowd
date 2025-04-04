using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teste.Tecnologia.Domain.Entities;
using Teste.Tecnologia.API.Models.Request;
using Teste.Tecnologia.API.Models.Response;
using Teste.Tecnologia.Domain.Interfaces.Services;

namespace Teste.Tecnologia.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/compra")]
    public class CompraController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService, IMapper mapper)
        {
            _mapper = mapper;
            _compraService = compraService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCompraAsync([FromBody] CompraRequest model)
        {
            try
            {
                var compra = _mapper.Map<Compra>(model);
                var compraId = await _compraService.CreateAsync(compra);
                return Ok(new { id = compraId });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> AlterarCompraAsync([FromRoute] Guid id, [FromBody] CompraRequest model)
        {
            try
            {
                var compra = _mapper.Map<Compra>(model);
                await _compraService.UpdateAsync(id, compra);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterCompra([FromRoute] Guid id)
        {
            try
            {
                var compra = await _compraService.GetAsync(id);
                if (compra == null)
                    return Ok();

                return Ok(_mapper.Map<CompraDetalheResponse>(compra));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasCompras()
        {
            try
            {
                var compras = await _compraService.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<CompraResponse>>(compras));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> CancelarCompra(Guid id)
        {
            try
            {
                await _compraService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
