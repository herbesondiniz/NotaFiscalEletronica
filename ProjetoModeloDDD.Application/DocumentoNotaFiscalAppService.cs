﻿using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class DocumentoNotaFiscalAppService : AppServiceBase<DocumentoNotaFiscal>, IDocumentoNotaFiscalAppService
    {
        private readonly IDocumentoNotaFiscalService _documentoNotaFiscalService;
        public DocumentoNotaFiscalAppService(IDocumentoNotaFiscalService documentoNFService)
            : base(documentoNFService)
        {
            _documentoNotaFiscalService = documentoNFService;
        }
    }
}
