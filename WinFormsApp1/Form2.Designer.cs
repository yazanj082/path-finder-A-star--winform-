
using System;
using System.Drawing;
using System.IO;
using WinFormsApp1.shared;

namespace WinFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent(int width, int height)
        {
            
            this.label1 = new System.Windows.Forms.Label();
            this.buttonL = new MyButton();
            this.buttonU = new MyButton();
            this.buttonR = new MyButton();
            this.buttonD = new MyButton();
            this.buttonE = new MyButton();
            this.buttonB = new MyButton();
            this.build = new MyButton();
            this.button = new MyButton[width,height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.button[i,j] = new MyButton();
                    this.button[i, j].x = i;
                    this.button[i, j].y = j;
                }
            }
            this.SuspendLayout();
            const int MAXWIDTH= 600;
            const int MAXHEIGHT = 600;
            int butonx = MAXWIDTH / width;
            int buttony = MAXHEIGHT / height;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j <height ; j++)
                {
                    this.button[i,j].Location = new System.Drawing.Point(i*butonx,j*buttony);
                    this.button[i,j].Name = "button";
                    this.button[i,j].Size = new System.Drawing.Size(butonx, buttony);
                    this.button[i,j].TabIndex = 0;
                    this.button[i,j].Text = "";
                    this.button[i,j].UseVisualStyleBackColor = true;
                    this.button[i,j].Click += new System.EventHandler(this.button1_Click);
                    
                    this.Controls.Add(this.button[i,j]);
                }
            }


            this.buttonL.type = 1;
            this.buttonL.Location = new System.Drawing.Point(MAXWIDTH, 25);
            this.buttonL.Name = "left";
            this.buttonL.Size = new System.Drawing.Size(50 , 50);
            this.buttonL.TabIndex = 0;
            this.buttonL.Text = "";
            this.buttonL.UseVisualStyleBackColor = true;
            this.buttonL.Click += new System.EventHandler(this.buttonType_Click);
            this.buttonL.BackgroundImage = Image.FromFile( @"../assets/left.png");
            this.buttonL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;


            this.buttonR.type = 3;
            this.buttonR.Location = new System.Drawing.Point(MAXWIDTH, 75);
            this.buttonR.Name = "right";
            this.buttonR.Size = new System.Drawing.Size(50, 50);
            this.buttonR.TabIndex = 0;
            this.buttonR.Text = "";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.Click += new System.EventHandler(this.buttonType_Click);
            this.buttonR.BackgroundImage = Image.FromFile(@"../assets/right.png");
            this.buttonR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            this.buttonU.type = 2;
            this.buttonU.Location = new System.Drawing.Point(MAXWIDTH, 125);
            this.buttonU.Name = "up";
            this.buttonU.Size = new System.Drawing.Size(50, 50);
            this.buttonU.TabIndex = 0;
            this.buttonU.Text = "";
            this.buttonU.UseVisualStyleBackColor = true;
            this.buttonU.Click += new System.EventHandler(this.buttonType_Click);
            this.buttonU.BackgroundImage = Image.FromFile(@"../assets/up.png");
            this.buttonU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;



            this.buttonD.type = 4;
            this.buttonD.Location = new System.Drawing.Point(MAXWIDTH, 175);
            this.buttonD.Name = "down";
            this.buttonD.Size = new System.Drawing.Size(50, 50);
            this.buttonD.TabIndex = 0;
            this.buttonD.Text = "";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.buttonType_Click);
            this.buttonD.BackgroundImage = Image.FromFile(@"../assets/down.png");
            this.buttonD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            this.buttonB.type = -1;
            this.buttonB.Location = new System.Drawing.Point(MAXWIDTH, 225);
            this.buttonB.Name = "block";
            this.buttonB.Size = new System.Drawing.Size(50, 50);
            this.buttonB.TabIndex = 0;
            this.buttonB.Text = "";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.buttonType_Click);
            this.buttonB.BackColor = Color.Black;


            this.buttonE.type = 5;
            this.buttonE.Location = new System.Drawing.Point(MAXWIDTH, 275);
            this.buttonE.Name = "exit";
            this.buttonE.Size = new System.Drawing.Size(50, 50);
            this.buttonE.TabIndex = 0;
            this.buttonE.Text = "Exit";
            this.buttonE.UseVisualStyleBackColor = true;
            this.buttonE.Click += new System.EventHandler(this.buttonType_Click);
            this.buttonE.BackColor = Color.Red;

           
            this.build.Location = new System.Drawing.Point(MAXWIDTH, 325);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(50, 50);
            this.build.TabIndex = 0;
            this.build.Text = "Build";
            this.build.UseVisualStyleBackColor = true;
            this.build.Click += new System.EventHandler(this.build_Click);
          


            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(MAXWIDTH, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "";

            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonL);
            this.Controls.Add(this.buttonR);
            this.Controls.Add(this.buttonU);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.buttonE);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.build);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Text = "Form2";

        }

        #endregion
        
        private MyButton buttonL;
        private MyButton buttonU;
        private MyButton buttonR;
        private MyButton buttonD;
        private MyButton buttonE;
        private MyButton buttonB;
        private MyButton build;
        private MyButton[,] button;
        private System.Windows.Forms.Label label1;
    }

}