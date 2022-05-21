using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DfaSimulator
{
    public class InputData
    {
        int from;
        String input;
        int to;

        public InputData(int from, String input, int to)
        {
            this.from = from;

            this.input = input;

            this.to = to;
        }

        public int getNextState(int current, String inp)
        {
            if (current == from && inp == input)
            {
                return to;
            }
            else
            {
                return -1;
            }
        }
    }
}
