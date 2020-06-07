namespace ds
{
class rsa
    {
        des des = new des();
        public void createUser(string emri)
        {
             SHA1CryptoServiceProvider sh1 = new SHA1CryptoServiceProvider();

        DateTime now = DateTime.Now;
        byte[] slt = new Byte[10];
        Random rand = new Random();
        rand.NextBytes(slt);

        string salt = Convert.ToBase64String(slt);

        //Console.Write(salt);
        Regex rg = new Regex("^(?=.{6,}$)(?=.*[a-z])(?=.*[0-9]).*$");



        Console.WriteLine(" Jepni fjalekalimin ..: ");
        var fjalkalimi = Console.ReadLine();// rregulloje sikur read-s

        var rt = rg.IsMatch(fjalkalimi);
        // Console.Write(rt);


        if (rt == false)
        {
            Console.WriteLine(" Fjalkalimi duhet te ket se paku 6 karaktete dhe  nje numer");
            return;
        }
        fjalkalimi = Convert.ToBase64String(sh1.ComputeHash(Convert.FromBase64String(fjalkalimi + salt)));
        Console.WriteLine(" Perserit fjalekalimin ..: ");
        var perserit = Console.ReadLine();
        perserit = Convert.ToBase64String(sh1.ComputeHash(Convert.FromBase64String(perserit + salt)));

        if (fjalkalimi == perserit)
        {
            Console.WriteLine(" Fjalkalimi perputhet");
            File.AppendAllText("C:/Users/hp/Desktop/db.txt", user + " " + salt + " " + fjalkalimi + " " + now + "\n");


        }
        else { Console.WriteLine(" Fjalkalimi nuk perputhet"); }
            
            
            RSACryptoServiceProvider r = new RSACryptoServiceProvider();
            //private key
            string celesiPrivat = r.ToXmlString(true);
            File.WriteAllText("C:/Users/hp/Desktop/keys/" + emri + "pri.xml", celesiPrivat);

            string celesiPublic = r.ToXmlString(false);
            File.WriteAllText("C:/Users/hp/Desktop/keys/" + emri + ".xml", celesiPublic);
            
             Console.WriteLine(" User : " + emri + " u krijua");
        }
        public void deleteUser(string emri)
        {
             File.Delete("C:/Users/hp/Desktop/keys/" + emri + ".xml");
            File.Delete("C:/Users/hp/Desktop/keys/" + emri + "pri.xml");
            string filere = File.ReadAllText("C: /Users/hp/Desktop/db.txt");
            string[] a = filere.Split();
           
            var temp = "";
           
            
           
            
             for (int i = 0; i < a.Length; i++)
             {
                if (emri == a[i])
                {
                    temp = a[i] + " " + a[i + 1] + " " + a[i + 2] + " " + a[i + 3] + " " + a[i + 4] + " " + a[i + 5];
                }
                

             }
            string save = filere.Replace(temp, " ");
            
            File.Delete("C: /Users/hp/Desktop/db.txt");
           var newfile= File.Create("C: /Users/hp/Desktop/db.txt");
            newfile.Close();
           File.AppendAllText("C: /Users/hp/Desktop/db.txt", save);
            
            Console.WriteLine(" User : " + emri + "u fshi");
        }
        public void exportKey(string emri, string opcioni)
        {
           
            if (opcioni == "public")
            {
                string key = File.ReadAllText("C:/Users/hp/Desktop/keys/" + emri + ".xml");
            Console.WriteLine("celesi public : " + key);
            
            }
            else if (opcioni == "private")
            {
                string key = File.ReadAllText("C:/Users/hp/Desktop/keys/" + emri + "pri.xml");
                Console.WriteLine(" Celesi privat ..: " + key);
            
        }
            else
            {
                Console.WriteLine(" Gabim ky celes nuk ekziston !!!");
            }

        }
    public  void importKey(string emri, string path)
    {
        string dest = " C:/Users/hp/Desktop/keys/" + emri;

        File.Move(path, dest);
        Console.WriteLine("key u zhvendos ne :" + dest);

    }
    public void writeText(string emri, string mesazhi,string path)
        {
            DES DESalg = DES.Create();
            byte[] keyb = new byte[8];
            byte[] ivb = new byte[8];
            keyb = DESalg.Key;

            ivb = DESalg.IV;
            
        string KEY = Convert.ToBase64String(keyb);
            string IV = Convert.ToBase64String(ivb);

            string enctext = encrypt(emri, mesazhi, KEY, IV);
        string[] arg = enctext.Split();
        string filepath = "C:/Users/hp/Desktop/keys/users.txt";
            arg[0] = arg[0] + " ";
            File.AppendAllText(filepath, arg[0]);
        
        if (String.IsNullOrEmpty(path))
        {
            Console.WriteLine("Encrypted ...:        " + enctext);

        }
        else
        {
            File.WriteAllText("C:/Users/hp/Desktop/keys/" + emri + "encrypted.xml", enctext);
            Console.WriteLine("teksti u ruajt ne :   C:/Users/hp/Desktop/keys/  ");


        }

            string filepath = "C:/Users/hp/Desktop/keys/users.txt";
        emri = emri + " ";
        File.AppendAllText(filepath, emri);


        
        arg[0] = arg[0] + " ";
        File.AppendAllText(filepath, arg[0]);

            
            
            

        }
    public void readText(string mesazhi)
    {
        //string t = Console.ReadLine();//File.ReadAllText("C:/Users/hp/Desktop/keys/"+ emri +"encrypted.xml");
        string dec = decrypt(mesazhi);
        string[] arg = dec.Split();




        Console.WriteLine(" Emri ..:" + arg[0]);
        Console.WriteLine(" Decrypted ..:" + arg[1]);




        File.WriteAllText("C:/Users/hp/Desktop/keys/" + arg[0] + "decrypted.xml", dec);
        Console.WriteLine("teksti u ruajt ne ...:" + "C:/Users/hp/Desktop/keys/");

    }

  
        public string encrypt(string emri, string teksti, string key, string iv)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);

            byte[] emribyte = Encoding.UTF8.GetBytes(emri);
            string emrist = Encoding.UTF8.GetString(emribyte);

            var pubkey = File.ReadAllText("C:/Users/hp/Desktop/keys/" + emri + ".xml");
            rsa.FromXmlString(pubkey);
            byte[] ivbytes = Convert.FromBase64String(iv);
            byte[] keybytes = Convert.FromBase64String(key);


            string ivst = Convert.ToBase64String(ivbytes);
            string rsakey = Convert.ToBase64String(rsa.Encrypt(keybytes, true));

            string emrienc = des.DESenc(emri, rsakey, ivst, emri);

            string teksenc = des.DESenc(emri, rsakey, ivst, teksti);

            string txt = emrienc + " " + ivst + " " + rsakey + " " + teksenc;

            return txt;
        }
        public string decrypt(string ciphertext)
        {

            string[] arg = ciphertext.Split();

            string emridec = des.DESdecrypt(arg[0], arg[2], arg[1], arg[0]);
            string tekstidec = des.DESdecrypt(arg[0], arg[2], arg[1], arg[3]);
            string plain = emridec + " " + tekstidec;

            return plain;
        }
        public string RSAdecr(string emri, string ciphertext)
        {
            // Decryption
            RSACryptoServiceProvider rsacsp = new RSACryptoServiceProvider(2048);

            // ciphertext (base64) -> ciphertext (byte[]) - Convert.FromBase64String
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);
            var pr = File.ReadAllText("C:/Users/hp/Desktop/keys/" + emri + "pri.xml");
            rsacsp.FromXmlString(pr);
            // ciphertext (byte[]) -> plaintext (byte[])  - rsa.Decrypt
            byte[] plaintextBytes = rsacsp.Decrypt(ciphertextBytes, true);

            // plaintext (byte[])  -> plaintext (string)  - Encoding.UTF8.GetString
            string plaintext = Convert.ToBase64String(plaintextBytes);

            return plaintext;
        }
    }
}
