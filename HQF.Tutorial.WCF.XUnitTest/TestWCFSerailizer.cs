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
        public void TestXmlSerialize()
        {
            var xmlFile = "sample_xml.xml";
            WCFSerailizer.ExportXmlSerializer(_fixture.CurrentEmployee,xmlFile);
            Assert.True(File.Exists(xmlFile));
        }

        [Fact]
        public void TestBinarySerialize()
        {
            var binaryFile = "binary.bin";
            WCFSerailizer.ExportBinarySerializer(_fixture.CurrentEmployee,binaryFile);
            Assert.True(File.Exists(binaryFile));
        }

        [Fact]
        public void TestNetDataContract()
        {
            var fileName = "NetDataContract.xml";
            WCFSerailizer.ExportNetDataContractSerializer(_fixture.CurrentEmployee,fileName);
            Assert.True(File.Exists(fileName));
        }

        [Fact]
        public void TestDataContract()
        {
            var dataContractFile = "DataContract.xml";
            WCFSerailizer.ExportDataContract(_fixture.CurrentEmployee,dataContractFile);
            Assert.True(File.Exists(dataContractFile));
        }

        [Fact]
        public void TestDataContractJson()
        {
            var josnFile = "DataContractJson.json";
            WCFSerailizer.ExportDataContractJsonSerilizer(_fixture.CurrentEmployee,josnFile);
            Assert.True(File.Exists(josnFile));
        }


    }
}