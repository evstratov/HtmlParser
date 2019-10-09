using AngleSharp.Parser.Html;
using HTMLParser.Core.Habr;
using System;

namespace HTMLParser.Core
{
    class ParserWorker<T> where T :class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;
        bool isActive = false;
        IParser<T> Parser
        {
            get
            {
                return parser;
            }

            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        { 
            get
            {
                return parserSettings;
            }

            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public bool IsActive { get { return isActive; } }

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;
        public ParserWorker (IParser<T> parser)
        {
            this.parser = parser;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }
        private async void Worker()
        {
            for(int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                if(!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseAsync(source);

                var result = parser.Parse(document);
                OnNewData.Invoke(this, result);
            }
            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
