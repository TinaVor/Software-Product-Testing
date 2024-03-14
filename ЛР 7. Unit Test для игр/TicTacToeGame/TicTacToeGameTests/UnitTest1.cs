using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using TicTacToeGame;


namespace TicTacToeGameTests
{
    [TestClass]
    public class MainFormTests
    {
        [TestMethod]
        public void ClickingButtonShouldChangeButtonText()
        {
            MainForm form = new MainForm();
            form.InitializeBoard();
            form.Button_Click(form.buttons[0, 0], null);
            Assert.AreEqual("X", form.buttons[0, 0].Text);
        }

        [TestMethod]
        public void CheckWinShouldReturnTrueWhenThreeInRow()
        {
            MainForm form = new MainForm();
            form.InitializeBoard();
            form.buttons[0, 0].Text = "X";
            form.buttons[0, 1].Text = "X";
            form.buttons[0, 2].Text = "X";
            Assert.AreEqual(true, form.buttons[0, 0].Enabled);
            Assert.AreEqual(true, form.buttons[0, 1].Enabled);
            Assert.AreEqual(true, form.buttons[0, 2].Enabled);
            Assert.AreEqual(true, form.buttons[1, 0].Enabled);
        }

        [TestMethod]
        public void CheckWinShouldReturnTrueWhenThreeInColumn()
        {
            MainForm form = new MainForm();
            form.InitializeBoard();
            form.buttons[0, 0].Text = "X";
            form.buttons[1, 0].Text = "X";
            form.buttons[2, 0].Text = "X";
            Assert.AreEqual(true, form.buttons[0, 0].Enabled);
            Assert.AreEqual(true, form.buttons[1, 0].Enabled);
            Assert.AreEqual(true, form.buttons[2, 0].Enabled);
            Assert.AreEqual(true, form.buttons[0, 1].Enabled);
        }

        [TestMethod]
        public void CheckWinShouldReturnTrueWhenThreeInDiagonal()
        {
            MainForm form = new MainForm();
            form.InitializeBoard();
            form.buttons[0, 0].Text = "X";
            form.buttons[1, 1].Text = "X";
            form.buttons[2, 2].Text = "X";
            Assert.AreEqual(true, form.buttons[0, 0].Enabled);
            Assert.AreEqual(true, form.buttons[1, 1].Enabled);
            Assert.AreEqual(true, form.buttons[2, 2].Enabled);
            Assert.AreEqual(true, form.buttons[0, 1].Enabled);
        }

        [TestMethod]
        public void CheckWinShouldReturnTrueWhenDraw()
        {
            MainForm form = new MainForm();
            form.InitializeBoard();
            form.buttons[0, 0].Text = "X";
            form.buttons[0, 1].Text = "O";
            form.buttons[0, 2].Text = "X";
            form.buttons[1, 0].Text = "O";
            form.buttons[1, 1].Text = "X";
            form.buttons[1, 2].Text = "O";
            form.buttons[2, 0].Text = "O";
            form.buttons[2, 1].Text = "X";
            form.buttons[2, 2].Text = "O";
            Assert.AreEqual(true, form.buttons[0, 0].Enabled);
            Assert.AreEqual(true, form.buttons[0, 1].Enabled);
            Assert.AreEqual(true, form.buttons[0, 2].Enabled);
            Assert.AreEqual(true, form.buttons[1, 0].Enabled);
            Assert.AreEqual(true, form.buttons[1, 1].Enabled);
            Assert.AreEqual(true, form.buttons[1, 2].Enabled);
            Assert.AreEqual(true, form.buttons[2, 0].Enabled);
            Assert.AreEqual(true, form.buttons[2, 1].Enabled);
            Assert.AreEqual(true, form.buttons[2, 2].Enabled);
        }

        [TestMethod]
        public void TestReset()
        {
            var form = new MainForm();

            form.Button_Click(form.buttons[0, 0], null);
            form.Button_Click(form.buttons[1, 0], null);
            form.Button_Click(form.buttons[0, 1], null);
            form.Button_Click(form.buttons[1, 1], null);
            form.Button_Click(form.buttons[2, 0], null);
            form.Button_Click(form.buttons[2, 1], null);
            form.Button_Click(form.buttons[2, 2], null);

            Assert.AreEqual("X", form.buttons[0, 0].Text);
            Assert.AreEqual("O", form.buttons[1, 0].Text);
            Assert.AreEqual("X", form.buttons[0, 1].Text);
            Assert.AreEqual("O", form.buttons[1, 1].Text);
            Assert.AreEqual("X", form.buttons[2, 0].Text);
            Assert.AreEqual("O", form.buttons[2, 1].Text);
            Assert.AreEqual("X", form.buttons[2, 2].Text);

            form.InitializeBoard();

            Assert.AreEqual(string.Empty, form.buttons[0, 0].Text);
            Assert.AreEqual(string.Empty, form.buttons[1, 0].Text);
            Assert.AreEqual(string.Empty, form.buttons[0, 1].Text);
            Assert.AreEqual(string.Empty, form.buttons[1, 1].Text);
            Assert.AreEqual(string.Empty, form.buttons[2, 0].Text);
            Assert.AreEqual(string.Empty, form.buttons[2, 1].Text);
            Assert.AreEqual(string.Empty, form.buttons[2, 2].Text);
        }
    }
}