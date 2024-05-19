using VideoCallApp.Data;
using VideoCallApp.Models;
using VideoCallApp.Repository.Interface;

namespace VideoCallApp.Repository
{
    public class ImageRepository:IImageRepository
    {
        private readonly VideoCallApplicationDbContext _applicationDb;
        public ImageRepository(VideoCallApplicationDbContext applicationDbContext)
        {
            _applicationDb = applicationDbContext;
        }
        public void AddImage(Image theImageToAdd)
        {
            _applicationDb.Images.Add(theImageToAdd);
            _applicationDb.SaveChanges();
        }
        public List<Image> GetAll()
        {
            List<Image> listImages = new List<Image>(_applicationDb.Images);
            return listImages;
        }
        public Image GetById(int id)
        {
            Image imageById = new Image();
            imageById = _applicationDb.Images.Find(id);
            return imageById;
        }
    }
}
