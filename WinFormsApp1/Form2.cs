using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.shared;

namespace WinFormsApp1
{
    
    public partial class Form2 : Form
    {
        Dictionary<MyButton, List<MyButton>> open =
          new Dictionary<MyButton, List<MyButton>>();
        List<MyButton> openL = new List<MyButton>();
        Dictionary<MyButton, List<MyButton>> closed =
 new Dictionary<MyButton, List<MyButton>>();
        MyButton currentNode;
        List<MyButton> exits = new List<MyButton>();
        bool roadfound = false;
        MyButton selected ;
        int width, height;
        bool phase2 = false;
        bool issource = true;
        MyButton source;
        MyButton destination;
        public Form2(int width, int height)
        {
            this.height = height;
            this.width = width;
            InitializeComponent(width, height);
            selected = new MyButton();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!phase2)
            {
                ((MyButton)sender).copy(selected);
                if (((MyButton)sender).type == 5){
                    exits.Add(((MyButton)sender));
                }
            }
            else
            {
                if (issource)
                {
                    if (((MyButton)sender).type != -1)
                    {
                        source = ((MyButton)sender);
                        label1.Text = "select destination";
                        issource = false;
                    }
                }
                else
                {
                    if (destination == null)
                    {
                        destination = ((MyButton)sender);
                        findPath();
                    }
                }
            }
        }
        private void buttonType_Click(object sender, EventArgs e)
        {
            if (!phase2)
            {
                selected = ((MyButton)sender);
                label1.Text = selected.Name;
            }
            else
            {
                if (!issource)
                {
                    int best = int.MaxValue;
                    MyButton bestExit = null;
                    List<MyButton> bestExitR = null;
                    foreach (MyButton b in exits)
                    {
                        if (b.type != 5)
                        {
                            continue;
                        }
                        destination = b;
                        findPath();
                        if (currentNode == null)
                        {
                            reset(false);
                            continue; 
                        }
                        if (open[currentNode].Count < best && roadfound)
                        {
                            best = open[currentNode].Count;
                            bestExitR = open[currentNode];
                            bestExit = currentNode;
                        }
                        reset(false);

                    }
                    issource = false;
                    if (bestExit != null)
                    {
                        
                        open.Add(bestExit, bestExitR);
                        currentNode = bestExit;
                        printpath(bestExitR);
                    }
                    else
                    {
                        label1.Text = "no path found";
                    }

                }
            }
            
            
        }
        private void build_Click(object sender, EventArgs e)
        {
            if (!phase2)
            {
                if (MyButton.exitCount >= 1)
                {
                    label1.Text = "select source";
                    phase2 = true;
                    buttonL.Visible = false;
                    buttonR.Visible = false;
                    buttonD.Visible = false;
                    buttonU.Visible = false;
                    buttonB.Visible = false;
                    build.Text = "Reset";
                    buttonE.Text = "To Exit";
                }
                else
                {
                    label1.Text = "minimum number of exits is 1";
                    selected = new MyButton();
                }
            }
            else
            {
                reset();
            }
        }

