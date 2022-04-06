using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    internal class Findprime
    {
        BigInteger n;
        int totalbit;
        string bitnum;
        string bit;
        bool safeprime,primenumber,firstbit;
        public Findprime(string stringbit)
        {
            Console.WriteLine("Enter bit use to findprime limit 63bit");
            totalbit = Convert.ToInt32(Console.ReadLine());
            bit = stringbit;
            findbitnumber();
        }
        public void findbitnumber()
        {
            Console.WriteLine("Stringbit Length :" + bit.Length+ "\nStringbit :"+bit);
            foreach (char a in bit)
            {
                if (firstbit)
                {
                    if (bitnum.Length<totalbit)
                    {
                        bitnum += a;
                    }
                    if (!primenumber&&bitnum.Length == totalbit)
                    {
                        n = convertnumber();
                        Console.WriteLine(n);
                        primenumber=prime(n);
                        Console.WriteLine("BooleanPrimenumber"+primenumber);
                        if (primenumber)
                        {
                            isSafeprime(n);
                            Console.WriteLine("BooleanSafeprime" + safeprime);
                        }
                        if (primenumber && safeprime) { break; }
                        firstbit = false;
                        primenumber = false;
                        safeprime = false;
                        bitnum = "";
                    }
                }
                else
                    if ('1'.CompareTo(a).Equals(0))
                    {
                        firstbit=true;
                        bitnum += a;
                    }  
            }
            if (primenumber && safeprime)
            {
                Console.WriteLine(n+" is Safeprime");
            }
            
        }
        public bool prime(BigInteger n)
        {
            Random rand = new Random();
            //random number less than n
            BigInteger a = rand.NextInt64((long)n-1);
            Console.WriteLine("RandomNumber :"+a);
            BigInteger gcdval =gcd(a,n);
            if (gcdval == 1)
            {
                Console.WriteLine(n + " Possible prime");
            }
            else
            {
                Console.WriteLine(n + " is Composite");
                return false;
            }
            BigInteger modval =BigInteger.ModPow(a,n-1,n) ;
            Console.WriteLine("Modvalue :"+modval);
            if (modval.Equals(1))
            {
                Console.WriteLine(n+" : isPrime");
                return true;
            }
            else
            {
                Console.WriteLine(n + " : isComposite");
                return false;
            }
        }
        public long convertnumber()
        {
            Console.WriteLine("\nBase2 :"+bitnum);
            long longbit = Convert.ToInt64(bitnum,2);
            Console.WriteLine("Base10 :"+longbit);
            return longbit;
        }
        public BigInteger gcd(BigInteger num1, BigInteger num2)
        {
            BigInteger temp;
            while (num2!=0)
            {
                temp = num1 % num2;
                num1 = num2;
                num2 = temp;
            }
            return num1;
        }
        public void isSafeprime(BigInteger number)
        {
            BigInteger q =( number - 1 )/ 2;
            if (prime(q))
            {
                safeprime = true;
            }
            else
                safeprime = false;
        }
       
    }
}
