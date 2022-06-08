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
                Util.CreateColoredConsoleMessage("Você não possui anotações!");
                return;
            }
            
            foreach(var note in Notes)
            {
                Util.CreateColoredConsoleMessage(FormatNote(note));
            }
        }

        public static void CreateNote(string title, string description)
        {
            int noteId = GenerateNoteId();

            var note = new Note(noteId, title, description);
            Notes.Add(note);
            SaveNoteToFile(note);
        }

        private static int GenerateNoteId()
        {
            if (Notes.Count > 0)
            {
                return Notes[Notes.Count - 1].Id + 1;
            }
            
            return 1;
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