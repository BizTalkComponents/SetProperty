using BizTalkComponents.Utils;
using BizTalkComponents.Utils.ContextExtensions;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;

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

        public string PropertyPath { get; set; }
        public string Value { get; set; }

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            pInMsg.Context.Promote(new ContextProperty(PropertyPath),Value);

            return pInMsg;
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            if (string.IsNullOrEmpty(PropertyPath))
            {
                PropertyPath = PropertyBagHelper.ToStringOrDefault(PropertyBagHelper.ReadPropertyBag(propertyBag, PropertyPathPropertyName), string.Empty);
            }

            if (string.IsNullOrEmpty(Value))
            {
                Value = PropertyBagHelper.ToStringOrDefault(PropertyBagHelper.ReadPropertyBag(propertyBag, ValuePropertyName), string.Empty);
            }   
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            PropertyBagHelper.WritePropertyBag(propertyBag, PropertyPathPropertyName, PropertyPath);
            PropertyBagHelper.WritePropertyBag(propertyBag, ValuePropertyName, Value);
        }
    }
}
