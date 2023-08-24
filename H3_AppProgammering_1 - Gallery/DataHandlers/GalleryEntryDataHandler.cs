using H3_AppProgammering_1___Gallery.Interfaces;
using H3_AppProgammering_1___Gallery.Models;
using MongoDB.Driver;
using MongoDB.Entities;

namespace H3_AppProgammering_1___Gallery.DataHandlers
{
    public class GalleryEntryDataHandler 
    {
        public GalleryEntryDataHandler()
        {
            DB.InitAsync("ImageGallery", "localhost", 27017);
        }
        public async Task<GalleryEntry> GetById(string id)
        {
            return await DB.Find<GalleryEntry>().OneAsync(id);
        }

        public async Task<IEnumerable<GalleryEntry>> GetAll()
        {
            return await DB.Find<GalleryEntry>().ManyAsync(_ => true);
        }

        public async Task<GalleryEntry> Create(string description, string fileName, string fileType, string image)
        {
            GalleryEntry galleryEntry = new GalleryEntry {
                Description = description, 
                FileName = fileName, 
                Filetype = fileType, 
                Base64Image = image};            

            await galleryEntry.SaveAsync();
            return galleryEntry;
        }

        public async Task<GalleryEntry> Create(GalleryEntry galleryEntry)
        {
            await galleryEntry.SaveAsync();
            return galleryEntry;
        }


        public async Task<GalleryEntry> Update(GalleryEntry galleryEntryChanges)
        {
            return await DB.UpdateAndGet<GalleryEntry>()
                    .MatchID(galleryEntryChanges.ID)
                    .ModifyWith(galleryEntryChanges)
                    .ExecuteAsync();
        }

        public async Task Delete(string id)
        {
            await DB.DeleteAsync<GalleryEntry>(id);
            return;
        }
    }
}
