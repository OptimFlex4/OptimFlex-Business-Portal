using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OptimflexPortal.cs
{
    //private string strHashedPassword;
    public class UserData
    {
        public int USR_ID { get; set; }
        public string USR_USERNAME { get; set; }
        public string USR_PASSWORD { get; set; }
        public int USR_TYPE { get; set; }
        public string USR_FAMILYNAME { get; set; }
        public string USR_FIRSTNAME { get; set; }
        public string USR_LASTNAME { get; set; }
        public string USR_REGISTERNO { get; set; }
        public string USR_TEL1 { get; set; }
        public string USR_TEL2 { get; set; }
        public int USR_GENDER { get; set; }
        public string USR_BIRTHDATE { get; set; }
        public int USR_ISENABLED_2FA { get; set; }
        public string AUTH_2FA_ISSUER_NAME { get; set; }
        public string AUTH_2FA_ISSUER_NOTE { get; set; }
        public string AUTH_2FA_SECRET_KEY { get; set; }
        public int AUTH_2FA_QRCODE_WIDTH { get; set; }
        public int AUTH_2FA_QRCODE_HEIGHT { get; set; }
        public int USR_ISVERIFIED_2FA { get; set; }
    }
    public class CSession
    {
        static string key { get; set; } = ConfigurationManager.AppSettings["OptimflexPortalPIN"]; //0pt1mFlex4
        public string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        public string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
        public UserData getCurrentUserData() {
            return (UserData)HttpContext.Current.Session["OptimflexPortalUserData"];
        }
        public void setUserData(UserData userData) {
            HttpContext.Current.Session["OptimflexPortalUserData"] = userData;
        }
    }
}