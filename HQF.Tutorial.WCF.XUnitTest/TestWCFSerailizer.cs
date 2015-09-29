using System.IO;
using Xunit;

namespace HQF.Tutorial.WCF.Serializer.XUnitTest
{
    public class TestWCFSerailizer : IClassFixture<SerializerFixture>
    {
        private SerializerFixture _fixture;

        public TestWCFSerailizer(SerializerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void TestXsdCreator()
        {
            var xsdFile = "sample.xsd";
            WCFSerailizer.ExportXsd<Employee>(xsdFile);
            Assert.True(File.Exists(xsdFile));
        }

        [Fact]
        public void TestNetDataContract()
        {
            var fileName = "sample.xml";
            WCFSerailizer.ExportNetDataContractSerializer<Employee>(_fixture.CurrentEmployee,fileName);
            Assert.True(File.Exists(fileName));
        }
    }
}