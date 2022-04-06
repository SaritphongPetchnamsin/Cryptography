using System.Configuration;
using System.IO;

namespace Cryptography // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path= ConfigurationSettings.AppSettings.Get("FileString");
            string strfile = File.ReadAllText(path);
            ConvertFiletobit confile = new ConvertFiletobit();
            confile.convertstringtobit(strfile);
            Findprime prime = new Findprime(confile.stringbit);
        }
    }
}
