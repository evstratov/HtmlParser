using AngleSharp.Dom.Html;

namespace HTMLParser.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
