using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (turn)
            {
                btn.Text = "X";
            }
            else
            {
                btn.Text = "O";
            }

            turn = !turn;
            btn.Enabled = false;
            turn_count++;

            check_win();
        }

        private void check_win()
        {
            bool winner = false;

            //Checks Horizontal
            if ((btn1.Text == btn2.Text) && (btn2.Text == btn3.Text) && (!btn1.Enabled))
            {
                winner = true;
                btn1.BackColor = Color.Red;
                btn2.BackColor = Color.Red;
                btn3.BackColor = Color.Red;
            }
            if ((btn4.Text == btn5.Text) && (btn5.Text == btn6.Text) && (!btn4.Enabled))
            {
                winner = true;
                btn4.BackColor = Color.Red;
                btn5.BackColor = Color.Red;
                btn6.BackColor = Color.Red;
            }
            if ((btn7.Text == btn8.Text) && (btn8.Text == btn9.Text) && (!btn7.Enabled))
            {
                winner = true;
                btn7.BackColor = Color.Red;
                btn8.BackColor = Color.Red;
                btn9.BackColor = Color.Red;
            }

            //Checks Vertical
            if ((btn1.Text == btn4.Text) && (btn4.Text == btn7.Text) && (!btn1.Enabled))
            {
                winner = true;
                btn1.BackColor = Color.Red;
                btn4.BackColor = Color.Red;
                btn7.BackColor = Color.Red;
            }
            if ((btn2.Text == btn5.Text) && (btn5.Text == btn8.Text) && (!btn2.Enabled))
            {
                winner = true;
                btn2.BackColor = Color.Red;
                btn5.BackColor = Color.Red;
                btn8.BackColor = Color.Red;
            }
            if ((btn3.Text == btn6.Text) && (btn6.Text == btn9.Text) && (!btn3.Enabled))
            {
                winner = true;
                btn3.BackColor = Color.Red;
                btn6.BackColor = Color.Red;
                btn9.BackColor = Color.Red;
            }

            //Checks Diagonal
            if ((btn1.Text == btn5.Text) && (btn5.Text == btn9.Text) && (!btn1.Enabled))
            {
                winner = true;
                btn1.BackColor = Color.Red;
                btn5.BackColor = Color.Red;
                btn9.BackColor = Color.Red;
            }
            if ((btn3.Text == btn5.Text) && (btn5.Text == btn7.Text) && (!btn7.Enabled))
            {
                winner = true;
                btn3.BackColor = Color.Red;
                btn5.BackColor = Color.Red;
                btn7.BackColor = Color.Red;
            }


            if (winner)
            {
                String player = "";
                buttons_off();

                if (turn)
                {
                    player = "O";
                }
                else
                {
                    player = "X";
                }

                MessageBox.Show(player + " Wins!", "WINNER!");
            }
            else
            {
                if (turn_count == 9)
                {
                    MessageBox.Show("It's a Draw!", "DRAW!");
                }
            }
        }

        public void buttons_off()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button btn = (Button)c;
                    btn.Enabled = false;
                }
            }
            catch
            { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                //Reset all buttons to start a new game
                foreach (Control c in Controls)
                {
                    Button btn = (Button)c;
                    btn.Enabled = true;
                    btn.Text = "";
                    btn.BackColor = Color.LightGray;
                }
            }
            catch
            { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
