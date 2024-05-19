using VideoCallApp.Models;

namespace VideoCallApp.Repository.Interface
{
    public interface IImageRepository
    {
        void AddImage(Image theImageToAdd);
        List<Image> GetAll();
        Image GetById(int id);
    }
}
