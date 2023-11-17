using Interfaces.RequestBody;
using Logic.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Mock;

namespace Test
{
    [TestClass]
    public class RuleTest
    {
        private RuleMock ruleMock;
        private RuleContainer ruleContainer;

        [TestInitialize]
        public void init()
        {
            ruleMock = new RuleMock();
            ruleContainer = new RuleContainer(ruleMock);
        }

        [TestMethod]
        public void TestGetRules()
        {
            var rules = ruleContainer.GetRules().Result;
            Assert.AreEqual(3, rules.Count);
            Assert.AreEqual("Rule 1", rules[0].RuleDescription);
        }

        [TestMethod]
        public void TestGetRule()
        {
            var rule = ruleContainer.GetRule(2).Result;
            Assert.AreEqual("Rule 2", rule.RuleDescription);
        }

        [TestMethod]
        public void TestCreateRule()
        {
            RuleBody ruleBody = new RuleBody
            {
                RuleDescription = "Rule 4"
            };
            ruleContainer.CreateRule(ruleBody).Wait();
            var rule = ruleContainer.GetRule(4).Result;
            Assert.AreEqual("Rule 4", rule.RuleDescription);
        }

        [TestMethod]
        public void TestUpdateRule()
        {
            RuleBody ruleBody = new RuleBody
            {
                RuleDescription = "Rule 4"
            };
            ruleContainer.UpdateRule(3, ruleBody).Wait();
            var rule = ruleContainer.GetRule(3).Result;
            Assert.AreEqual("Rule 4", rule.RuleDescription);
        }

        [TestMethod]
        public void TestDeleteRule()
        {
            ruleContainer.DeleteRule(3).Wait();
            var rules = ruleContainer.GetRules().Result;
            Assert.AreEqual(2, rules.Count);
        }
    }
}
