﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class VisaUpdateImageOptionTests
    {
        [TestMethod]
        public void GetHtmlProductionTest()
        {
            VisaHelper.Environment.IsSandbox = false;
            IOptions options = new VisaUpdateImageOptions("shared_Key", "abc123", EventTypes.Confirm, "apiKey", 21M, 22M, CurrencyCodes.USD);

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(VisaUpdateImageOptions.ProductionUrl));
            Assert.IsTrue(result.Contains("eventType=Confirm"));
            Assert.IsTrue(result.Contains("apikey=apiKey"));
            Assert.IsTrue(result.Contains("subtotal=21.00"));
            Assert.IsTrue(result.Contains("total=22.00"));
            Assert.IsTrue(result.Contains("currencyCode=USD"));
        }

        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new VisaUpdateImageOptions("shared_Key", "abc123", EventTypes.Confirm, "apiKey", 21M, 22M, CurrencyCodes.USD);

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(VisaUpdateImageOptions.SandboxUrl));
            Assert.IsTrue(result.Contains("eventType=Confirm"));
            Assert.IsTrue(result.Contains("apikey=apiKey"));
            Assert.IsTrue(result.Contains("subtotal=21.00"));
            Assert.IsTrue(result.Contains("total=22.00"));
            Assert.IsTrue(result.Contains("currencyCode=USD"));
        }

        [TestMethod]
        public void GetHtmlTestWithPaymentRequestTest()
        {
            IOptions options = new VisaUpdateImageOptions("shared_Key", "abc123", EventTypes.Confirm, "apiKey", new PaymentRequestOptions
            {
                CurrencyCode = CurrencyCodes.USD,
                Subtotal = 21M,
                Total = 22M
            });

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(VisaUpdateImageOptions.SandboxUrl));
            Assert.IsTrue(result.Contains("eventType=Confirm"));
            Assert.IsTrue(result.Contains("apikey=apiKey"));
            Assert.IsTrue(result.Contains("subtotal=21.00"));
            Assert.IsTrue(result.Contains("total=22.00"));
            Assert.IsTrue(result.Contains("currencyCode=USD"));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            VisaHelper.Environment.IsSandbox = true;
        }
    }
}