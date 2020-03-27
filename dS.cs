using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ds
{
    class Program
    {
        static void Main(string[] args)
        {
            count numero = new count();
            morse morseC = new morse();
            caesar caesarC = new caesar();
             

                if (args[0] == "1")
                {
                     Environment.Exit(-1);
                }
                else if (args[1] == "2")
                {
                    if (args[2] == "1") { Console.WriteLine("numri i charactereve : " + numero.countCh(args[0])); }
                    else if (args[2] == "2") { Console.WriteLine("numri i rreshtave : " + numero.countLi(args[0])); }
                    else if (args[2] == "3") { Console.WriteLine("numri i fjaleve : " + numero.countW(args[0])); }
                    else if (args[2] == "4") { Console.WriteLine("numri i fjalive : " + numero.countWo(args[0])); }
                    else if (args[2] == "5") { Console.WriteLine("numri i zanoreve : " + numero.countZan(args[0])); }
                    else if (args[2] == "6") { Console.WriteLine("numri i bashtingelloreve : " + numero.countBash(args[0])); }
                    else if(args[2]=="7") {Console.WriteLine("numri i simboleve : " + numero.countSymb(args[0]));}
                    else { Console.WriteLine("Wrong input !!!"); }
                }
                else if (args[1] == "3")
                {
                    char[] ar = args[0].ToCharArray();
                    string emri = "", VP = "";
                    if (args[2] == "1")
                    {
                        for (int i = 0; i < ar.Length; i++)
                        {
                            emri = emri + morseC.morseEnco(ar[i]);//encode
                            if (ar[i] == ' ')
                            {

                            }
                            else { Console.Beep(); }

                            Console.Write(morseC.morseEnco(ar[i]));


                        }
                        Console.WriteLine("\n");
                    }
                    

                    else if (args[2] == "2")
                    {

                        for (int i = 0; i < ar.Length; i++)//decode
                        {
                            VP = VP + ar[i];

                            if (ar[i] == ' ')
                            {
                                emri = emri + morseC.morseDeco(VP);
                                VP = "";
                            }
                        }
                        Console.WriteLine(emri);
                    }
                    else { Console.WriteLine("Wrong input !!!"); }

                }
                else if (args[1] == "4")
                {
                    int k = Convert.ToInt32(args[3]);
                   
                    if (args[2] == "1") { Console.WriteLine("ciphertext : " + caesarC.caesarCipherEnco(args[0], k)); }
                    else if (args[2] == "2") { Console.WriteLine("plaintext : " + caesarC.caesarCipherDeco(args[0], k)); }
                    else { Console.WriteLine("Wrong input !!!"); }

                }
                else
                {
                    Console.WriteLine("Wrong input !!!");
                }
            
            Console.ReadKey();
        }
    }
}
class count
{
    public  int countCh(string emri)
    {
        char[] a = emri.ToCharArray();
        int q = a.Length;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == ' ')
            {
                q -= 1;
            }

        }
        return q;
    }
   
    public  int countLi(string emri)
    {
        char[] v = emri.ToCharArray();
        int lines = 1;
        for (int i = 0; i < v.Length; i++)
        {
            if (v[i] == '\n')
            {
                lines++;
            }
        }
        return lines;
    }
 public  int countSymb(string emri)
        {
            char[] symbols = { '.', ',', '!', '?' };
            char[] b = emri.ToCharArray();
            int count=0;
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (b[i] == symbols[j])
                    {
                        count++;
                    }

                }
            }
            return count;
        }
    public  int countW(string emri) //count fjaleve
    {
        char[] a = emri.ToCharArray();
        int countW = 1;
       
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == ' ')
            {
                countW++;
            }
            else if (a[i] == '.') { countW++; }

        }
        return countW;
    }
    public  int countWo(string emri) //count fjalive
    {

        char[] a = emri.ToCharArray();
        int countW = 0;
        // int q = a.Length;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == '.')
            {
                countW++;
            }


        }
        return countW;
    }
    public  int countZan(string emri)
    {
        char[] a = emri.ToCharArray();
        int countW = 0;
        char[] b = { 'a', 'e', 'ë', 'o', 'u', 'y', 'i', 'A', 'E', 'Ë', 'O', 'U', 'Y', 'I' };
        // int q = a.Length;
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                if (a[i] == b[j])
                {
                    countW++;
                }

            }
        }
        return countW;
    }
    public  int countBash(string emri)
    {
        char[] a = emri.ToCharArray();
        int countW = 0, space = 0;
        char[] b = { 'a', 'e', 'ë', 'o', 'u', 'y', 'i', 'A', 'E', 'Ë', 'O', 'U', 'Y', 'I' };
        int q = a.Length;
        for (int i = 0; i < a.Length; i++)
        {


            for (int j = 0; j < b.Length; j++)
            {
                if (a[i] == b[j])
                {
                    countW++;
                }




            }
            if (a[i] == ' ')
            {
                q--;
            }

        }
        int bash = 0;
        bash = q - countW - space;
        return bash;
    }
}
