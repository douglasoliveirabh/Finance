using Finance.Scrappers.Tasks.Scrappers;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Finance.Scrappers.Tests.Unit
{
    public class EmpresaScrapTest
    {
        [Fact()]
        public async Task ShouldTestIfThereAreManyThanOneCompanie()
        {
            var empresasScrapper = new EmpresaScrapper();
            var empresas = await empresasScrapper.ExecuteScrapAsync();
            empresas.Should().HaveCountGreaterThan(0);
        }
    }
}
