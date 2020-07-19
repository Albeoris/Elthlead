using System;
using System.Collections;
using UnityEngine;

namespace Elthlead.ResourceManager
{
    public static class ExtensionsMonoBehaviour
    {
        public static void StartCoroutine(this MonoBehaviour self, Action action)
        {
            self.StartCoroutine(Evaluate(action));
        }
        
        private static IEnumerator Evaluate(Action action)
        {
            action();
            yield break;
        }
    }
}