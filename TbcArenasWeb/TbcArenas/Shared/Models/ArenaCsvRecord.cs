using CsvHelper.Configuration.Attributes;

namespace TbcArenas.Shared.Models;

public class ArenaCsvRecord
{
    [Name("isRanked")]
    public string IsRanked { get; set; }

    [Name("startTime")]
    public string StartTime { get; set; }

    [Name("endTime")]
    public string EndTime { get; set; }

    [Name("zoneId")]
    public int ZoneId { get; set; }

    [Name("duration")]
    public int Duration { get; set; }

    [Name("teamName")]
    public string TeamName { get; set; }

    [Name("teamPlayerName1")]
    public string TeamPlayerName1 { get; set; }

    [Name("teamPlayerName2")]
    public string TeamPlayerName2 { get; set; }

    [Name("teamPlayerName3")]
    public string TeamPlayerName3 { get; set; }

    [Name("teamPlayerName4")]
    public string TeamPlayerName4 { get; set; }

    [Name("teamPlayerName5")]
    public string TeamPlayerName5 { get; set; }

    [Name("teamPlayerClass1")]
    public string TeamPlayerClass1 { get; set; }

    [Name("teamPlayerClass2")]
    public string TeamPlayerClass2 { get; set; }

    [Name("teamPlayerClass3")]
    public string TeamPlayerClass3 { get; set; }

    [Name("teamPlayerClass4")]
    public string TeamPlayerClass4 { get; set; }

    [Name("teamPlayerClass5")]
    public string TeamPlayerClass5 { get; set; }

    [Name("teamPlayerRace1")]
    public string TeamPlayerRace1 { get; set; }

    [Name("teamPlayerRace2")]
    public string TeamPlayerRace2 { get; set; }

    [Name("teamPlayerRace3")]
    public string TeamPlayerRace3 { get; set; }

    [Name("teamPlayerRace4")]
    public string TeamPlayerRace4 { get; set; }

    [Name("teamPlayerRace5")]
    public string TeamPlayerRace5 { get; set; }

    [Name("oldTeamRating")]
    public int OldTeamRating { get; set; }

    [Name("newTeamRating")]
    public int NewTeamRating { get; set; }

    [Name("diffRating")]
    public int DiffRating { get; set; }

    [Name("mmr")]
    public int Mmr { get; set; }

    [Name("enemyOldTeamRating")]
    public int EnemyOldTeamRating { get; set; }

    [Name("enemyNewTeamRating")]
    public int EnemyNewTeamRating { get; set; }

    [Name("enemyDiffRating")]
    public int EnemyDiffRating { get; set; }

    [Name("enemyMmr")]
    public int EnemyMmr { get; set; }

    [Name("enemyTeamName")]
    public string EnemyTeamName { get; set; }

    [Name("enemyPlayerName1")]
    public string EnemyPlayerName1 { get; set; }

    [Name("enemyPlayerName2")]
    public string EnemyPlayerName2 { get; set; }

    [Name("enemyPlayerName3")]
    public string EnemyPlayerName3 { get; set; }

    [Name("enemyPlayerName4")]
    public string EnemyPlayerName4 { get; set; }

    [Name("enemyPlayerName5")]
    public string EnemyPlayerName5 { get; set; }

    [Name("enemyPlayerClass1")]
    public string EnemyPlayerClass1 { get; set; }

    [Name("enemyPlayerClass2")]
    public string EnemyPlayerClass2 { get; set; }

    [Name("enemyPlayerClass3")]
    public string EnemyPlayerClass3 { get; set; }

    [Name("enemyPlayerClass4")]
    public string EnemyPlayerClass4 { get; set; }

    [Name("enemyPlayerClass5")]
    public string EnemyPlayerClass5 { get; set; }

    [Name("enemyPlayerRace1")]
    public string EnemyPlayerRace1 { get; set; }

    [Name("enemyPlayerRace2")]
    public string EnemyPlayerRace2 { get; set; }

    [Name("enemyPlayerRace3")]
    public string EnemyPlayerRace3 { get; set; }

    [Name("enemyPlayerRace4")]
    public string EnemyPlayerRace4 { get; set; }

    [Name("enemyPlayerRace5")]
    public string EnemyPlayerRace5 { get; set; }

    [Name("enemyFaction")]
    public string EnemyFaction { get; set; }
}
