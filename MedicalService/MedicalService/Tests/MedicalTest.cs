using MedicalService.Driver;
using MedicalService.Page;
using NUnit.Framework;

namespace MedicalService.Tests
{
    public class Tests
    {
        LoginPage loginPage;
        MedicalPage medicalPage;
        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            medicalPage = new MedicalPage();
        }
        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_MakeAppointment_ShouldAppointmentBeCompleted()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doe", "ThisIsNotAPassword");
            medicalPage.SelectFacility("Hongkong CURA Healthcare Center");
            medicalPage.CheckBox.Click();
            medicalPage.MedicAid.Click();
            medicalPage.Date.SendKeys("25/12/2022");
            medicalPage.Comment.SendKeys("Svaki komentar je suvisan");
            medicalPage.BookApp.Submit();

            Assert.That("Appointment Confirmation", Is.EqualTo(medicalPage.Confirm.Text));

        }
    }
}