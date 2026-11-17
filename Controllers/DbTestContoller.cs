using Microsoft.AspNetCore.Mvc;
using metermngemen.Data;

namespace metermngemen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DbTestController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DbTestController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> TestConnection()
    {
        bool ok = await _context.Database.CanConnectAsync();

        if (ok)
            return Ok("Database connected successfully");

        return StatusCode(500, "Database connection failed");
    }
}