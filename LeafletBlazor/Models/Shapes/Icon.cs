namespace LeafletBlazor.Models
{
    public class Icon
    {
        public Icon(IconOptions options)
        {
            Options = options;
        }

        internal IconOptions Options { get; set; }
    }
}
