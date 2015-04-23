using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winterdom.BizTalk.PipelineTesting;

namespace BizTalkComponents.PipelineComponents.SetProperty.Tests.UnitTests
{
    [TestClass]
    public class SetPropertyTests
    {
        [TestMethod]
        public void TestSetPropertyPromote()
        {
            var pipeline = PipelineFactory.CreateEmptyReceivePipeline();
            var component = new SetProperty
            {
                PropertyPath = "http://tempuri.org#MyProp",
                Value = "Test",
                PromoteProperty = true
            };

            pipeline.AddComponent(component, PipelineStage.Decode);

            var message = MessageHelper.Create("<test></test>");


            Assert.IsNull(message.Context.Read("MyProp", "http://tempuri.org"));

            var output = pipeline.Execute(message);

            Assert.AreEqual(1, output.Count);

            Assert.IsTrue(output[0].Context.IsPromoted("MyProp", "http://tempuri.org"));
        }


        [TestMethod]
        public void TestSetPropertyWrite()
        {
            var pipeline = PipelineFactory.CreateEmptyReceivePipeline();
            var component = new SetProperty
            {
                PropertyPath = "http://tempuri.org#MyProp",
                Value = "Test",
                PromoteProperty = false
            };

            pipeline.AddComponent(component, PipelineStage.Decode);

            var message = MessageHelper.Create("<test></test>");


            Assert.IsNull(message.Context.Read("MyProp", "http://tempuri.org"));

            var output = pipeline.Execute(message);

            Assert.AreEqual(1, output.Count);

            Assert.IsFalse(output[0].Context.IsPromoted("MyProp", "http://tempuri.org"));
        }

        [TestMethod]
        public void TestSetPropertyPromotePropertyNotSet()
        {
            var pipeline = PipelineFactory.CreateEmptyReceivePipeline();
            var component = new SetProperty
            {
                PropertyPath = "http://tempuri.org#MyProp",
                Value = "Test"
            };

            pipeline.AddComponent(component, PipelineStage.Decode);

            var message = MessageHelper.Create("<test></test>");


            Assert.IsNull(message.Context.Read("MyProp", "http://tempuri.org"));

            var output = pipeline.Execute(message);

            Assert.AreEqual(1, output.Count);

            Assert.IsFalse(output[0].Context.IsPromoted("MyProp", "http://tempuri.org"));
        }
    }
}
