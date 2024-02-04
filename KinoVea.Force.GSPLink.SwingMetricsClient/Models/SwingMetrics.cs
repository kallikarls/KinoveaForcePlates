namespace GSPLink.Abstractions.Models
{
    public class SwingMetrics
    {
        public int ShotNumber { get; set; }

        public BallMetrics BallMetrics { get; set; } 

        public bool ContainsBallMetrics
        {
            get { return BallMetrics != null; }
        }

        public ClubMetrics ClubMetrics { get; set; }

        public bool ContainsClubMetrics
        {
            get { return ClubMetrics != null; }
        }

        public ShotType ShotType { get; set; } = ShotType.Normal;

        public SwingTimings SwingTimings { get; set; } = new SwingTimings();
        
    }
}
