using H3_AppProgammering_1___Gallery.Models;

namespace H3_AppProgammering_1___Gallery.Interfaces
{
    public interface IGalleryEntry
    {
        public Task<IEnumerable<GalleryEntry>> GetAll();
        public Task<GalleryEntry> GetById(int id);

        public Task<GalleryEntry> Create(GalleryEntry galleryEntry);
        public Task<GalleryEntry> Create(string description, string fileName, string fileType, byte[] image);
        public Task<GalleryEntry> Update(GalleryEntry galleryEntry);
        public Task<GalleryEntry> Delete(int id);
    }
}
