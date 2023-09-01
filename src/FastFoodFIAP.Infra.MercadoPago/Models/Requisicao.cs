using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodFIAP.Infra.MercadoPago.Models
{
    public class Requisicao
    {
        public string external_reference { get; set; } = "";
        public string title { get; set; } = "";
        public string notification_url { get; set; } = "";
        public decimal total_amount { get; set; }
        public string description { get; set; } = "";
        public List<Item> items { get; set; } = new List<Item>();
        public CashOut cash_out { get; set; }= new CashOut();
    }
}
