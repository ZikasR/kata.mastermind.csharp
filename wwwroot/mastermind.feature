Feature: Mastermind 

As a Codebreaker  
I want to guess the pattern 
So that I break the shield.

Scenario Outline: Get Result case   
  Given The pattern is  <pattern>
  When My guess equals <guess>
  Then the result equals <result>
  And the shield is <boken> broken
Examples:
| case|             pattern          | guess                        | result                     | broken|
|  1  |[White, Green, Yellow, Yellow]|[White, Green, Yellow, Yellow]|[Black, Black, Black, Black]|       |
|  2  |[White, Green, Yellow, Yellow]|[Black, Red, Blue, Black]     |[Empty, Empty, Empty, Empty]|not    |
|  3  |[White, Green, Yellow, Yellow]|[Green, Green, White, Yellow] |[Empty, Black, White, Black]|not    |
|  4  |[White, Green, Yellow, Yellow]|[Blue, Green, Yellow, Green]  |[Empty, Black, Black, Empty]|not    |
|  5  |[White, Green, Yellow, Yellow]|[Blue, Green, Yellow, Green]  |[Empty, Black, Black, Empty]|not    |
|  6  |[White, Green, Yellow, Yellow]|[Yellow, Green, Yellow, White]  |[White, Black, Black, White]|not    |
|  7  |[Red, Blue, Red, Red]         |[Blue, Black, Red, Blue]  |[White, Empty, Black, White]|not    |