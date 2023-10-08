namespace ValidHabit.Domain.Entities
{
    public class MotivationAnswer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Guid UserId { get; set; }
        public int QuestionId { get; set; }

        
        public virtual UserProfile User { get; set; }
        public virtual MotivationQuestion Question { get; set; }
    }
}
