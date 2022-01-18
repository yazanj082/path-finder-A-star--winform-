using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinFormsApp1.shared
{
    class MyButton : System.Windows.Forms.Button
    { public static int exitCount=0;
        public int x, y;
        public int type=0; //0:road 1:left 2:up 3:right 4:down 5:Exit -1:block
         
        public void copy(MyButton b)
        {   
            this.BackColor = b.BackColor;
            if (this.type == 5)
            {
                exitCount -= 1;
            }
            this.type = b.type;
            this.BackgroundImage = b.BackgroundImage;
            this.BackgroundImageLayout = b.BackgroundImageLayout;
            this.Text = b.Text;
            if (this.type == 5)
            {
                exitCount++;
            }
            
        }
    }
}
