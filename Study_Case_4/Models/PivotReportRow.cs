namespace Study_Case_4.Models
{
    public class PivotReportRow
    {
        public string NIK { get; set; } = string.Empty;
        public string Nama { get; set; } = string.Empty;
        public List<string> AttendanceMarks { get; set; } = new List<string>();
        public int Total { get; set; }
    }
}
