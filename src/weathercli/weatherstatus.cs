using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathercli
{
    internal class weatherstatus
    {
        public static void getvisu(string weather) // displays current weather with some ascii art
        {
            switch (weather)
            {
                case "Mostly Cloudy":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(@"      
        .-~~~-.
.- ~ ~-(       )_ 
/                 ~ -.
|                      \
\                       .
  ~- . _____________.-~)
                                ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Partly Cloudy":
                    
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(@"      


                _
              (`  ).                   _
             (     ).              .:(`  )`.
)           _(       '`.          :(   .    )
        .=(`(      .   )     .--  `.  (    ) )
       ((    (..__.:'-'   .+(   )   ` _`  ) )
`.     `(       ) )       (   .  )     (   ) 
  )      ` __.:'   )     (   (   ))     `-'
)  )  ( )       --'       `- __.'        
.-'  (_.'          .')                    
                  (_  )                     

                                ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Mostly Sunny":
                    
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(@"      
      ;   :   ;
   .   \_,!,_/   ,
    `.,'     `.,'
     /         \
~ -- :         : -- ~
     \         /
    ,'`._   _.'`.
   '   / `!` \   `
      ;   :   ;                                 ");
                        Console.ForegroundColor = ConsoleColor.White;

                        break;

                case "Mostly Clear":

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(@"      
    
        *    *          *   
                *               *

                            * 



                                                ");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"  

Error 324
no ascii 
                                ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                    
            }
        }
    }
}
