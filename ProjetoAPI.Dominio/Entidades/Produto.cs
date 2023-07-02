using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Dominio.Entidades
{
    public class Produto
    {
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
    }
}
