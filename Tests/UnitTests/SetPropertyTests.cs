﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winterdom.BizTalk.PipelineTesting;

namespace BizTalkComponents.PipelineComponents.SetProperty
{
    [TestClass]
    public class SetPropertyTests
    {
        [TestMethod]
        public void TestSetProperty()
        {
            var pipeline = PipelineFactory.CreateEmptyReceivePipeline();
            var component = new PipelineComponents.SetProperty.SetProperty
            {
                PropertyPath = "http://tempuri.org#MyProp",
                Value = "Test"
            };

            pipeline.AddComponent(component, PipelineStage.Decode);

            var message = MessageHelper.Create("<test></test>");


            Assert.IsNull(message.Context.Read("MyProp", "http://tempuri.org"));

            var output = pipeline.Execute(message);

            Assert.AreEqual(1, output.Count);

            Assert.IsTrue(output[0].Context.IsPromoted("MyProp", "http://tempuri.org"));
        }
    }
}
