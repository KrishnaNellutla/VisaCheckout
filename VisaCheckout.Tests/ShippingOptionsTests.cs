﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class ShippingOptionsTests
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new ShippingOptions();

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("shipping:{"));
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new ShippingOptions
            {
                AcceptedRegions = "US",
                CollectShipping = true
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("shipping:{"));
            Assert.IsTrue(result.Contains("acceptedRegions:\"US\""));
            Assert.IsTrue(result.Contains("collectShipping:\"true\""));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            VisaCheckout.VisaHelper.Environment.IsSandbox = false;
        }
    }
}