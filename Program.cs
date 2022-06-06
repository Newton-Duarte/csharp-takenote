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
        }

        public static void CreateNote(Note note)
        {
            Notes.Add(note);
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