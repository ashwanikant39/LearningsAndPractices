using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class ImpactIndicatorModel
    {
        public int Id { get; set; }
        public int EnergySavingAchieved { get; set; }
        public int MSMEUnitsReached { get; set; }
        public int EnergyEfficciencyMeasure { get; set; }
        public int InvestorParticipatingMsmeUnits { get; set; }
        public string user_id { get; set; }
    }
}