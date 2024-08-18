using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class DocumentoNotaFiscalService: ServiceBase<DocumentoNotaFiscal>, IDocumentoNotaFiscalService
    {
        private readonly IDocumentoNotaFiscalRepository _documentoNotaFiscalRepository;
        public DocumentoNotaFiscalService(IDocumentoNotaFiscalRepository documentoNotaFiscalRepository) :
            base(documentoNotaFiscalRepository)
        {
            _documentoNotaFiscalRepository = documentoNotaFiscalRepository;
        }
    }
}
