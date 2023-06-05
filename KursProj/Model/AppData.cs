using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProj.Model
{
    public enum TableName
    {
        Authors,
        Books,
        Genres,
        Role,
        PublishingHouse,
        State,        
        Users,        
        UserBookPair
    }
    public static class AppData
    {
        //https://www.youtube.com/watch?v=7SoudUnDk5k
        public static kursachBDEntities db = new kursachBDEntities();

    }
}