        void reset(bool resCur=true)
        {
            if (currentNode != null)
            {
                foreach (MyButton b in open[currentNode])
                {
                    if (b.type == 0)
                    {
                        
                        b.BackColor = default(Color);
                        b.UseVisualStyleBackColor = true;
                    }
                    else if (b.type == 1)
                    {
                        
                         b.BackgroundImage = Image.FromFile(@"../assets/left.png");
                        
                    }
                    else if (b.type == 2)
                    {

                        b.BackgroundImage = Image.FromFile(@"../assets/up.png");

                    }
                    else if (b.type == 3)
                    {

                        b.BackgroundImage = Image.FromFile(@"../assets/right.png");

                    }
                    else if (b.type == 4)
                    {

                        b.BackgroundImage = Image.FromFile(@"../assets/down.png");

                    }
                    else
                    {
                        b.BackColor = Color.Red;
                    }

                }
                open.Clear();
                closed.Clear();
                if (resCur)
                {
                    source = null;
                }
                
                currentNode = null;
                
                destination = null;
                openL.Clear();
                issource = true;
                label1.Text = "select source";
            }
            else
            {
                destination = null;
                openL.Clear();
                open.Clear();
                closed.Clear();
                label1.Text = "select source";
                issource = true;
                if (resCur)
                {
                    source = null;
                }
            }

        }
        void findPath()
        {
            roadfound = false;
         
            openL.Add(source);
            open.Add(source, new List<MyButton>(openL));
            
            
             currentNode = source;
            
            while (true)
            {
                if (open.Count == 0)
                {
                    label1.Text="no path found";
                    return;
                }
                if (currentNode == null)
                {
                    label1.Text = "no path found";
                    break;
                }
                if (currentNode == destination)
                {
                    
                    roadfound = true;
                    printpath(open[currentNode]);
                    break;
                }

                else
                {
                    closed.Add(currentNode,open[currentNode]);
                    open.Remove(currentNode);
                    
                    openL=findSuccessors(closed[currentNode]);
                    if (openL.Count != 0)
                    {
                        for(int i=0;i< openL.Count; i++)
                        {

                            if (closed.ContainsKey(openL[i]))
                            {
                                if (getH(closed[currentNode],openL[i])+1 >= getH(closed[openL[i]], openL[i]))
                                {
                                    
                                }
                                else
                                {
                                    open.Add(openL[i], new List<MyButton>(closed[currentNode]));
                                    open[openL[i]].Add(openL[i]);
                                    closed.Remove(openL[i]);
                                }
                            }
                            else
                            {
                                if (open.ContainsKey(openL[i]))
                                {

                                }
                                else
                                {
                                    open.Add(openL[i], new List<MyButton>(closed[currentNode]));
                                    open[openL[i]].Add(openL[i]);
                                }
                            }
                            
                        }

                    }
                    currentNode = findBest(open);
                }

            }
        }
        MyButton findBest(Dictionary<MyButton, List<MyButton>> dict)
        {
            MyButton best=null;
            int bestValue = int.MaxValue;
            foreach (MyButton key in dict.Keys)
            {
                int value = getH(dict[key],key);
              // int value=dict[key].Count + (destination.x - key.x + destination.y - key.y);
                if (bestValue > value)
                {
                    bestValue = value;
                    best = key;
                }
            }
                return best;
        }
        int getH(List<MyButton> mylist,MyButton source)
        {
            int f = mylist.Count+ (Math.Abs(destination.x - source.x )+ Math.Abs(destination.y - source.y));
            return f;
        }
        void printpath(List<MyButton> mylist)
        {
            label1.Text = "path found";
            foreach (MyButton b in mylist)
            {
                b.BackColor = Color.Green;
                if(b.type == 1)
                {
                    b.BackgroundImage = Image.FromFile(@"../assets/gleft.png");
                }
                if (b.type == 2)
                {
                    b.BackgroundImage = Image.FromFile(@"../assets/gup.png");
                }
                if (b.type == 3)
                {
                    b.BackgroundImage = Image.FromFile(@"../assets/gright.png");
                }
                if (b.type == 4)
                {
                    b.BackgroundImage = Image.FromFile(@"../assets/gdown.png");
                }
            }
            

        }
        List<MyButton> findSuccessors(List<MyButton> current)
        {
            MyButton currentNode = current[current.Count - 1];
            if (currentNode.type == 0 || currentNode.type == 5)
            {
                return roadSuccessors(current);
            }
            else if (currentNode.type == 1)
            {
                return leftSuccessors(current);
            }
            else if (currentNode.type == 2)
            {
                return upSuccessors(current);
            }
            else if (currentNode.type == 3)
            {
                return rightSuccessors(current);
            }
            else if (currentNode.type == 4)
            {
                return downSuccessors(current);
            }

            return new List<MyButton>();
        }
        List<MyButton> roadSuccessors(List<MyButton> current)
        {
            MyButton currentNode = current[current.Count - 1];
            int x, y;
            List<MyButton> result = new List<MyButton>();
            x = currentNode.x;
            y = currentNode.y;
            MyButton previous = null;
            if (current.Count > 1)
                previous = current[current.Count - 2];
            if (x + 1 < width)
            {
                if ((button[x + 1, y].type == 0 || button[x + 1, y].type == 5||button[x + 1, y].type == 1) && button[x + 1, y] != previous)
                {
                    result.Add(button[x + 1, y]);
                }
            }
            if (x - 1 >= 0)
            {
                if ((button[x - 1, y].type == 0 || button[x - 1, y].type == 5 || button[x - 1, y].type == 3) && button[x - 1, y] != previous)
                {
                    result.Add(button[x - 1, y]);
                }
            }
            if (y - 1 >= 0)
            {
                if ((button[x , y-1].type == 0 || button[x , y-1].type == 5 || button[x , y-1].type == 4) && button[x, y - 1] != previous)
                {
                    result.Add(button[x, y - 1]);
                }
            }
            if (y + 1 < height)
            {
                if ((button[x , y+1].type == 0 || button[x , y+1].type == 5 || button[x , y+1].type == 2) && button[x, y + 1] != previous)
                {
                    result.Add(button[x, y + 1]);
                }
            }

            return result;
        }

