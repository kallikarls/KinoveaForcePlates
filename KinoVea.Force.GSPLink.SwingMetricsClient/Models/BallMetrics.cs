﻿namespace GSPLink.Abstractions.Models
{
    public class BallMetrics
    {
        public float Speed { get; set; }

        public float SpinAxis { get; set; }

        public float TotalSpin { get; set; }

        public float HLA { get; set; }

        public float VLA { get; set; }

        public float BackSpin { get; set; }


        public float SideSpin { get; set; }


        public float CarryDistance { get; set; }

        public GolfBallType GolfBallType { get; set; }

        public SpinCalculationType SpinCalculationType { get; set; }
    }
}
