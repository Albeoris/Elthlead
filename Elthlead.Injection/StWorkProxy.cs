using System;
using Elthlead.Framework;

namespace Elthlead.Injection
{
    public static class StWorkProxy
    {
        static StWorkProxy()
        {
            try
            {
                var assembly = typeof(MapMain).Assembly;
                var type = assembly.RequireType("StWork");

                __selectLanguage = type.RequireStaticField("selectLanguage").Access<Int32>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failed to prepare {nameof(StDataProxy)}.");
            }
        }

        private static readonly StaticFieldAccessor<Int32> __selectLanguage;

        public static Int32 CurrentLanguage
        {
            get => __selectLanguage.Value;
            set => __selectLanguage.Value = value;
        }
    }
}