using _18Marts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18Marts.Services
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();
        Video Get(int _id);
        void Add(Video _newVideo);
        int Commit();
    }
}
