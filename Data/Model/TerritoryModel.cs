using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class TerritoryModel
    {
        private int territoryID;

        public int TerritoryID
        {
            get { return territoryID; }
            set { territoryID = value; }
        }

        private string territoryDescription;

        public string TerritoryDescription
        {
            get { return territoryDescription; }
            set { territoryDescription = value; }
        }

        private string regionDescription;
        public string RegionDescription
        {
            get { return regionDescription; }
            set { regionDescription = value; }
        }




    }
}
