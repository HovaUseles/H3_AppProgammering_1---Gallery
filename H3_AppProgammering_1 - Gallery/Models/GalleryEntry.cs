using MongoDB.Driver;
using MongoDB.Entities;

namespace H3_AppProgammering_1___Gallery.Models
{
    public class GalleryEntry : Entity
    {
        public byte[] ImageBytes { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
    }
}
