using System;
using System.Collections.Generic;

namespace A7
{
    public class PoliceStation
    {
        List<ICitizen> _BlackList;
        public List<ICitizen> BlackList
        {
            set
            {
                this._BlackList = value;
            }
            get
            {
                return this._BlackList;
            }

        }
        public PoliceStation(List<ICitizen> blackList)
        {
            BlackList = blackList;
        }

        public  bool BackgroundCheck(ICitizen citizen)
        {
            if (BlackList.Contains(citizen))
                return true;
            return false;
        }
    }
}