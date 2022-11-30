using MedicalService.Driver;
using MedicalService.Page;

namespace MedicalService.Tests
{

    public class LoginTest
    {
        LoginPage loginPage;
        string Message = "Login failed! Please ensure the username and password are valid.";
        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();

        }
        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }
        [Test]
        public void TC01_LoginWithInvalidUsername_LoginShouldBeUnsuccessful()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doeic", "ThisIsNotAPassword");

            Assert.That(Message, Is.EqualTo(loginPage.InvalidUsername.Text));
        }
        [Test]
        public void TC02_LoginWithInvalidPassword_LoginShouldBeUnsuccessful()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doe", "Password");

            Assert.That(Message, Is.EqualTo(loginPage.InvalidUsername.Text));
        }
        [Test]
        public void TC03_LoginWithoutData_LoginShouldBeUnsuccessful()
        {
            loginPage.AppMedic.Click();
            loginPage.ButtonLogin.Click();

            Assert.That(Message, Is.EqualTo(loginPage.InvalidUsername.Text));
        }
        [Test]
        public void TC04_LoginWithInvalidData_LoginShouldBeUnsuccessful()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doeic", "Password");

            Assert.That(Message, Is.EqualTo(loginPage.InvalidUsername.Text));
        }
    }
}
