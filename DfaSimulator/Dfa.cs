
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DfaSimulator
{
    public class Dfa
    {
        public List<int> states = new List<int>();
        public int startState;
        public List<int> acceptedStates = new List<int>();
        public List<String> possibleInputs = new List<String>();
        public List<InputData> inputData = new List<InputData>();
        public String input;
        int currentState;
        public String output;

        public void dfaMethod()
        {
            states.Clear();
            acceptedStates.Clear();
            possibleInputs.Clear();
            inputData.Clear();
            output = "";
        }

        public int numberOfStates()
        {
            return states.Count;
        }

        public bool isDfa()
        {
            for (int i = 0; i <= states.Count - 1; i++)
            {
                for (int k = 0; k <= input.Length - 1; k++)
                {
                    if (InputDataControl(i, input[k].ToString())==-1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int InputDataControl(int cur, String inp)
        {
            int sonuc = -1;
            for (int i = 0; i <= inputData.Count - 1; i++)
            {
                if (inputData[i].getNextState(cur, inp)!=-1)
                {
                    sonuc= inputData[i].getNextState(cur, inp);
                }
            }
            return sonuc;
        }


        public String print(int q1, int q2, String inp)
        {
            return "\nGoes from q" + q1 + " to q" + q2 + " when input is " + inp;
        }

        public bool run()
        {
            currentState = startState;
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (InputDataControl(currentState, input[i].ToString()) != -1)
                {
                    output += print(currentState, InputDataControl(currentState, input[i].ToString()), input[i].ToString());
                    currentState = InputDataControl(currentState, input[i].ToString());       
                }
            }

            if (acceptedStates.Contains(currentState))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
