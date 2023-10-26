namespace todoList.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}