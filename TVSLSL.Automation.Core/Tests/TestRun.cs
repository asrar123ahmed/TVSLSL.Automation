namespace TVSLSL.Automation.Common.Tests
{
    using System;
    using System.IO;

    public static class TestRun
    {
        private static string testResultsDirectory = null;

        public static string SelectedBrowser { get; set; }

        public static string SelectedEnvironment { get; set; }

        public static string SelectedPlatform { get; set; }

        public static string GetCurrentTestResultDirectory()
        {
            if (testResultsDirectory == null)
            {
                string parentDirectory = string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\..\..\Test Runs");
                parentDirectory = Path.GetFullPath(parentDirectory);

                Directory.SetCurrentDirectory(parentDirectory);

                testResultsDirectory = string.Format(@"{0}\TESTRUN_{1}", parentDirectory,
                                                                         DateTime.Now.ToString("dd.MM.yyyy HH_mm_ss"));

                DirectoryInfo testDirectory = Directory.CreateDirectory(testResultsDirectory);
                Directory.SetCurrentDirectory(testDirectory.FullName);

                return testDirectory.FullName;
            }
            else
            {
                return testResultsDirectory;
            }
        }

        public static string GetSelectedBrowser()
        {
            return SelectedBrowser.ToLower();
        }
    }
}