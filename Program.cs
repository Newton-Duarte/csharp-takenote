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
                Util.CreateColoredConsoleMessage("Anotação não encontrada!");
                return;
            }

            Notes.Remove(note);
            Util.CreateColoredConsoleMessage("Anotação excluída com sucesso!");

            CleanNotesFile();
            SaveAllNotesToFile();
        }

        public static void CleanNotesFile()
        {
            File.WriteAllText(sourcePath, String.Empty);
        }

        public static void SaveAllNotesToFile()
        {
            foreach(var note in Notes)
            {
                SaveNoteToFile(note);
            }
        }

        public static void ReadNotesFromFile()
        {
            try
            {
                using(StreamReader sr = File.OpenText(sourcePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        var splittedLine = line.Split("|");

                        var noteTitle = splittedLine[2];
                        var noteDescription = splittedLine[3];

                        var noteId = GenerateNoteId();
                        var note = new Note(noteId, noteTitle, noteDescription);
                        Notes.Add(note);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                System.Console.WriteLine("Arquivo não encontrado!");
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Criando o arquivo...");
                CleanNotesFile();
            }
            catch (IOException e)
            {
                System.Console.WriteLine("Ocorreu um erro!");
                System.Console.WriteLine(e.Message);
            }
        }

        public static void SaveNoteToFile(Note note)
        {
            try
            {
                using(StreamWriter sw = File.AppendText(sourcePath))
                {
                    string formattedNote = FormatNote(note);
                    sw.WriteLine(formattedNote);
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine("Ocorreu um erro!");
                System.Console.WriteLine(e.Message);
            }
        }

        public static string FormatNote(Note note)
        {
            return $"{note.Id} | {note.CreatedAt.ToString("dd/MM/yyyy hh:mm")} | {note.Title} | {note.Description}";
        }
    }
}