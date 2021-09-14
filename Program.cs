using System;
using System.Collections.Generic;
using System.Linq;

namespace BracketMatch
{
    class Program
    {
        // unit test args defined in launch.json
        public static void Main(string[] args)
        {
            string[] array = new string[] { "{", "}" };
            IDictionary<string, string> dt = new Dictionary<string, string>();
            dt.Add(new KeyValuePair<string, string>("{", "}"));

            foreach(string word in args)
            {
                Console.WriteLine(word);
                bool returnValue = Match(word, array, dt);
                Console.WriteLine(returnValue);
            }
            
            static bool Match(string characters, string[] array, IDictionary<string, string> dt )
            {
                int length = characters.Length;
                string last = null;
                string hold = null;
                List<string> stack = new List<string>();
                
                for (int i = 0; i < length; i++)
                {
                    string ph = characters[i].ToString();
                    
                    if (array.Contains(ph)) // is bracket?
                    {  
                        if (ph == array[0].ToString())
                        { 
                            stack.Add(ph); // if open bracket add to stack
                        }
                        else
                        {
                            if (stack.Count == 0) // null check
                            {
                                hold = null; 
                            }
                            else
                            {
                                last = stack[stack.Count -1]; // retrieve last open bracket
                                hold = dt[last]; // dictionary lookup
                                stack.RemoveAt(stack.Count -1); // remove last open bracket
                            }

                            if (ph != hold) { return false; } else { } // match check
                        }
                    }
                    else
                    {
                        // ignore non bracket characters
                    }
                }
                if (stack.Count != 0) { return false;} // check for extra open brackets
                else { return true; }
            }
        }
    }
}