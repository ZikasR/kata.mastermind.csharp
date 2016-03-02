using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;

namespace Mastermind.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        
    } 
    
    public class Game
    {
        public int GameId { get; set; }
        
        public Guid Token {get; set;}
        
        public List<Codepeg> Shield {get; set;}
        
        public string PlayerName {get; set;}
        
        public DateTime Start {get; set;}
        
        public DateTime End {get; set;}
        
        public int trialsNumber {get; set;}
    }
    
    public class Codepeg 
    {
        public int CodepegId { get; set; }
        
        public int Location {get; set;}
        
        public string Color {get; set;}
    }
    
    public class Score
    {
        public string player { get; set; }
        
        public double trialsNumberAverage { get; set; }
        
        public int finishedGames { get; set; }
    }
};