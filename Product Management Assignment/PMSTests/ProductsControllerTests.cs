using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMS.Controllers;
using System.Web.Mvc;
using System.Linq;
using System;
using PMS;
using PMS.Models;

namespace PMSTests
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void Index()
        {


            //Arrange
            ProductsController controller = new ProductsController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void Details()
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            //Arrange
            //  ProductsController controller = new ProductsController();

            //Act
            var result = _context.Products.ToList();

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
