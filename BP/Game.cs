using System;
using System.Collections.Generic;
using Mastermind.Models;

namespace Mastermind.BP
{
    public class GameProcessor{
        
        public List<Codepeg> newShield()
        {
            List<Codepeg> shield = new List<Codepeg>();
                         
            for (int i = 0; i < 4; i++)
            {
                
                Array values = Enum.GetValues(typeof(CodepegColors));
                Random random = new Random();
                CodepegColors randomCodepegColor = (CodepegColors)values.GetValue(random.Next(values.Length));
                
                shield.Add(new Codepeg{
                    Location = i,
                    Color = randomCodepegColor.ToString()              
                });                
            }
            
            return shield;                    
        }
        
        private enum CodepegColors 
        {
            Red,
            Green,
            Yellow,
            Blue,
            White,
            Black
        }
    }
}