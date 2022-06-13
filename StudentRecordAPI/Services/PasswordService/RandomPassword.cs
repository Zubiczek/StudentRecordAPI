using System;
using System.Text;

namespace StudentRecordAPI.Services.PasswordService
{
    public class RandomPassword : IRandomPassword
    {
        public string Generate()
        {
            StringBuilder builder = new StringBuilder();
            Random rnd = new Random();
            char[] possiblechars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 
            'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z', '0',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '#', '$', '&', '?'};
            for(int i=0; i<10; i++)
            {
                int random = rnd.Next(possiblechars.Length);
                builder.Append(possiblechars[random]);
            }
            return builder.ToString();
        }
    }
}
