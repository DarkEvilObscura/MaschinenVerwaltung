using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dropbox.Api;

namespace Downloader
{
    internal class DropBox
    {
        public DropBox()
        {
            CheckDownloadDirectory();
        }

        public async Task<Dropbox.Api.Users.FullAccount> GetAccountInfo()
        {
            string oauth2Token = "sl.BHdNt9nXL4A70f91xSy0wCVnjjBunKvEBIaW5dxHhJxkKcrBDcXrPik0beFch8lIRNxzh6vcEXlkaB7X_Pn2_Nh51QffInxyxECdtRWb7ANbrwjTmIO0BrDRcA7pTtRAVIyJM7o";
            DropboxClient dbx = new DropboxClient(oauth2Token);
            Dropbox.Api.Users.FullAccount account = await dbx.Users.GetCurrentAccountAsync();
            return account;
        }

        public static async Task Run()
        {
            string oauth2Token = "sl.BHdNt9nXL4A70f91xSy0wCVnjjBunKvEBIaW5dxHhJxkKcrBDcXrPik0beFch8lIRNxzh6vcEXlkaB7X_Pn2_Nh51QffInxyxECdtRWb7ANbrwjTmIO0BrDRcA7pTtRAVIyJM7o";
            using (var dbx = new DropboxClient(oauth2Token))
            {
                var account = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", account.Name.DisplayName, account.Email);
            }
        }

        async Task Download(DropboxClient dbx, string folder, string file)
        {
            using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
            {
                Console.WriteLine(await response.GetContentAsStringAsync());
            }
        }

        private void CheckDownloadDirectory()
        {
            string path = Application.StartupPath;
            DirectoryInfo directory = Directory.CreateDirectory(path + @"\downloads");
        }

        public async void DownloadFile(string url)
        {
            await Task.Run(() => { 
                
            });
        }
    }
}
