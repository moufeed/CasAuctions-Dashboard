using System; 

namespace TamTech.CasAuctions.Dashboard.SDK.Core.Attributes
{
   public class ControllerNameAttribute : Attribute
    {
        public string Name { get; }

        public ControllerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
