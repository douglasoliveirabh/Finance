using Finance.Scrappers.Domain.Entities;
using Finance.Shared.Scrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Scrappers.Tasks.Scrappers.Interfaces
{
    public interface IEmpresaScrapper : IScrapper<IEnumerable<Empresa>>
    {
    }
}
