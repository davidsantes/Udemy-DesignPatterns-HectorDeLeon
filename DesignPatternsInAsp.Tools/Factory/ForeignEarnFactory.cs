namespace DesignPatternsInAsp.Tools.Factory
{
    public class ForeignEarnFactory : EarnFactory
    {
        private readonly decimal _percentage;
        private readonly decimal _extra;

        public ForeignEarnFactory(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public override IEarn GetEarn()
        {
            return new ForeignEarn(_percentage, _extra);
        }
    }
}
