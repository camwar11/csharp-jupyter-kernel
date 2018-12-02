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
            SaveConnectionFile(connectionFile, filePath);

            CSharp.Jupyter.Kernel.Program.Main(new string[] { filePath });

            Assert.Equal(0, Environment.ExitCode);
        }

        private static void SaveConnectionFile(ConnectionFile connectionFile, string filePath)
        {
            using (System.IO.TextWriter writer = new System.IO.StreamWriter(filePath))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(writer, connectionFile);
            }
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

        [Fact]
        public void ActualConfigFile()
        {            
            var connectionFile = new ConnectionFile()
            {
                ControlPort = 49719,
                HBPort = 49720,
                IOPubPort = 49717,
                IP = "127.0.0.1",
                Key = "55a7f5b9-1c79fe2f86fc46227253e2b7",
                ShellPort = 49716,
                SignatureScheme = "hmac-sha256",
                StdinPort = 49718,
                Transport = "tcp",
                KernelName = "csharp"
            };

            string filePath = "TestConnectionFile.json";

            SaveConnectionFile(connectionFile, filePath);
            
            CSharp.Jupyter.Kernel.Program.Running = true;

            CSharp.Jupyter.Kernel.Program.Main(new string[] { filePath });
        }
    }
}
