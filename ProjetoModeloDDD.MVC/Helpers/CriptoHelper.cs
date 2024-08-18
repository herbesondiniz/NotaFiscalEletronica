using System.Security.Cryptography;
using System.Text;

namespace ProjetoModeloDDD.MVC.Helpers
{
    public class CriptoHelper
    {
        public static string hashMD5(string val)
        {
            var ret = string.Empty;
            var hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(val));
            for (int i = 0; i < hash.Length; i++)
            {
                ret += hash[i].ToString("x2");
            }

            return ret;
        }
    }
}