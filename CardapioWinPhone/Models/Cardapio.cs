using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioWinPhone.Models
{
    class Cardapio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Restaurante_id { get; set; }
    }
}
