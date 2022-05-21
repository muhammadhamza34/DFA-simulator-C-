using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace DfaSimulator
{
    public partial class Form1 : Form
    {
        public Dfa dfa = new Dfa();
        
        
        
        public Form1()
        {
            InitializeComponent();
        }

        public bool isState(String s)
        {
            if (s.Length != 2)
            {
                return false;
            }
            else if (s[0].ToString() != "q")
            {
                return false;
            }
            else
            {
                try
                {
                    int k=Convert.ToInt32(s[1].ToString());
                    if (!dfa.states.Contains(k))
                    {
                        MessageBox.Show("ATTENTION: q is not previously defined on the state system" + k + "");
                        return false;
                    }
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            dfa. dfaMethod();
            richTextBox2.Text = "";
            bool noProblem = true;
            String errorMessage="";
            richTextBox2.BackColor = Color.Aqua;
            int numberOfStates;
            numberOfStates = Convert.ToInt32(numericUpDown1.Value);
            if (numberOfStates == 0)
            {
                errorMessage += "Unable to calculate because you entered the state number 0\n";
                noProblem = false;
            }
            

            String possibleInputs = textBox1.Text;
            

            String inputData = richTextBox1.Text;
            

            String inputStirng = textBox2.Text;
            

            String startState = textBox3.Text;
            

            String acceptedStates = textBox4.Text;
            

            for (int i = 0; i <= numberOfStates - 1; i++)
            {
                dfa.states.Add(i); 
            }

            startState = startState.Replace(" ", "");
            if (startState.Length < 1)
            {
                errorMessage +="Error in the start state definition! \n" +
                "Please define in qn form. Where n should be at least 1 smaller than the state number\n";
                noProblem = false;
            }
            else if (startState[0] == 'q')
            {
                
                try
                {
                    Char c = startState[1];
                    int a = Convert.ToInt32(c.ToString());
                    if (a <= numberOfStates - 1)
                    {
                        
                        dfa.startState = a;
                    }
                    else
                    {
                        errorMessage += "Defined Start State not found between defined statues.\n";
                        noProblem = false;
                    }
                }
                catch
                {
                    errorMessage += "Incorrect entry in start index format\n";
                    noProblem = false;
                }

            }
            else
            {
                errorMessage += "There is an error in the start state definition format qn\n";
                noProblem = false;
            }


            
            acceptedStates = acceptedStates.Replace(" ", "");
            String[] acceptedtemp = acceptedStates.Split(',');
            for (int i = 0; i <= acceptedtemp.Length - 1; i++)
            {
                if (acceptedtemp[i][0] == 'q' && acceptedtemp[i].Length == 2)
                {
                    Char c = acceptedtemp[i][1];
                    try
                    {
                        int j = Convert.ToInt32(c.ToString());
                        if (j <= numberOfStates - 1)
                        {
                            dfa.acceptedStates.Add(j);
                            
                        }
                        else
                        {
                            errorMessage += "you define q" + j + " not found in defined statards.\n";
                            noProblem = false;
                        }
                    }
                    catch {
                        errorMessage += "Error in Accepted State Definition\n";
                        noProblem = false;
                    }  
                }
                else
                {
                    errorMessage +="Error detected in Accepted State Definition\n"+
                        "Separate the accepted statues you have defined with a comma and enter them in qn format\n";
                    noProblem = false;
                }
                
            }
            possibleInputs = possibleInputs.Replace(" ","");
            String[] tempPI=possibleInputs.Split(',');

            for (int i = 0; i <= tempPI.Length - 1; i++)
            {
                if (tempPI[i] != "")
                {
                    dfa.possibleInputs.Add(tempPI[i]);
                    
                }
            }

            inputData = inputData.Replace(" ", "");
            inputData = inputData.Replace("\n", "");
            String[] tempID=inputData.Split('|');

            if (inputData == "")
            {
                errorMessage += "You forgot to define which statuses will move the statuses for which inputs.";
                noProblem = false;
            }
            try
            {
                for (int i = 0; i <= tempID.Length - 1; i++)
                {
                    if (tempID[i] != "")
                    {
                        String[] tempSplit = tempID[i].Split(',');
                        if (isState(tempSplit[0]) && tempSplit[1] != "" && isState(tempSplit[2]))
                        {
                            InputData id = new InputData(Convert.ToInt32(tempSplit[0][1].ToString()), tempSplit[1], Convert.ToInt32(tempSplit[2][1].ToString()));
                            

                            dfa.inputData.Add(id);
                        }
                        else
                        {
                            errorMessage += "Problem in Dfa Definition\n";
                            noProblem = false;
                        }
                    }
                }
            }
            catch
            {
                errorMessage += "Problem in Dfa Definition\n";
                noProblem = false;
            }

           

            string input = textBox2.Text;
            input=input.Replace(" ","");
            bool flag = true;
            if (input == "")
            {
                errorMessage += "\nInput Forgot to enter\n";
                noProblem = false;
            }
            else
            {
                for (int i = 0; i <= input.Length - 1; i++)
                {
                    if (!possibleInputs.Contains(input[i]))
                    {
                        flag = false;
                    }
                }

                if (!flag)
                {
                    errorMessage +="You entered incorrect input.\n";
                    noProblem = false;
                }
                else
                {
                    dfa.input = input;
                }
            }

            if (noProblem)
            {
                if (dfa.isDfa())
                {

                    if (dfa.run())
                    {
                        richTextBox2.Text = dfa.output;
                        richTextBox2.Text += "\ninput DFA Accept by";
                        richTextBox2.BackColor = Color.GreenYellow;
                        button2.Enabled = true;
                    }
                    else
                    {
                        richTextBox2.Text = dfa.output;
                        richTextBox2.Text += "";
                        richTextBox2.Text += "\nInput DFA It was not accepted by";
                        richTextBox2.BackColor = Color.Red;
                        button2.Enabled = true;

                    }
                }
                else
                {
                    richTextBox2.Text = "Input Data The definitions you make in part do not meet the requirement of being dfa";
                    richTextBox2.BackColor = Color.Olive;
                }
            }
            else
            {
                richTextBox2.Text += "Problems are detected in your definitions.\n";
                richTextBox2.Text += errorMessage;
                richTextBox2.BackColor = Color.Orange;
            }
            
            
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            DfaMECH dc = new DfaMECH(dfa);
            dc.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //richTextBox1.Text = "q0,0,q2\n|q0,1,q1\n|q1,0,q2\n|q1,1,q0\n|q2,0,q4\n|q2,1,q1\n|q4,0,q3\n|q4,1,q2\n|q3,0,q1\n|q3,1,q3";

            string[] lines = File.ReadAllLines(@"E:\dfa-simulator\DfaSimulator\transition.txt").ToArray();
            richTextBox1.Text = string.Join("\n", lines);

            //textBox2.Text = "10100";
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Yellow;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DFA Simulator designed by \n MUHAMMADHAMZA 10040 \n AGHALAROSHKHAN 10055 \n BILALRAJPUt 9904");
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
