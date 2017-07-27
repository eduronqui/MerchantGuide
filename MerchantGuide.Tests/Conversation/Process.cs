using MerchantGuide.Tests.Conversation.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.Tests.Conversation
{
    [TestClass]
    public class Process
    {

        [TestMethod]
        public void MustProcessAssignment()
        {
            var valuesStorage = new ValuesStorageMock();
            var processor = new MerchantGuide.Conversation.Processors.AssignmentProcessor(valuesStorage);

            processor.Process("um is I");

            Assert.IsTrue(valuesStorage.LiteralValues.ContainsKey("um"));
            Assert.AreEqual("I", valuesStorage.LiteralValues["um"]);
        }

        [TestMethod]
        public void MustProcessCreditAssignment()
        {
            var valuesStorage = new ValuesStorageMock();
            valuesStorage.AddLiteral("um", "I");

            var processor = new MerchantGuide.Conversation.Processors.CreditAssignmentProcessor(valuesStorage);

            processor.Process("um Prata is 5 Credits");

            Assert.IsTrue(valuesStorage.ComputedValues.ContainsKey("Prata"));
            Assert.AreEqual(5, valuesStorage.ComputedValues["Prata"]);
        }

        [TestMethod]
        public void MustProcessCreditAssignment_StoreValueOfOne()
        {
            var valuesStorage = new ValuesStorageMock();
            valuesStorage.AddLiteral("cinco", "V");

            var processor = new MerchantGuide.Conversation.Processors.CreditAssignmentProcessor(valuesStorage);

            processor.Process("cinco Prata is 5 Credits");

            Assert.IsTrue(valuesStorage.ComputedValues.ContainsKey("Prata"));
            Assert.AreEqual(1, valuesStorage.ComputedValues["Prata"]);
        }

        [TestMethod]
        public void MustProcessHowMuchAssignment()
        {
            var valuesStorage = new ValuesStorageMock();
            valuesStorage.AddLiteral("um", "I");

            var processor = new MerchantGuide.Conversation.Processors.HowMuchProcessor(valuesStorage);

            var answer = processor.Process("how much is um um um?");
            var expected = "um um um is 3";

            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void MustProcessHowManyAssignment()
        {
            var valuesStorage = new ValuesStorageMock();
            valuesStorage.AddLiteral("um", "I");
            valuesStorage.AddLiteral("cinco", "V");
            valuesStorage.AddComputed("Prata", 30);

            var processor = new MerchantGuide.Conversation.Processors.HowManyProcessor(valuesStorage);

            var answer = processor.Process("how many credits is um cinco Prata ?");
            var expected = "um cinco Prata is 120 Credits";

            Assert.AreEqual(expected, answer);
        }
    }
}
