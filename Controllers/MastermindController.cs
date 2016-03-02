using System;
using Microsoft.AspNet.Mvc;

namespace Mastermind.Controllers
{
    [Route("api/[controller]")]
    public class MastermindController : Controller
    {
        [HttpGet("{player}")]
        public Guid Get(string player)
        {
            var Token = Guid.NewGuid();
            return Token;
        }
    }
}