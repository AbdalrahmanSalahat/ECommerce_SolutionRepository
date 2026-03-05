using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Classes
{
    public class FileService : IFileService
    {
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", filename);
                using (var stream = File.Create(filepath))
                {
                    await file.CopyToAsync(stream);
                }

                return filename;
            }
            throw new Exception("file is empty");

        }
    }
}
