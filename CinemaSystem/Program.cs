using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine($"{i + 1}) {ListOfFilms[i]} ({FilmAgeRatings[i]}) Tickets sold: {TicketsSold[i]}/45");
            }
        }

        // Subroutine to ask the user for the film they want to see
        static int AskUserForFilm(string[] ListOfFilms, string[] ListOfAgeRatings, int[] TicketsSold)
        {
            // Asks for a film selection (and validates it)
            int UserSelection = 0;
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
                }
                catch
                {
                    Console.WriteLine("That is not a number. Please try again.");
                }

            } while (UserSelection > ListOfFilms.Length || UserSelection < 0);
            if (UserSelection == 0)
            {
                return 0;
            }

            // Asks for the uers's age (and validates it) to see if they are allowed to watch the film
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

        // Subroutine to print a ticket once the program is done
        // NOTE TO SELF: ADD SEAT NUMBER HERE IF YOU CHOOSE TO ADD IT

        static void PrintATicket(string Film, DateTime Date /*seat number?*/)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Aquinas multiplex   ");
            Console.WriteLine($"Film : {Film}");
            Console.WriteLine($"Date : {Date}");
            //Console.WriteLine($"Seat : {Seat}");
            Console.WriteLine("\n");
            Console.WriteLine("Enjoy the film!     ");
            Console.WriteLine("--------------------");
        }

    }
}
