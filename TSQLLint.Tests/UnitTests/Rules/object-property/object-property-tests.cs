using System;
using System.Collections.Generic;
using NUnit.Framework;
using TSQLLint.Lib.Rules;
using TSQLLint.Lib.Rules.RuleViolations;

namespace TSQLLint.Tests.UnitTests.Rules
{
    public class ObjectPropertyRuleTests
    {
        private static readonly object[] testCases = 
        {
            new object[]
            {
                "object-property", "object-property-no-error",  typeof(ObjectPropertyRule), new List<RuleViolation>()
            },
            new object[]
            {
                "object-property", "object-property-one-error", typeof(ObjectPropertyRule), new List<RuleViolation>
                {
                    new RuleViolation(ruleName: "object-property", startLine: 3, startColumn: 7)
                }
            },
            new object[]
            {
                "object-property", "object-property-two-errors", typeof(ObjectPropertyRule), new List<RuleViolation>
                {
                    new RuleViolation(ruleName: "object-property", startLine: 3, startColumn: 7),
                    new RuleViolation(ruleName: "object-property", startLine: 8, startColumn: 7)
                }
            },
            new object[]
            {
                "object-property", "object-property-one-error-mixed-state", typeof(ObjectPropertyRule), new List<RuleViolation>
                {
                    new RuleViolation(ruleName: "object-property", startLine: 5, startColumn: 7)
                }
            }
        };
        
        [Test, TestCaseSource("testCases")]
        public void TestRule(string rule, string testFileName, Type ruleType, List<RuleViolation> expectedRuleViolations)
        {
            RulesTestHelper.RunRulesTest(rule, testFileName, ruleType, expectedRuleViolations);
        }
    }
}
