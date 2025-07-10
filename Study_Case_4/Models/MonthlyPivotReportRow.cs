namespace Study_Case_4.Models
{
    public class MonthlyPivotReportRow
    {
        public string NIK { get; set; } = string.Empty;
        public string Nama { get; set; } = string.Empty;
        public List<int> AttendanceCounts { get; set; } = new List<int>();
        public int Total { get; set; }
    }
}
