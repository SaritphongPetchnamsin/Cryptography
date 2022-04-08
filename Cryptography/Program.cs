using System.Configuration;
using System.IO;

namespace Cryptography // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strfile="";
            string path= ConfigurationSettings.AppSettings.Get("FileString");
            Console.WriteLine("Enter name of text file in folder FileString");
            string filename = Console.ReadLine();
            try
            {
                strfile = File.ReadAllText(path+filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("File not found,Please save file in FileString folder");
                return;
            }
            ConvertFiletobit confile = new ConvertFiletobit();
            confile.convertstringtobit(strfile);
            Findprime prime = new Findprime(confile.stringbit);
        }
    }
}
