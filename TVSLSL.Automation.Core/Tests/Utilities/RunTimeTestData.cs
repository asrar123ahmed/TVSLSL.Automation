namespace TVSLSL.Automation.Common.Tests.Utilities
{
    using System.Collections.Generic;

    public static class RunTimeTestData
    {
        private static Dictionary<string, object> testData;

        static RunTimeTestData()
        {
            testData = new Dictionary<string, object>();
        }

        public static void AddTestData(string key, object value)
        {
            testData.Add(key, value);
        }

        public static void ClearTestData()
        {
            testData.Clear();
        }

        public static object GetTestData(string key)
        {
            return testData[key];
        }
    }
}
