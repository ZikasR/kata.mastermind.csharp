using System;
using Xunit;

namespace Codebreaker
{

    public class ProgramTest
    {        
        Program _program;
        
        public ProgramTest(){
            _program = new Program();             
        }
        
        [Fact]
        public void createNewGame_should_return_a_token(){
                        
           Assert.Equal(_program.createNewGame().GetType(), typeof(Guid));             
        }
        
        [Fact]
        public void createNewGame_should_make_Get_call(){
            
        }
    }
}