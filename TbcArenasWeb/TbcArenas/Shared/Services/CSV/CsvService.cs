using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using TbcArenas.Shared.Models;

namespace TbcArenas.Shared.Services.CSV;

public class CsvService : ICsvService
{
    public IEnumerable<ArenaCsvRecord> ParseCsv(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            MissingFieldFound = null
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);

        var records = csv.GetRecords<ArenaCsvRecord>().ToList();

        return records;
    }
}
