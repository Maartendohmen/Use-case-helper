﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Use_Case_Helper
{
    public partial class Form1 : Form
    {
        int aantalman = 0;
        int selectedactors = 0;
        Graphics g;
        Nameactor name = new Nameactor();
        Use_Case_input usecaseinput = new Use_Case_input();
        Pen p = new Pen(Color.Black, 2);
        Color background = Color.FromKnownColor(KnownColor.Control);

        public Form1()
        {
            InitializeComponent();
        }

        private void pnteken_Click(object sender, EventArgs e)
        {
            if (rbtnactor.Checked && rbtncreate.Checked)
            {
                Point mouseposition = pnteken.PointToClient(Cursor.Position);

                if (mouseposition.X < 140)
                {
                    // MessageBox.Show("X = " + a.X.ToString() + " " + "Y = " + a.Y.ToString());

                    switch (aantalman)
                    {
                        case 0:
                            name.ShowDialog();
                            label1.Visible = true;
                            label1.Text = name.tbname.Text;

                            g = pnteken.CreateGraphics();

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
                            aantalman++;
                            break;

                        case 1:
                            name.ShowDialog();
                            label2.Visible = true;
                            label2.Text = name.tbname.Text;

                            g = pnteken.CreateGraphics();

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
                            aantalman++;
                            break;

                        case 2:
                            name.ShowDialog();
                            label3.Visible = true;
                            label3.Text = name.tbname.Text;

                            g = pnteken.CreateGraphics();

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
                            aantalman++;
                            break;

                        case 3:
                            MessageBox.Show("You have reached the maximum number of actors");
                            break;
                    }


                }
            }

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
            }

            if(rbtnselect.Checked)
            {
                Point mouseposition = pnteken.PointToClient(Cursor.Position);
                Rectangle mousepositionrect = new Rectangle(mouseposition.X, mouseposition.Y, 1, 1);
                Rectangle mannetje1 = new Rectangle(10, 0, 100, 93);
                Rectangle mannetje2 = new Rectangle(10, 100, 100, 93);
                Rectangle mannetje3 = new Rectangle(10, 200, 100, 93);
                Rectangle mannetje1select = Rectangle.Intersect(mannetje1, mousepositionrect);
                Rectangle mannetje2select = Rectangle.Intersect(mannetje2, mousepositionrect);
                Rectangle mannetje3select = Rectangle.Intersect(mannetje3, mousepositionrect);

                if (selectedactors == 1)
                {
                    MessageBox.Show("Select one actor at a time");
                }

                else if (mannetje1select.X != 0 && mannetje2select.X == 0 && mannetje3select.X == 0)
                {
                    g.DrawRectangle(p, mannetje1);
                    selectedactors++;
                }

               else if (mannetje1select.X == 0 && mannetje2select.X != 0 && mannetje3select.X == 0)
                {
                    g.DrawRectangle(p, mannetje2);
                    selectedactors++;
                }

               else if (mannetje1select.X == 0 && mannetje2select.X == 0 && mannetje3select.X != 0)
                {
                    g.DrawRectangle(p, mannetje3);
                    selectedactors++;
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
    }
 }

