using System;
using System.Collections.Generic;
using System.IO;

namespace Downloader
{
    class SZipParameter
    {
        public enum ArchiveOperation
        {
            Create,
            Extract,
            CRC32Checksum
        }

        public ArchiveOperation operation { get; private set; }
        public string Password { get; private set; }
        public string FileName { get; private set; }
        public List<string> FileNames { get; private set; }
        public List<string> Checksums { get; private set; }
        public string ArchiveFileName { get; private set; }

        public SZipParameter()
        {

        }

        public SZipParameter(ArchiveOperation operation, string password = null, string fileName = null, List<string> fileNames = null, string archiveFileName = null)
        {
            this.operation = operation;
            if(operation==ArchiveOperation.Create)
            {
                this.Password = password;
                this.ArchiveFileName = archiveFileName;
                this.FileNames = fileNames;
            }
            else if(operation==ArchiveOperation.Extract)
            {
                this.Password = password;
                this.FileName = fileName;
            }
            else if(operation==ArchiveOperation.CRC32Checksum)
            {
                this.FileNames = fileNames;
            }
        }

        public void SetOperation(ArchiveOperation operation)
        {
            this.operation = operation;
        }

        public void SetCreateArgs(string password, string archiveFileName)
        {
            this.operation = ArchiveOperation.Create;
            this.Password = password;
            this.ArchiveFileName = archiveFileName;
        }

        public void SetExtractArgs(string password, string fileName)
        {
            this.operation = ArchiveOperation.Extract;
            this.Password = password;
            this.FileName = fileName;
        }

        public void SetFileNames(params string[] fileNames)
        {
            List<string> listFiles = new List<string>();
            string path = Directory.GetCurrentDirectory();
            foreach (string item in fileNames)
            {
                if(File.Exists($"{path}\\{item}"))
                {
                    listFiles.Add(item);
                }
            }

            this.FileNames = (listFiles.Count > 0) ? listFiles : null;
        }
    }
}
