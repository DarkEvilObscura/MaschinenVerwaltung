using System.Collections.Generic;
using System.Diagnostics;

namespace Downloader
{
    class Kompression
    {
        public void StartOperation(SZipParameter parameter)
        {
            List<string> list = new List<string>();

            string args = string.Empty;
            if(parameter.operation==SZipParameter.ArchiveOperation.Create)
            {
                args = $"a -p{{{parameter.Password}}} -t7z \"{parameter.ArchiveFileName}\"";
                foreach (string item in parameter.FileNames)
                {
                    args += $" \"{item}\"";
                }
            }
            else if(parameter.operation==SZipParameter.ArchiveOperation.Extract)
            {
                args = $"e -aoa -p{{{parameter.Password}}} \"{parameter.FileName}\"";
            }

            Process process = CreateProcess(args);
            process.Start();
            process.WaitForExit(15000);
            int i = 1;
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                if (parameter.operation==SZipParameter.ArchiveOperation.Create)
                {
                    if(i==14)
                    {
                        if(line=="Everything is Ok")
                        {
                            break;
                        }
                    }
                }
                else if(parameter.operation==SZipParameter.ArchiveOperation.Extract)
                {
                    if(i==17)
                    {
                        if(line == "Everything is Ok")
                        {
                            break;
                        }
                    }
                }
                i++;
            }
        }

        public void StartOperation(SZipParameter parameter, out List<string> listResult)
        {
            List<string> list = new List<string>();

            string args = string.Empty;
            if (parameter.operation == SZipParameter.ArchiveOperation.CRC32Checksum)
            {
                args = "h -scrc";
                foreach (string item in parameter.FileNames)
                {
                    args += $" \"{item}\"";
                }
            }
            Process process = CreateProcess(args);
            process.Start();
            process.WaitForExit(15000);
            int i = 1;
            bool startBorder = false;
            bool endBorder = false;
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                if (parameter.operation == SZipParameter.ArchiveOperation.CRC32Checksum)
                {
                    if (line == "-------- -------------  ------------")
                    {
                        if (!startBorder)
                        {
                            startBorder = true;
                            continue;
                        }
                        if (startBorder && !endBorder)
                        {
                            endBorder = true;
                            break;
                        }
                    }
                    if (startBorder)
                    {
                        string checksum = line.Substring(0, 8);
                        list.Add(checksum);
                    }
                }
                i++;
            }
            listResult = list;
        }

        private Process CreateProcess(string args)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = "7za.exe";
                processStartInfo.Arguments = args;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardOutput = true;
                process.StartInfo = processStartInfo;

                return process;
            }
        }
    }
}

/* AddFiles
(1):
(2): 7-Zip (a) 21.07 (x86) : Copyright (c) 1999-2021 Igor Pavlov : 2021-12-26
(3):
(4): Scanning the drive:
(5): 2 files, 23695 bytes (24 KiB)
(6):
(7): Creating archive: test.7z
(8):
(9): Add new data to archive: 2 files, 23695 bytes (24 KiB)
(10):
(11):
(12): Files read from disk: 2
(13): Archive size: 14386 bytes (15 KiB)
(14): Everything is Ok
 */

/* GetCRC32
(1):
(2): 7-Zip (a) 21.07 (x86) : Copyright (c) 1999-2021 Igor Pavlov : 2021-12-26
(3): 
(4): Scanning
(5): 1 file, 12402 bytes (13 KiB)
(6):
(7): CRC32             Size  Name
(8): -------- -------------  ------------
(9): C83DA99F         12402  Centura.xlsx
(10): -------- -------------  ------------
(11): C83DA99F         12402
(12):
(13): Size: 12402
(14):
(15): CRC32  for data:              C83DA99F
(16):
(17): Everything is Ok
 */

/* Extrahieren
(1):
(2): 7-Zip (a) 21.07 (x86) : Copyright (c) 1999-2021 Igor Pavlov : 2021-12-26
(3):
(4): Scanning the drive for archives:
(5): 1 file, 14386 bytes (15 KiB)
(6):
(7): Extracting archive: test.7zip
(8): --
(9): Path = test.7zip
(10): Type = 7z
(11): Physical Size = 14386
(12): Headers Size = 226
(13): Method = LZMA2:24k 7zAES
(14): Solid = +
(15): Blocks = 1
(16):
(17): Everything is Ok
(18):
(19): Files: 2
(20): Size:       23695
(21): Compressed: 14386
 */






//-ao(Overwrite mode) switch
//Specifies the overwrite mode during extraction, to overwrite files already present on disk.

//Syntax
//-ao[a | s | t | u]
//Switch Description
//-aoa	Overwrite All existing files without prompt.
//-aos	Skip extracting of existing files.
//-aou	aUto rename extracting file (for example, name.txt will be renamed to name_1.txt).
//-aot    auto rename existing file (for example, name.txt will be renamed to name_1.txt).