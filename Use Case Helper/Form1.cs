﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Use_Case_Helper
{
    public partial class Form1 : Form
    {
        int aantalman = 0;
        int selectedactors = 0;
        int selectedcases = 0;
        public int wichcase = 0;
        int fillcounter = 0;
        string naamactor = "";
        string nw = "";
        Graphics g;
        Nameactor name = new Nameactor();
        Use_Case_input usecaseinput = new Use_Case_input();
        Pen p = new Pen(Color.Black, 2);
        Pen z = new Pen(Color.FromKnownColor(KnownColor.Control));
        Color background = Color.FromKnownColor(KnownColor.Control);
        Rectangle usecaseselect = new Rectangle();
        List<Rectangle> usecases = new List<Rectangle>();

        Rectangle match;
        Rectangle mannetje1select;
        Rectangle mannetje2select;
        Rectangle mannetje3select;
        Rectangle mannetje1;
        Rectangle mannetje2;
        Rectangle mannetje3;

        public Form1()
        {
            InitializeComponent();
        }

        private void pnteken_Click(object sender, EventArgs e)
        {


            
            //maak mannetje


            if (rbtnactor.Checked && rbtncreate.Checked)
            {
                Point mouseposition = pnteken.PointToClient(Cursor.Position);

                if (mouseposition.X < 140)
                {
                    switch (aantalman)
                    {
                        case 0:
                            name.ShowDialog();
                            label1.Visible = true;
                            label1.Text = name.tbname.Text;

                            g = pnteken.CreateGraphics();

                            mannetje1tekenen();

                            aantalman++;
                            break;

                        case 1:
                            name.ShowDialog();
                            label2.Visible = true;
                            label2.Text = name.tbname.Text;

                            g = pnteken.CreateGraphics();

                            mannetje2tekenen();
                           
                            aantalman++;
                            break;

                        case 2:
                            name.ShowDialog();
                            label3.Visible = true;
                            label3.Text = name.tbname.Text;

                            g = pnteken.CreateGraphics();

                            mannetje3tekenen();

                            aantalman++;
                            break;

                        case 3:
                            MessageBox.Show("You have reached the maximum number of actors");
                            break;
                    }


                }
            }























            //maak case





            if (rbtnusecases.Checked && rbtncreate.Checked)
            {
                Point a = pnteken.PointToClient(Cursor.Position);

                usecaseinput.ShowDialog();

                g = pnteken.CreateGraphics();

                string name = usecaseinput.tbname.Text;
                Font font = new Font("Arial", 12);
                Brush r = new SolidBrush(Color.Black);

                g.DrawString(name, font, r, a.X - 2, a.Y - 3);
                SizeF lengte = g.MeasureString(name, font);
                g.DrawEllipse(p, a.X - 7, a.Y - 7, lengte.Width + 17, lengte.Height + 17);
                int width = Convert.ToInt32(lengte.Width + 17);
                int height = Convert.ToInt32(lengte.Height + 17);
                Rectangle nieuwe = new Rectangle(a.X - 7, a.Y - 7, width, height);
                usecases.Add(nieuwe);

            }

















            //select mannetje







            if (rbtnselect.Checked && rbtnactor.Checked)
            {
                Point mouseposition = pnteken.PointToClient(Cursor.Position);
                Rectangle mousepositionrect = new Rectangle(mouseposition.X, mouseposition.Y, 1, 1);
                mannetje1 = new Rectangle(10, 0, 100, 93);
                mannetje2 = new Rectangle(10, 100, 100, 93);
                mannetje3 = new Rectangle(10, 200, 100, 93);
                mannetje1select = Rectangle.Intersect(mannetje1, mousepositionrect);
                mannetje2select = Rectangle.Intersect(mannetje2, mousepositionrect);
                mannetje3select = Rectangle.Intersect(mannetje3, mousepositionrect);

                if (selectedactors == 1)
                {
                    MessageBox.Show("Select one actor at a time");
                }
                else if (aantalman == 0)
                {
                    MessageBox.Show("Please create a actor first");
                }

                else if (mannetje1select.X != 0 && mannetje2select.X == 0 && mannetje3select.X == 0)
                {
                    g.DrawRectangle(p, mannetje1);
                    selectedactors++;
                }

                else if (mannetje1select.X == 0 && mannetje2select.X != 0 && mannetje3select.X == 0 && aantalman >1)
                {
                    g.DrawRectangle(p, mannetje2);
                    selectedactors++;
                }

                else if (mannetje1select.X == 0 && mannetje2select.X == 0 && mannetje3select.X != 0 && aantalman > 2)
                {
                    g.DrawRectangle(p, mannetje3);
                    selectedactors++;
                }
                else
                {
                    MessageBox.Show("Create the corresponding actor first");
                }

            }







            //select cases

            if (selectedcases == 1)
            {
                MessageBox.Show("Please select one case at a time");
            }

            if (rbtnselect.Checked && rbtnusecases.Checked)
            {
                Point mouseposition = pnteken.PointToClient(Cursor.Position);

                Rectangle mousepositionrect = new Rectangle(mouseposition.X, mouseposition.Y, 5, 5);
                foreach (Rectangle cases in usecases)
                {
                    wichcase++;
                    match = Rectangle.Intersect(mousepositionrect, cases);
                    if (match.X != 0 && selectedcases < 1)
                    {
                        usecaseselect = cases;
                        selectedcases++;
                        break;
                    }

                }

                //draw line

                if (match.X != 0 && mannetje1select.X != 0)
                {
                    g.DrawLine(p, mannetje1select.X + 75, mannetje1select.Y, match.X - 75, match.Y);

                    Brush filler = new SolidBrush(background);
                    g.FillRectangle(filler, mannetje1.X-1 , mannetje1.Y-1 , mannetje1.Width+5,mannetje1.Height+5);

                    //teken mannetje opnieuw
                    mannetje1tekenen();

                    selectedactors = 0;
                    selectedcases = 0;
                    match.X = 0;
                    mannetje1select.X = 0;
                    naamactor = label1.Text;

                    wichcase = 0;

                }
                else if (match.X != 0 && mannetje2select.X != 0)
                {
                    g.DrawLine(p, mannetje2select.X + 75, mannetje2select.Y, match.X - 75, match.Y);

                    naamactor = label2.Text;


                    Brush filler = new SolidBrush(background);
                    g.FillRectangle(filler, mannetje2.X - 1, mannetje2.Y - 1, mannetje2.Width + 5, mannetje2.Height + 5);

                    mannetje2tekenen();

                    match.X = 0;
                    mannetje2select.X = 0;
                    selectedactors = 0;
                    selectedcases = 0;
                    wichcase = 0;

                }
                else if (match.X != 0 && mannetje3select.X != 0)
                {
                    g.DrawLine(p, mannetje3select.X + 75, mannetje3select.Y, match.X - 75, match.Y);

                    naamactor = label3.Text;

                    Brush filler = new SolidBrush(background);
                    g.FillRectangle(filler, mannetje3.X - 1, mannetje3.Y - 1, mannetje3.Width + 5, mannetje3.Height + 5);

                    mannetje3tekenen();

                    match.X = 0;
                    mannetje3select.X = 0;
                    selectedactors = 0;
                    selectedcases = 0;
                    wichcase = 0;
                }


                else
                {
                   
                    string element = "*" + wichcase.ToString() + "*";
                    string result = "";

                    for (int i = 0; i < usecaseinput.input.Count; i++)
                    {
                        if (usecaseinput.input[i].Contains(element))
                        { 
                            result = usecaseinput.input[i];

                                if (fillcounter == 0)
                                {
                                    nw = result.Replace("*" + wichcase.ToString() + "*", "");
                                    usecaseinput.tbname.Text = nw;
                                }
                                if (fillcounter == 1)
                                {
                                    nw = result.Replace("*" + wichcase.ToString() + "*", "");
                                    usecaseinput.tbsummary.Text = nw;
                                }
                            //    if (fillcounter == 2)
                            //    {
                            //          usecaseinput.tbactoren.Text = naamactor;
                            //          usecaseinput.input.Add("*" + wichcase + "*" + naamactor);         
                            //     }
                                if (fillcounter == 3)
                                {
                                    nw = result.Replace("*" + wichcase.ToString() + "*", "");
                                    usecaseinput.tbassumption.Text = nw;
                                }
                                if (fillcounter == 4)
                                {
                                    nw = result.Replace("*" + wichcase.ToString() + "*", "");
                                    usecaseinput.tbdescription.Text = nw;
                                }
                                if (fillcounter == 5)
                                {
                                    nw = result.Replace("*" + wichcase.ToString() + "*", "");
                                    usecaseinput.tbexceptions.Text = nw;
                                }
                                if (fillcounter == 6)
                                {
                                    nw = result.Replace("*" + wichcase.ToString() + "*", "");
                                    usecaseinput.tbresult.Text = nw;
                                }
                                fillcounter++;
                                
                        }
                    }
                    usecaseinput.ShowDialog();
                    fillcounter = 0;
                    selectedcases = 0;
                    wichcase = 0;

                }
            }
        }










        private void btnclear_Click(object sender, EventArgs e)
        {
            g.Clear(background);
            aantalman = 0;
            selectedactors = 0;
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }


//verwijder actor


        private void btnremove_Click(object sender, EventArgs e)
        {
            Brush filler = new SolidBrush(background);

            if (rbtnactor.Checked && rbtnselect.Checked)
            {

                if (mannetje1select.X != 0 && mannetje2select.X == 0 && mannetje3select.X == 0)
                {
                    g.FillRectangle(filler, 9, 0, 102, 95);
                    aantalman--;
                    selectedactors = 0;
                    label1.Text = "";
                    label1.Visible = false;
                }

                else if (mannetje1select.X == 0 && mannetje2select.X != 0 && mannetje3select.X == 0)
                {
                    g.FillRectangle(filler, 9, 99, 102, 95);
                    aantalman--;
                    selectedactors = 0;
                    label2.Text = "";
                    label2.Visible = false;
                }

                else if (mannetje1select.X == 0 && mannetje2select.X == 0 && mannetje3select.X != 0)
                {
                    g.FillRectangle(filler, 9, 199, 102, 95);
                    aantalman--;
                    selectedactors = 0;
                    label3.Text = "";
                    label3.Visible = false;
                }
            }

            //verwijdercasus

            if (rbtnusecases.Checked && rbtnselect.Checked)
            {
                g.FillRectangle(filler, usecaseselect.X -1,usecaseselect.Y-1,usecaseselect.Width+3,usecaseselect.Height+2);
                selectedcases--;
            }
       }

       


        public void mannetje1tekenen()
        {
            Point linkervoetb = new Point(20, 80);
            Point linkervoete = new Point(60, 60);
            Point rechtervoetb = new Point(100, 80);
            Point rechtervoete = new Point(60, 60);
            Point rugb = new Point(60, 60);
            Point ruge = new Point(60, 20);
            Point armb = new Point(20, 40);
            Point arme = new Point(100, 40);

            g.DrawLine(p, linkervoetb, linkervoete);
            g.DrawLine(p, rechtervoetb, rechtervoete);
            g.DrawLine(p, rugb, ruge);
            g.DrawLine(p, armb, arme);
            g.DrawEllipse(p, 50, 0, 20, 20);
        }

    public void mannetje2tekenen()
        {
            Point linkervoetb1 = new Point(20, 180);
            Point linkervoete1 = new Point(60, 160);
            Point rechtervoetb1 = new Point(100, 180);
            Point rechtervoete1 = new Point(60, 160);
            Point rugb1 = new Point(60, 160);
            Point ruge1 = new Point(60, 120);
            Point armb1 = new Point(20, 140);
            Point arme1 = new Point(100, 140);

            g.DrawLine(p, linkervoetb1, linkervoete1);
            g.DrawLine(p, rechtervoetb1, rechtervoete1);
            g.DrawLine(p, rugb1, ruge1);
            g.DrawLine(p, armb1, arme1);
            g.DrawEllipse(p, 50, 100, 20, 20);
        }

        public void mannetje3tekenen()
        {
            Point linkervoetb2 = new Point(20, 280);
            Point linkervoete2 = new Point(60, 260);
            Point rechtervoetb2 = new Point(100, 280);
            Point rechtervoete2 = new Point(60, 260);
            Point rugb2 = new Point(60, 260);
            Point ruge2 = new Point(60, 220);
            Point armb2 = new Point(20, 240);
            Point arme2 = new Point(100, 240);

            g.DrawLine(p, linkervoetb2, linkervoete2);
            g.DrawLine(p, rechtervoetb2, rechtervoete2);
            g.DrawLine(p, rugb2, ruge2);
            g.DrawLine(p, armb2, arme2);
            g.DrawEllipse(p, 50, 200, 20, 20);
        }
       
    }
}


