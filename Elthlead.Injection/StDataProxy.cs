using System;
using Elthlead.Framework;

namespace Elthlead.Injection
{
    public static class StDataProxy
    {
        static StDataProxy()
        {
            try
            {
                var assembly = typeof(MapMain).Assembly;
                var type = assembly.RequireType("StData");

                __eventMessageList = type.RequireStaticField("eventMessageList").Access<EventMessageList>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failed to prepare {nameof(StDataProxy)}.");
            }
        }

        private static readonly StaticFieldAccessor<EventMessageList> __eventMessageList;

        public static EventMessageList EventMessageList
        {
            get => __eventMessageList.Value;
            set => __eventMessageList.Value = value;
        }
    }
}