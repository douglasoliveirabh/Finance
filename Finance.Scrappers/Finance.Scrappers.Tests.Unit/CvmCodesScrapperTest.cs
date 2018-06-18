using Finance.Scrappers.Tasks.Scrappers;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Finance.Scrappers.Tests.Unit
{
    public class CvmCodesScrapperTest
    {

        [Fact()]
        public async Task ShouldTestIfThereAreManyThanOneCompanie()
        {
            var cvmCodesScrapper = new CvmCodesScrapper();
            var cvmCodes = await cvmCodesScrapper.ExecuteScrapAsync();
            cvmCodes.Should().HaveCountGreaterThan(0);
        }


    }
}
