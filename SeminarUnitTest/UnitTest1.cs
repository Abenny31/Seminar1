using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seminar_algebra.Controllers;
using System.Web.Mvc;



namespace SeminarUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHomeIndex()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

       

       
            
    }
}
