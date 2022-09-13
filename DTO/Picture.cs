using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Picture
    {
        public int IdPicture { get; set; }
        public string Url { get; set; }
        public int IdRoom { get; set; }

        public override string ToString()
        {
            return "Id picture: " + IdPicture +
                    "URL: " + Url +
                    "IdRoom : " + IdRoom;
        }

    }
}
