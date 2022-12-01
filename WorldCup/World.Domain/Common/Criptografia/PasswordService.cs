namespace WorldCup.Domain.Common.Criptografia
{
    public class PasswordService
    {
        public static string Encrypt(string password)
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
            crypt.HashAlgorithm = "md5";
            crypt.EncodingMode = "hex";

            return crypt.HashStringENC(password);
        }
    }
}
