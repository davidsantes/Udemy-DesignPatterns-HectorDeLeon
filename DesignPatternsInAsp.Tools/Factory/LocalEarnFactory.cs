namespace DesignPatternsInAsp.Tools.Factory
{
    public class LocalEarnFactory : EarnFactory
    {
        private readonly decimal _percentage;
        public LocalEarnFactory(decimal percentage)
        {
            _percentage = percentage;
        }

        public override IEarn GetEarn()
        {
            return new LocalEarn(_percentage);
        }
    }
}
