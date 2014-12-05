using System;
using System.Collections;
using System.Linq;
using BizTalkComponents.Utils;

namespace BizTalkComponents.PipelineComponents.SetProperty
{
    public partial class SetProperty
    {
        public string Name { get { return "SetProperty"; } }
        public string Version { get { return "1.0"; } }
        public string Description { get { return "Promotes a value to a specified context property."; } }

        public void GetClassID(out Guid classID)
        {
            classID = new Guid("DF2A20CE-F884-469C-B4DC-0ADFF1E51111");
        }

        public void InitNew()
        {

        }

        public IEnumerator Validate(object projectSystem)
        {
            return ValidationHelper.Validate(this, false).ToArray().GetEnumerator();
        }

        public bool Validate(out string errorMessage)
        {
            var errors = ValidationHelper.Validate(this, true).ToArray();

            if (errors.Any())
            {
                errorMessage = string.Join(",", errors);

                return false;
            }

            errorMessage = string.Empty;

            return true;
        }

        public IntPtr Icon { get { return IntPtr.Zero; } }
    }
}
