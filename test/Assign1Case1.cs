using Xunit;
using System.Text.RegularExpressions;
using System.IO;
using System;

namespace csharpassignment
{
    public class Assign1Case1
    {
        [Fact]
        public void ConsoleOutputTest()
        {
            string[] expectedArray = { 
                "************************************",
                "*  The stars shine in Greenville.  *",
                "************************************"
            };

            //set output
            var output = new StringWriter();
            Console.SetOut(output);

            GreenvilleMotto.Main();

            //parse the output into a string array 
            //then check each index in the array below
            var arrayFromMainMethod = output.ToString().Split("\n");

            for (int i = 0; i < expectedArray.Length; i++)
            {
                //removing the \r will make End Of Line Windows vs *nux a non-issue
                Assert.Equal(expectedArray[i], arrayFromMainMethod[i].Replace("\r", ""));
            }

            //use regex to match console output as well
            Assert.Matches(new Regex(@"\*{36}"), arrayFromMainMethod[0]);
            Assert.Matches(new Regex(@"\*([\s]{2})The stars shine in Greenville.([\s]{2})\*"), arrayFromMainMethod[1]);
            Assert.Matches(new Regex(@"\*{36}"), arrayFromMainMethod[2]);

            //clean up
            output.Dispose();
        }
    }
}
