///ETML
///Author : Jeremy Bortone
///Date   : 27.11.2024

using System.Text;

namespace Calculatrice_C_
{

    /// <summary>
    /// Ce programme a pour but de simuler une calculatrice avec interface graphique.
    /// </summary>

    internal class Program
    {
        static void Main(string[] args)
        {
            //Déclaration variables pavé numérique
            string zero = " 0 ";
            string one = " 1 ";
            string two = " 2 ";
            string three = " 3 ";
            string four = " 4 ";
            string five = " 5 ";
            string six = " 6 ";
            string seven = " 7 ";
            string eight = " 8 ";
            string nine = " 9 ";

            //Déclaration opérations (et point)
            string division = " / ";
            string multiplication = " * ";
            string substraction = " - ";
            string addition = " + ";
            string equality = " = ";
            string dot = " . ";

            //Déclaration coordonées
            int line = 0;
            int colomn = 0;

            //Déclaration de la variable du numéro de position de chaque touche
            int poition = 0;

            //Déclaration variable touche pressée
            var pressedKey = ConsoleKey.Spacebar;

            //Déclaration de la chaîne de caractères que l'utilisateur va construire
            StringBuilder builder = new();

            //Déclaration d'une liste avec des chaînes de caractères
            List<string> numbersString = new();

            //Déclaration d'une liste avec les nombres
            List<double> numbersDouble = new();

            //Déclaration de la chaîne de caractères à afficher
            string operation = "";

            //Déclaration de la variable pour le résultat final
            double result = 0;

            //Déclaration d'une liste pour le type d'opération
            List<string> operationType = new();


            //Effaser le curseur
            Console.CursorVisible = false;

            //Pavé numérique
            while (pressedKey != ConsoleKey.Escape)
            {

                //Directions de la séléction
                if (pressedKey == ConsoleKey.Escape)
                {
                    break;
                }
                switch (pressedKey)
                {
                    case ConsoleKey.RightArrow:
                        if (colomn < 3)
                        {
                            colomn++;
                            poition++;
                        }
                        else
                        {
                            colomn = 0;
                            poition -= 3;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (colomn > 0)
                        {
                            colomn--;
                            poition--;
                        }
                        else
                        {
                            colomn = 3;
                            poition += 3;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (line < 3)
                        {
                            line++;
                            poition += 4;
                        }
                        else
                        {
                            line = 0;
                            poition -= 12;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (line > 0)
                        {
                            line--;
                            poition -= 4;
                        }
                        else
                        {
                            line = 3;
                            poition += 12;
                        }
                        break;
                }
                switch (poition)
                {
                    case 0:
                        seven = "[7]";
                        break;
                    case 1:
                        eight = "[8]";
                        break;
                    case 2:
                        nine = "[9]";
                        break;
                    case 3:
                        division = "[/]";
                        break;
                    case 4:
                        four = "[4]";
                        break;
                    case 5:
                        five = "[5]";
                        break;
                    case 6:
                        six = "[6]";
                        break;
                    case 7:
                        multiplication = "[*]";
                        break;
                    case 8:
                        one = "[1]";
                        break;
                    case 9:
                        two = "[2]";
                        break;
                    case 10:
                        three = "[3]";
                        break;
                    case 11:
                        substraction = "[-]";
                        break;
                    case 12:
                        zero = "[0]";
                        break;
                    case 13:
                        dot = "[.]";
                        break;
                    case 14:
                        equality = "[=]";
                        break;
                    case 15:
                        addition = "[+]";
                        break;
                }

                //Selection d'un élément
                if (pressedKey == ConsoleKey.Enter)
                {
                    switch (poition)
                    {
                        case 0:
                            builder.Append("7");
                            operation += "7";
                            break;
                        case 1:
                            builder.Append("8");
                            operation += "8";
                            break;
                        case 2:
                            builder.Append("9");
                            operation += "9";
                            break;
                        case 3:
                            numbersString.Add(builder.ToString());
                            operation += " / ";
                            builder.Clear();
                            break;
                        case 4:
                            builder.Append("4");
                            operation += "4";
                            break;
                        case 5:
                            builder.Append("5");
                            operation += "5";
                            break;
                        case 6:
                            builder.Append("6");
                            operation += "6";
                            break;
                        case 7:
                            numbersString.Add(builder.ToString());
                            operation += " * ";
                            builder.Clear();
                            break;
                        case 8:
                            builder.Append("1");
                            operation += "1";
                            break;
                        case 9:
                            builder.Append("2");
                            operation += "2";
                            break;
                        case 10:
                            builder.Append("3");
                            operation += "3";
                            break;
                        case 11:
                            numbersString.Add(builder.ToString());
                            operation += " - ";
                            builder.Clear();
                            break;
                        case 12:
                            builder.Append("0");
                            operation += "0";
                            break;
                        case 13:
                            builder.Append(",");
                            operation += ",";
                            break;
                        case 14:
                            numbersString.Add(builder.ToString());
                            operation += " = ";
                            builder.Clear();

                            for (int i = 0; i < numbersString.Count; i++)
                            {
                                bool verification = double.TryParse(numbersString[i], out double newNumber);
                                numbersDouble.Add(newNumber);
                            }

                            if (operation.Contains(" * "))
                            {
                                result = numbersDouble[0] * numbersDouble[1];
                            }
                            else if (operation.Contains(" / "))
                            {
                                result = numbersDouble[0] / numbersDouble[1];
                            }
                            else if (operation.Contains(" + "))
                            {
                                result = numbersDouble[0] + numbersDouble[1];
                            }
                            else if (operation.Contains(" - "))
                            {
                                result = numbersDouble[0] - numbersDouble[1];
                            }

                            operation = operation + result;
                            break;
                        case 15:
                            numbersString.Add(builder.ToString());
                            operation += " + ";
                            builder.Clear();
                            break;
                    }
                }

                //Affichage pavé numérique
                Console.WriteLine($"{seven}{eight}{nine}{division}");
                Console.WriteLine($"{four}{five}{six}{multiplication}");
                Console.WriteLine($"{one}{two}{three}{substraction}");
                Console.WriteLine($"{zero}{dot}{equality}{addition}");
                Console.WriteLine($"Expression : {operation}");

                //Renitialisation variables pavé numérique
                zero = " 0 ";
                one = " 1 ";
                two = " 2 ";
                three = " 3 ";
                four = " 4 ";
                five = " 5 ";
                six = " 6 ";
                seven = " 7 ";
                eight = " 8 ";
                nine = " 9 ";

                //Renitialisation opérations (et point)
                division = " / ";
                multiplication = " * ";
                substraction = " - ";
                addition = " + ";
                equality = " = ";
                dot = " . ";

                //Attendre que l'utilisateur presse une touche et la mémoriser
                pressedKey = Console.ReadKey().Key;

                //Renitialiser l'écran
                Console.Clear();
            }
        }
    }
}
