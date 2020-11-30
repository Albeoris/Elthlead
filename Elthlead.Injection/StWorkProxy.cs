using System;
using Elthlead.Framework;
using GameCommon;

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
                __gameSystemWork = type.RequireStaticField("gameSystemWork").Access<GameSystemWork>();
                __mapAttribute = type.RequireStaticField("mapAttribute").Access<MapAttribute[]>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failed to prepare {nameof(StDataProxy)}.");
            }
        }

        private static readonly StaticFieldAccessor<Int32> __selectLanguage;
        private static readonly StaticFieldAccessor<GameSystemWork> __gameSystemWork;
        private static readonly StaticFieldAccessor<MapAttribute[]> __mapAttribute;

        public static Int32 CurrentLanguage
        {
            get => __selectLanguage.Value;
            set => __selectLanguage.Value = value;
        }
        
        public static GameSystemWork GameSystemWork
        {
            get => __gameSystemWork.Value;
            set => __gameSystemWork.Value = value;
        }
        
        public static MapAttribute[] MapAttribute
        {
            get => __mapAttribute.Value;
            set => __mapAttribute.Value = value;
        }
    }
}