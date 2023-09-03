namespace FastFoodFIAP.Application.ViewModels
{
    public class ImagemViewModel
    {
        public string Url { get; set; } = "";

        public ImagemViewModel() { }

        public ImagemViewModel(string url) { 
            Url = url;
        }
    }
}