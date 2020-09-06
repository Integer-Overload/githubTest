using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tankwar
{
    /// <summary>
    /// Summay Description for Form1
    /// </summary>
    /// 

    public partial class Form1 : Form
    {
        /// <summary>
        /// Required designer variable
        /// </summary>
        /// 
        string path= "E:/4. PROJECTS/Visual_Studio_Projects/TankGame/TankWar/images/";
        
        int P1Tank_traj = 1, p1Shelltraj = 0;
        int P2Tank_traj = 1, p2Shelltraj = 0;
        Boolean p1shelllive = false;
        Boolean p2shelllive = false;


        public Form1()
        {
            /// Required for Windows Form Designer Support:

            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            //added manually from tutorial, adds event handler for when we press key down for the image

            /// TO DO: add any constructor code after intialisedComponent Call
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //load firing on tank 2
            
            InitialiseP1Firing();
            InitialiseP2Firing();
            
        }



        /// what happens to image (how it moves) when the buttons are pressed
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            ///  *****TANK ONE CODE *****
            ///  
            // code for tankONE Image LEFT movement:
            if (e.KeyCode.ToString() == "A") // what happens when player press A key / left movement
            {
                pictureBox1.Image = Image.FromFile(path + "tank1.bmp");
                pictureBox1.Left = pictureBox1.Left - 5;
                pictureBox1.Refresh();
                P1Tank_traj = 1;
            }

            // code for tankONE Image RIGHT movement:
            if (e.KeyCode.ToString() == "D") // what happens when player press A key / Right movement
            {
                pictureBox1.Image = Image.FromFile(path + "tank2.bmp");
                pictureBox1.Left = pictureBox1.Left + 5;
                pictureBox1.Refresh();
                P1Tank_traj = 2;
            }

            // code for tankONE Image TOP movement:
            if (e.KeyCode.ToString() == "W") // what happens when player press A key / Top movement
            {
                pictureBox1.Image = Image.FromFile(path + "tank4.bmp");
                pictureBox1.Top = pictureBox1.Top - 5;
                pictureBox1.Refresh();
                P1Tank_traj = 3;
            }

            // code for tankONE Image BOTTOM movement:
            if (e.KeyCode.ToString() == "S") // what happens when player press A key / Bottom movement
            {
                pictureBox1.Image = Image.FromFile(path + "tank3.bmp");
                pictureBox1.Top = pictureBox1.Top + 5;
                pictureBox1.Refresh();
                P1Tank_traj = 4;
            }

            /// BULLET FIRING TANK ONe:
            if (e.KeyCode.ToString() == "Q")
            {
                P1firing(); // PLAYER 1 FIRING USING 'Q' KEY
            }

            ///  *****TANK TWO CODE *****
            ///  
              // code for tankTWO Image LEFT movement:
            if (e.KeyCode.ToString() == "Left") // what happens when player press A key / left movement
            {
                pictureBox2.Image = Image.FromFile(path + "tank1.bmp");
                pictureBox2.Left = pictureBox2.Left - 5;
                pictureBox2.Refresh();
                P2Tank_traj = 1;
            }

            // code for tankTWO Image RIGHT movement:
            if (e.KeyCode.ToString() == "Right") // what happens when player press A key / Right movement
            {
                pictureBox2.Image = Image.FromFile(path + "tank2.bmp");
                pictureBox2.Left = pictureBox2.Left + 5;
                pictureBox2.Refresh();
                P2Tank_traj = 2;
            }

            // code for tankTWO Image TOP movement:
            if (e.KeyCode.ToString() == "Up") // what happens when player press A key / Top movement
            {
                pictureBox2.Image = Image.FromFile(path + "tank4.bmp");
                pictureBox2.Top = pictureBox2.Top - 5;
                pictureBox2.Refresh();
                P2Tank_traj = 3;


            }

            // code for tankTWO Image BOTTOM movement:
            if (e.KeyCode.ToString() == "Down") // what happens when player press A key / Bottom movement
            {
                pictureBox2.Image = Image.FromFile(path + "tank3.bmp");
                pictureBox2.Top = pictureBox2.Top + 5;
                pictureBox2.Refresh();
                P2Tank_traj = 4;
            }

           

            
            //TANK 2 BULLET FIRING
            if (e.KeyCode.ToString() == "Z")
            {
                P2firing();//PLAYER 2 FIRING USING KEY "5"
            }

            TestCollision();

            DetectWall(); // prevents tanks from coming of the edges of the screen
                          // OffScreenOnScreen(); // allows tanks to reppear on the screen on the other side

        }

        /// FUNCTION TO DONT SHOW SHELL ON SCREEN UNTIL PLAYER FIRES

        private void InitialiseP1Firing()
        {
            pictureBox3.Left = -100;
            pictureBox3.Top = -100;
            //image set off the screen so its no seen when screen first loads
            p1Shelltraj = 0;
            p1shelllive = false; // THE FIRING IS SET TO OFF with a boolean
        }
        

        //METHOD THAT STARTS THE SHELL/bullet firing:
        private void P1firing()
        {
            timer1.Enabled = true;
            p1shelllive = true; // THE FIRING IS SET TO ON with a boolean
            SET_TRAJECTORY();
           
        }

        private void InitialiseP2Firing()
        {
            pictureBox4.Left = -100;
            pictureBox4.Top = -100;
            //image set off the screen so its no seen when screen first loads
            p2Shelltraj = 0;
            p2shelllive = false; // THE FIRING IS SET TO OFF with a boolean
        }


        //METHOD THAT STARTS THE SHELL/bullet firing:
        private void P2firing()
        {
            timer2.Enabled = true;
            p2shelllive = true; // THE FIRING IS SET TO ON with a boolean
            SET_TRAJECTORY();

        }

        //TIMER FUNCTION FOR TO MOVE BULLET
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveShell();
          
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            MoveShell2();
        }


        //what happens when bullter moves
        private void MoveShell()
        {
            if (p1shelllive == true)
            {
                //case move left bullet
                if (p1Shelltraj ==1)
                {
                    pictureBox3.Left = pictureBox3.Left - 5; 
                }

                //case move right bullet
                if (p1Shelltraj == 2)
                {
                    pictureBox3.Left = pictureBox3.Left + 5;
                }
                //case move up bullet
                if (p1Shelltraj == 3)
                {
                    pictureBox3.Top = pictureBox3.Top - 5;
                }
                //case move down bullet
                if (p1Shelltraj == 4)
                {
                    pictureBox3.Top = pictureBox3.Top + 5;
                }


                if ((pictureBox3.Left > pictureBox2.Left) && (pictureBox3.Left < (pictureBox2.Left + pictureBox2.Width)) && (pictureBox3.Top > pictureBox2.Top) && (pictureBox3.Top < (pictureBox2.Top + pictureBox2.Height)))
                {
                    p1shelllive = false;
                    pictureBox3.Left = -100;
                    pictureBox3.Top = -100;
                }
                if ((pictureBox3.Left > pictureBox1.Left) && (pictureBox3.Left < (pictureBox1.Left + pictureBox1.Width)) && (pictureBox3.Top > pictureBox1.Top) && (pictureBox3.Top < (pictureBox1.Top + pictureBox1.Height)))
                {
                    p1shelllive = false;
                    pictureBox3.Left = -100;
                    pictureBox3.Top = -100;
                }

                //CODE TO REMOVE BULLET IF IT HAS MISSED AND GONE OFFSCREEN:
                if ((pictureBox3.Left < 0 ) || (pictureBox3.Left > this.Width) || (pictureBox3.Top > this.Height) || (pictureBox3.Top < 0))
                        {
                            p1shelllive = false;
                            timer1.Enabled = false;
                            pictureBox3.Left = -100;
                            pictureBox3.Top = -100;
                            /* if the bullet goes off the screen 
                             then set the bullet firing to false switch off the timer and reset
                            the position of the bullet*/
                        }

                pictureBox3.Refresh(); //reset position of the bullet on screen /bullet
            }

        }

        private void MoveShell2()
        {
            if (p2shelllive == true)
            {
                //case move left bullet
                if (p2Shelltraj == 1)
                {
                    pictureBox4.Left = pictureBox4.Left - 5;
                }

                //case move right bullet
                if (p2Shelltraj == 2)
                {
                    pictureBox4.Left = pictureBox4.Left + 5;
                }
                //case move up bullet
                if (p2Shelltraj == 3)
                {
                    pictureBox4.Top = pictureBox4.Top - 5;
                }
                //case move down bullet
                if (p2Shelltraj == 4)
                {
                    pictureBox4.Top = pictureBox4.Top + 5;
                }


                if ((pictureBox4.Left > pictureBox2.Left) && (pictureBox4.Left < (pictureBox2.Left + pictureBox2.Width)) && (pictureBox4.Top > pictureBox2.Top) && (pictureBox4.Top < (pictureBox2.Top + pictureBox2.Height)))
                {
                    p2shelllive = false;
                    pictureBox4.Left = -100;
                    pictureBox4.Top = -100;
                }
                if ((pictureBox4.Left > pictureBox1.Left) && (pictureBox4.Left < (pictureBox1.Left + pictureBox1.Width)) && (pictureBox4.Top > pictureBox1.Top) && (pictureBox4.Top < (pictureBox1.Top + pictureBox1.Height)))
                {
                    p2shelllive = false;
                    pictureBox4.Left = -100;
                    pictureBox4.Top = -100;
                }

                //CODE TO REMOVE BULLET IF IT HAS MISSED AND GONE OFFSCREEN:
                if ((pictureBox4.Left < 0) || (pictureBox4.Left > this.Width) || (pictureBox4.Top > this.Height) || (pictureBox4.Top < 0))
                {
                    p2shelllive = false;
                    timer2.Enabled = false;
                    pictureBox4.Left = -100;
                    pictureBox4.Top = -100;
                    /* if the bullet goes off the screen 
                     then set the bullet firing to false switch off the timer and reset
                    the position of the bullet*/
                }

                pictureBox4.Refresh(); //reset position of the bullet on screen /bullet
            }

        }


        //METHOD that sets the trajectory of the shell/bullet
        private void SET_TRAJECTORY()
        {
          if(P1Tank_traj == 1) // tank 2 trajectory
            {
                pictureBox3.Left = pictureBox1.Left; //position of the bullet image
                pictureBox3.Top = pictureBox1.Top + (pictureBox1.Height / 2); //SETS position of bullet image to midpoint of the tank image
                p1Shelltraj = 1; // bullet trakectory is set to same trajectory as tank
            }

            if (P1Tank_traj == 2) // tank trajectory
            {
                pictureBox3.Left = pictureBox1.Left + pictureBox1.Width; //position of the bullet image
                pictureBox3.Top = pictureBox1.Top + (pictureBox1.Height / 2); //SETS position of bullet image to midpoint of the tank image
                p1Shelltraj = 2; // bullet trakectory is set to same trajectory as tank
            }

            if (P1Tank_traj == 3) // tank trajectory
            {
                pictureBox3.Left = pictureBox1.Left + (pictureBox1.Width / 2); //position of the bullet image
                pictureBox3.Top = pictureBox1.Top ; //SETS position of bullet image to midpoint of the tank image
                p1Shelltraj = 3; // bullet trakectory is set to same trajectory as tank
            }
            if (P1Tank_traj == 4) // tank trajectory
            {
                pictureBox3.Left = pictureBox1.Left + (pictureBox1.Width / 2); //position of the bullet image
                pictureBox3.Top = pictureBox1.Top + pictureBox1.Height; //SETS position of bullet image to midpoint of the tank image
                p1Shelltraj = 4; // bullet trakectory is set to same trajectory as tank
            }


            if (P2Tank_traj == 1) // tank  trajectory
            {
                pictureBox4.Left = pictureBox2.Left; //position of the bullet image
                pictureBox4.Top = pictureBox2.Top + (pictureBox2.Height / 2); //SETS position of bullet image to midpoint of the tank image
                p2Shelltraj = 1; // bullet trakectory is set to same trajectory as tank
            }

            if (P2Tank_traj == 2) // tank trajectory
            {
                pictureBox4.Left = pictureBox2.Left; //position of the bullet image
                pictureBox4.Top = pictureBox2.Top + (pictureBox2.Height / 2); //SETS position of bullet image to midpoint of the tank image
                p2Shelltraj = 2; // bullet trakectory is set to same trajectory as tank
            }

            if (P2Tank_traj == 3) // tank trajectory
            {
                pictureBox4.Left = pictureBox2.Left; //position of the bullet image
                pictureBox4.Top = pictureBox2.Top + (pictureBox2.Height / 2); //SETS position of bullet image to midpoint of the tank image
                p2Shelltraj = 3; // bullet trakectory is set to same trajectory as tank
            }
            if (P2Tank_traj == 4) // tank trajectory
            {
                pictureBox4.Left = pictureBox2.Left; //position of the bullet image
                pictureBox4.Top = pictureBox2.Top + (pictureBox2.Height / 2); //SETS position of bullet image to midpoint of the tank image
                p2Shelltraj = 4; // bullet trakectory is set to same trajectory as tank
            }

        }

        public void DetectWall()
        {
            /// this method / routine is going to prevent the tanks from going
            /// off the screen:
            /// 

            // *****************************************
            //******************TANK ONE ***********
            if (pictureBox1.Left <= 0)
                pictureBox1.Left = pictureBox1.Left + 20;
            
            // stops from going to the left side of the screen
            // when left posistion of picturebox1 reaches position 0 the edge of the screen
            // we set original position + 20 and prevents from going over the left edge of screen:

            if (pictureBox1.Left >= (this.Width - pictureBox1.Width))
                pictureBox1.Left = pictureBox1.Left - 50;
            // stops from going to the right side of the screen
            // but using picture with (the whole size of the actual image witdh)

            // from going off the top (prevents tank from going off the top of the screen):
            if (pictureBox1.Top <= 0)
                pictureBox1.Top = pictureBox1.Top + 20;

            //from going off the bottom of the screen (prevents tank from going off the bottom screen):
            if (pictureBox1.Top >= this.Height - pictureBox1.Height)
                pictureBox1.Top = pictureBox1.Top - 50;

            // *****************************************
            //******************TANK TWO ***********

            if (pictureBox2.Left <= 0)
                pictureBox2.Left = pictureBox2.Left + 20;
            // stops from going to the left side of the screen
            // when left posistion of picturebox1 reaches position 0 the edge of the screen
            // we set original position + 20 and prevents from going over the left edge of screen:

            if (pictureBox2.Left >= (this.Width - pictureBox2.Width))
                pictureBox2.Left = pictureBox2.Left - 50;
            // stops from going to the right side of the screen
            // but using picture with (the whole size of the actual image witdh)

            // from going off the top (prevents tank from going off the top of the screen):
            if (pictureBox2.Top <= 0)
                pictureBox2.Top = pictureBox2.Top + 20;

            //from going off the bottom of the screen (prevents tank from going off the bottom screen):
            if (pictureBox2.Top >= this.Height - pictureBox2.Height)
                pictureBox2.Top = pictureBox2.Top - 50;

        }

        //method to make tanks appear on the other side of the screen:
        public void OffScreenOnScreen()
        {

            // *****************************************
            //******************TANK ONE ***********

            if (pictureBox1.Left + pictureBox1.Width <= 0)
            {

                pictureBox1.Left = this.Width - 1;
                pictureBox1.Refresh();
            }

            if (pictureBox1.Left >= this.Width)
            {
                pictureBox1.Left = 0 - pictureBox1.Width;
                pictureBox1.Refresh();
            }

            if (pictureBox1.Top <= 0 - pictureBox1.Height)
            {
                pictureBox1.Top = this.Height - 1;
                pictureBox1.Refresh();
            }


            if (pictureBox1.Top >= this.Height)
            {
                pictureBox1.Top = 0 - pictureBox1.Height;

            }

            // *****************************************
            //******************TANK TWO ***********

            if (pictureBox2.Left + pictureBox2.Width <= 0)
            {

                pictureBox2.Left = this.Width - 1;
                pictureBox2.Refresh();
            }

            if (pictureBox2.Left >= this.Width)
            {
                pictureBox2.Left = 0 - pictureBox2.Width;
                pictureBox2.Refresh();
            }

            if (pictureBox2.Top <= 0 - pictureBox2.Height)
            {
                pictureBox2.Top = this.Height - 1;
                pictureBox2.Refresh();
            }


            if (pictureBox2.Top >= this.Height)
            {
                pictureBox2.Top = 0 - pictureBox2.Height;

            }
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        //Sample Collision Code :


        private void TestCollision()
        {
            //Tank1FACELEFT_Tank2FACERIGHT
            if ((pictureBox2.Left + pictureBox2.Width) > pictureBox1.Left)

                if (pictureBox2.Left < (pictureBox1.Left + pictureBox1.Width))

                    if ((pictureBox2.Top + pictureBox2.Width) > pictureBox1.Top)

                        if (pictureBox2.Top < (pictureBox1.Top + pictureBox1.Height))
                        {

                            pictureBox1.Left = pictureBox1.Left - 20;
                            pictureBox2.Left = pictureBox2.Left + 20;

                        }

            ///Tank1FACEDOWN_Tank2FACEUP

            if ((pictureBox1.Left + pictureBox1.Width) > pictureBox2.Left)
                if (pictureBox1.Left < (pictureBox2.Left + pictureBox2.Width))
                    if ((pictureBox1.Top + pictureBox1.Width) > pictureBox2.Top)
                        if (pictureBox1.Top < (pictureBox2.Top + pictureBox2.Height))
                        {
                            pictureBox1.Top = pictureBox1.Top - 20;
                            pictureBox2.Top = pictureBox2.Top + 20;

                        }
        }


    }


}
