using MongoDB.Driver;
using MongoDB.Entities;

namespace H3_AppProgammering_1___Gallery.Models
{
    public class GalleryEntry : Entity
    {
        public string Base64Image { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string Filetype { get; set; }
    }
}
