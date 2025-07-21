namespace TestAPI.Helper
{
    public class UploadHandler
    {

        public string Upload(IFormFile file_url)
        {
            //extension
            List<string> validExtension = new List<string>() { ".pdf", ".docx" };
            string extension = Path.GetExtension(file_url.FileName);
            if (!validExtension.Contains(extension))
            {
                return $"Extension is not valid ({string.Join(',',validExtension)})";
            }

            //file size
            long size = file_url.Length;
            if (size > (16 * 1024 * 1024))
                return "Maximum size can be 16MB";

            //name changing
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(),"Uploads");
            using FileStream stream = new FileStream(Path.Combine(path,fileName), FileMode.Create);
            file_url.CopyTo(stream);

            return fileName;
        }
    }
}
