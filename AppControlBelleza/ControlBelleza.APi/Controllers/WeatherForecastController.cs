using Microsoft.AspNetCore.Mvc;

namespace ControlBelleza.APi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly DataContext _context;
    public CitasController(DataContext context)
    {
        _context = context;
    }



}
