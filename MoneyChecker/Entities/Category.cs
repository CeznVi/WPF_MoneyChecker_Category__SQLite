using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Entities
{

    /*  NEEED COPY PAST  */

    class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImgSrc { get; set; }

        public int? ParrentId { get; set; } = null;

        public List<Category> SubCategories { get; set;}  //list sub cattegory, not save in BD, saving in memory


    }
}
