using System;
using System.Drawing;
using TwitterUCU;

namespace CompAndDel.Filters
{

    public class FilterTwitter : IFilter
    {
        public string Path { get; }
        public string Tweet { get; }

        public FilterTwitter(string path, string tweet)
        {
            this.Path = path;
            this.Tweet = tweet;
        }

        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(this.Tweet, this.Path));
            return image;
        }
    }
}