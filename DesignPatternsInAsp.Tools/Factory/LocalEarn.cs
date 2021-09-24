namespace DesignPatternsInAsp.Tools.Factory
{
    public class LocalEarn : IEarn
    {
        private readonly decimal _percentage;
        public LocalEarn(decimal percentage)
        {
            _percentage = percentage;
        }
        public decimal Earn(decimal amount)
        {
            return amount * _percentage;
        }
    }
}
