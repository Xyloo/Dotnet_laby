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

        public UploadModel(IWebHostEnvironment environment)
        { 
            imagesDir = Path.Combine(environment.WebRootPath, "images");
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
                using var watermark = new MagickImage("watermark.png");
                watermark.Resize(image.Width / 3, image.Height / 3);
                watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 4);
                image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);

                using var fs = System.IO.File.OpenWrite(Path.Combine(imagesDir, fileName));
                image.Write(fs);
            }
            return RedirectToPage("Index");
        }
    }
}
