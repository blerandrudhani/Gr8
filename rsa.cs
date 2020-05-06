namespace ds
{
class rsa
    {
        des des = new des();
        public void createUser(string emri)
        {
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
            Console.WriteLine(" User : " + emri + " u fshi");
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
