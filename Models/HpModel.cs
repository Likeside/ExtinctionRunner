namespace ExtinctionRunner
{
    public class HpModel
    {
        public float MaxHealthPoints { get; private set; }
        public float CurrentHealthPoints { get; set; }

        public HpModel(float maxHealthPoints)
        {
            MaxHealthPoints = maxHealthPoints;
            CurrentHealthPoints = maxHealthPoints;
        }
        
    }
}