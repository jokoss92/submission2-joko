private readonly IImageService _imageService = new ImageService();

[HttpPost]
public async Task<ActionResult> 
    Upload(FormCollection formCollection){
        var model = new UploadedImage();
        if (Request != null) {
            HttpPostedFileBase file = Request.Files["uploadedFile"];
            model = await _imageService.CreateUploadedImage(file);
        }

        return View("Index", model);
    }