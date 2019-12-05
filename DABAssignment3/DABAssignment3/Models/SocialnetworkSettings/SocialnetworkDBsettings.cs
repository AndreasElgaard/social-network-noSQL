using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABAssignment3.Models.SocialnetworkSettings
{
    public class SocialnetworkDBsettings : ISocialnetworkDBsettings
    {
        public string CircleCollectionName { get; set; }
        public string CommentCollectionName { get; set; }
        public string PostCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISocialnetworkDBsettings
    {
        string CircleCollectionName { get; set; }
        string CommentCollectionName { get; set; }
        string PostCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
