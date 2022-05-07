using AutoMapper;
using TbcArenas.Shared.Models;

namespace TbcArenas.Shared.Services.Arena;

public class ArenaService : IArenaService
{
    private const int maxPlayers = 5;
    private readonly IMapper mapper;

    public ArenaService(IMapper mapper) => this.mapper = mapper;

    public IEnumerable<ArenaRecord> MapCsvRecords(IEnumerable<ArenaCsvRecord> arenaCsvRecords)
    {
        var mappedArenaRecords = new List<ArenaRecord>();
        var orderedFilteredArenaCsvRecords = arenaCsvRecords
            .Where(x => x.Duration is not 0)
            .OrderBy(x => long.Parse(x.EndTime));

        foreach (var arenaCsvRecord in orderedFilteredArenaCsvRecords)
        {
            var mappedArenaRecord = this.mapper.Map<ArenaRecord>(arenaCsvRecord);

            MapTeams(arenaCsvRecord, mappedArenaRecord);

            mappedArenaRecords.Add(mappedArenaRecord);
        }

        return mappedArenaRecords;
    }

    private static void MapTeams(ArenaCsvRecord arenaCsvRecord, ArenaRecord mappedArenaRecord)
    {
        mappedArenaRecord.Team = new TeamRecord
        {
            Name = arenaCsvRecord.TeamName,
            Mmr = arenaCsvRecord.Mmr,
            Rating = arenaCsvRecord.NewTeamRating,
            Players = GetPlayers(arenaCsvRecord)
        };

        mappedArenaRecord.EnemyTeam = new TeamRecord
        {
            Name = arenaCsvRecord.EnemyTeamName,
            Mmr = arenaCsvRecord.EnemyMmr,
            Rating = arenaCsvRecord.EnemyNewTeamRating,
            Players = GetPlayers(arenaCsvRecord, isEnemy: true)
        };
    }

    private static HashSet<PlayerRecord> GetPlayers(ArenaCsvRecord arenaCsvRecord, bool isEnemy = false)
    {
        var players = new HashSet<PlayerRecord>();

        var nameProp = isEnemy ? "EnemyPlayerName" : "TeamPlayerName";
        var classProp = isEnemy ? "EnemyPlayerClass" : "TeamPlayerClass";
        var raceProp = isEnemy ? "EnemyPlayerRace" : "TeamPlayerRace";

        for (var i = 1; i <= maxPlayers; i++)
        {
            var nameValue = arenaCsvRecord.GetType().GetProperty($"{nameProp}{i}").GetValue(arenaCsvRecord, null)?.ToString();
            var classValue = arenaCsvRecord.GetType().GetProperty($"{classProp}{i}").GetValue(arenaCsvRecord, null)?.ToString();
            var raceValue = arenaCsvRecord.GetType().GetProperty($"{raceProp}{i}").GetValue(arenaCsvRecord, null)?.ToString();

            var player = CreatePlayer(nameValue, classValue, raceValue);

            if (player is null)
            {
                continue;
            }

            _ = players.Add(player);
        }

        return players;
    }

    private static PlayerRecord CreatePlayer(string name, string @class, string race)
    {
        return string.IsNullOrEmpty(name) || string.IsNullOrEmpty(@class) || string.IsNullOrEmpty(race)
            ? null
            : new PlayerRecord
            {
                Name = name,
                Class = @class.ToClass(),
                Race = race.ToRace()
            };
    }
}
