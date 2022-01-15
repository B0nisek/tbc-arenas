using TbcArenas.Shared.Models;

namespace TbcArenas.Shared.Services.CSV;

public interface ICsvService
{
    IEnumerable<ArenaCsvRecord> ParseCsv(string filePath);
    IEnumerable<ArenaCsvRecord> ParseCsvEmbeddedResource(string resourceName);
}
