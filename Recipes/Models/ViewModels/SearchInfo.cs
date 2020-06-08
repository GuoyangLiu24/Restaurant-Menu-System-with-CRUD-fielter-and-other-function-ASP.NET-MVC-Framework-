using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models.ViewModels
{
    public class SearchInfo
    {
        private static string searchInfo;

        public static void setSearchInfo(string s)
        {
            searchInfo = s;
        }
        public static string getSearchInfo()
        {
            return searchInfo;
        }
    }
}
