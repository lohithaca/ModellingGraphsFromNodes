using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    internal class Link
    {
        private string fromStation;
        private string toStation;
        private decimal time;
        private decimal delay;
        private decimal totalTime;
        private bool status;
        private Link nextLink;
        private string journeyName;

        

        public Link(string fromStation,string toStation,int time,string journey)
        {
            this.fromStation = fromStation;
            this.toStation = toStation;
            this.time = time;
            this.delay = 0;
            totalTime = (decimal)(time + delay);
            status = true;
            nextLink = null;
            this.journeyName = journey;
        }

        public void addDelay(double delay)
        {
            this.delay = Convert.ToDecimal(delay);
            totalTime = time + Convert.ToDecimal(delay);          
        }

        public void removeDelay()
        {
            delay = 0;
            totalTime = time;
        }

        public void openTrack()
        {
            status = true;
        }

        public void closeTrack()
        {
            status = false;
        }

        public void addLink(Link nextLink)
        {
            if (nextLink == null)
            {
                this.nextLink = nextLink;
            }
        }

        public Link getLink()
        {
            return nextLink;
        }

        public void setLink(Link nextLink)
        {
            this.nextLink = nextLink;
        }

        public string getFromStation()
        {
            return fromStation;
        }

        public string getToStation()
        {
            return toStation;
        }

        public bool getStatus()
        {
            return status;
        }

        public bool isEquel(Link link)
        {
            if ((this.getFromStation().Equals(link.getFromStation()))&&(this.getToStation().Equals(link.getToStation())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal getTotalTime()
        {
            return totalTime;
        }

        public decimal getDelay()
        {
            return delay;
        }

        public string getJourney()
        {
            return journeyName;
        }
    }
}
