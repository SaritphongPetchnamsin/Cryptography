using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    internal class ConvertFiletobit
    {
        public List<byte> stringbyte=new List<byte>();
        public string stringbit { get; set; }

        public void convertstringtobit(string text)
        {
            foreach (var index in text)
            {
                stringbyte.Add(Convert.ToByte(index));
            }
            foreach (byte index in stringbyte)
            {
                stringbit+=Convert.ToString(index,2);
            }
        }
    }
}
