using AutoMapper;
using TbcArenas.Shared.Models;

namespace TbcArenas.Shared.Services.Arena;

public class ArenaService : IArenaService
{
    private readonly IMapper mapper;

    public ArenaService(IMapper mapper) => this.mapper = mapper;

    public IEnumerable<ArenaRecord> MapCsvRecords(IEnumerable<ArenaCsvRecord> arenaCsvRecords)
    {
        var mappedArenaRecords = new List<ArenaRecord>();
        var orderedFilteredArenaCsvRecords = arenaCsvRecords
            .Where(x => x.Duration != 0)
            .OrderBy(x => long.Parse(x.EndTime));

        foreach (var arenaCsvRecord in orderedFilteredArenaCsvRecords)
        {
            var mappedArenaRecord = this.mapper.Map<ArenaRecord>(arenaCsvRecord);

            mappedArenaRecord.Team = new TeamRecord
            {
                Name = arenaCsvRecord.TeamName,
                Mmr = arenaCsvRecord.Mmr,
                Rating = arenaCsvRecord.NewTeamRating
            };

            mappedArenaRecords.Add(mappedArenaRecord);
        }

        return mappedArenaRecords;
    }
}
