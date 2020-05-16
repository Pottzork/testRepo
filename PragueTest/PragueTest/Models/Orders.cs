using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PragueTest.Models
{
    public class Orders
    {
        public Orders()
        {

        }

        [PrimaryKey]
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public string ParkingSpot { get; set; }


        public override string ToString()
        {
            return this.RegistrationNumber + " ( " + this.ParkingSpot + " )";
        }


    }
}
