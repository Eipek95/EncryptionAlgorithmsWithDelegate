using System;
using System.Text;

namespace EncryptionAlgorithmsWithDelegate
{
    class Program
    {
        //tobase64algorithms---->8 bitlik verileri 64 bitlik formata çeviriyor.yani byte dizisi üzerinde değişiklik yapıyor
        //caesarencryption---->klavyeden girilmiş olan yada veritabanında bulunuş olan verileri belirlediğimiz aralıktan sonra gelecek karekterlere eşleyen şifreleme

        delegate void EncryptionAlgorithms(string dataToBeEncrypted);
        #region ToBase64Algorithms
        public static void encryptionToBase64(string targetText)
        {
            byte[] dataArray = ASCIIEncoding.ASCII.GetBytes(targetText);//Ascii formatında şifreleme yapar ve bit dizisine atar
            string encryptedText = Convert.ToBase64String(dataArray);//gelen bit dizisini 8 bitten 64 bite çevirir
            Console.WriteLine("ToBase64 algoritması ile şifrelenen cümle-----> " + targetText);
            Console.WriteLine("ToBase64 algoritması ile şifreli cümle-----> " + encryptedText);
            decryptionToBase64(encryptedText);
        }
        public static void decryptionToBase64(string encryptedText)
        {
            byte[] decodingTextArray = Convert.FromBase64String(encryptedText);//parametre ile gelen 64 bitlik veriyi 8 bitlik veriye çevirir ve bit dizisine atar
            string decodingTarget = ASCIIEncoding.ASCII.GetString(decodingTextArray);//decodingTextArray dizisini string formatında alır
            Console.WriteLine("ToBase64 algoritması ile şifrelenen cümlenin deşifresi-----> " + decodingTarget);
        }
        #endregion

        #region CaesarEncryption
        public static void encryptionCeaser(string targetText)
        {
            string getAll = null;
            char[] charactersArray = targetText.ToCharArray();//veriden gelen değerleri char dizisine ata
           
            foreach (char item in charactersArray)
            {
                getAll += Convert.ToChar(item + 3).ToString();

            }
            Console.WriteLine();
            Console.WriteLine("CaesarEncryption algoritması ile şifrelenen cümle-----> " + targetText);
            Console.WriteLine("CaesarEncryption algoritması ile şifreli cümle-----> " + getAll);//dizide girdiğimiz karakterlerin  üç karekter ötesini getirir.
            decryptionCeaser(getAll);
        }
        public static void decryptionCeaser(string encryptedText)
        {
            string getExpresion = encryptedText;
            string getAll = null;
            char[] charactersArray2 = getExpresion.ToCharArray();
            foreach (char item2 in charactersArray2)
            {
            getAll += Convert.ToChar(item2 - 3).ToString();
            }
            Console.Write("CaesarEncryption algoritması ile şifrelenen cümlenin deşifresi-----> " + getAll);
        }
        #endregion
        static void Main(string[] args)
        {
            EncryptionAlgorithms encryption = new EncryptionAlgorithms(encryptionToBase64);
            encryption += encryptionCeaser;
            Console.WriteLine("Şifrelenecek Cümleyi giriniz: ");
            encryption(Console.ReadLine());
        }
    }
}
