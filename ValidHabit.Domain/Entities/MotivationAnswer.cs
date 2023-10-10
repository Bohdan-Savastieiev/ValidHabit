namespace ValidHabit.Domain.Entities
{
    public class MotivationAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int QuestionId { get; set; }
        public virtual MotivationQuestion Question { get; set; }
    }
}
