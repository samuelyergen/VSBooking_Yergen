using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Room
    {
        public int IdRoom { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public double Price { get; set; }
        public bool HasTv { get; set; }
        public bool HasHairDryer { get; set; }
        
       
        public override string ToString()
        {
            return "Id room: " + IdRoom +
                    "Number : " + Number +
                    "Description: " + Description +
                    "Type: " + Type +
                    "Price: " + Price +
                    "Has tv: " + HasTv +
                    "Has hair dryer: " + HasHairDryer; 
                    
        }
    }
}
