namespace TVSLSL.Automation.Common.Tests.Utilities
{
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using System;

    public static class Asserter
    {
        public static void AssertThat<T>(T actual, IResolveConstraint expression, string message, bool createTestStep = true)
        {
            if (createTestStep)
            {
                TestLogger.CreateTestStep(message);
            }

            try
            {
                Assert.That(actual, expression, message);
            }
            catch (Exception e)
            {
                TestLogger.CurrentTestStep.MarkAsFailure(e);
                throw e;
            }
        }
    }
}