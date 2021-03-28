using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    public class Spy
    {

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] allFields = classType.GetFields(
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo item in allFields.Where(f => requestedFields.Contains(f.Name)))
            {
                result.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return result.ToString();

        }
    }
}
