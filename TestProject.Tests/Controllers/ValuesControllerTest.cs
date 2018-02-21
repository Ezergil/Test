using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Упорядочение
            CategoriesController controller = new CategoriesController();

            // Действие
            IEnumerable<string> result = controller.Get();

            // Утверждение
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Упорядочение
            CategoriesController controller = new CategoriesController();

            // Действие
            string result = controller.Get(5);

            // Утверждение
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Упорядочение
            CategoriesController controller = new CategoriesController();

            // Действие
            controller.Post("value");

            // Утверждение
        }

        [TestMethod]
        public void Put()
        {
            // Упорядочение
            CategoriesController controller = new CategoriesController();

            // Действие
            controller.Put(5, "value");

            // Утверждение
        }

        [TestMethod]
        public void Delete()
        {
            // Упорядочение
            CategoriesController controller = new CategoriesController();

            // Действие
            controller.Delete(5);

            // Утверждение
        }
    }

    public class CategoriesController
    {
        public IEnumerable<string> Get()
        {
            throw new System.NotImplementedException();
        }

        public void Post(string value)
        {
            throw new System.NotImplementedException();
        }

        public void Put(int i, string value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int i)
        {
            throw new System.NotImplementedException();
        }

        internal string Get(int v)
        {
            throw new NotImplementedException();
        }
    }
}
