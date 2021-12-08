using TbcArenas.Shared.Models;

namespace TbcArenas.Shared.Services.Arena;

public interface IArenaService
{
    IEnumerable<ArenaRecord> MapCsvRecords(IEnumerable<ArenaCsvRecord> arenaCsvRecords);
}
