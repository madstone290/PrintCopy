using NUnit.Framework;
using SimPrinter.Core;
using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.NUnitTest
{
    public class ProductDistinguisherTest
    {
        [Test]
        public void IsPizza1()
        {
            ProductDistinguisher productDistinguisher = new ProductDistinguisher();

            var productType = productDistinguisher.Distinguish("콤비네이션 L");

            Assert.AreEqual(ProductType.Pizza, productType);
        }

        [Test]
        public void IsPizza2()
        {
            ProductDistinguisher productDistinguisher = new ProductDistinguisher();

            var productType = productDistinguisher.Distinguish("콤비네이션 세트 R");

            Assert.AreEqual(ProductType.Pizza, productType);

        }


        [Test]
        public void IsOther1()
        {
            ProductDistinguisher productDistinguisher = new ProductDistinguisher();

            var productType = productDistinguisher.Distinguish("콜라 1.25L");

            Assert.AreEqual(ProductType.SideDish, productType);
        }

        [Test]
        public void IsOther2()
        {
            ProductDistinguisher productDistinguisher = new ProductDistinguisher();

            var productType = productDistinguisher.Distinguish("콘치즈그라탕 L");

            Assert.AreEqual(ProductType.SideDish, productType);
        }
    }
}
