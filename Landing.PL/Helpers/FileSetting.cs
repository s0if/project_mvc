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
        public static string updateFie(IFormFile file ,string foldername, string filenameold)
        {
            string folderpathdelete = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", foldername, filenameold);
            if (File.Exists(folderpathdelete))
            {
                File.Delete(folderpathdelete);
            }
            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", foldername);
            string newfilename = $"{Guid.NewGuid()}{file.Name}";
            string newfilepath = Path.Combine(folderpath, newfilename);
            var filestream = new FileStream(newfilepath, FileMode.Create);

            file.CopyTo(filestream);
            filestream.Close();
            return newfilename;

        }



    }
    
}
