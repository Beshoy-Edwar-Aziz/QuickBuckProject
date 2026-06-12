namespace QuickBuck.Helpers
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    public static class DocumentSettings
    {
        public static string UploadFile(byte[] File,string Type ,string FolderName)
        {
        /*    string FolderPath = ""; 
            string FileName = "";
            if (Type=="image") {
                FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", FolderName); 
                FileName = $"Image_{Guid.NewGuid()}.jpg";
            }
            else if (Type == "document")
            {
                FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);
                FileName = $"Document_{Guid.NewGuid()}.pdf";
            }
            string CompleteFilePath = Path.Combine(FolderPath,FileName);
            using var Fs = new FileStream(CompleteFilePath,FileMode.Create);
            Fs.Write(File, 0, File.Length);
            return FileName;*/
            var cloudinary = new Cloudinary(new Account(
           Environment.GetEnvironmentVariable("Cloudinary__CloudName"),
           Environment.GetEnvironmentVariable("Cloudinary__ApiKey"),
           Environment.GetEnvironmentVariable("Cloudinary__ApiSecret")
       ));
            using var stream = new MemoryStream(File);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("upload", stream),
                Folder = FolderName
                
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.SecureUrl.ToString();
        } 
        public static void DeleteFile(string FileName,string FolderName, string FileType)
        {
            string FolderPath="";
            string FilePath="";
            if (FileType=="image")
            {
                 FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", FolderName);
                 FilePath= Path.Combine(FolderPath,FileName);
            }
            else if (FileType=="document")
            {
                FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);
                FilePath = Path.Combine(FolderPath,FileName);
            }
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        } 
    }
}
