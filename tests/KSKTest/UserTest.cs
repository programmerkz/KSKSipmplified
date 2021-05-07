using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KSKSimplified.KSK.Models;


namespace KSKTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Объект ошибочно создался с null параметром login")]
        public void TestConstructorWithNullLogin()
            => new User(null, "123");

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Объект ошибочно создался с null параметром password")]
        public void TestConstructorWithNullPassword()
            => new User("some_name", null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Объект ошибочно создался с пустым параметром login")]
        public void TestConstructorWithEmptyLogin()
            => new User("", "123");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Объект ошибочно создался с пустым параметром password")]
        public void TestConstructorWithEmptyPassword()
            => new User("some_name", "");

        [TestMethod]
        public void TestIsAuthWithWrongPassword()
        {
            // Arrange
            string userPassword = "123456";
            string wrongPassword = "123abc";

            // Act
            User usr = new User("db_admin", userPassword);

            // Assert
            Assert.IsFalse(usr.IsAuth(wrongPassword));
        }

        [TestMethod]
        public void TestIsAuthWithRightPassword()
        {
            // Arrange
            string userPassword = "123456qwerty";
            string rightPassword = "123456qwerty";

            // Act
            User usr = new User("db_admin", userPassword);

            // Assert
            Assert.IsTrue(usr.IsAuth(rightPassword));
        }
    }
}
