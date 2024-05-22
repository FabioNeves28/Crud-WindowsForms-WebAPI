using System;
using System.Collections.Generic;

namespace WebApplication10.Models
{
    public partial class UnidadesMedida
    {
        public UnidadesMedida()
        {
            Produtos = new HashSet<Produto>();
        }

        public string Sigla { get; set; } = null!;
        public string? Descricao { get; set; }
        public bool? CasasDecimais { get; set; }
        public string? Ativa { get; set; }
        public int? CadastradoUsuario { get; set; }
        public DateTime? CadastradoData { get; set; }
        public int? AlteradoUsuario { get; set; }
        public DateTime? AlteradoData { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
