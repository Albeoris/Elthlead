namespace Elthlead.Injection
{
    public sealed class StDataHandler
    {
        private readonly StDataEventMessageListHandler _handler = new StDataEventMessageListHandler();

        public void Update()
        {
            _handler.Update();
        }
    }
}