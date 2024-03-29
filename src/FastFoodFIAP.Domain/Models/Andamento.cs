﻿using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public class Andamento : Entity, IAggregateRoot
    {
        public Guid PedidoId { get; private set; }
        public DateTime DataHoraInicio { get; private set; }
        public DateTime? DataHoraFim { get; private set; }
        public Guid? FuncionarioId { get; private set; }
        public int SituacaoId { get; private set; }
        public bool Atual { get; set; }

        public virtual Pedido? PedidoNavegation { get; private set; }
        public virtual Funcionario? FuncionarioNavegation { get; private set; }
        public virtual SituacaoPedido? SitucaoPedidoNavegation { get; private set; }

        private Andamento()
        {

        }

        public Andamento(Guid id, Guid pedidoId, Guid? funcionarioId, int situacaoId, DateTime dataHoraInicio, DateTime? dataHoraFim = null, bool atual = false)
        {
            Id = id;
            PedidoId = pedidoId;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
            Atual = atual;
        }
    }
}
