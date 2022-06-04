using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            PictureProvider pictureProvider = new PictureProvider();
            IPicture picture = pictureProvider.GetPicture(@"luke.jpg");
            PipeNull pipeNull = new PipeNull();
            FilterNegative negative = new FilterNegative();
            PipeSerial serialNegative = new PipeSerial(negative, pipeNull);
            FilterGreyscale grey = new FilterGreyscale();
            PipeSerial serialGrey = new PipeSerial(grey, serialNegative);
            IPicture greyfilter = serialGrey.Send(picture);
            
            
            //Ejercicio 2
            
            PictureProvider pictureProvider_2 = new PictureProvider();
            IPicture picture_2 = pictureProvider_2.GetPicture(@"luke.jpg");
            PipeNull pipeNull_2 = new PipeNull();
            FilterNegative negative_2 = new FilterNegative();
            FilterSaveImage saveNegative = new FilterSaveImage(@"negativefilter.jpg");
            PipeSerial serialSaveNegative = new PipeSerial(saveNegative,pipeNull_2);
            PipeSerial serialNegative_2 = new PipeSerial(negative, serialSaveNegative);
            FilterSaveImage saveGrey = new FilterSaveImage(@"greyfilter.jpg");
            PipeSerial serialSaveGrey = new PipeSerial(saveGrey,serialNegative_2);
            FilterGreyscale grey_2 = new FilterGreyscale();
            PipeSerial serialGrey_2 = new PipeSerial(grey_2, serialSaveGrey);
            IPicture greyfilter_2 = serialGrey_2.Send(picture);

            //Ejercicio 3
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("", "@negativefilter.jpg"));

            //Ejercicio 4}
            FilterTwitter tweet = new FilterTwitter($@"{picture}", "");
            PipeSerial serialTwitter = new PipeSerial(tweet, pipeNull);
            FilterConditional Face = new FilterConditional();
            PipeSerial SerialTwitter = new PipeSerial(Face, serialTwitter);
            PipeConditionalFork pipeConditional = new PipeConditionalFork(SerialTwitter, serialNegative);
        }
    }
}
