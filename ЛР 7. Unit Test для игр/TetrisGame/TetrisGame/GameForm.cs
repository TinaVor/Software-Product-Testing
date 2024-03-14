using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TetrisGame
{
    public partial class GameForm : Form
    {
        // Tetris board properties
        public const int BoardWidth = 10;
        private const int BoardHeight = 20;
        public readonly Color[,] board = new Color[BoardWidth, BoardHeight];

        // Tetris piece properties
        public Point currentPiecePosition;
        public List<Point> currentPiece;

        // Timer for game loop
        private Timer gameTimer;

        public GameForm()
        {
            InitializeComponent();
            InitializeGame();
            this.DoubleBuffered = true;
        }

        public void InitializeGame()
        {
            // Set up the form
            this.Text = "Tetris Game";
            this.Size = new Size(315, 635);
            this.Paint += MainForm_Paint;
            this.KeyDown += MainForm_KeyDown;

            // Initialize the game board
            for (int i = 0; i < BoardWidth; i++)
            {
                for (int j = 0; j < BoardHeight; j++)
                {
                    board[i, j] = Color.White;
                }
            }

            // Initialize the game timer
            gameTimer = new Timer();
            gameTimer.Interval = 500; // milliseconds
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            // Start a new piece
            StartNewPiece();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // Draw the game board
            for (int i = 0; i < BoardWidth; i++)
            {
                for (int j = 0; j < BoardHeight; j++)
                {
                    using (SolidBrush brush = new SolidBrush(board[i, j]))
                    {
                        e.Graphics.FillRectangle(brush, i * 30, j * 30, 30, 30);
                    }
                }
            }

            // Draw the current piece
            foreach (var point in currentPiece)
            {
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    e.Graphics.FillRectangle(brush, (currentPiecePosition.X + point.X) * 30, (currentPiecePosition.Y + point.Y) * 30, 30, 30);
                }
            }
        }

        public void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle keyboard input for moving the piece
            if (e.KeyCode == Keys.Left && CanMove(-1, 0))
            {
                currentPiecePosition.X--;
            }
            else if (e.KeyCode == Keys.Right && CanMove(1, 0))
            {
                currentPiecePosition.X++;
            }
            else if (e.KeyCode == Keys.Down && CanMove(0, 1))
            {
                currentPiecePosition.Y++;
            }

            // Redraw the form
            this.Invalidate();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Move the piece down
            if (CanMove(0, 1))
            {
                currentPiecePosition.Y++;
            }
            else
            {
                // Lock the piece in place and start a new piece
                PlacePiece();
                StartNewPiece();
            }

            // Redraw the form
            this.Invalidate();

        }
        private Random random = new Random();
        private void StartNewPiece()
        {

            // Generate a random piece
            int pieceIndex = random.Next(7); // There are 7 possible pieces
            currentPiece = GetPiece(pieceIndex);

            // Set initial position for the piece
            currentPiecePosition = new Point(BoardWidth / 2 - 1, 0);
        }

        // Define the possible Tetris pieces
        private List<Point> GetPiece(int pieceIndex)
        {
            List<Point> piece;
            switch (pieceIndex)
            {
                case 0: // I Piece
                    piece = new List<Point> { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(0, 3) };
                    break;
                case 1: // J Piece
                    piece = new List<Point> { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(1, 2) };
                    break;
                case 2: // L Piece
                    piece = new List<Point> { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(-1, 2) };
                    break;
                case 3: // O Piece
                    piece = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) };
                    break;
                case 4: // S Piece
                    piece = new List<Point> { new Point(1, 0), new Point(2, 0), new Point(0, 1), new Point(1, 1) };
                    break;
                case 5: // T Piece
                    piece = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(1, 1) };
                    break;
                case 6: // Z Piece
                    piece = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 1) };
                    break;
                default:
                    throw new InvalidOperationException("Invalid piece index");
            }

            return piece;
        }

        private void PlacePiece()
        {
            // Place the current piece on the board
            foreach (var point in currentPiece)
            {
                board[currentPiecePosition.X + point.X, currentPiecePosition.Y + point.Y] = Color.Blue;
            }

            CheckLines();
            if (IsGameOver())
            {
                gameTimer.Stop();  // Stop the game timer when the game is over
                MessageBox.Show("Game Over");
                this.Close();
                return;
            }

        }


        public bool CanMove(int xOffset, int yOffset)
        {
            // Check if the piece can be moved in the specified direction
            foreach (var point in currentPiece)
            {
                int x = currentPiecePosition.X + point.X + xOffset;
                int y = currentPiecePosition.Y + point.Y + yOffset;

                // Check boundaries and collision with other pieces
                if (x < 0 || x >= BoardWidth || y >= BoardHeight || (y >= 0 && board[x, y] != Color.White))
                {
                    return false;
                }

                if (currentPiecePosition.Y + yOffset < 0)
                {
                    return false;
                }

            }

            return true;
        }

        public void CheckLines()
        {
            // Check each line from bottom to top
            for (int y = BoardHeight - 1; y >= 0; y--)
            {
                bool lineIsComplete = true;
                for (int x = 0; x < BoardWidth; x++)
                {
                    // Check if any cell in the line is empty
                    if (board[x, y] == Color.White)
                    {
                        lineIsComplete = false;
                        break;
                    }
                }

                if (lineIsComplete)
                {
                    // Remove the complete line and shift all lines above it down
                    RemoveLine(y);
                    ShiftLinesDown(y);
                }
            }
        }

        private void RemoveLine(int lineIndex)
        {
            // Remove the specified line
            for (int x = 0; x < BoardWidth; x++)
            {
                board[x, lineIndex] = Color.White;
            }
        }

        private void ShiftLinesDown(int lineIndex)
        {
            // Shift all lines above the specified line down
            for (int y = lineIndex - 1; y >= 0; y--)
            {
                for (int x = 0; x < BoardWidth; x++)
                {
                    board[x, y + 1] = board[x, y];
                    board[x, y] = Color.White;
                }
            }
        }

        public bool IsGameOver()
        {
            // Check if any cell in the top row contains a piece
            for (int x = 0; x < BoardWidth; x++)
            {
                if (board[x, 0] != Color.White)
                {
                    return true;
                }
            }

            return false;
        }

    }
}