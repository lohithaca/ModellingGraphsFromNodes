using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Transport
{
    internal class ShortPath
    {
        ArrayList visitedStationList = new ArrayList();
        ArrayList shortPathStationList = new ArrayList();
        ArrayList haveToVisitLinkList = new ArrayList();
        public void shortPath(StationList stationList,Station start, Station end)
        {
                  
            for (int i = 0; i < stationList.getArryList().Count; i++)
            {
                shortPathStationList.Add(stationList.getArryList()[i]);
            }
            
            returnLink(start.getStationName(), stationList.getArryList());
            initialTimeCalculation(haveToVisitLinkList,shortPathStationList,start);
            addRemoveVisitedStation(start);
           
            
           while(shortPathStationList.Count !=0)
            {
                int minIndex = minTimeIndex(shortPathStationList);
                           
                    Station minStation = (Station)shortPathStationList[minIndex];
                    returnLink(minStation.getStationName(), stationList.getArryList());
                    timeCalculation(haveToVisitLinkList, shortPathStationList, minStation);
                    addRemoveVisitedStation(minStation);   
            }
            displayVisitedStation();
            Console.WriteLine();
            displayPath(start, end);

        }

        public void returnLink(string stationName, ArrayList stationList)
        {
            if (haveToVisitLinkList != null)
            {
                haveToVisitLinkList.Clear();
            }

            ArrayList haveToVisitLink = new ArrayList();
            for (int i = 0; i < stationList.Count; i++)
            {
                Station station1 = (Station)stationList[i];
                if (station1.getStationName().Equals(stationName))
                {
                    Link link = station1.getStationLink();
                    while (link != null)
                    {
                        if (link.getStatus())
                        {
                            haveToVisitLinkList.Add(link);
                        }
                        link = link.getLink();
                    }
                }
            }
        }

        
        public int minTimeIndex(ArrayList shortPathStationList)
        {
            decimal min = Int32.MaxValue;
            int index = 0;
            for(int i = 0;i < shortPathStationList.Count; i++)
            {
                Station station1 = (Station)shortPathStationList[i];
                if(station1.getShorestTime()< min)
                {
                    min = station1.getShorestTime();
                    index = i;
                }
            }
            return index;
        }

        public void initialTimeCalculation(ArrayList haveToVisitLink, ArrayList shortPathStationList,Station source)
        {
            source.setShortestTime(0);
            
            for (int j = 0; j < haveToVisitLink.Count; j++)
            {
                Link link = (Link)haveToVisitLink[j];
                for (int i = 0; i < shortPathStationList.Count; i++)
                {
                    Station station1 = (Station)shortPathStationList[i];
                    if (link.getToStation().Equals(station1.getStationName()))
                    {
                        decimal tempTotalTime = source.getShorestTime()+link.getTotalTime();
                        if(tempTotalTime < station1.getShorestTime())
                        {
                            station1.setShortestTime(link.getTotalTime());
                            station1.setPreviousStation(source);
                            station1.setPreviousLink(link);
                        }                     
                    }
                }
            }
        }

        public void timeCalculation(ArrayList haveToVisitLink, ArrayList shortPathStationList, Station source)
        {
            for (int j = 0; j < haveToVisitLink.Count; j++)
            {
                Link link = (Link)haveToVisitLink[j];
                for (int i = 0; i < shortPathStationList.Count; i++)
                {
                    Station station1 = (Station)shortPathStationList[i];
                    if (link.getToStation().Equals(station1.getStationName()))
                    {
                        decimal tempTotalTime = source.getShorestTime() + link.getTotalTime();

                        if (tempTotalTime < station1.getShorestTime())
                        {
                            station1.setShortestTime(tempTotalTime);
                            station1.setPreviousStation(source);
                            station1.setPreviousLink(link);
                        }

                    }
                }
            }
        }

        public void addRemoveVisitedStation(Station station)
        {
            Station visitedStation = null;
            int visitedStationIndex = -1;

            for(int i = 0;i < shortPathStationList.Count; i++)
            {
                Station station1 = (Station)shortPathStationList[i];
                if (station1.getStationName().Equals(station.getStationName()))
                {
                    visitedStationIndex = i;
                    visitedStation = station1;
                }
            }
            if(visitedStationIndex > -1)
            {
                shortPathStationList.RemoveAt(visitedStationIndex);
            }
            if(visitedStation != null)
            {
                visitedStationList.Add(visitedStation);
            }
        }

        public void displayVisitedStation()
        {
            foreach(Station station in visitedStationList)
            {
                string previousStationName;
                if (station.getPreviousStation() != null)
                {
                    previousStationName = station.getPreviousStation().getStationName();
                }
                else
                {
                    previousStationName = "";
                }
                
                Console.WriteLine("Station Name - "+station.getStationName()+" Min Time -" 
                    +station.getShorestTime().ToString("0.00")+" min Previous Station - "+previousStationName);
            }
        }

        

        public void displayPath(Station start, Station end)
        {

            ArrayList shorestPath = new ArrayList();
            Station station = null;
            string previousJourney = "";

            for (int i = 0; i < visitedStationList.Count; i++)
            {
                Station station1 = (Station)visitedStationList[i];
                if (station1.getStationName().Equals(end.getStationName()))
                {
                    station = station1;
                }
            }
            while (station != null)
            {
                Station currentStation = station;
                if (currentStation.getPreviousLink() != null)
                {
                    shorestPath.Add(currentStation.getPreviousLink());
                }
                station = currentStation.getPreviousStation();
            }
            Console.WriteLine("Route : "+start.getStationName()+" to " +end.getStationName());
            for (int j = shorestPath.Count - 1; j >= 0; j--)
            {
                Link link = (Link)shorestPath[j];
                if (j == shorestPath.Count - 1)
                {
                    Console.WriteLine("Start - "+start.getStationName()+","+link.getJourney());
                    Console.WriteLine("From - " + link.getFromStation() + "- To - "
                    + link.getToStation() + "     " + link.getTotalTime().ToString("0.00") + " min");
                    previousJourney = link.getJourney();
                }
                else if (j == 0)
                {
                    if (link.getJourney().Equals(previousJourney))
                    {
                        Console.WriteLine(link.getJourney());
                        Console.WriteLine(" From - " + link.getFromStation() + "- To - "
                        + link.getToStation() + "     " + link.getTotalTime().ToString("0.00") + "min");
                        Console.WriteLine("End - " + link.getToStation() + " , " + link.getJourney());
                        previousJourney = link.getJourney();
                    }
                    else
                    {
                        Console.WriteLine("Change - "+link.getJourney());
                        Console.WriteLine(" From - " + link.getFromStation() + "- To - "
                        + link.getToStation() + "     " + link.getTotalTime().ToString("0.00") + "min");
                        Console.WriteLine("End - " + link.getToStation() + " , " + link.getJourney());
                        previousJourney = link.getJourney();
                    }
                    
                }
                else
                {
                    if (link.getJourney().Equals(previousJourney))
                    {
                        Console.WriteLine(link.getJourney());
                        Console.WriteLine(" From - " + link.getFromStation() + "- To - "
                        + link.getToStation() + "     " + link.getTotalTime().ToString("0.00") + "min");
                        previousJourney = link.getJourney();
                    }
                    else
                    {
                        Console.WriteLine("Change - " + link.getJourney());
                        Console.WriteLine(" From - " + link.getFromStation() + "- To - "
                        + link.getToStation() + "     " + link.getTotalTime().ToString("0.00") + "min");
                        previousJourney = link.getJourney();
                    }

                    
                }
                Console.WriteLine();
            }
            Link lastLink = (Link)shorestPath[0];

            for (int i = 0; i < visitedStationList.Count; i++)
            {
                Station station1 = (Station)visitedStationList[i];
                if (station1.getStationName().Equals(lastLink.getToStation()))
                {
                    Console.WriteLine("Total Journey Time:  " + station1.getShorestTime().ToString("0.00") + " min");
                }
            }

        }


    }
}
