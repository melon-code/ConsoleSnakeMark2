using System;
using System.Reflection;

namespace ConsoleSnakeMark2Tests {
    public static class TestExtensionMethods {
        public static T GetFieldValue<T>(this object testObject, string name) {
            var field = testObject.GetType().GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)field?.GetValue(testObject);
        }

        public static T GetPropertyValue<T>(this object testObject, string name) {
            var field = testObject.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)field?.GetValue(testObject);
        }

        public static T InvokeMethod<T>(this object testObject, string name, params object[] parameters) {
            var method = testObject.GetType().GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            return (T)method?.Invoke(testObject, parameters);
        }

        public static T InvokeStaticMethod<T>(Type testObjectType, string name, params object[] parameters) {
            var method = testObjectType.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            return (T)method?.Invoke(null, parameters);
        }
    }
}
