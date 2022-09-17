using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    internal class UserInput
    {
        public static void selection()
        {
            Console.WriteLine("Select your Input Type");
            Console.WriteLine("1 - Add Journey Time Delay");
            Console.WriteLine("2 - Remove Journey Time Delay");
            Console.WriteLine("3 - Close Track");
            Console.WriteLine("4 - Open Track");
            Console.WriteLine("5 - Print Closed Track sections");
            Console.WriteLine("6 - Print Delay Journey Track sections");

            int inputNumber = Convert.ToInt32(Console.ReadLine());

            switch (inputNumber)
            {
                case 1:
                    addJourneyDelay();
                    break;
                case 2:
                    removeJourneyDelay();
                    break;
                case 3:
                    closeTrack();
                    break;
                case 4:
                    openTrack();
                    break;
                case 5:
                    printClosedTrack();
                    break;
                case 6:
                    printDelayTrack();
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }

        }

        public static void addJourneyDelay()
        {
            Console.WriteLine("Name of the Start Station");
            string fromStation = Console.ReadLine();
            Console.WriteLine("Name of the End Station");
            string toStation = Console.ReadLine();
            Console.WriteLine("Enter the delay in minutes");
            int delay = Convert.ToInt32(Console.ReadLine());

            Link toOpenLink = StationList.searchLink(fromStation, toStation);
            if (toOpenLink != null)
            {
                toOpenLink.addDelay(delay);
                Console.WriteLine("Successfull added the delay");
            }
            else
            {
                Console.WriteLine("Check the input");
            }
        }

        public static void removeJourneyDelay()
        {
            Console.WriteLine("Name of the Start Station");
            string fromStation = Console.ReadLine();
            Console.WriteLine("Name of the End Station");
            string toStation = Console.ReadLine();
            
            Link toOpenLink = StationList.searchLink(fromStation, toStation);
            if (toOpenLink != null)
            {
                toOpenLink.removeDelay();
                Console.WriteLine("Successfull added the delay");
            }
            else
            {
                Console.WriteLine("Check the input");
            }
        }

        public static void closeTrack()
        {
            Console.WriteLine("Name of the Start Station");
            string fromStation = Console.ReadLine();
            Console.WriteLine("Name of the End Station");
            string toStation = Console.ReadLine();
            Link toOpenLink = StationList.searchLink(fromStation, toStation);
            if (toOpenLink != null)
            {
                toOpenLink.closeTrack();
                Console.WriteLine("Successfull change the status of the link to CLOSE");
            }
            else
            {
                Console.WriteLine("Check the input");
            }
        }

        public static void openTrack()
        {
            Console.WriteLine("Name of the Start Station");
            string fromStation = Console.ReadLine();
            Console.WriteLine("Name of the End Station");
            string toStation = Console.ReadLine();
            Link toOpenLink = StationList.searchLink(fromStation, toStation);
            if(toOpenLink != null)
            {
                toOpenLink.openTrack();
                Console.WriteLine("Successfull change the status of the link to OPEN");
            }
            else
            {
                Console.WriteLine("Check the input");
            }
            
        }

        public static void printClosedTrack()
        {
            StationList.displayClosedLink();
        }

        public static void printDelayTrack()
        {
            StationList.delayLink();
        }
    }
}
