using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssetGroup : FullAuditModel
    {
        public string AssetGroupName { get; set; }
        public string AssetGroupCode { get; set; }
        public string AssetType { get; set; }
    }
}
