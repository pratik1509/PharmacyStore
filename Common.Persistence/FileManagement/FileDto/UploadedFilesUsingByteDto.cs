using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Persistence.FileManagement.FileDto
{
   public class UploadedFilesUsingByteDto
    {
        public List<FileDto> UplodedFiles { get; set; }
    }

    public class FileDto
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}
