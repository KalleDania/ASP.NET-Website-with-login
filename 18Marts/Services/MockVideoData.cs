using System.Collections.Generic;
using System.Linq;
using Eksempel_1.Entities;
using Eksempel_1.Models;

namespace Eksempel_1.Services
{
    public class MockVideoData : IVideoData
    {
        private List<Video> videos;

        public MockVideoData()
        {
            videos = new List<Video>
            {
               new Video { Id = 1, Genre = Models.Genres.Comedy, Title = "Shreck"},
               new Video { Id = 2,  Genre = Models.Genres.Horror, Title = "Despicable me" },
               new Video { Id = 3,  Genre = Models.Genres.Romance, Title = "Megamind" }
            };
        }

        public void Add(Video _newVideo)
        {
            // Linqs MAX tjekker hvad id er på den øverste item i collectionen, vildt smart!
            _newVideo.Id = videos.Max(item => item.Id) + 1;
            videos.Add(_newVideo);
        }

        public int Commit()
        {
            return 0;
        }

        public Video Get(int _id)
        {
            return videos.FirstOrDefault(item => item.Id.Equals(_id));
        }

        public IEnumerable<Video> GetAll()
        {
            return videos;
        }
    }
}
