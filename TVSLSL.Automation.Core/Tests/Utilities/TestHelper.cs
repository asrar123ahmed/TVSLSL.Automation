namespace TVSLSL.Automation.Common.Tests.Utilities
{
    using System;
    using System.Text.RegularExpressions;
    using System.Threading;

    public static class TestHelper
    { 
        //Utilty class - holds methods that might be useful for UI tests

        public static bool IsAplhabetical(string textA, string textB)
        {
            int minTextLength = (textA.Length > textB.Length ? textB.Length : textA.Length);

            char[] textAChars = textA.ToLower().ToCharArray();
            char[] textBChars = textB.ToLower().ToCharArray();

            int i = 0;
            do
            {
                if (i == minTextLength)
                {
                    if (textA.Length > textB.Length)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                if (textAChars[i] < textBChars[i])
                {
                    return true;
                }

                if (textAChars[i] > textBChars[i])
                {
                    return false;
                }

                i++;
            }
            while (true);
        }

        public static bool ContainsAlphaNumericCharacters(string text)
        {
            return new Regex("^[a-zA-Z0-9]*$").IsMatch(text);
        }

        public static string GenerateRandomAlphaText(int textlength)
        {
            string availableCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return GenerateRandomText(textlength, availableCharacters);
        }

        public static string GenerateRandomNumericText(int textlength)
        {
            string availableCharacters = "0123456789";
            return GenerateRandomText(textlength, availableCharacters);
        }

        public static string GetDigitsOnly(string text)
        {
            Regex digitsOnly = new Regex(@"[^\d]");

            return digitsOnly.Replace(text, string.Empty);
        }

        public static string GetTodaysDate(string format, int modifyDays = 0)
        {
            DateTime datetime = DateTime.Now;

            if (modifyDays != 0)
            {
                datetime = datetime.AddDays(modifyDays);
            }

            return datetime.ToString(format);
        }

        public static void HandleActionOrAssertionException(string stepDescription, Exception ex)
        {
            TestLogger.CurrentTestStep.MarkAsFailure(ex);
            HandleException(stepDescription, ex);
        }

        public static void HandleException(string message, Exception ex)
        {      
            throw new Exception(message, ex.InnerException);
        }

        public static string RemoveNonNumericCharacters(string text)
        {
            return Regex.Replace(text, "[^0-9]", "");
        }

        public static string RemoveNewlineCharacters(string text)
        {
            if (text == null)
            {
                return string.Empty;
            }

            text = text.Replace(Environment.NewLine, " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\r", " ");

            return text;
        }

        private static string GenerateRandomText(int textlength, string availableCharacters)
        {            
            Thread.Sleep(1);
            char[] randomString = new char[textlength];
            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < randomString.Length; i++)
            {
                int randomIndex = random.Next(availableCharacters.Length);
                randomString[i] = availableCharacters[randomIndex];
            }

            return new String(randomString);
        }
    }
}