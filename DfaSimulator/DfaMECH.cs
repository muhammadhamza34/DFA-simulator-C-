using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DfaSimulator
{
    public partial class DfaMECH : Form
    {
        Dfa dfa = new Dfa();
        System.Drawing.Graphics graphicsObj;
        int currentState;
        
        public DfaMECH(Dfa d)
        {
            InitializeComponent();
            dfa = d;
        }

        private void DfaCizim_Load(object sender, EventArgs e)
        {
            currentState = dfa.startState;
            label4.Text = dfa.input;
            
        }

        public void ciz()
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            label3.Text = "";

            inputIndex = 0;
            currentState = dfa.startState;
            
            Font myFont = new System.Drawing.Font("Helvetica", 28, FontStyle.Regular);
            Font myFont2 = new System.Drawing.Font("Helvetica", 18, FontStyle.Regular);

            Brush myBrush = new SolidBrush(System.Drawing.Color.DarkSlateGray);
            Brush myBrush2 = new SolidBrush(System.Drawing.Color.DarkGreen);
            Brush myBrush3 = new SolidBrush(System.Drawing.Color.Goldenrod);

            Pen myPen = new Pen(System.Drawing.Color.Black, 1);
            Pen myPen2 = new Pen(System.Drawing.Color.Black, 3);

            Font myFontX = new System.Drawing.Font("Helvetica", 18, FontStyle.Regular);
            Brush myBrushX = new SolidBrush(System.Drawing.Color.GreenYellow);
            Pen myPenX = new Pen(System.Drawing.Color.GreenYellow, 3);

            graphicsObj = this.CreateGraphics();
            
            

             List<Point> cordinates = new List<Point>();

            int dikey;
            int yatay=20;
            for (int i = 0; i < dfa.numberOfStates(); i++)
            {
                if (i == 0)
                {
                    dikey = 150;
                    
                }
                else if ((i % 2) == 0)
                {
                    dikey = 250;
                    
                }
                else 
                {
                    dikey = 50;
                    yatay += 150;
                }
                
                if (dfa.acceptedStates.Contains(i))
                {
                    Rectangle myRectangle2 = new Rectangle(yatay-5, dikey-5, 60, 60);
                    graphicsObj.DrawEllipse(myPen2, myRectangle2);
                }

                if (dfa.startState == i)
                {
                    graphicsObj.DrawString("start", myFont2, myBrush2, yatay-5, dikey-25);
                }
                
                Rectangle myRectangle = new Rectangle(yatay, dikey, 50, 50);
                graphicsObj.DrawEllipse(myPen2, myRectangle);
                graphicsObj.DrawString("q" + i, myFont, myBrush3, yatay, dikey);
                
                Point p = new Point(yatay+26, dikey+26);
                cordinates.Add(p);
            }
            ArrowRenderer arrow = new ArrowRenderer();
            for (int i = 0; i < dfa.numberOfStates(); i++)
            {
                for (int j = 0; j < dfa.possibleInputs.Count; j++)
                {
                    arrow.Width = 20;
                    Point pp1 = cordinates[i];
                    Point pp2 = cordinates[dfa.InputDataControl(i, dfa.possibleInputs[j])];
                    
                    
                    if (pp1.X == pp2.X && pp1.Y==pp2.Y)
                    {
                        if (i == 0)
                        {
                            int y = pp1.Y;
                            int x = pp1.X + 25;
                            Point pp3 = new Point(x, y);

                            int y2 = pp1.Y;
                            int x2 = pp1.X - 25;
                            Point pp4 = new Point(x2, y2);

                            int y3 = pp1.Y - 80;
                            int x3 = pp1.X + 40;
                            Point pp5 = new Point(x3, y3);

                            int y4 = pp1.Y - 80;
                            int x4 = pp1.X - 40;
                            Point pp6 = new Point(x4, y4);


                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp5.X - 40, pp5.Y);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp3, pp4, pp5, pp6);
                        }
                        else if ((i % 2) == 0)
                        {
                            int y = pp1.Y;
                            int x = pp1.X + 25;
                            Point pp3 = new Point(x, y);

                            int y2 = pp1.Y;
                            int x2 = pp1.X - 25;
                            Point pp4 = new Point(x2, y2);

                            int y3 = pp1.Y + 80;
                            int x3 = pp1.X + 40;
                            Point pp5 = new Point(x3, y3);

                            int y4 = pp1.Y + 80;
                            int x4 = pp1.X - 40;
                            Point pp6 = new Point(x4, y4);


                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp5.X-43, pp5.Y-20);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp3, pp4, pp5, pp6);
                        }
                        else
                        {
                            int y = pp1.Y;
                            int x = pp1.X + 25;
                            Point pp3 = new Point(x, y);

                            int y2 = pp1.Y;
                            int x2 = pp1.X - 25;
                            Point pp4 = new Point(x2, y2);

                            int y3 = pp1.Y - 80;
                            int x3 = pp1.X + 40;
                            Point pp5 = new Point(x3, y3);

                            int y4 = pp1.Y - 80;
                            int x4 = pp1.X - 40;
                            Point pp6 = new Point(x4, y4);


                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp5.X - 40, pp5.Y);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp3, pp4, pp5, pp6);
                        }
                        
                    }
                    else if (pp1.X == pp2.X)
                    {
                        if (pp1.Y > pp2.Y)
                        {
                            int y = pp1.Y - (Math.Abs(pp1.Y - pp2.Y) / 2);
                            int x = pp2.X + 30;
                            Point pp3 = new Point(x, y);
                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp3.X - 15, pp3.Y - 15);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.Y < pp2.Y)
                        {
                            int y = pp2.Y - (Math.Abs(pp2.Y - pp1.Y) / 2);
                            int x = pp2.X - 30;
                            Point pp3 = new Point(x, y);
                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp3.X - 15, pp3.Y - 15);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                        }
                    }
                    else if (pp1.Y == pp2.Y)//Aynı dikey çizgide bulunanlar
                    {
                        if (pp1.X > pp2.X)
                        {
                            int x = pp1.X - (Math.Abs(pp1.X - pp2.X) / 2);
                            int y = pp2.Y - 30;
                            Point pp3 = new Point(x, y);
                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp3.X - 15, pp3.Y - 15);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.X < pp2.X)
                        {
                            int x = pp2.X - (Math.Abs(pp2.X - pp1.X) / 2);
                            int y = pp2.Y + 30;
                            Point pp3 = new Point(x, y);
                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp3.X - 15, pp3.Y - 15);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                        }
                    }
                    else
                    {
                        if (pp1.X < pp2.X && pp1.Y > pp2.Y)
                        {
                            int x = pp2.X-30;
                            int y = pp1.Y-30;
                            Point pp3 = new Point(x, y);
                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp3.X - 15, pp3.Y - 15);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.X > pp2.X && pp1.Y < pp2.Y)
                        {
                            int x = pp2.X+30;
                            int y = pp1.Y+30;
                            Point pp3 = new Point(x, y);
                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp3.X - 15, pp3.Y - 15);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.X < pp2.X && pp1.Y < pp2.Y)
                        {
                            int x = pp1.X + 30;
                            int y = pp2.Y - 30;
                            Point pp3 = new Point(x, y);
                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp3.X - 15, pp3.Y - 15);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.X > pp2.X && pp1.Y > pp2.Y)
                        {
                            int x = pp1.X - 30;
                            int y = pp2.Y + 30;
                            Point pp3 = new Point(x, y);
                            graphicsObj.DrawString(dfa.possibleInputs[j], myFont2, myBrush2, pp3.X - 15, pp3.Y - 15);
                            arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                        }


                        //arrow.DrawArrow(graphicsObj, myPen, myBrush, pp1, pp2);
                    }

                    //arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, pp1, pp2, pp3, pp3);
                    
                    //Point p11=new Point((p1.X+p2.X)/4, (p1.Y+p2.Y)/4);
                    //arrow.DrawArrowOnCurve(graphicsObj, myPen, myBrush, p1, p2,p11,p11);
                }
            }
            
            /////////////////////////////////////////////////////////
            
            yatay = 20;
            for (int i = 0; i < dfa.numberOfStates(); i++)
            {
                if (i == 0)
                {
                    dikey = 150;

                }
                else if ((i % 2) == 0)
                {
                    dikey = 250;

                }
                else                 {
                    dikey = 50;
                    yatay += 150;
                }

                if (dfa.acceptedStates.Contains(i))
                {
                    Rectangle myRectangle2 = new Rectangle(yatay - 5, dikey - 5, 60, 60);
                    graphicsObj.DrawEllipse(myPen2, myRectangle2);
                }
                if (i != dfa.startState)
                {
                    Rectangle myRectangle = new Rectangle(yatay, dikey, 50, 50);
                    graphicsObj.DrawEllipse(myPen2, myRectangle);
                }
                else
                {
                    Rectangle myRectangle = new Rectangle(yatay, dikey, 50, 50);
                    graphicsObj.DrawEllipse(myPenX, myRectangle);
                }
                graphicsObj.DrawString("q" + i, myFont, myBrush3, yatay, dikey);
                //Point p = new Point(yatay + 26, dikey + 26);
                //cordinates.Add(p);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        int inputIndex = 0;

        public void play()
        {
            String input = "";
            if (inputIndex < dfa.input.Length)
            {
                input = dfa.input[inputIndex].ToString();
                inputIndex++;
                label3.Text += input;
            }
            else
            {
                if (dfa.acceptedStates.Contains(currentState))
                {
                    MessageBox.Show("Last state is accepted state");
                }
                else
                {
                    MessageBox.Show("Last state is not accepted state");
                }
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                
            }

            Font myFontX = new System.Drawing.Font("Helvetica", 18, FontStyle.Regular);
            Brush myBrushX = new SolidBrush(System.Drawing.Color.GreenYellow);
            Pen myPenX = new Pen(System.Drawing.Color.GreenYellow, 3);

            Font myFont = new System.Drawing.Font("Helvetica", 28, FontStyle.Regular);
            Font myFont2 = new System.Drawing.Font("Helvetica", 18, FontStyle.Regular);

            Brush myBrush = new SolidBrush(System.Drawing.Color.DarkSlateGray);
            Brush myBrush2 = new SolidBrush(System.Drawing.Color.DarkGreen);
            Brush myBrush3 = new SolidBrush(System.Drawing.Color.Goldenrod);

            Pen myPen = new Pen(System.Drawing.Color.Black, 3);
            Pen myPen2 = new Pen(System.Drawing.Color.Black, 3);

            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();

            //önce bütün state'lerin rengini değişiyoruz
            int yatay = 20;
            int dikey;
            for (int i = 0; i < dfa.numberOfStates(); i++)
            {
                //State çiziyoruz şu an sadece
                if (i == 0)
                {
                    dikey = 150;

                }
                else if ((i % 2) == 0) 
                {
                    dikey = 250;

                }
                else 
                {
                    dikey = 50;
                    yatay += 150;
                }


                if (dfa.acceptedStates.Contains(i))
                {
                    Rectangle myRectangle2 = new Rectangle(yatay - 5, dikey - 5, 60, 60);
                    graphicsObj.DrawEllipse(myPen, myRectangle2);
                }
                Rectangle myRectangle = new Rectangle(yatay, dikey, 50, 50);
                graphicsObj.DrawEllipse(myPen, myRectangle);
            }



            
            yatay = 20;
            for (int i = 0; i < dfa.numberOfStates(); i++)
            {
                
                if (i == 0)
                {
                    dikey = 150;

                }
                else if ((i % 2) == 0)
                {
                    dikey = 250;

                }
                else 
                {
                    dikey = 50;
                    yatay += 150;
                }

                if (dfa.InputDataControl(currentState, input) == i)
                {
                    
                    if (dfa.acceptedStates.Contains(i))
                    {
                        Rectangle myRectangle2 = new Rectangle(yatay - 5, dikey - 5, 60, 60);
                        graphicsObj.DrawEllipse(myPenX, myRectangle2);
                    }
                    Rectangle myRectangle = new Rectangle(yatay, dikey, 50, 50);
                    graphicsObj.DrawEllipse(myPenX, myRectangle);
                    //graphicsObj.DrawString("q" + i, myFont, myBrush, yatay, dikey);
                }
            }
            currentState = dfa.InputDataControl(currentState, input);
            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            String input="";
            if (inputIndex < dfa.input.Length)
            {
                input = dfa.input[inputIndex].ToString();
                inputIndex++;
                label3.Text += input;
            }
            else
            {
                timer1.Stop();
                if (dfa.acceptedStates.Contains(currentState))
                {
                    MessageBox.Show("Last state is accepted state");
                }
                else
                {
                    MessageBox.Show("Last state is not accepted state");
                }
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                
            }

            Font myFontX = new System.Drawing.Font("Helvetica", 18, FontStyle.Regular);
            Brush myBrushX = new SolidBrush(System.Drawing.Color.GreenYellow);
            Pen myPenX = new Pen(System.Drawing.Color.GreenYellow, 3);

            Font myFont = new System.Drawing.Font("Helvetica", 28, FontStyle.Regular);
            Font myFont2 = new System.Drawing.Font("Helvetica", 18, FontStyle.Regular);

            Brush myBrush = new SolidBrush(System.Drawing.Color.DarkSlateGray);
            Brush myBrush2 = new SolidBrush(System.Drawing.Color.DarkGreen);
            Brush myBrush3 = new SolidBrush(System.Drawing.Color.Goldenrod);

            Pen myPen = new Pen(System.Drawing.Color.Black, 3);
            Pen myPen2 = new Pen(System.Drawing.Color.Black, 3);
            
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();

            
            int yatay = 20;
            int dikey;
            for (int i = 0; i < dfa.numberOfStates(); i++)
            {
                
                if (i == 0)
                {
                    dikey = 150;

                }
                else if ((i % 2) == 0)
                {
                    dikey = 250;

                }
                else 
                {
                    dikey = 50;
                    yatay += 150;
                }

               
                if (dfa.acceptedStates.Contains(i))
                {
                    Rectangle myRectangle2 = new Rectangle(yatay - 5, dikey - 5, 60, 60);
                    graphicsObj.DrawEllipse(myPen, myRectangle2);
                }
                Rectangle myRectangle = new Rectangle(yatay, dikey, 50, 50);
                graphicsObj.DrawEllipse(myPen, myRectangle);
            }



            
            yatay = 20;
            for (int i = 0; i < dfa.numberOfStates(); i++)
            {
                if (i == 0)
                {
                    dikey = 150;

                }
                else if ((i % 2) == 0)
                {
                    dikey = 250;

                }
                else 
                {
                    dikey = 50;
                    yatay += 150;
                }

                if (dfa.InputDataControl(currentState,input)==i)
                {
                    
                    if (dfa.acceptedStates.Contains(i))
                    {
                        Rectangle myRectangle2 = new Rectangle(yatay - 5, dikey - 5, 60, 60);
                        graphicsObj.DrawEllipse(myPenX, myRectangle2);
                    }
                    Rectangle myRectangle = new Rectangle(yatay, dikey, 50, 50);
                    graphicsObj.DrawEllipse(myPenX, myRectangle);
                    //graphicsObj.DrawString("q" + i, myFont, myBrush, yatay, dikey);
                }
            }
            currentState = dfa.InputDataControl(currentState, input);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            play();
        }
    }
}
