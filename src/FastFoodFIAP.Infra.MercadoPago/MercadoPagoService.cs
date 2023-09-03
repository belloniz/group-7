using FastFoodFIAP.Domain.Interfaces.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using static System.Net.Mime.MediaTypeNames;
using FastFoodFIAP.Infra.MercadoPago.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FastFoodFIAP.Domain.Models.PedidoAggregate;

namespace FastFoodFIAP.Infra.MercadoPago
{
    public class MercadoPagoService : IGatewayPagamento, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string user_id = "657762990";
        private readonly string external_pos_id = "SUC001POS001";
        private readonly string accessToken = "TEST-7091834242473976-082007-3f2848b83eb8c872aebc130399396854-657762990";

        public MercadoPagoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> SolicitarQrCodeAsync(Pedido pedido)
        {
            Requisicao requisicao =  new Requisicao();

            requisicao.external_reference= pedido.Id.ToString();
            requisicao.title = "Pedido FastFood FIAP";
            requisicao.notification_url = "https://www.fastfoodfiap.com.br/api/webhook";
            requisicao.description = "Autoatendimento";
            requisicao.total_amount = 2;
            
            foreach(var combo in pedido.Combos)
                foreach(var produto in combo.Produtos)
                {
                    Item item = new Item();
                    item.sku_number = produto.ProdutoId.ToString();
                    item.category = "";
                    item.title = "";
                    item.description = "";
                    item.unit_price = produto.ValorUnitario;
                    item.quantity = produto.Quantidade * combo.Quantidade;
                    item.unit_measure = "unit";
                    item.total_amount = produto.Quantidade;

                    requisicao.items.Add(item);
                }
            
            requisicao.cash_out.amount = 0;

            QrData? qrData = await PostRequisicaoAsync(requisicao);

            return qrData is null?"" : qrData.qr_data;

        }

        public async Task<QrData?> PostRequisicaoAsync(Requisicao requisicao)
        {
            var requisicaoJson = new StringContent(
                JsonSerializer.Serialize(requisicao),
                Encoding.UTF8,
                Application.Json);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            using var httpResponseMessage =
                await _httpClient.PostAsync($"instore/orders/qr/seller/collectors/{user_id}/pos/{external_pos_id}/qrs", requisicaoJson);

            var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(resultString)
            ? new QrData()
            : JsonSerializer.Deserialize<QrData>(resultString);            
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}