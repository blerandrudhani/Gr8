namespace ds
{
    class des
    {
        
        public string DESenc(string emri, string keystr, string ivstr, string teksti)
        {
rsa rsa = new rsa();
            string k = rsa.RSAdecr(emri, keystr);

            byte[] key = Convert.FromBase64String(k);
            byte[] iv = Convert.FromBase64String(ivstr);
            byte[] tekstibyte = Encoding.UTF8.GetBytes(teksti);

            if (String.IsNullOrEmpty(teksti))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(teksti);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

        }

        public string DESdecrypt(string emri, string keystr, string ivstr, string teksti)
        {
            rsa rsa = new rsa();
 string filere = File.ReadAllText("C:/Users/hp/Desktop/keys/users.txt");
            string[] a = filere.Split();
            for (int i = 0; i < a.Length; i++)
            {
                if (emri == a[i]) { emri = a[i - 1]; }
            }

            string k = rsa.RSAdecr(emri, keystr);

            byte[] key = Convert.FromBase64String(k);
            byte[] iv = Convert.FromBase64String(ivstr);
            byte[] tekstibyte = Encoding.UTF8.GetBytes(teksti);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(teksti));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(key, iv), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();


        }
    }
}
