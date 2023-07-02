using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string? Telefone { get; private set; }
        public string? Email { get; private set; }
    }
}
