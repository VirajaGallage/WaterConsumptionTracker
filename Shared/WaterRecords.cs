using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterConsumptionTracker.Shared
{
    public class WaterRecords
    {
        public int Id { get; set; }

        public DateTime IntakeDate { get; set; }

        public int Usage {  get; set; }

        public UsersManagement? User {  get; set; }

        public int UserId { get; set; }
    }
}
