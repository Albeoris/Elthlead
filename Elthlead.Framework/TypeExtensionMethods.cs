using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Elthlead.Framework
{
    public static class ExtensionsReflection
    {
        public static Type RequireType(this Assembly assembly, String typeName)
        {
            return assembly.GetType(typeName, throwOnError: true, ignoreCase: false);
        }

        public static FieldInfo RequireStaticField(this Type type, String fieldName)
        {
            return type.GetField(fieldName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                   ?? throw new NullReferenceException($"Cannot find the static field [{fieldName}] of type [{type}].");
        }

        public static MethodInfo RequireStaticMethod(this Type type, String methodName)
        {
            return RequireStaticMethod(type, methodName, isGeneric: false);
        }
        
        public static MethodInfo RequireStaticMethod<T>(this Type type, String methodName)
        {
            MethodInfo methodDefinition = RequireStaticMethod(type, methodName, isGeneric: true);
            return methodDefinition.MakeGenericMethod(typeof(T));
        }

        public static MethodInfo RequireStaticMethod(this Type type, String methodName, params Type[] arguments)
        {
            return RequireStaticMethod(type, methodName, isGeneric: false, arguments);
        }
        
        private static MethodInfo RequireStaticMethod(this Type type, String methodName, Boolean isGeneric, Type[] arguments = null)
        {
            IEnumerable<MethodInfo> methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            methods = methods.Where(m => m.Name == methodName);
            methods = methods.Where(m => m.IsGenericMethodDefinition == isGeneric);
            if (arguments != null)
                methods = methods.Where(m => Filter(m, arguments));
            return methods.SingleOrDefault() ?? throw new NullReferenceException($"Cannot find the static method [{methodName}] of type [{type}].");
        }

        private static Boolean Filter(MethodInfo method, Type[] arguments)
        {
            var parameters = method.GetParameters();
            if (parameters.Length != arguments.Length)
            {
                Log.Message($"Invalid params: {parameters.Length} != {arguments.Length}");
                return false;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType != arguments[i])
                {
                    Log.Message($"Invalid param {i}: {parameters[i].ParameterType} != {arguments[i]}");
                    return false;
                }
            }

            return true;
        }

        public static MethodInfo RequireInstanceMethod(this Type type, String methodName)
        {
            return type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   ?? throw new NullReferenceException($"Cannot find the instance method [{methodName}] of type [{type}].");
        }

        public static StaticFieldAccessor<T> Access<T>(this FieldInfo self)
        {
            if (self.IsStatic)
                return new StaticFieldAccessor<T>(self);

            throw new NotSupportedException(self.Name);
        }
    }
}