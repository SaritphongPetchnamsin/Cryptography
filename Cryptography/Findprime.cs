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
        bool safeprime,primenumber,firstbit,firstround=true;
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
                        if (firstround)
                        {
                            n = convertnumber();
                            firstround = false;
                        }
                        primenumber=prime(n);
                        if (primenumber)
                        {
                            isSafeprime(n);
                        }
                        if (primenumber && safeprime) 
                        {
                            Console.WriteLine(n+" is Prime and SafePrime");
                            break;
                        }else
                            if (primenumber)
                            {
                                Console.WriteLine(n + " is Prime but not SafePrime");
                            }
                        primenumber = false;
                        safeprime = false;
                        nextNumber();
                    }
                }
                else
                    if ('1'.CompareTo(a).Equals(0))
                    {
                        firstbit=true;
                        bitnum += a;
                    }  
            }
            
        }
        public bool prime(BigInteger n)
        {
            int trial = 0;
            Random rand = new Random();
            //separate even number ,0 and 1
            if (n%2==0||n%3==0)
            {
                if (n % 2 == 0)
                {
                    Console.WriteLine(n + "%2 =0 is not Prime ");
                }
                else
                {
                    Console.WriteLine(n + "%3 =0 is not Prime ");
                }
                return false;
            }
            BigInteger e = (n-1)/2;
            while (trial<50)
            {
                //random number less than n
                BigInteger a = rand.NextInt64((long)n-1);
                Console.WriteLine("Round :"+(trial+1)+" RandomNumber :"+a);
                BigInteger output = BigInteger.ModPow(a,e,n);
                if ((output%n).Equals(1))
                {
                    Console.WriteLine("Round :" + (trial + 1) +" is Prime");
                    return true;
                }
                else
                {
                    Console.WriteLine("Round :" + (trial + 1) + " is not Prime");
                }
                trial++;
            }
            return false;
        }
        public BigInteger convertnumber()
        {
            Console.WriteLine("\nBase2 :"+bitnum);
            BigInteger longbit = Convert.ToInt64(bitnum,2);
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
            Console.WriteLine("(p-1)/2 = "+q);
            if (prime(q))
            {
                safeprime = true;
            }
            else
                safeprime = false;
        }
        public void nextNumber( )
        {
            if ((n % 2).Equals(0))
            {
                n++;
                Console.WriteLine("\nnext number :"+n);            
            }
            else
            {
                n += 2;
                Console.WriteLine("\nnext number :" + n);
            }
                
        }
       
    }
}
