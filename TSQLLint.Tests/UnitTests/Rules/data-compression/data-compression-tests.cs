using System;
using System.Collections.Generic;
using NUnit.Framework;
using TSQLLint.Lib.Rules;
using TSQLLint.Lib.Rules.RuleViolations;

namespace TSQLLint.Tests.UnitTests.Rules
{
    public class DataCompressionRuleTests
    {
        private static readonly object[] testCases = 
        {
            new object[]
            {
                "data-compression", "data-compression-no-error",  typeof(DataCompressionOptionRule), new List<RuleViolation>()
            },
            new object[]
            {
                "data-compression", "data-compression-one-error", typeof(DataCompressionOptionRule), new List<RuleViolation>
                {
                    new RuleViolation(ruleName: "data-compression", startLine: 1, startColumn: 1)
                }
            },
            new object[]
            {
                "data-compression", "data-compression-two-errors", typeof(DataCompressionOptionRule), new List<RuleViolation>
                {
                    new RuleViolation(ruleName: "data-compression", startLine: 1, startColumn: 1),
                    new RuleViolation(ruleName: "data-compression", startLine: 5, startColumn: 1)
                }
            },
            new object[]
            {
                "data-compression", "data-compression-one-error-mixed-state", typeof(DataCompressionOptionRule), new List<RuleViolation>
                {
                    new RuleViolation(ruleName: "data-compression", startLine: 6, startColumn: 1)
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
