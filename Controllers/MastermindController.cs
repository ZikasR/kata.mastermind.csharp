using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.BP;
using Mastermind.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Mastermind.Controllers
{
    [Route("api/[controller]")]
    public class MastermindController : Controller
    {
        
        private GameContext _context;
        
        public MastermindController(GameContext context){
            _context = context;
        }
        
        [HttpGet("newGame/{player}")]
        public Guid Get(string player)
        {
            if(String.IsNullOrEmpty(player)){
                throw new ArgumentException("Veuillez spécifier votre pseudo");
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
        
       [HttpPost("Result/")]
        public string[] GetResult(Guid token, List<string> guess)
        {

            if(token == null || token == Guid.Empty){
                throw new ArgumentException("Veuillez spécifier votre token");
            }
            
            if(guess == null || guess.Count == 0){
                throw new ArgumentException("Veuillez spécifier votre proposition");
            }
            
            List<Codepeg> codepegs = new List<Codepeg>();
            for (int i = 0; i < guess.Count; i++)
            {
                codepegs.Add(new Codepeg{
                    Location = i,
                    Color = guess[i]
                });
            }
           
            Game game = _context.Games.Include(g => g.Shield).Where(g=> g.Token == token).FirstOrDefault();                      
            GameProcessor gameProcessor = new GameProcessor();            
            List<GameProcessor.KeyPeg> result =  gameProcessor.getFeedback(codepegs, game.Shield);
                                  
            
            if(gameProcessor.IsShieldBroken(result))
            {
                game.End = DateTime.Now;
                _context.Games.Update(game);
                _context.SaveChanges();
            }else {
                game.trialsNumber++;
                _context.Games.Update(game);
                _context.SaveChanges();
            }
            
            string[] myNewList = new string[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                myNewList[i] = result[i].ToString();
            }
            
            return myNewList;
        }
        
        [HttpGet("ListColors/")]
        public string[] GetColors(string player)
        {
            return Enum.GetNames(typeof(GameProcessor.CodepegColors));
        }
        
        [HttpGet("Scors")]
        public List<Score> GetScors()
        {
            List<string> players = _context.Games.Select(p => p.PlayerName).Distinct().ToList();
            List<Score> scores = new List<Score>();
            GameProcessor gameProcessor = new GameProcessor();
            
            foreach (var player in players)
            {
                scores.Add(gameProcessor.GetScore(_context, player));
            }
            
            return scores.OrderByDescending(s=>s.trialsNumberAverage).ToList();
        }
    }
}