using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BizTalkComponents.Utils;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using IComponent = Microsoft.BizTalk.Component.Interop.IComponent;

namespace BizTalkComponents.PipelineComponents.SetProperty
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("D219F6DA-473A-4E3C-B0C3-24F764A22148")]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    public partial class SetProperty : IComponent, IBaseComponent,
                                        IPersistPropertyBag, IComponentUI
    {
        private const string PropertyPathPropertyName = "PropertyPath";
        private const string ValuePropertyName = "Value";
        private const string PromoteProperytName = "Promote";

        [DisplayName("Property Path")]
        [Description("The property path where the specified value will be promoted to, i.e. http://temupuri.org#MyProperty.")]
        [RegularExpression(@"^.*#.*$",
         ErrorMessage = "A property path should be formatted as namespace#property.")]
        [RequiredRuntime]
        public string PropertyPath { get; set; }

        [DisplayName("Value")]
        [Description("The value that should be promoted to the specified property.")]
        [RequiredRuntime]
        public string Value { get; set; }

        [DisplayName("Promote Property")]
        [Description("Specifies whether the property should be promoted or just written to the context.")]
        [RequiredRuntime]
        public bool PromoteProperty { get; set; }

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            string errorMessage;

            if (!Validate(out errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            pInMsg.Context.Promote(new ContextProperty(PropertyPath), Value);

            return pInMsg;
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            PropertyPath = PropertyBagHelper.ToStringOrDefault(PropertyBagHelper.ReadPropertyBag(propertyBag, PropertyPathPropertyName), string.Empty);
            Value = PropertyBagHelper.ToStringOrDefault(PropertyBagHelper.ReadPropertyBag(propertyBag, ValuePropertyName), string.Empty);
            PromoteProperty = PropertyBagHelper.ReadPropertyBagBool(propertyBag, PromoteProperytName);
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            PropertyBagHelper.WritePropertyBag(propertyBag, PropertyPathPropertyName, PropertyPath);
            PropertyBagHelper.WritePropertyBag(propertyBag, ValuePropertyName, Value);
            PropertyBagHelper.WritePropertyBag(propertyBag, PromoteProperytName, PromoteProperty);
        }
    }
}
