using AutoMapper;
using TbcArenas.Shared.Models;

namespace TbcArenas.Shared.Services.Arena;

public class ArenaService : IArenaService
{
    private readonly IMapper mapper;

    public ArenaService(IMapper mapper) => this.mapper = mapper;

    public IEnumerable<ArenaRecord> Some(IEnumerable<ArenaCsvRecord> arenaCsvRecords)
    {
        var mappedArenaRecords = new List<ArenaRecord>();

        foreach (var arenaCsvRecord in arenaCsvRecords)
        {
            var mappedArenaRecord = this.mapper.Map<ArenaRecord>(arenaCsvRecord);



            mappedArenaRecords.Add(mappedArenaRecord);
        }

        return mappedArenaRecords;
    }
}
