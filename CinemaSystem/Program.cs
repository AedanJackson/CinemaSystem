using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CinemaSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Stores the current films showing and their age ratings and tickets sold (in the corresponding index)
            string[] ListOfFilms = { "Rush", "How I Live Now", "Thor: The Dark World", "Filth", "Planes" };
            string[] FilmAgeRatings = { "15", "15", "12", "18", "U" };
            int[] TicketsSold = { 0, 0, 0, 0, 0 };
            while (true)
            {
                while (true)
                {
                    DisplayCurrentFilms(ListOfFilms, FilmAgeRatings, TicketsSold);
                    int FilmSelected = AskUserForFilm(ListOfFilms, FilmAgeRatings, TicketsSold);
                    if (FilmSelected == 0)
                    {
                        break;
                    }
                    else
                    {
                        TicketsSold[FilmSelected] += 1;
                    }
                    DateTime Date = GetDate();
                    PrintATicket(ListOfFilms[FilmSelected], Date);

                }
            }
            
        }

        // Subroutine to print a list of the current films

        static void DisplayCurrentFilms(string[] ListOfFilms, string[] FilmAgeRatings, int[] TicketsSold)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Welcome to Aquinas multiplex!");
            Console.WriteLine("We are currently showing:");
            for (int i = 0; i < ListOfFilms.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {ListOfFilms[i]} ({FilmAgeRatings[i]}) Tickets sold: {TicketsSold[i]}");
            }
        }

        // Subroutine to ask the user for the film they want to see
        static int AskUserForFilm(string[] ListOfFilms, string[] ListOfAgeRatings, int[] TicketsSold)
        {
            // Asks for a film selection (and validates it)
            int UserSelection = 0;
            bool ValidUserSelection = false;
            do
            {
                Console.Write($"What film would you like to watch? Please enter a value\nbetween 1 and {ListOfFilms.Length}. Enter 0 to exit and return to main screen: ");
                try
                {
                    UserSelection = Convert.ToInt32(Console.ReadLine());
                    if (UserSelection < 0 || UserSelection > ListOfFilms.Length)
                    {
                        Console.WriteLine("Not a valid selection");
                    }
                    else
                    {
                        ValidUserSelection = true;
                    }
                }
                catch
                {
                    Console.WriteLine("That is not a number. Please try again.");
                }

            } while (!ValidUserSelection);
            if (UserSelection == 0)
            {
                return 0;
            }

            // Asks for the uers's age (and validates it) to see if they are allowed to watch the film. Does not ask for age if the film is rated "U"
            // Ouputs the correct corresponding message for each age rating depending on the user's age.
            // This can maybe be cleaned up this code feels kind of ugly
            if (ListOfAgeRatings[UserSelection - 1] == "U")
            {
                Console.WriteLine("Great news! This film is rated U. Anyone may watch this film.");
            }
            else
            {
                Console.Write($"{ListOfFilms[UserSelection - 1]} is rated {ListOfAgeRatings[UserSelection - 1]}. Please enter your age.\nEnter 0 to exit and return to the main screen: ");
                bool ValidUserAge = false;
                int UserAge = 0;
                do
                {
                    try
                    {
                        UserAge = Convert.ToInt32(Console.ReadLine());
                        ValidUserAge = true;
                    }
                    catch
                    {
                        Console.WriteLine("That is not a valid age");
                    }
                } while (!ValidUserAge);

                if (UserAge == 0)
                {
                    return 0;
                }
                if (ListOfAgeRatings[UserSelection - 1] == "18" && UserAge < 18)
                {
                    Console.WriteLine("You cannot watch this film, you are too young. Come back in a couple of years!");
                    return 0;
                }
                else if (ListOfAgeRatings[UserSelection - 1] == "15" && UserAge < 15)
                {
                    Console.WriteLine("You cannot watch this film, you are too young. Come back in a couple of years!");
                    return 0;
                }
                else if (ListOfAgeRatings[UserSelection - 1] == "12" && UserAge < 12)
                {
                    Console.WriteLine("You cannot watch this film, you are too young. Come back in a couple of years!");
                    return 0;
                }
                else if (ListOfAgeRatings[UserSelection - 1] == "PG" && UserAge < 12)
                {
                    Console.WriteLine("You can watch this film, but you need to have a parent with you.");
                }
            }
            return UserSelection - 1;
        }

        // Subroutine to ask the user for the date they want to watch the film

        static DateTime GetDate()
        {
            // Validation section, checks that the user has entered a correct date and that that date is not in the past, and no more than one week into the future
            bool ValidDateSelection = false;
            DateTime Date = DateTime.MinValue;
            do
            {
                Console.Write("Enter the date you would like to watch the film: ");
                try
                {
                    Date = Convert.ToDateTime(Console.ReadLine());
                    if (Date < DateTime.Now)
                    {
                        Console.WriteLine("Cannot book for a date in the past");
                    }
                    else if (Date > DateTime.Now + TimeSpan.FromDays(7))
                    {
                        Console.WriteLine("This date is too far in the future. Please enter a date less than a week away");
                    }
                    else
                    {
                        ValidDateSelection = true;
                    }
                }
                catch
                {
                    Console.WriteLine("That is not a valid date, please enter a date in the format DD/MM/YYYY");
                }
            } while (!ValidDateSelection);
            return Date;
        }

        // Subroutine to print a ticket once the program is done
        // NOTE TO SELF: ADD SEAT NUMBER HERE IF YOU CHOOSE TO ADD IT

        static void PrintATicket(string Film, DateTime Date /*seat number?*/)
        {
            Console.WriteLine("Your ticket:");
            Console.WriteLine("--------------------");
            Console.WriteLine("Aquinas multiplex   ");
            Console.WriteLine($"Film : {Film}");
            Console.WriteLine($"Date : {Date.Day}/{Date.Month}/{Date.Year}");
            //Console.WriteLine($"Seat : {Seat}");
            Console.WriteLine("\n");
            Console.WriteLine("Enjoy the film!     ");
            Console.WriteLine("--------------------");
        }

    }
}
