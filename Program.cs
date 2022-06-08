namespace TakeNote
{
    class Program
    {
        static List<Note> Notes = new List<Note>();
        static string targetPath = Directory.GetCurrentDirectory();
        static char osSeparator = Path.DirectorySeparatorChar;
        static string fileName = "notes.txt";
        static string sourcePath = @$"{targetPath}{osSeparator}{fileName}";
        static void Main(string[] args)
        {
            ReadNotesFromFile();
            Console.Clear();
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
        }

        public static void CreateNote(string title, string description)
        {
            int noteId;

            if (Notes.Count > 0) {
                noteId = Notes[Notes.Count - 1].Id + 1;
            } else {
                noteId = 1;
            }

            Notes.Add(new Note(noteId, title, description));
        }

        public static void DeleteNote(int noteId)
        {
            var note = Notes.Find(note => note.Id == noteId);

            if (note == null) {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Anotação não encontrada!");
                Console.WriteLine("-----------------------------");
                return;
            }

            Notes.Remove(note);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Anotação excluída com sucesso!");
            Console.WriteLine("-----------------------------");
        }
    }
}