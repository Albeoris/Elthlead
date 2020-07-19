using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elthlead.Framework
{
    public static class ExtensionsDelegate
    {
        public static IEnumerable<T> Enumerate<T>(this T action) where T : Delegate
        {
            if (action is null)
                yield break;

            foreach (T item in action.GetInvocationList().OfType<T>())
                yield return item;
        }
    }
}