﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using weathercli;

namespace weathercli
{ 
    class navmenu
    {
        

        public static void submenu()
        {
            bool selected = false;
            int position = 0;

            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.CursorTop = Console.CursorTop + 4;
            Console.WriteLine("");
            selector(0);

            ConsoleKeyInfo keyp;
            
            do
            { 
                keyp = Console.ReadKey(true);
                
                switch(keyp.Key)
                {
                    case ConsoleKey.UpArrow:
                    

                        if(position == 0)
                        {
                            
                        }

                        else
                        {
                            selector(position);
                            position--;
                            selector(position);
                        }
                    break;
                    case ConsoleKey.DownArrow:
                    
                    
                        if (position == 4)
                        {
                            selector(position);
                            position = 3;
                            selector(position);
                        }
                        else
                        {
                            selector(position);
                            position++;
                            selector(position);
                        }
                    break;
                    case ConsoleKey.Enter:
                    
                        Debug.WriteLine("Enter pressed");
                        selected = true;
                        options(position);
                    break;

                    default:
                    
                        break;
                    
                }

            }while (!selected);

        }


            
     

        public static void selector(int position)
        {
            if (position == 0)
            {
                clearline.clearcurrentline(6);
                Console.WriteLine(" ");
                Console.Write("[x]");
                Console.WriteLine(" change location");
                Console.Write("[ ]");
                Console.WriteLine(" weatherforecast");
                Console.Write("[ ]");
                Console.WriteLine(" set alert");
                Console.Write("[ ]");
                Console.WriteLine(" options");
            }
            if (position == 1)
            {
                clearline.clearcurrentline(6);
                Console.WriteLine(" ");
                Console.Write("[ ]");
                Console.WriteLine(" change location");
                Console.Write("[x]");
                Console.WriteLine(" weatherforecast");
                Console.Write("[ ]");
                Console.WriteLine(" set alert");
                Console.Write("[ ]");
                Console.WriteLine(" options");
            }
            if (position == 2)
            {
                clearline.clearcurrentline(6);
                Console.WriteLine(" ");
                Console.Write("[ ]");
                Console.WriteLine(" change location");
                Console.Write("[ ]");
                Console.WriteLine(" weatherforecast");
                Console.Write("[x]");
                Console.WriteLine(" set alert");
                Console.Write("[ ]");
                Console.WriteLine(" options");
            }
            if (position == 3)
            {
                clearline.clearcurrentline(6);
                Console.WriteLine(" ");
                Console.Write("[ ]");
                Console.WriteLine(" change location");
                Console.Write("[ ]");
                Console.WriteLine(" weatherforecast");
                Console.Write("[ ]");
                Console.WriteLine(" set alert");
                Console.Write("[x]");
                Console.WriteLine(" options");
            }



        }

        public static void options(int optionnumber)
        {
            if (optionnumber == 0)
            {
                string location = "";
                bool a = false; 
                Console.Clear();
                Console.WriteLine("Change your location:"); 
                
                while (!a)
                {
                    try

                    {
                        Console.WriteLine("Enter the location you want to know the weather from: (city,countrycode)");
                        location = Console.ReadLine();
                        if (!location.Contains(",") || location.Any(c => char.IsDigit(c))) //Check if input contains a comma and doesnt contain a number
                        { throw new Exception("Locations must contain comma, and not contain any numbers"); };

                        a = true;
                        break;

                        
                    
                    }
                    catch (Exception) {
                    Console.Clear();
                    Console.WriteLine("Please use the correct format");
                    }
                }

                locationrequest n = new locationrequest();
                n.geocode(location);

                
                Console.ReadKey();
           ;

            }

            if (optionnumber == 1)
            {
                Console.Clear();
                Console.WriteLine("Forecast for set location:");

                Console.WriteLine("today:");
                
            }
        }
    }
}

