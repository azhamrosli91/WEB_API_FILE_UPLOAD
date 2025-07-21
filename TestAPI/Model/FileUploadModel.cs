namespace TestAPI.Model
{
    public class FileUploadModel
    {
        public IFormFile file_url {  get; set; }
        public string original_filename { get; set; }
        public string job_desc { get; set; }
        public string user_id { get; set; }

    }
}
