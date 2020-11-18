using System;
using System.Security.Cryptography;
using System.Text;

namespace Articles.Util
{
    public static class HashMD5
    {
        public static string GetMd5Hash(MD5 md5Hash, string valor)
        {
            byte[] bytMensagem = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(valor));
            // Cria o Hash MD5 hash

            StringBuilder sBuilder = new StringBuilder();

            for (int iItem = 0; iItem < bytMensagem.Length; iItem++)
            {
                sBuilder.Append(bytMensagem[iItem].ToString("X2"));
            }
            return sBuilder.ToString();
        }

        public static String getMD5(String valor)
        {
            string hash = "";

            using (var md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, valor);
            }

            return hash;
        }
    }
}