        List<MyButton> leftSuccessors(List<MyButton> current)
        {
            MyButton currentNode = current[current.Count - 1];
            int x, y;
            List<MyButton> result = new List<MyButton>();
            x = currentNode.x;
            y = currentNode.y;
            MyButton previous = null;
            if (current.Count > 1)
                previous = current[current.Count - 2];
        
            if (x - 1 >= 0)
            {
                if ((button[x - 1, y].type == 0 || button[x - 1, y].type == 5 || button[x - 1, y].type == 3) && button[x - 1, y] != previous)
                {
                    result.Add(button[x - 1, y]);
                }
            }
           
           

            return result;
        }
        List<MyButton> rightSuccessors(List<MyButton> current)
        {
            MyButton currentNode = current[current.Count - 1];
            int x, y;
            List<MyButton> result = new List<MyButton>();
            x = currentNode.x;
            y = currentNode.y;
            MyButton previous = null;
            if (current.Count > 1)
                previous = current[current.Count - 2];

            if (x + 1 < width)
            {
                if ((button[x + 1, y].type == 0 || button[x + 1, y].type == 5 || button[x + 1, y].type == 1) && button[x + 1, y] != previous)
                {
                    result.Add(button[x + 1, y]);
                }
            }



            return result;
        }
        List<MyButton> upSuccessors(List<MyButton> current)
        {
            MyButton currentNode = current[current.Count - 1];
            int x, y;
            List<MyButton> result = new List<MyButton>();
            x = currentNode.x;
            y = currentNode.y;
            MyButton previous = null;
            if (current.Count > 1)
                previous = current[current.Count - 2];

            if (y - 1 >= 0)
            {
                if ((button[x , y-1].type == 0 || button[x , y-1].type == 5 || button[x , y-1].type == 4) && button[x, y - 1] != previous)
                {
                    result.Add(button[x, y - 1]);
                }
            }


            return result;
        }
        List<MyButton> downSuccessors(List<MyButton> current)
        {
            MyButton currentNode = current[current.Count - 1];
            int x, y;
            List<MyButton> result = new List<MyButton>();
            x = currentNode.x;
            y = currentNode.y;
            MyButton previous = null;
            if (current.Count > 1)
                previous = current[current.Count - 2];

            if (y + 1 < height)
            {
                if ((button[x , y+1].type == 0 || button[x , y+1].type == 5 || button[x , y+1].type == 2) && button[x, y + 1] != previous)
                {
                    result.Add(button[x, y + 1]);
                }
            }


            return result;
        }
    }
}
