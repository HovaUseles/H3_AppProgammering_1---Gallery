using H3_AppProgammering_1___Gallery.DTOs;
using H3_AppProgammering_1___Gallery.Interfaces;
using H3_AppProgammering_1___Gallery.Models;
using MongoDB.Entities;

namespace H3_AppProgammering_1___Gallery.DataHandlers
{
    public class GalleryEntryDataHandler : IGalleryEntry
    {
        public GalleryEntryDataHandler()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            DB.InitAsync(config["CollectionName"]!, config["ConnectionString"]!, config.GetValue<int>("PortNumber"));
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

        public async Task<List<GalleryEntry>> CreateMany(List<GalleryEntryDTO> galleryArray)
        {
            List<GalleryEntry> galleryEntryList = new List<GalleryEntry>();

            foreach (GalleryEntryDTO item in galleryArray)
            {
                galleryEntryList.Add(new GalleryEntry
                {
                    Description = item.Description,
                    FileName = item.FileName,
                    Filetype = item.Filetype,
                    Base64Image = item.Base64Image
                });
            }

            await galleryEntryList.SaveAsync();
            return galleryEntryList;
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
