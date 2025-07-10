namespace Study_Case_4.Models
{
    public class PivotReportViewModel
    {
        public List<string> DateHeaders { get; set; } = new List<string>();
        public List<PivotReportRow> Rows { get; set; } = new List<PivotReportRow>();
    }
}
