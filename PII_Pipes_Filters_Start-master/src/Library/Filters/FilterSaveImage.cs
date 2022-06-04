namespace CompAndDel.Filters
{
    public class FilterSaveImage : IFilter
    {
        public string PathToPersist { get; set; }

        public FilterSaveImage(string pathToPersist)
        {
            this.PathToPersist = pathToPersist;
        }
        public IPicture Filter(IPicture image)
        {
            this.Persist(image, this.PathToPersist);
            return image;
        }

        private void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
    }
}