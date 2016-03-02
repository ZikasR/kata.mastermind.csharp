using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Models;

namespace Mastermind.BP
{
    public class GameProcessor{
        
        public List<Codepeg> newShield()
        {
            List<Codepeg> shield = new List<Codepeg>();
            Random random = new Random();
                         
            for (int i = 0; i < 4; i++)
            {                
                CodepegColors randomCodepegColor = GetRandomCodepegColor(random);
                
                shield.Add(new Codepeg{
                    Location = i,
                    Color = randomCodepegColor.ToString()              
                });               
            }
            
            return shield;                    
        }
        
        public CodepegColors GetRandomCodepegColor(Random random){
            Array values = Enum.GetValues(typeof(CodepegColors));          
            return (CodepegColors)values.GetValue(random.Next(0, values.Length-1));
        }
        
        public List<KeyPeg> getFeedback(List<Codepeg> codepegs, List<Codepeg> pattern)
        {
           List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
                                 
            for (int i = 0; i < codepegs.Count; i++)
            {
                // Same location same color
                if (codepegs[i].Location == pattern[i].Location && codepegs[i].Color == pattern[i].Color)
                {
                    pattern[i].Color = CodepegColors.Empty.ToString();
                    keyPegs.Add(GameProcessor.KeyPeg.Black);
                    continue;
                }
                                               
                // Same color not same location
                var exists = pattern.Any(p => p.Color == codepegs[i].Color); 
                if(exists){
                    var location = pattern.Where(p => p.Color == codepegs[i].Color).FirstOrDefault().Location;
                    pattern[location].Color = CodepegColors.Empty.ToString();
                    keyPegs.Add(GameProcessor.KeyPeg.White);
                    continue;
                }
                
                keyPegs.Add(GameProcessor.KeyPeg.Empty);
            }
            
            return keyPegs;
        }
        
        public bool IsShieldBroken(List<KeyPeg> keyPegs){
            return !(keyPegs.Any(k => k == KeyPeg.White || k == KeyPeg.Empty) && keyPegs.Count > 0);                       
        }
        
        public enum CodepegColors 
        {
            Red,
            Green,
            Yellow,
            Blue,
            White,
            Black,
            Empty
        }

        public enum KeyPeg
        {
            White,            
            Black,
            Empty
        }
    }
}