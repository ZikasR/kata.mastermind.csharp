using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Models;
using Newtonsoft.Json;

namespace Mastermind.BP
{
    public class GameProcessor{
        
        public List<Codepeg> newShield()
        {
            List<Codepeg> shield = new List<Codepeg>();
            Random random = new Random();
                         
            for (int i = 0; i < 8; i++)
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

            for(int i = 0; i < pattern.Count; i++){
               keyPegs.Add(GameProcessor.KeyPeg.Empty);
            }
            
            // deep copy oO
            var deserializeSettings = new JsonSerializerSettings {ObjectCreationHandling = ObjectCreationHandling.Replace};
            List<Codepeg> patternTmp = JsonConvert.DeserializeObject<List<Codepeg>>(JsonConvert.SerializeObject(pattern), deserializeSettings);
                                            
            for (int i = 0; i < codepegs.Count; i++)
            {
                // Same location same color
                if (codepegs[i].Location == patternTmp[i].Location && codepegs[i].Color == patternTmp[i].Color)
                {
                    patternTmp[i].Color = CodepegColors.Empty.ToString();
                    keyPegs[i] =  GameProcessor.KeyPeg.Black;
                }
         
            }           
            
            for(int i = 0; i < codepegs.Count; i++){
                // Same color not same location
                var exists = patternTmp.Any(p => p.Color == codepegs[i].Color); 
                if(exists &&  keyPegs[i] != GameProcessor.KeyPeg.Black){
                    keyPegs[i] =  GameProcessor.KeyPeg.White;
                }
            }
            

            
            return keyPegs;
        }
        
        public bool IsShieldBroken(List<KeyPeg> keyPegs){
            return !(keyPegs.Any(k => k == KeyPeg.White || k == KeyPeg.Empty) && keyPegs.Count > 0);                       
        }
        
        public Score GetScore(GameContext context, string player)
        {
            List<Game> PlayerGamesList = context.Games.Where(g => g.PlayerName == player && !g.End.Equals(DateTime.MinValue)).ToList();           

            return new Score {
                player = player,
                trialsNumberAverage = PlayerGamesList.Count > 0 ? PlayerGamesList.Average(p => p.trialsNumber) : 0,
                finishedGames = PlayerGamesList.Count
            };                


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