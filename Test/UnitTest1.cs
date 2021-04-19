using NUnit.Framework;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace SchemaWritter.Test
{
    public class Tests
    {
        [Test]
        public void itShouldWritteSchemaCorrectly()
        {
            string projectDir = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().IndexOf("/bin"));
            string schemaDir = projectDir + "/docker/schema.sql";
            if(File.Exists(schemaDir))
            {
                File.Delete(schemaDir);
            }
            Program.Main(new string[]{projectDir});
            Assert.True(File.Exists(schemaDir));
            string[] lines = File.ReadAllLines(schemaDir);
            Assert.That(lines.Length > 1);
        }
    }
}