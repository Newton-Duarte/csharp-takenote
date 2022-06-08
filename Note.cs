public class Note
{
    public int Id;
    public string Title;
    public string Description;
    public DateTime CreatedAt = DateTime.Now;

    public Note(int id, string title, string description)
    {
        Id = id;
        Title = title.Trim();
        Description = description.Trim();
    }

}