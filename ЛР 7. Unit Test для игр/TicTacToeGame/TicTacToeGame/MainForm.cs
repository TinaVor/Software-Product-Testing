using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class MainForm : Form
    {
        private bool isPlayer1Turn;
        private char[,] board;
        public Button[,] buttons;

        public MainForm()
        {
            InitializeComponent();
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            isPlayer1Turn = true;
            board = new char[3, 3];
            buttons = new Button[,] {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button9 }
            };

            foreach (var button in buttons)
            {
                button.Text = string.Empty;
                button.Enabled = true;
                button.BackColor = Color.White;
                button.Click += Button_Click;
            }
        }

        public void Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            int row = GetButtonRow(button);
            int col = GetButtonColumn(button);

            if (isPlayer1Turn)
            {
                button.Text = "X";
                button.BackColor = Color.LightSkyBlue;
                board[row, col] = 'X';
            }
            else
            {
                button.Text = "O";
                button.BackColor = Color.LightPink;
                board[row, col] = 'O';
            }

            button.Enabled = false;
            isPlayer1Turn = !isPlayer1Turn;

            if (CheckForWin(row, col))
            {
                string winner = isPlayer1Turn ? "Player 2 (O)" : "Player 1 (X)";
                MessageBox.Show("Game Over! " + winner + " wins!");
                InitializeBoard();
            }
            else if (CheckForDraw())
            {
                MessageBox.Show("Game Over! It's a draw!");
                InitializeBoard();
            }
        }

        private int GetButtonRow(Button button)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (buttons[row, col] == button)
                    {
                        return row;
                    }
                }
            }
            return -1;
        }

        private int GetButtonColumn(Button button)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (buttons[row, col] == button)
                    {
                        return col;
                    }
                }
            }
            return -1;
        }

        public bool CheckForWin(int row, int col)
        {
            char player = isPlayer1Turn ? 'O' : 'X';

            // Check row and column
            if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
            {
                return true;
            }
            if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
            {
                return true;
            }

            // Check diagonals
            if (row == col && board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            if (row + col == 2 && board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            return false;
        }

        private bool CheckForDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '\0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
