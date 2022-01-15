using Microsoft.AspNetCore.Mvc;
using TbcArenas.Shared.Models;
using TbcArenas.Shared.Services.Arena;
using TbcArenas.Shared.Services.CSV;

namespace TbcArenas.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ArenaController : ControllerBase
{
    private readonly ICsvService csvService;
    private readonly IArenaService arenaService;

    public ArenaController(ICsvService csvService, IArenaService arenaService)
    {
        this.csvService = csvService;
        this.arenaService = arenaService;
    }

    [HttpGet]
    public IEnumerable<ArenaRecord> Get()
    {
        var csv = this.csvService.ParseCsvEmbeddedResource("test_data.csv");
        var result = this.arenaService.MapCsvRecords(csv);

        return result.ToList();
    }
}
