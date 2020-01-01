using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoRe.Core.Test.Classes
{
    public class TestConfiguration : Configuration
    {
        public int Integer { get; set; }
        public string String { get; set; }
        public decimal Decimal { get; set; }
        public bool Boolean { get; set; }
        public DateTime DateTime { get; set; }
        public TestConfigurationObject TestConfigurationObject { get; set; }

        public TestConfiguration(string path) : base(path) { }
        public TestConfiguration() { }

        public override void Read()
        {
            TestConfiguration tc = Read<TestConfiguration>();
            Integer = tc.Integer;
            String = tc.String;
            Decimal = tc.Decimal;
            Boolean = tc.Boolean;
            DateTime = tc.DateTime;
            TestConfigurationObject = tc.TestConfigurationObject;
        }

    }
}
