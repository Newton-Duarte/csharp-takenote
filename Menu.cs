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
            Console.WriteLine("Você escolheu adicionar uma anotação!");

            Console.WriteLine("Informe o Título: ");
            string title = Console.ReadLine();

            Console.WriteLine("Informe a Descrição: ");
            string description = Console.ReadLine();

            Program.CreateNote(title, description);
            Show();
        }

        static void ListNotes()
        {
            Console.WriteLine("Você escolheu listar todas as anotações!");
            Console.WriteLine("-----------------------------");
            Program.ListNotes();
            Console.WriteLine("-----------------------------");
            Show();
        }

        static void DeleteNote()
        {
            Console.WriteLine("Lista de Anotações");
            Console.WriteLine("-----------------------------");
            Program.ListNotes();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Informe o identificador da anotação: ");

            short noteId = short.Parse(Console.ReadLine());

            Program.DeleteNote(noteId);
            Show();
        }

        static void ExportNotes()
        {
            Console.WriteLine("Você escolheu exportar as anotações em arquivo");
            Show();
        }
    }
}