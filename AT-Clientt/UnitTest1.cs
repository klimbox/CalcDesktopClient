using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
namespace AT_Client
{

    [TestClass]
    public class UnitTest1
    {
        private const string appPath = @"..\..\..\CalcDesktopClient\bin\Debug\CalcDesktopClient.exe";
        private static Window window1;
        [ClassInitialize]
        public static void Class_Init(TestContext context)
        {
            Application application = Application.Launch(appPath);
            window1 = application.GetWindow("Calculator", InitializeOption.WithCache);
        }

        [TestCleanup]
        public void Data_Clean()
        {
            window1.Close();
            Application application = Application.Launch(appPath);
            window1 = application.GetWindow("Calculator", InitializeOption.NoCache);
        }
        [ClassCleanup]
        public static void Class_Clean()
        {
            window1.Close();
        }
        [TestMethod]
        [DataRow("button1")]
        [DataRow("button2")]
        [DataRow("button3")]
        [DataRow("button4")]
        [DataRow("button5")]
        [DataRow("button6")]
        [DataRow("button7")]
        [DataRow("button8")]
        [DataRow("button9")]
        [DataRow("button10")]
        [DataRow("button11")]
        [DataRow("button12")]
        [DataRow("button13")]
        [DataRow("button14")]
        [DataRow("button15")]
        [DataRow("button16")]
        [DataRow("button17")]
        [DataRow("button18")]
        public void Button_presense(String id)
        {
            Button button = window1.Get<Button>(id);
            Assert.AreEqual(true, button.Visible);
        }

        [TestMethod]
        [DataRow("button1", "7")]
        [DataRow("button2", "9")]
        [DataRow("button3", "8")]
        [DataRow("button5", "4")]
        [DataRow("button6", "5")]
        [DataRow("button7", "6")]
        [DataRow("button9", "1")]
        [DataRow("button10", "2")]
        [DataRow("button11", "3")]
        [DataRow("button13", ",")]
        [DataRow("button14", "0")]
        public void Simple_Check(String id, String exp)
        {
            Button button = window1.Get<Button>(id);
            button.Click();
            Assert.AreEqual(exp, window1.Get<TextBox>("textBox1").Text);
        }
        [TestMethod]
        [DataRow("button1", "777")]
        [DataRow("button2", "999")]
        [DataRow("button3", "888")]
        [DataRow("button5", "444")]
        [DataRow("button6", "555")]
        [DataRow("button7", "666")]
        [DataRow("button9", "111")]
        [DataRow("button10", "222")]
        [DataRow("button11", "333")]
        [DataRow("button13", ",,,")]
        [DataRow("button14", "000")]
        public void Complex_Check(String id, String exp)
        {
            Button button = window1.Get<Button>(id);
            for (int i = 0; i < 3; i++)
            {
                button.Click();
            }
            Assert.AreEqual(exp, window1.Get<TextBox>("textBox1").Text);
        }
        [TestMethod]
        [DataRow("button1", "button5", "button4", "11")]
        [DataRow("button2", "button7", "button8", "3")]
        [DataRow("button3", "button10", "button12", "16")]
        [DataRow("button5", "button5", "button16", "1")]
        public void Real_job(String fNum, String sNum, String op, String exp)
        {
            Button fButton = window1.Get<Button>(fNum);
            Button sButton = window1.Get<Button>(sNum);
            Button OpButton = window1.Get<Button>(op);
            Button ResButton = window1.Get<Button>("button17");
            fButton.Click();
            OpButton.Click();
            sButton.Click();
            ResButton.Click();
           // Assert.AreEqual(exp, window1.Get<TextBox>("textBox1").Text);
        }
    }
}
