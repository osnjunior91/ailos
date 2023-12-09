namespace Questao2
{
    public class ApiResponse
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<Match> Data { get; set; }
    }
    public class Match
    {
        public string Competition { get; set; }
        public int Year { get; set; }
        public string Round { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Team1goals { get; set; }
        public int Team2goals { get; set; }
    }
}
