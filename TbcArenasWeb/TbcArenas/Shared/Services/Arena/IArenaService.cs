using TbcArenas.Shared.Models;

namespace TbcArenas.Shared.Services.Arena;

public interface IArenaService
{
    IEnumerable<ArenaRecord> Some(IEnumerable<ArenaCsvRecord> arenaCsvRecords);
}
