namespace Scripts.Struct
{
    public struct Result
    {
        public Result(int totalExperience, int time, int score)
        {
            TotalExperience = totalExperience;
            Time = time;
            Score = score;
        }

        public int TotalExperience { get; private set; }
        public int Time { get; private set; }
        public int Score { get; private set; }
    }
}