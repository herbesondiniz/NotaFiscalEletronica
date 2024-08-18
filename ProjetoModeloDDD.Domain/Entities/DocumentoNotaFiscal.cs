using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class DocumentoNotaFiscal
    {
        public int DocumentoNotaFiscalId { get; set; }
        public string Ambiente { get; set; }
        public string TipoDocumento { get; set; }
    }
}
