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
                    else if(args[2]=="3") {caesarC.bruteForce(args[0]);}
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
class morse
{
    public string morseEnco(char t)
    {
        switch (t)
        {
            case 'a':
                return ".- ";
            case 'b':
                return"-... ";
            case 'c':
                return "-.-. ";
            case 'd':
                return "-.. ";
            case 'e':
                return ". ";
            case 'f':
                return "..-. ";
            case 'g':
                return "--. ";
            case 'h':
                return ".... ";
            case 'i':
                return ".. ";
            case 'j':
                return ".--- ";
            case 'k':
                return "-.- ";
            case 'l':
                return ".-.. ";
            case 'm':
                return "-- ";
            case 'n':
                return "-. ";
            case 'o':
                return "--- ";
            case 'p':
                return ".--. ";
            case 'q':
                return "--.- ";
            case 'r':
                return ".-. ";
            case 's':
                return "... ";
            case 't':
                return "- ";
            case 'u':
                return "..- ";
            case 'v':
                return "...- ";
            case 'w':
                return ".-- ";
            case 'x':
                return "-..- ";
            case 'y':
                return "-.-- ";
            case ' ':
                return "/ ";
            
            case 'z':
                return "--.. ";
        }

        return "";
    }
    public char morseDeco(string text)
    {
        switch (text)
        {
            case ".- ":
                return 'a';

            case "-... ":
                return 'b';

            case "-.-. ":
                return 'c';

            case "-.. ":
                return 'd';
            case ". ":
                return 'e';
            case "..-. ":
                return 'f';
            case "--. ":
                return 'g';
            case ".... ":
                return 'h';
            case ".. ":
                return 'i';
            case ".--- ":
                return 'j';
            case "-.- ":
                return 'k';
            case ".-.. ":
                return 'l';
            case "-- ":
                return 'm';
            case "-. ":
                return 'n';
            case "--- ":
                return 'o';
            case ".--. ":
                return 'p';
            case "--.- ":
                return 'q';
            case ".-. ":
                return 'r';
            case "... ":
                return 's';
            case "- ":
                return 't';
            case "..- ":
                return 'u';
            case "...- ":
                return 'v';
            case ".-- ":
                return 'w';
            case "-..- ":
                return 'x';
            case "-.-- ":
                return 'y';
            case "/ ":
                return ' ';
            case "--.. ":
                return 'z';
        }


        return ' ';
    }
}
class caesar
{
    public char[] chars = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '0', '1', '2', '3', '4', '5',
            '6', '7', '8', '9', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z'

        };
     public string caesarCipherEnco(string text, int offset)
        {
            string temp = text.ToLower();
            char[] plain = temp.ToCharArray();

            for (int i = 0; i < plain.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    if (j <= chars.Length - offset)
                    {
                        if (plain[i] == chars[j])
                        {
                            if (j +offset> 25)
                            {

                                plain[i] =chars[(j+offset)%26] ;
                                break;
                            }
                            plain[i] = chars[j+ offset];
                            break;
                        }
                    }
                    else if (plain[i] == chars[j])
                    {
                        plain[i] = chars[j - (chars.Length - offset )];
                    }
                }
            }
            return new string(plain);
        }

        public string ceasarCipherDeco(string cip, int offset)
        {
            string temp = cip.ToLower();
            char[] cipher = temp.ToCharArray();

            for (int i = 0; i < cipher.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    if (j >= offset && cipher[i] == chars[j])
                    {
                        cipher[i] = chars[j - offset];
                        break;
                    }
                    if (cipher[i] == chars[j] && j < offset)
                    {
                        cipher[i] = chars[(chars.Length - offset ) + j];
                        break;
                    }
                }
            }
            return new string(cipher);
        }
     public  void bruteForce(string emri)
        {
            int shift = 1;
            for(int i = 0; i < 26; i++)
            {
                
                

                Console.WriteLine("test " + shift+ ": " + ceasarCipherDeco(emri,shift));
                shift++;
            }
           
        }
    //  https://code.sololearn.com/cg0k07P9f2r8/#cs

}   
