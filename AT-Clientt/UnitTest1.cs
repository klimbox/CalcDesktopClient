using System;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using NUnit.Framework;

namespace AT_Client
{

    [TestFixture]
    public class UnitTest1
    {

        private const string appPath = @"D:\Client desktop\CalcDesktopClient\CalcDesktopClient\bin\Debug\CalcDesktopClient.exe";


        private  Window window1;
        //[Initialize]
        //public static void Class_Init(TestContext context)
        //{
        //    Application application = Application.Launch(appPath);
        //    window1 = application.GetWindow("Calculator", InitializeOption.WithCache);
        //}

        //[TestCleanup]
        //public static void Data_Clean()
        //{
        //    window1.Close();
        //    Application application = Application.Launch(appPath);
        //    window1 = application.GetWindow("Calculator", InitializeOption.NoCache);
        //}
        //[ClassCleanup]
        //public static void Class_Clean()
        //{
        //    window1.Close();
        //}

        [TestCase("button1")]
        [TestCase("button2")]
        [TestCase("button3")]
        [TestCase("button4")]
        [TestCase("button5")]
        [TestCase("button6")]
        [TestCase("button7")]
        [TestCase("button8")]
        [TestCase("button9")]
        [TestCase("button10")]
        [TestCase("button11")]
        [TestCase("button12")]
        [TestCase("button13")]
        [TestCase("button14")]
        [TestCase("button15")]
        [TestCase("button16")]
        [TestCase("button17")]
        [TestCase("button18")]
        [Test]
        public void Button_presense(String id)
        {
            Application application = Application.Launch(appPath);
            window1 = application.GetWindow("Calculator", InitializeOption.WithCache);
            Button button = window1.Get<Button>(id);
            Assert.AreEqual(true, button.Visible);
            window1 = application.GetWindow("Calculator", InitializeOption.NoCache);
            window1.Close();
        }

        [TestCase("button1", "7")]
        [TestCase("button2", "9")]
        [TestCase("button3", "8")]
        [TestCase("button5", "4")]
        [TestCase("button6", "5")]
        [TestCase("button7", "6")]
        [TestCase("button9", "1")]
        [TestCase("button10", "2")]
        [TestCase("button11", "3")]
        [TestCase("button13", ",")]
        [TestCase("button14", "0")]
        [Test]
        public void Simple_Check(String id, String exp)
        {
            Application application = Application.Launch(appPath);
            window1 = application.GetWindow("Calculator", InitializeOption.WithCache);
            Button button = window1.Get<Button>(id);
            button.Click();
            Assert.AreEqual(exp, window1.Get<TextBox>("textBox1").Text);
            window1 = application.GetWindow("Calculator", InitializeOption.NoCache);
            window1.Close();
        }
        [TestCase("button1", "777")]
        [TestCase("button2", "999")]
        [TestCase("button3", "888")]
        [TestCase("button5", "444")]
        [TestCase("button6", "555")]
        [TestCase("button7", "666")]
        [TestCase("button9", "111")]
        [TestCase("button10", "222")]
        [TestCase("button11", "333")]
        [TestCase("button13", ",,,")]
        [TestCase("button14", "000")]
        [Test]
        public void Complex_Check(String id, String exp)
        {
            Application application = Application.Launch(appPath);
            window1 = application.GetWindow("Calculator", InitializeOption.WithCache);
            Button button = window1.Get<Button>(id);
            for (int i = 0; i < 3; i++)
            {
                button.Click();
            }
            Assert.AreEqual(exp, window1.Get<TextBox>("textBox1").Text);
            window1 = application.GetWindow("Calculator", InitializeOption.NoCache);
            window1.Close();
        }
        [TestCase("button1", "button5", "button4", "11")]
        [TestCase("button2", "button7", "button8", "3")]
        [TestCase("button3", "button10", "button12", "16")]
        [TestCase("button5", "button5", "button16", "1")]
        [Test]
        public void Real_job(String fNum, String sNum, String op, String exp)
        {
            Application application = Application.Launch(appPath);
            window1 = application.GetWindow("Calculator", InitializeOption.WithCache);
            Button fButton = window1.Get<Button>(fNum);
            Button sButton = window1.Get<Button>(sNum);
            Button OpButton = window1.Get<Button>(op);
            Button ResButton = window1.Get<Button>("button17");
            fButton.Click();
            OpButton.Click();
            sButton.Click();
            ResButton.Click();
            // Assert.AreEqual(exp, window1.Get<TextBox>("textBox1").Text);
            window1 = application.GetWindow("Calculator", InitializeOption.NoCache);
            window1.Close();
        }
    }
}
