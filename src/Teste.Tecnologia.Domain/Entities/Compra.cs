﻿using System.ComponentModel.DataAnnotations.Schema;
using Teste.Tecnologia.Domain.Services.Notification;

namespace Teste.Tecnologia.Domain.Entities
{   
    public class Compra : EntityBase
    {
        protected Compra() : base() { }

        public Compra(string numeroVenda, DateOnly dataVenda, string clienteId, string codigoLoja) : base()
        {
            NumeroVenda = numeroVenda;
            DataVenda = dataVenda;
            ClienteId = clienteId;
            CodigoLoja = codigoLoja;
            Cancelada = false;
            Itens = [];
        }

        public string NumeroVenda { get; private set; }
        public DateOnly DataVenda { get; private set; }
        public string ClienteId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorTotalDesconto { get; private set; }
        public string CodigoLoja { get; private set; }
        public bool Cancelada { get; private set; }
        public DateOnly? CanceladaEm { get; private set; }
        public virtual ICollection<ItemCompra> Itens { get; private set; }

        public bool Validar()
        {
            if (!Itens.Any())
                NotificationWrapper.Add("compra", "Não foi adicionado nenhum ítem na compra");

            Itens.ToList().ForEach(x => x.Validar());

            return NotificationWrapper.IsValid;
        }

        public void AplicarDesconto()
        {
            Itens.ToList().ForEach(x => x.AplicarDesconto());
            ValorTotalDesconto = Itens.Sum(x => x.ValorDesconto);
            CalcularValorTotal();
        }

        private void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(x => x.ValorTotal);
        }

        public void CancelarCompra()
        {
            Cancelada = true;
            CanceladaEm = DateOnly.FromDateTime(DateTime.Now);
        }

        public void AlterarItens(IEnumerable<ItemCompra> itens)
        {
            if(itens == null || !itens.Any())
            {
                NotificationWrapper.Add("itens", "Não foi encontrado nenhum item para ser alterado");
                return;
            }

            Itens = itens.ToList();
            AplicarDesconto();
        }
    }
}
