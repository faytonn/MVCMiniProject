﻿using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.Helpers
{
    public static class FileService
    {
        public static async Task<string> GenerateFileAsync(this IFormFile file, string filePath)
        {
            var fileName = Guid.NewGuid() + file.FileName;

            filePath = Path.Combine(filePath, fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.CreateNew))
                await fs.CopyToAsync(fs);

            return fileName;
        }

        public static bool DeleteFile(this string fileName, string filePath)
        {
            filePath = Path.Combine(filePath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
