using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;

namespace BLL
{
    public class PictureManager : IPictureManager
    {
        private IPictureDB PictureDB { get; }

        public PictureManager(IPictureDB pictureDB)
        {
            PictureDB = pictureDB;
        }

        public Picture GetPicture(Room r, int idPicture)
        {
            return PictureDB.GetPicture(r, idPicture);
        }

        public List<Picture> GetPictures(Room r)
        {
            return PictureDB.GetPictures(r);
        }

        public Picture AddPicture(Picture p, Room r)
        {
            return PictureDB.AddPicture(p, r);
        }

        public int DeleteSpecPicture(Room r, int idPicture)
        {
            return PictureDB.DeleteSpecPicture(r, idPicture);
        }

        public int DeletePictures(Room r)
        {
            return PictureDB.DeletePictures(r);
        }

        public int UpdatePicture(Room r, int idPicture, string url)
        {
            return PictureDB.UpdatePicture(r, idPicture, url);
        }


    }
}
