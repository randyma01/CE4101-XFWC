namespace PEDS_XWFC.Models
{
    public class Statistic
    {
        public int IdStatitics { get; set; }
        public int WonGames { get; set; }
        public int LostGames { get; set; }
        public int DrawGames { get; set; }
        public int MinutesPlayed { get; set; }
        public int Goals { get; set; }
        public int ShotsOnTarget { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int StoppedPenalties { get; set; }
        public int PenaltiesCommited { get; set; }
        public int SavedShots { get; set; }
    }
}