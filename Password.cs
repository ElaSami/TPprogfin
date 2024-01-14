using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur_de_Mot_de_passe
{
   public class Password
    {
        private static ArrayList passwordsList = new ArrayList();

        public Password()
        {
            
            Length = 12;
            URL = "";


        }

        private string passwordValue;
        private string description;
        private string specialCharacters;
        private string userAccount;
        public string URL { get; set; }
        public string Note { get; set; }



        public string LowerCaseCharacters => "abcdefghijklmnopqrstuvwxyz";
        public string DigitCharacters => "0123456789";

        public string Description
        {
            get => description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))throw new ArgumentException("La description ne peut pas être vide.");

                description = value;
            }
        }
        public string InsertRandomCharacter(string input, string characters)
        {
            Random random = new Random();
            int position = random.Next(0, input.Length + 1);
            char randomCharacter = characters[random.Next(0, characters.Length)];
            return input.Insert(position, randomCharacter.ToString());
        }
        public string PasswordValue { get {  return passwordValue; } set { passwordValue = value; } }
        public int Length { get; set; }
        public string UserAccount { get {return userAccount; } set { userAccount= value; } }

        public string SpecialCharacters
        {
            get { return specialCharacters; }
            set
            {
                // Vérifier si la valeur est nulle ou composée uniquement d'espaces
                if (!string.IsNullOrWhiteSpace(value))
                {
                    specialCharacters = value;
                }
                // Sinon, accepter une chaîne vide ou composée uniquement d'espaces
                // Vous pouvez également choisir de ne rien faire dans ce cas, en fonction de vos besoins
            }

    }
    /* public string GeneratePassword()
    {
        StringBuilder password = new StringBuilder();
        Random random = new Random();

        string validChars = LowerCaseCharacters;

        if (HasUppercaseCharacters || HasDigitCharacters || HasSpecialCharacters())
        {
            if (HasUppercaseCharacters)
                validChars += UpperCaseCharacters;

            if (HasDigitCharacters)
                validChars += DigitCharacters;

            if (HasSpecialCharacters())
                validChars += SpecialCharacters;

            for (int i = 0; i < Length; i++)
            {
                password.Append(validChars[random.Next(0, validChars.Length)]);
            }
        }
        else
        {
            // Si une seule option est cochée, inclure au moins un caractère de cette option
            if (HasUppercaseCharacters)
                password.Append(UpperCaseCharacters[random.Next(0, UpperCaseCharacters.Length)]);
            else if (HasDigitCharacters)
                password.Append(DigitCharacters[random.Next(0, DigitCharacters.Length)]);
            else if (HasSpecialCharacters())
                password.Append(SpecialCharacters[random.Next(0, SpecialCharacters.Length)]);
        }

        passwordValue = password.ToString();
        return passwordValue;
    }
    */
    public bool HasUppercaseCharacters { get; set; }
        public bool HasDigitCharacters { get; set; }
        public string UpperCaseCharacters => LowerCaseCharacters.ToUpper();

        public bool HasSpecialCharacters()
        {
            return !string.IsNullOrEmpty(specialCharacters);
        }

          public string GeneratePassword()
           {
               StringBuilder password = new StringBuilder();
               Random random = new Random();

               string validChars = LowerCaseCharacters;
               if (HasUppercaseCharacters)
                   validChars += UpperCaseCharacters;
               if (HasDigitCharacters)
                   validChars += DigitCharacters;
               if (HasSpecialCharacters())
                   validChars += specialCharacters;

               for (int i = 0; i < Length; i++)
               {
                   password.Append(validChars[random.Next(0, validChars.Length)]);
               }

               passwordValue = password.ToString();
               return passwordValue;
           }
       
        

        public override string ToString()
        {
            return Description;
        }

    }
}

