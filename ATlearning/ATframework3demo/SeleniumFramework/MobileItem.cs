namespace atFrameWork2.SeleniumFramework
{
    public class MobileItem : BaseItem
    {
        public MobileItem(string xpathLocator, string description) : this(new List<string> { xpathLocator }, description)
        {
        }

        public MobileItem(List<string> xpathLocators, string description) : base(xpathLocators, description)
        {
        }
    }
}
