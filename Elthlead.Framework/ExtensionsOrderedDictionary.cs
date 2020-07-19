using System;
using System.Collections.Generic;
using System.Linq;

namespace Elthlead.Framework
{
    public static class ExtensionsDictionary
         {
             public static IEnumerable<Reference<TValue>> Enumerate<TValue>(this IDictionary<String, TValue> dic)
             {
                 foreach (var pair in dic)
                     yield return new Reference<TValue>(pair.Key, pair.Value);
             }
         }
}