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
    public TimeSpan Duration { get; set; }
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
    public ArenaRecordProfile() => this.CreateMap<ArenaCsvRecord, ArenaRecord>()
        .ForMember(dest => dest.IsRanked, opt => opt.MapFrom(src => src.IsRanked == "YES"))
        .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => DateTime.UnixEpoch.AddSeconds(double.Parse(src.StartTime))))
        .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => DateTime.UnixEpoch.AddSeconds(double.Parse(src.EndTime))))
        .ForMember(dest => dest.Zone, opt => opt.MapFrom(src => (Zone)src.ZoneId))
        .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.Duration)));
}