using clientWebApp;
using clientWebApp.Controllers;
using System.Web.Mvc;
namespace NunitTest
{
    public class Tests
    {
        HomeController hm;
        [SetUp]
        public void Setup()
        {
            hm = new HomeController();
        }
        [Test]
        public void ActionFunctionality()
        {
            
        }
    }
}