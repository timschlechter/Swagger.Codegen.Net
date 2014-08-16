using ApprovalTests;
using ApprovalTests.Core;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Swagger.Codegen.Processors.CSharp;
using System;
using System.IO;
using System.Text;

namespace Swagger.Codegen.Tests
{
    [TestFixture]
    [UseReporter(typeof(BeyondCompareReporter))]
    public class CSharpProcessorTests
    {
        [Test]
        public void Process_PetStore_ShouldBeApproved()
        {
            using (var stream = new MemoryStream())
            {
                var codeGenerator = new Codegenerator();
                codeGenerator.Process(
                    new CodegenSettings
                    {
                        ApiName = "Petstore",
                        ApiUrl = "http://petstore.swagger.wordnik.com/api/api-docs",
                        Processor = new CSharpProcessor(),
                        Namespace = "SomeNamespace"
                    },
                    stream
                );

                var result = Encoding.UTF8.GetString(stream.ToArray());

                Approvals.Verify(result);                 
            }
        }
    }
}