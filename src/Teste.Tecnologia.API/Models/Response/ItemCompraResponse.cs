﻿namespace Teste.Tecnologia.API.Models.Response
{
    public class ItemCompraResponse
    {
        public Guid Id { get; set; }
        public string CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
