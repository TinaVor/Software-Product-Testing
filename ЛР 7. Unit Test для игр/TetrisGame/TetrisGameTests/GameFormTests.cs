using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TetrisGame;


namespace GameFormTests
{
    [TestClass]
    public class TetrisGameTests
    {
        [TestMethod]
        public void CorrectInitialization()
        {
            // Arrange
            var gameForm = new GameForm();

            // Assert
            Assert.AreEqual("Tetris Game", gameForm.Text);
        }

        [TestMethod]
        public void IsGameOver_InitialCondition_ShouldNotBeGameOver()
        {
            // Arrange
            var gameForm = new GameForm();

            // Assert
            Assert.IsFalse(gameForm.IsGameOver());
        }

        [TestMethod]
        public void IsGameOver_PieceInTheTopRow_ShouldBeGameOver()
        {
            // Arrange
            var gameForm = new GameForm();
            gameForm.board[GameForm.BoardWidth / 2, 0] = Color.Blue;

            // Assert
            Assert.IsTrue(gameForm.IsGameOver());
        }

        [TestMethod]
        public void CanMove_PieceInTheBord_ShouldBeCanMove()
        {
            // Arrange
            var gameForm = new GameForm();

            // Assert
            Assert.IsTrue(gameForm.CanMove(0,0));
        }

        [TestMethod]
        public void CanMove_PieceNotInTheBord_ShouldBeCanNotMove()
        {
            // Arrange
            var gameForm = new GameForm();

            // Assert
            Assert.IsFalse(gameForm.CanMove(340, 0));
        }

    }
}