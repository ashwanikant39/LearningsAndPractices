using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class KnowledgeBankViewModel
    {
        public List<KnowledgeBankModel> ListKnowledgeBankModel { get; set; }
      
    }

    public class KnowledgeBankModel
    {
        public KnowledgeBankType KnowledgeBankType { get; set; }
        public List<KnowledgeBank> ListKnowledgeBank { get; set; }
    }

    public class VideoLibraryViewModel
    {
        public List<Sector> ListSector { get; set; }
        public Int32 sector_id { get; set; }
        public List<VideoLibrary> ListVideoLibrary { get; set; }

        public VideoLibraryViewModel()
        {
            ListSector = new List<Sector>();
            ListVideoLibrary = new List<VideoLibrary>();
        }

    }

}