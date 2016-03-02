using System;
using Mastermind.BP;
using Mastermind.Models;
using Microsoft.AspNet.Mvc;

namespace Mastermind.Controllers
{
    [Route("api/[controller]")]
    public class MastermindController : Controller
    {
        
        private GameContext _context;
        
        public MastermindController(GameContext context){
            _context = context;
        }
        
        [HttpGet("{player}")]
        public Guid Get(string player)
        {
            if(String.IsNullOrEmpty(player)){
                throw new ArgumentException("Veuillez votre pseudo");
            }
            
            var Token = Guid.NewGuid(); 
            
            GameProcessor gameProcessor = new GameProcessor();           
            
            _context.Games.Add(new Game{
                Token = Token,
                Shield = gameProcessor.newShield(),
                PlayerName = player,                
                Start = DateTime.Now,                                                
            });
            
            _context.SaveChanges();                        

            return Token;
        }
    }
}