using HtmlAgilityPack;

namespace AquaCore.General
{
    public class HtmlTools
    {
        static string GetItemAttributeValueFromHtml(Func<HtmlNode, string> action, List<string> xpathes, string origPageSource, bool printSourceHtmlIfError, bool noLog = false)
        {
            string result = default;
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(origPageSource);
            string attrValue = default;

            foreach (var locator in xpathes)
            {
                try
                {
                    var elementNodes = htmlDoc.DocumentNode.SelectNodes(locator);

                    if (elementNodes != null)
                    {
                        foreach (var foundNode in elementNodes)
                        {
                            attrValue = action.Invoke(foundNode);
                            if (!string.IsNullOrEmpty(attrValue))
                                break;
                        }
                    }
                }
                catch (NullReferenceException) { }

                if (!string.IsNullOrEmpty(attrValue))
                {
                    result = attrValue;
                    break;
                }
            }

            return result;
        }

        public static string GetItemInnerTextFromHtml(List<string> xpathes, string origPageSource, bool printSourceHtmlIfError, bool noLog = false)
        {
            return GetItemAttributeValueFromHtml(n => n.InnerText, xpathes, origPageSource, printSourceHtmlIfError, noLog);
        }
    }
}
