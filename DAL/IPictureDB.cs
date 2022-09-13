using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IPictureDB
    {
        Picture AddPicture(Picture p, Room r);
        int DeletePictures(Room r);
        int DeleteSpecPicture(Room r, int idPicture);
        Picture GetPicture(Room r, int idPicture);
        List<Picture> GetPictures(Room r);
        int UpdatePicture(Room r, int idPicture, string url);
    }
}