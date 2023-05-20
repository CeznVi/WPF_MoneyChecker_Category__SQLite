using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImgSrc { get; set; }

        public int? ParentId { get; set; } = null;

        public List<Category> SubCategories { get; set; }       //список для хранения субкатегорий (в б.д не хранится)



        /* OLD VERSION  */
        public override string ToString()
        {
            return $"Id: {Id}; Title: {Title}.";
        }

    }
}
