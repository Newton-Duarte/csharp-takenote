namespace TakeNote
{
    public static class Menu
    {
        public static void Show()
        {
            Util.CreateConsoleTitle("Bem-vindo ao TakeNote");
            Console.WriteLine("1 - Adicionar Anotação");
            Console.WriteLine("2 - Listar Anotações");
            Console.WriteLine("3 - Excluir Anotação");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("Escolha uma opção: ");

            short option = short.Parse(Console.ReadLine());

            HandleChoseOption(option);
        }

        static void HandleChoseOption(short option)
        {
            switch (option)
            {
                case 0: Exit(); break;
                case 1: AddNote(); break;
                case 2: ListNotes(); break;
                case 3: DeleteNote(); break;
                default: Show(); break;
            }
        }

        static void Exit()
        {
            Environment.Exit(0);
        }

        static void AddNote()
        {
            Util.CreateConsoleTitle("Adicionar Anotação");

            Console.WriteLine("Informe o Título: ");
            string title = Console.ReadLine();

            Console.WriteLine("Informe a Descrição: ");
            string description = Console.ReadLine();

            Program.CreateNote(title, description);
            Show();
        }

        static void ListNotes()
        {
            Util.CreateConsoleTitle("Lista de Anotações");
            Program.ListNotes();
            Show();
        }

        static void DeleteNote()
        {
            Util.CreateConsoleTitle("Lista de Anotações");
            Program.ListNotes();
            Console.WriteLine("Informe o identificador da anotação: ");

            short noteId = short.Parse(Console.ReadLine());

            Program.DeleteNote(noteId);
            Show();
        }
    }
}