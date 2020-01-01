using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoRe.Core.Test
{
    [TestClass]
    public class ConfigurationTests
    {
        private string Path = System.IO.Path.Combine(Pathmanager.ConfigurationDirectory, "test.xml");

        [TestMethod]
        public void TestWrite()
        {
            try
            {
                Classes.TestConfiguration tc = new Classes.TestConfiguration();
                tc.Write();
                Assert.Fail("No exception has been thrown");
            }
            catch { }

            try
            {
                Classes.TestConfiguration tc = GetConfig();

                Assert.AreEqual(Path, tc.Path, true, "Path not equal");

                tc.Write();

                Assert.IsTrue(System.IO.File.Exists(Path), "Xml was not written");
            }
            finally
            {
                DeleteConfig();
            }

        }

        [TestMethod]
        public void TestRead()
        {

            try
            {
                Classes.TestConfiguration tc = new Classes.TestConfiguration();
                tc.Read();
                Assert.Fail("No exception has been thrown");
            }
            catch { }

            try
            {
                Classes.TestConfiguration tcw = GetConfig();
                tcw.Write();

                Classes.TestConfiguration tcr = new Classes.TestConfiguration(Path);
                tcr.Read();

                Assert.AreEqual(tcw.Boolean, tcr.Boolean, "Booleans are not equal");
                Assert.AreEqual(tcw.DateTime, tcr.DateTime, "DateTimes are not equal");
                Assert.AreEqual(tcw.Decimal, tcr.Decimal, "Decimals are not equal");
                Assert.AreEqual(tcw.Integer, tcr.Integer, "Intergers are not equal");
                Assert.AreEqual(tcw.String, tcr.String, "Strings are not equal");
                Assert.AreEqual(tcw.TestConfigurationObject.NegativeDecimal, tcr.TestConfigurationObject.NegativeDecimal, "Negative decimal are not equal");
                Assert.AreEqual(tcw.TestConfigurationObject.NegativeInteger, tcr.TestConfigurationObject.NegativeInteger, "Negative integer are not equal");
            }
            finally
            {
                DeleteConfig();
            }

        }

        private Classes.TestConfiguration GetConfig()
        {
            Classes.TestConfiguration tc = new Classes.TestConfiguration(Path);
          
            tc.Boolean = true;
            tc.DateTime = DateTime.Now; ;
            tc.Decimal = 85.94M;
            tc.Integer = 61;
            tc.String = "HelloWorld!";

            tc.TestConfigurationObject = new Classes.TestConfigurationObject()
            {
                NegativeDecimal = -101.202M,
                NegativeInteger = -132
            };

            return tc;
        }

        private void DeleteConfig()
        {
            try
            {
                System.IO.Directory.Delete(Pathmanager.ConfigurationDirectory, true);
            }
            catch { }

        }

    }
}
