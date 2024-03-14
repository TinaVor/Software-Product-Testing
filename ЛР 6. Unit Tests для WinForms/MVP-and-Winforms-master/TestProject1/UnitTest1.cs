using ClassLibrary1;
using System.Reflection;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private User user;
        class User : IUserInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string ErrorMessage { get; set; }
            public bool ShowFormErrors { get; set; }
            public string PlaceOfResidence { get; set; }
            public string Gender { get; set; }

            public event EventHandler? SaveAttempted;
        }
        [TestInitialize]
        public void TestInitialize()
        {
            user = new User();
            user.FirstName = "Крош";
            user.LastName = "Смешарикович";
            user.Email = "Морковь@mail.ru";
            user.Phone = "88005355555";
            user.PlaceOfResidence = "Россия";
            user.Gender = "Мужчина";
        }

        [TestMethod]
        public void AllFieldsNotEmpty()
        {
            Assert.IsFalse(string.IsNullOrEmpty(user.FirstName));
            Assert.IsFalse(string.IsNullOrEmpty(user.LastName));
            Assert.IsFalse(string.IsNullOrEmpty(user.Email));
            Assert.IsFalse(string.IsNullOrEmpty(user.Phone));
            Assert.IsFalse(string.IsNullOrEmpty(user.PlaceOfResidence));
            Assert.IsFalse(string.IsNullOrEmpty(user.Gender));
            Assert.IsFalse(user.ShowFormErrors);
        }

        [TestMethod]
        public void CapitalizedWords()
        {
            bool firstSymbol = char.IsUpper(user.FirstName[0]);
            Assert.IsTrue(firstSymbol);
        }

        [TestMethod]
        public void EmailHaveSymbol()
        {
            Assert.IsTrue(user.Email.Contains("@"));
        }

        [TestMethod]
        public void CorrectPhone()
        {
            Assert.IsTrue(user.Phone.StartsWith("+7") || user.Phone.StartsWith("8"));
        }
        [TestMethod]
        public void CorrectGender()
        {
            Assert.IsTrue(user.Gender == "Женщина" || user.Gender == "Мужчина");
        }

        [TestMethod]
        public void PlaceRussian()
        {
            Assert.IsTrue(user.PlaceOfResidence == "Россия");
        }
    }
}