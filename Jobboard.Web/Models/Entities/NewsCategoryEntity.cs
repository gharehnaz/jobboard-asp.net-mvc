using System.Collections.Generic;

namespace Jobboard.Web.Models.Entities
{
    public class NewsCategoryEntity
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<News> NewsEntities { get; set; }

        public NewsCategoryEntity()
        {
            NewsEntities = new List<News>();
        }
    }
}