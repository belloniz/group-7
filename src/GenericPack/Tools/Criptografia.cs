using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenericPack.Tools
{
    public class Criptografia
    {
        private const string encryptionKey = "AE09F72B007CAAB5";

        // HexToByte
        // Converts a hexadecimal string to a byte array. Used to convert encryption
        // key values from the configuration.
        public static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2 - 1 + 1];
            for (int i = 0; i <= returnBytes.Length - 1; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        // EncodePassword
        // Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
        public static string EncodePassword(string password)
        {
            string encodedPassword = password;
            HMACSHA1 hash = new HMACSHA1();

            hash.Key = HexToByte(encryptionKey);
            encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));

            return encodedPassword;
        }

        // CheckPassword
        // Compares password values based on the MembershipPasswordFormat.
        public static bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            pass1 = EncodePassword(password);

            if (pass1 == pass2)
                return true;

            return false;
        }
    }

}
