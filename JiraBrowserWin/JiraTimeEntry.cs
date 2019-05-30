using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JiraBrowserWin
{
    class JiraTimeEntry
    {

        public DateTime PostingDate { get; set; }
        public string JobNo { get; set; }
        public string SubprojectCode { get; set; }
        public string ActivityNo { get; set; }
        public string WebNo { get; set; }
        public string LocationCode { get; set; }
        public string WorkType { get; set; }
        public string WorkHours { get; set; }
        public string ChargeableHours { get; set; }
        public int Unchargeable { get; set; }
        public string StepCode { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public int OwnTransfer { get; set; }
        public string Kilometres { get; set; }
        public string TimeTravel { get; set; }
        public string Parking { get; set; }
        public int Exported { get; set; }
        public string guid { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string author { get; set; }
        public string Description { get; set; }
        public int RealMinutes { get; set; }        
        public string JiraWorklogId { get; set; }
    }
}
