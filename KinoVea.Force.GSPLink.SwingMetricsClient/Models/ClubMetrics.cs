namespace GSPLink.Abstractions.Models
{
    public class ClubMetrics
    {
        public float Speed { get; set; }


        public float AngleOfAttack { get; set; }


        public float FaceToTarget { get; set; }

        public float FaceToPath => Path * -1 + FaceToTarget;


        public float Lie { get; set; }


        public float Loft { get; set; }


        public float Path { get; set; }


        public float SpeedAtImpact { get; set; }


        public float VerticalFaceImpact { get; set; }


        public float HorizontalFaceImpact { get; set; }
              
    }
}
