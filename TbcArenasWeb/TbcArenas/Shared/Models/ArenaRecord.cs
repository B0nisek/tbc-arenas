using AutoMapper;

namespace TbcArenas.Shared.Models;

public enum Zone 
{
    RuinsOfLordaeron = 3968,
    Nagrand = 3698,
    BladesEdgeMountains = 3702
}

public class ArenaRecord
{
    public bool IsRanked { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Zone Zone { get; set; }
    public DateTime Duration { get; set; }
    public TeamRecord Team { get; set; }
    public TeamRecord EnemyTeam { get; set; }
    public int OldTeamRating { get; set; }
    public int NewTeamRating { get; set; }
    public int DiffRating { get; set; }
    public int Mmr { get; set; }
    public int EnemyOldTeamRating { get; set; }
    public int EnemyNewTeamRating { get; set; }
    public int EnemyDiffRating { get; set; }
    public int EnemyMmr { get; set; }
}

public class ArenaRecordProfile : Profile
{
    public ArenaRecordProfile() => this.CreateMap<ArenaCsvRecord, ArenaRecord>();
}