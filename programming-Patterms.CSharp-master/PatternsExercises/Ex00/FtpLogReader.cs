using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Ex00.ExternalLibs;
namespace Patterns.Ex00
{
    class FtpLogReader: ILogReader
    {
        private FtpClient client;

        public string Password { get; private set; }
        public string Login { get; private set; }       

        public FtpLogReader(FtpClient client, string password, string login)
        {
            this.client = client;
            Password = password;
            Login = login;           
        }
        public string ReadLogFile(string identificator)
        {

            return client.ReadFile(Login, Password, identificator);
        }
        
    }
}
