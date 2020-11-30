using System;
using Elthlead.Framework;
using Elthlead.ResourceManager;
using UnityEngine;
using Object = System.Object;

// ReSharper disable InconsistentNaming

namespace Elthlead.Injection
{
    public sealed class ElthleadEngine : MonoBehaviour
    {
        private StDataHandler _stDataHandler;
        private InputHandler _inputHandler;

        private void Awake()
        {
            try
            {
                Log.Message($"[{nameof(ElthleadEngine)}] Initializing...");
                LogRedirector.Redirect();
                HarmonyPatches.Patch();

                _stDataHandler = new StDataHandler();
                _inputHandler = new InputHandler();
                Log.Message($"[{nameof(ElthleadEngine)}] Initialized.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"[{nameof(ElthleadEngine)}] Failed to initialize.");
                Environment.Exit(2);
            }
        }

        private void Update()
        {
            _stDataHandler.Update();
            _inputHandler.Update();
        }
    }
}