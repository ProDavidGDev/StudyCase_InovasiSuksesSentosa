namespace Study_Case_4.Models
{
    public class MonthlyPivotReportViewModel
    {
        public List<string> MonthHeaders { get; set; } = new List<string>();
        public List<MonthlyPivotReportRow> Rows { get; set; } = new List<MonthlyPivotReportRow>();
    }
}
