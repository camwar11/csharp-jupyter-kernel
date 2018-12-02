using System;
using Xunit;
using CSharp.Jupyter.Kernel;

namespace test
{
    public class SmokeTests
    {
        [Fact]
        public void SmokeTestHappy()
        {
            var connectionFile = new ConnectionFile()
            {
                ControlPort = 1,
                HBPort = 2,
                IOPubPort = 3,
                IP = "127.0.0.1",
                Key = "abcdefg",
                ShellPort = 4,
                SignatureScheme = "sha",
                StdinPort = 5,
                Transport = "tcp"
            };

            
            string filePath = "connectionfile.json";

            using(System.IO.TextWriter writer = new System.IO.StreamWriter(filePath))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(writer, connectionFile); 
            } 

            CSharp.Jupyter.Kernel.Program.Main(new string[] { filePath });

            Assert.Equal(0, Environment.ExitCode);
        }

        [Fact]
        public void SmokeTestMissingFile()
        {
            CSharp.Jupyter.Kernel.Program.Main(new string[] { "missing" });

            Assert.Equal(1, Environment.ExitCode);
        }

        [Fact]
        public void SmokeTestNoArgs()
        {
            CSharp.Jupyter.Kernel.Program.Main(new string[] { });

            Assert.Equal(1, Environment.ExitCode);
        }
    }
}
