using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    internal class Station
    {
        private string stationName;
        private Link stationLink;
        private decimal shortestTime;
        private Station previousStation;
        private Link previousLink;

        public Station(string stationName)
        {
            this.stationName = stationName;
            stationLink = null;
            shortestTime = Int32.MaxValue;

        }

        public Link getStationLink()
        {
            return stationLink;
        }
        public void addLinkStation(Link link)
        {
            stationLink = link;
        }

        public string getStationName()
        {
            return stationName;
        }

        public bool isEquel(Station station)
        {
            if (this.getStationName().Equals(station.getStationName()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setShortestTime(decimal time)
        {
             shortestTime = time;
        }

        public decimal getShorestTime()
        {
            return shortestTime;
        }

        public void setPreviousStation(Station previousStation)
        {
            this.previousStation = previousStation;
        }

        public Station getPreviousStation()
        {
            return previousStation;
        }

        public void setPreviousLink(Link previousLink)
        {
            this.previousLink = previousLink;
        }

        public Link getPreviousLink()
        {
            return previousLink;
        }
    }
}
