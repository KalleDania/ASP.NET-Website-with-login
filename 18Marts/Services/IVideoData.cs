using Eksempel_1.Entities;
using System.Collections.Generic;

namespace Eksempel_1.Services
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();
        Video Get(int _id);
        void Add(Video _newVideo);
        int Commit();
    }
}
