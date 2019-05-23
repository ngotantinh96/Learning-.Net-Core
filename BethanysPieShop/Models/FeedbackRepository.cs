namespace BethanysPieShop.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext db;

        public FeedbackRepository(AppDbContext db)
        {
            this.db = db;
        }
        public void AddFeedback(Feedback feedback)
        {
            db.Add(feedback);
            db.SaveChanges();
        }
    }
}
