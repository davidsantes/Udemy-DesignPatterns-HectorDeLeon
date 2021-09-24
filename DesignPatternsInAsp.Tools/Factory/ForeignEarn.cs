namespace DesignPatternsInAsp.Tools.Factory
{
    public class ForeignEarn : IEarn
    {
        private readonly decimal _percentage;
        private readonly decimal _extra;

        public ForeignEarn(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public decimal Earn(decimal amount)
        {
            return amount * _percentage + _extra;
        }
    }
}
