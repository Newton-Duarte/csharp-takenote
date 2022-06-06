namespace TakeNote
{
    class Program
    {
        static List<Note> Notes = new List<Note>();
        static void Main(string[] args)
        {
            Menu.Show();
        }

        public static void ListNotes()
        {
            if (Notes.Count == 0) {
                Console.WriteLine("Você não possui anotações!");
                return;
            }
            
            foreach(var note in Notes)
            {
                Console.WriteLine($"{note.Id} | {note.CreatedAt.ToString("dd/MM/yyyy hh:mm")} | {note.Title} | {note.Description}");
            }

            Menu.Show();
        }

        public static void CreateNote(Note note)
        {
            Notes.Add(note);
            Menu.Show();
        }
    }
}