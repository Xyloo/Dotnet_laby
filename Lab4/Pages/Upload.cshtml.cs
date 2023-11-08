using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab4.Pages
{
    public class UploadModel : PageModel
    {
        [BindProperty]
        public IFormFile Upload { get; set; }

        private string imagesDir;
        private MagickImage watermark;

        public UploadModel(IWebHostEnvironment environment)
        { 
            imagesDir = Path.Combine(environment.WebRootPath, "images");
            watermark = new MagickImage("watermark.png");
            watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 4);
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Upload != null)
            {
                string extension = ".jpg";
                switch (Upload.ContentType)
                {
                    case "image/png":
                        extension = ".png";
                        break;
                    case "image/gif":
                        extension = ".gif";
                        break;
                }
                var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + extension;

                using var image = new MagickImage(Upload.OpenReadStream());
                watermark.Resize(image.Width / 3, image.Height / 3);
                image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);

                image.WriteAsync(Path.Combine(imagesDir, fileName));
            }
            return RedirectToPage("Index");
        }
    }
}
