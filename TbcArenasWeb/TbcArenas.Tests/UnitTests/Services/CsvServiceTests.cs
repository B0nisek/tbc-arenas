using TbcArenas.Shared.Services.CSV;
using Xunit;

namespace TbcArenas.Tests.UnitTests.Services;

public class CsvServiceTests
{
    private readonly ICsvService csvService;
    private const string csvFileName = "c:\\Users\\boni\\Downloads\\2s_2.csv";

    public CsvServiceTests() => this.csvService = new CsvService();

    [Fact]
    public void CsvService_ShouldParseCsvCorrectly()
    {
        var result = this.csvService.ParseCsv(csvFileName);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}
