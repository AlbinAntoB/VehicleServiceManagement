
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSeviceManagement.Framework.Helper
{
    public class EncryptionHelper
    {
        public static string DefaultPassword = "iV4sdwiXQ1iz4v/nUeJAjlZ/wk13UAnvw8HpHCWymvOx3DIXYkZDaQ==";
        public static string DecryptDefaultPassword = "LQ7PPsSS6DHidqrPigR4ECd1M3kIG8gDnok3Bd4lU6m/3LioUSzAFokQO2t6uJyS";
        public static string EncryptionKey = "OptionC@New2020";

        public static string HashPassword(string Password)
        {
            if (string.IsNullOrEmpty(Password)) return null;
            if (Password.Length < 1) return null;
            byte[] salt = new byte[20];
            byte[] key = new byte[20];
            byte[] ret = new byte[40];

            try
            {
                RNGCryptoServiceProvider randomBytes = new RNGCryptoServiceProvider();
                randomBytes.GetBytes(salt);
                var hashBytes = new Rfc2898DeriveBytes(Password, salt, 10000);
                key = hashBytes.GetBytes(20);
                Buffer.BlockCopy(salt, 0, ret, 0, 20);
                Buffer.BlockCopy(key, 0, ret, 20, 20);
                // returns salt/key pair
                return Convert.ToBase64String(ret);
            }
            finally
            {
                if (salt != null)
                    Array.Clear(salt, 0, salt.Length);
                if (key != null)
                    Array.Clear(key, 0, key.Length);
                if (ret != null)
                    Array.Clear(ret, 0, ret.Length);
            }
        }
        public static bool VerifyPassword(string PasswordHash, string Password)
        {
            if (string.IsNullOrEmpty(PasswordHash) || string.IsNullOrEmpty(Password)) return false;
            if (PasswordHash.Length < 40 || Password.Length < 1) return false;

            byte[] salt = new byte[20];
            byte[] key = new byte[20];
            byte[] hash = Convert.FromBase64String(PasswordHash);
            byte[] ret = new byte[40];

            try
            {
                Buffer.BlockCopy(hash, 0, salt, 0, 20);
                Buffer.BlockCopy(hash, 20, key, 0, 20);

                var hashBytes = new Rfc2898DeriveBytes(Password, salt, 10000);

                byte[] newKey = hashBytes.GetBytes(20);
                if (newKey != null)
                    if (newKey.SequenceEqual(key))

                        return true;

                return false;
            }
            finally
            {
                if (salt != null)
                    Array.Clear(salt, 0, salt.Length);
                if (key != null)
                    Array.Clear(key, 0, key.Length);
                if (hash != null)
                    Array.Clear(hash, 0, hash.Length);
            }
        }

        /// <summary>
        /// accepts a plain text string and returns the string encrypted
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// 

        public static string EncryptValue(string sEncryptionData)
        {
            string sEncryptionValue = string.Empty;
            try
            {

                byte[] clearBytes = Encoding.Unicode.GetBytes(sEncryptionData);
                using (Aes encryptor = Aes.Create())
                {
                    // encryptor.Padding = PaddingMode.None;
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    // encryptor.Key = pdb.GetBytes(24);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        sEncryptionValue = Convert.ToBase64String(ms.ToArray());
                        sEncryptionValue = sEncryptionValue.Replace("/", "♥"); 
                    }
                }
            }
            catch (Exception Ex)
            {
                new ErrorLog().WriteLog(Ex);
            }
            return sEncryptionValue;
        }
        /// <summary>
        /// accepts an encrypted string and returns the string as plain text
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string DecryptValue(string cipherText)
        {

            string sDecrpytText = "";
            try
            {
                if (cipherText != null && EncryptionKey != "" && cipherText != "")
                {
                    cipherText = cipherText.Replace( "♥","/");

                    cipherText = cipherText.Replace(" ", "+");// Replace the Empty string with. Becase FromBase64String won't accept the Empty string
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    using (Aes encryptor = Aes.Create())
                    {
                        // encryptor.Padding = PaddingMode.Zeros;
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        //encryptor.Key = pdb.GetBytes(24);
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.Close();
                            }
                            sDecrpytText = Encoding.Unicode.GetString(ms.ToArray());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                new ErrorLog().WriteLog(Ex);
            }
            return sDecrpytText;
        }

        public static string GetRandomPassword(int iLen = 8)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz0123456989#@!ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < iLen; i++)
            {
                int x = random.Next(1, chars.Length);
                //Don't Allow repeation of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            return password;
        }

        public static string GetRandomNumber(int iLen = 6)
        {
            char[] chars = "0123456989".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < iLen; i++)
            {
                int x = random.Next(1, chars.Length);
                //Don't Allow repeation of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            return password;
        }
    }
    public class CryptoEngine
    {
        public static string EncryptionKey = "OptionCFORMS";

        public static string Encrypt(string input)
        {
          
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(EncryptionKey);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            string EncryptValue = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            EncryptValue = EncryptValue.Replace("/", "♥");
            return EncryptValue;
        }
        public static string Decrypt(string DecryptValues)
        {
            DecryptValues = DecryptValues.Replace(" ", "+");
            DecryptValues = DecryptValues.Replace( "♥","/");
            byte[] inputArray = Convert.FromBase64String(DecryptValues);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(EncryptionKey);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }

//    public class  WriteFormattedGrade(Grade grade, int dioceseID, int gradeLevel)
//    {
//            if (grade.Type != 0)
//            {
//                if (grade.IsRubric)
//                {
//                    if (dioceseID == 119 && (gradeLevel == 14 || (gradeLevel >= 1 && gradeLevel <= 4)))
//                    {


//#line default
//#line hidden
//                        BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6312, 22, false);


//#line 90 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"
//                        WriteTo(__razor_helper_writer, WriteAlphaGrade(grade));


//#line default
//#line hidden
//                        EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6312, 22, false);


//#line 90 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"

//                    }
//                    else
//                    {


//#line default
//#line hidden
//                        BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6417, 22, false);


//#line 94 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"
//                        WriteTo(__razor_helper_writer, WriteAlphaGrade(grade));


//#line default
//#line hidden
//                        EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6417, 22, false);


//#line 94 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"

//                        if (grade.PostRunningCStar && grade.Numeric.HasValue)
//                        {

//#line default
//#line hidden
//                            BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6537, 5, true);

//                            WriteLiteralTo(__razor_helper_writer, "<span");

//                            EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6537, 5, true);

//                            BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6542, 22, true);

//                            WriteLiteralTo(__razor_helper_writer, " class=\"numeric-grade\"");

//                            EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6542, 22, true);

//                            BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6564, 1, true);

//                            WriteLiteralTo(__razor_helper_writer, ">");

//                            EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6564, 1, true);

//                            BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6566, 40, false);


//#line 96 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"
//                            WriteTo(__razor_helper_writer, String.Format("{0:0.00}", grade.Numeric));


//#line default
//#line hidden
//                            EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6566, 40, false);

//                            BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6606, 7, true);

//                            WriteLiteralTo(__razor_helper_writer, "</span>");

//                            EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6606, 7, true);


//#line 96 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"
//                        }
//                    }
//                }
//                else
//                {


//#line default
//#line hidden
//                    BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6700, 22, false);


//#line 101 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"
//                    WriteTo(__razor_helper_writer, WriteAlphaGrade(grade));


//#line default
//#line hidden
//                    EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6700, 22, false);


//#line 101 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"

//                    if (grade.PostRunningCStar && grade.Numeric.HasValue)
//                    {

//#line default
//#line hidden
//                        BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6812, 5, true);

//                        WriteLiteralTo(__razor_helper_writer, "<span");

//                        EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6812, 5, true);

//                        BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6817, 22, true);

//                        WriteLiteralTo(__razor_helper_writer, " class=\"numeric-grade\"");

//                        EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6817, 22, true);

//                        BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6839, 1, true);

//                        WriteLiteralTo(__razor_helper_writer, ">");

//                        EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6839, 1, true);

//                        BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6841, 38, false);


//#line 103 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"
//                        WriteTo(__razor_helper_writer, String.Format("{0:0}%", grade.Numeric));


//#line default
//#line hidden
//                        EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6841, 38, false);

//                        BeginContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6879, 7, true);

//                        WriteLiteralTo(__razor_helper_writer, "</span>");

//                        EndContext(__razor_helper_writer, "~/App_Code/Helpers/SiteHelper.cshtml", 6879, 7, true);


//#line 103 "C:\Users\Bsoft\Desktop\Family portal\family\family.optionc.com\website\App_Code\Helpers\SiteHelper.cshtml"
//                    }
//                }
//            }

//    }
}
