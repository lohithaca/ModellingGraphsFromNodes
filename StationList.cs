using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    internal class StationList
    {
        static ArrayList stationList = new ArrayList();
        int stationIndex = -1;

        public bool searchStation(Station station)
        {
            bool isAvailable = false;
            for (int i = 0; i < stationList.Count; i++)
            {
                Station station1 = (Station)stationList[i];
                if (station1.isEquel(station))
                {
                    isAvailable = true;
                    stationIndex = i;
                    break;
                }
            }
            if (isAvailable)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void addStation(Station station)
        {
            bool isAvailable = searchStation(station);
            if (!isAvailable)
            {
                stationList.Add(station);
                stationIndex = stationList.Count;
            }
            
        }

        public void displayStation()
        {
            foreach(Station station in stationList)
            {
                Console.WriteLine(station.getStationName());
            }
        }

        public void addLink(Station station, Link link)
        {
            addStation(station);
            Station station1 = (Station)stationList[stationIndex];

            if(!isAvailableLink(station.getStationName(), link))
            {
                if (station1.getStationLink() == null)
                {
                    station1.addLinkStation(link);
                }
                else
                {
                    Link nextLink = station1.getStationLink();
                    while (nextLink.getLink() != null)
                    {
                        nextLink = nextLink.getLink();
                    }
                    nextLink.setLink(link);
                }
            }

            
        }

        public void displayLink()
        {
            for (int i = 0; i < stationList.Count; i++)
            {
                Station station1 = (Station)stationList[i];
                Console.Write(station1.getStationName()+" -> ");
                Link nextLink = station1.getStationLink();
                while (nextLink != null)
                {
                    Console.Write(nextLink.getFromStation()+":"+nextLink.getToStation()+" -> ");
                    nextLink = nextLink.getLink();
                }
                Console.WriteLine();
            }
        }

        public static void displayClosedLink()
        {
            for (int i = 0; i < stationList.Count; i++)
            {
                Station station1 = (Station)stationList[i];
                Link nextLink = station1.getStationLink();
                while (nextLink != null)
                {
                    if (!nextLink.getStatus())
                    {
                        Console.Write(nextLink.getJourney() + " : "+nextLink.getFromStation() 
                            + ":" + nextLink.getToStation() + " - Closed ");
                    }
                    nextLink = nextLink.getLink();
                }
                Console.WriteLine();
            }
        }

        public static void delayLink()
        {
            for (int i = 0; i < stationList.Count; i++)
            {
                Station station1 = (Station)stationList[i];
                Link nextLink = station1.getStationLink();
                while (nextLink != null)
                {
                    if (nextLink.getDelay()>0)
                    {
                        Console.Write(nextLink.getJourney()+" : "+nextLink.getFromStation() + ":" 
                            + nextLink.getToStation() + " - " +nextLink.getDelay().ToString("0.00") + "min");
                    }
                    nextLink = nextLink.getLink();
                }
                Console.WriteLine();
            }
        }


        public ArrayList getArryList()
        {
            return stationList;
        }

        public bool isAvailableLink(string stationName, Link link)
        {
            bool isLinkConnected = false;
            for (int i = 0; i < stationList.Count; i++)
            {
                Station station1 = (Station)stationList[i];
                if (station1.getStationName().Equals(stationName))
                {
                    Link nextLink = station1.getStationLink();
                    while (nextLink != null)
                    {
                        if (nextLink.Equals(link))
                        {
                            isLinkConnected = true;
                        }
                        nextLink = nextLink.getLink();
                    }
                }
            }
            return isLinkConnected;
        }

        public static Link searchLink(string stationName, string toStation)
        {
            Link searchLink = null;
            for (int i = 0; i < stationList.Count; i++)
            {
                Station station1 = (Station)stationList[i];
                if (station1.getStationName().Equals(stationName))
                {
                    Link link = station1.getStationLink();
                    while (link != null)
                    {
                        if (link.getToStation().Equals(toStation))
                        {
                            searchLink = link;
                        }
                        link = link.getLink();
                    }
                }
            }
            return searchLink;
        }
    }
}
