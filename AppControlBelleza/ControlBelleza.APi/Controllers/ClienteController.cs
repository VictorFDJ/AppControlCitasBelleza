using ControlBelleza.ControlBelleza.Persitence;
using Microsoft.AspNetCore.Mvc;

namespace ControlBelleza.APi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly DataContext _context;
    public ClienteController(DataContext context)
    {
        _context = context;
    }



}
