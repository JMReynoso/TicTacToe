using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TicTacToe1.Parser
{
    class ValidateInputForPosition
    {
        private LinkedList<char> Line;
        private int iterator;
        public ValidateInputForPosition(string input)
        {
            Line = new LinkedList<char>();
            iterator = 0;

            foreach (char c in input)
            {
                Line.AddLast(c);
            }
        }

        public bool verifyInput()
        {
            
            if (Char.IsNumber(Line.ElementAt(iterator)))
            {
                number();
                comma();
                numberLast();

                return true;
            }

            return false;
        }

        public void number()
        {
            if (iterator >= Line.Count)
            {
                return;
            }


            if (Char.IsNumber(Line.ElementAt(iterator)))
            {
                iterator++;
                number();
                return;
            }

            else if (Line.ElementAt(iterator).Equals(','))
            {
                return;
            }

            else Error();
        }

        public void numberLast()
        {
            if (iterator >= Line.Count)
            {
                if (!Char.IsNumber(Line.ElementAt(iterator-1)))
                {
                    ErrorNoLastNumber();
                }
                return;
            }

            if (Char.IsNumber(Line.ElementAt(iterator)))
            {
                iterator++;
                numberLast();
                return;
            }

            else Error();
        }

        public void comma()
        {
            if (iterator >= Line.Count)
            {
                ErrorNoComma();
            }

            if (Line.ElementAt(iterator).Equals(','))
            {
                iterator++;
                return;
            }

            else Error();
        }

        public void Error()
        {
            Console.WriteLine("Error at input index {0}", iterator);
            Environment.Exit(2);
        }

        public void ErrorNoComma()
        {
            Console.WriteLine("Error at input index {0}: No Comma", iterator);
            Environment.Exit(2);
        }

        public void ErrorNoLastNumber()
        {
            Console.WriteLine("Error at input index {0}: String does not end in a number", iterator);
            Environment.Exit(2);
        }
    }
}
