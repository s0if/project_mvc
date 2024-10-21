using Microsoft.Identity.Client;

namespace Landing.PL.Helpers
{
    public class FileSetting
    {
        public static string uploadFile(IFormFile file, string foldername)
        {
            string folderpath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", foldername);
            string filename = $"{Guid.NewGuid()}{file.FileName}";
            string filepath = Path.Combine(folderpath, filename);

            var filestream = new FileStream(filepath , FileMode.Create);
            file.CopyTo(filestream);
            filestream.Close();
            return filename;
        }
        public static void deleteFile(string foldername, string namefile)
        {
            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", foldername, namefile);

            if (File.Exists(folderpath))
            {
                File.Delete(folderpath);
            }

        }
        



    }
    
}
