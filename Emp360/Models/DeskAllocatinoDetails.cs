using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp360.Models
{
    public class DeskAllocatinoDetails
    {   
        public int SrNo { get; set; }
        public string SeatNo { get; set; }
        public string MachineNo { get; set; }
         public string VId { get; set; }
        public string GPM { get; set; }
        public string AssetType { get; set; }
        public string MsReportingManager { get; set; }
        public string ProjectName{ get; set; }
        public DateTime ModifiedDate{ get; set; }
        public string ModifiedBy{ get; set; }
        public bool isStale{ get; set; }

        public Gpmmaster GPMMaster { get; set; }




        
    }
}
