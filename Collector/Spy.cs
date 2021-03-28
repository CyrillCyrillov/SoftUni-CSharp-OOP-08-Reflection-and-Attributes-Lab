using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classlFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder resultMistakes = new StringBuilder();

            foreach (FieldInfo item in classlFields)
            {
                resultMistakes.AppendLine($"{item.Name} must private!");
            }

            foreach (MemberInfo item in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                resultMistakes.AppendLine($"{item.Name} have to be public!");
            }

            foreach (MemberInfo item in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                resultMistakes.AppendLine($"{item.Name} have to be private!");
            }

            return resultMistakes.ToString();
        }



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

        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder resultPrivateMethods = new StringBuilder();

            resultPrivateMethods.AppendLine($"All Private Methods of Class: {investigatedClass}");
            resultPrivateMethods.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MemberInfo item in classMethods)
            {
                resultPrivateMethods.AppendLine(item.Name);
            }

            return resultPrivateMethods.ToString();

        }

        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);

            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder resultGettersAndSetters = new StringBuilder();

            foreach (MethodInfo item in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                resultGettersAndSetters.AppendLine($"{item.Name} will return {item.ReturnType}");
            }

            foreach (MethodInfo item in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                resultGettersAndSetters.AppendLine($"{item.Name} will return {item.GetParameters().First().ParameterType}");
            }

            return resultGettersAndSetters.ToString();
        }
    }
}
