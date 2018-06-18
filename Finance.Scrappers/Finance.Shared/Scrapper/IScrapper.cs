using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Shared.Scrapper
{
    public interface IScrapper<T> 
    {
        Task<T> ExecuteScrapAsync();
    }
}
