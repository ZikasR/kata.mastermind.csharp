using System;
using System.Collections.Generic;
using Mastermind.Models;
using Xunit;

namespace Mastermind.BP
{
    public class GameTest : IDisposable
    {
        List<Codepeg> pattern;
        public GameTest()
        {
            pattern = new List<Codepeg>();

            pattern.Add(new Codepeg{
                Location = 0,
                Color = "White"
            });
            
            pattern.Add(new Codepeg{
                Location = 1,
                Color = "Green"
            });
            
            pattern.Add(new Codepeg{
                Location = 2,
                Color = "Yellow"
            });
            
            pattern.Add(new Codepeg{
                Location = 3,
                Color = "Yellow"
            });
        }

        public void Dispose()
        {
            //codepegs.Dispose();
        }
    
        [Fact]
        public void GetRandomCodepegColor_should_return_random_color(){
            
            GameProcessor gameProcessor = new GameProcessor();
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                GameProcessor.CodepegColors randomCodepegColor = gameProcessor.GetRandomCodepegColor(random);
                //Console.WriteLine(randomCodepegColor.ToString());
            }
        }
        
        [Fact]
        public void getFeedback_should_return_black_keys_when_guess_and_pattern_matches()
        {
            GameProcessor gameProcessor = new GameProcessor();
            
            List<Codepeg> codepegs = new List<Codepeg>();
            
            codepegs.Add(new Codepeg{
                Location = 0,
                Color = "White"
            });
            
            codepegs.Add(new Codepeg{
                Location = 1,
                Color = "Green"
            });
            
            codepegs.Add(new Codepeg{
                Location = 2,
                Color = "Yellow"
            });
            
            codepegs.Add(new Codepeg{
                Location = 3,
                Color = "Yellow"
            });
                        
            var result  = gameProcessor.getFeedback(codepegs, pattern);
            
            List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            
            Assert.Equal(result, keyPegs);
        }
        
        [Fact]
        public void getFeedback_should_return_empty_when_codepeg_does_not_exist_in_pattern()
        {
            GameProcessor gameProcessor = new GameProcessor();
            
            List<Codepeg> codepegs = new List<Codepeg>(4);

            codepegs.Add(new Codepeg{
                Location = 0,
                Color = "Black"
            });   

            List<GameProcessor.KeyPeg> result  = gameProcessor.getFeedback(codepegs, pattern);
            
            List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            
            Assert.Equal(result, keyPegs);
        }
        
        [Fact]
        public void getFeedback_should_return_empty_when_all_codepeg_does_not_exist_in_pattern()
        {
            GameProcessor gameProcessor = new GameProcessor();
            
            List<Codepeg> codepegs = new List<Codepeg>(4);

            codepegs.Add(new Codepeg{
                Location = 0,
                Color = "Black"
            });
            
            codepegs.Add(new Codepeg{
                Location = 1,
                Color = "Red"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 2,
                Color = "Blue"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 3,
                Color = "Black"
            });    

            List<GameProcessor.KeyPeg> result  = gameProcessor.getFeedback(codepegs, pattern);
            
            List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            
            Assert.Equal(result, keyPegs);
        }
        
        [Fact]
        public void getFeedback_should_return_white_when_codepeg_does_exist_in_pattern_but_not_in_the_same_position()
        {
            GameProcessor gameProcessor = new GameProcessor();
            
            List<Codepeg> codepegs = new List<Codepeg>(4);

            codepegs.Add(new Codepeg{
                Location = 0,
                Color = "Green"
            });   

            List<GameProcessor.KeyPeg> result  = gameProcessor.getFeedback(codepegs, pattern);
            
            List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.White);
            
            Assert.Equal(result, keyPegs);
        }
        
        [Fact]
        public void getFeedback_should_return_expected_result()
        {
            GameProcessor gameProcessor = new GameProcessor();
            
            List<Codepeg> codepegs = new List<Codepeg>(4);

            codepegs.Add(new Codepeg{
                Location = 0,
                Color = "Green"
            });
            
            codepegs.Add(new Codepeg{
                Location = 1,
                Color = "Green"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 2,
                Color = "White"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 3,
                Color = "Yellow"
            });   

            List<GameProcessor.KeyPeg> result  = gameProcessor.getFeedback(codepegs, pattern);
            
            List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.White);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            
            Assert.Equal(result, keyPegs);
        }
        
        
        [Fact]
        public void getFeedback_should_return_expected_result_1()
        {
            GameProcessor gameProcessor = new GameProcessor();
            
            List<Codepeg> codepegs = new List<Codepeg>(4);

            codepegs.Add(new Codepeg{
                Location = 0,
                Color = "Blue"
            });
            
            codepegs.Add(new Codepeg{
                Location = 1,
                Color = "Green"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 2,
                Color = "Yellow"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 3,
                Color = "Green"
            });   

            List<GameProcessor.KeyPeg> result  = gameProcessor.getFeedback(codepegs, pattern);
            
            List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            
            Assert.Equal(result, keyPegs);
        }
        
        [Fact]
               public void getFeedback_should_return_expected_result_2()
        {
            GameProcessor gameProcessor = new GameProcessor();
            
            List<Codepeg> codepegs = new List<Codepeg>(4);

            codepegs.Add(new Codepeg{
                Location = 0,
                Color = "Yellow"
            });
            
            codepegs.Add(new Codepeg{
                Location = 1,
                Color = "Green"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 2,
                Color = "Yellow"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 3,
                Color = "White"
            });   

            List<GameProcessor.KeyPeg> result  = gameProcessor.getFeedback(codepegs, pattern);
            
            List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.White);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.White);
            
            Assert.Equal(result, keyPegs);
        }
        
        [Fact]
        public void getFeedback_should_return_expected_result_3()
        {
            GameProcessor gameProcessor = new GameProcessor();
            
            pattern[0].Color = "Red";
            pattern[1].Color = "Blue";
            pattern[2].Color = "Red";
            pattern[3].Color = "Red";
            
            List<Codepeg> codepegs = new List<Codepeg>(4);

            codepegs.Add(new Codepeg{
                Location = 0,
                Color = "Blue"
            });
            
            codepegs.Add(new Codepeg{
                Location = 1,
                Color = "Black"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 2,
                Color = "Red"
            }); 
            
            codepegs.Add(new Codepeg{
                Location = 3,
                Color = "Blue"
            });   

            List<GameProcessor.KeyPeg> result  = gameProcessor.getFeedback(codepegs, pattern);
            
            List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.White);
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.White);
            
            Assert.Equal(result, keyPegs);
        }
        
        [Fact]
        public void IsShieldBroken_should_return_false_if_at_least_one_keypeg_is_white()
        {
           List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.White);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.White);
            
            GameProcessor gameProcessor = new GameProcessor();

            Assert.False(gameProcessor.IsShieldBroken(keyPegs));            
        }
        
        [Fact]
        public void IsShieldBroken_should_return_false_if_at_least_one_keypeg_is_empty()
        {
           List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.Empty);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            
            GameProcessor gameProcessor = new GameProcessor();

            Assert.False(gameProcessor.IsShieldBroken(keyPegs));            
        }
        
        [Fact]
        public void IsShieldBroken_should_return_true_if_all_keypegs_are_black()
        {
           List<GameProcessor.KeyPeg> keyPegs = new List<GameProcessor.KeyPeg>();
            
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            keyPegs.Add(GameProcessor.KeyPeg.Black);
            
            GameProcessor gameProcessor = new GameProcessor();

            Assert.True(gameProcessor.IsShieldBroken(keyPegs));            
        }
    }
}