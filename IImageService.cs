public interface IImageService {
    Task<UploadedImage> CreateUploadedImage(HttpPostedFileBase file);
}

public class ImageService : IImageService{
    public async Task<UploadedImage>
    CreateUploadedImage(HttpPostedFileBase file){
        if((file != null) && (file.ContentLength > 0) &&
        !string.IsNullOrEmpty(file.FileName)){
            byte[] fileBytes = new byte[file.ContentLength];
            await file.InputStream.ReadAsync(fileBytes, 0,
            Convert.ToInt32(file.ContentLength)); 

            return new UploadedImage {
                ContentType = file.ContentType,
                Data = fileBytes,
                Name = file.FileName,

                Url = string.Format("data:image/jpeg;base64,{0}",
                Convert.ToBase64String(fileBytes))
            };
        }
        return null;
    }
}