static void Menu()
{
    Console.Clear();

    Console.WriteLine("Bem-vindo ao TakeNote!");
    Console.WriteLine("======================");
    Console.WriteLine("Escolha uma opção: ");
    Console.WriteLine("1 - Adicionar Anotação");
    Console.WriteLine("2 - Listar Anotações");
    Console.WriteLine("3 - Excluir Anotação");
    Console.WriteLine("4 - Exportar em Arquivo");
    Console.WriteLine("0 - Sair");

    short option = short.Parse(Console.ReadLine());

    HandleChoseOption(option);
}

static void HandleChoseOption(short option)
{
    switch(option)
    {
        case 0: Exit(); break;
        case 1: AddNote(); break;
        case 2: ListNotes(); break;
        case 3: DeleteNote(); break;
        case 4: ExportNotes(); break;
        default: Menu(); break;
    }
}

static void Exit()
{
    Environment.Exit(0);
}

static void AddNote()
{
    Console.WriteLine("Você escolheu adicionar uma anotação!");
}

static void ListNotes()
{
    Console.WriteLine("Você escolheu listar todas as anotações!");
}

static void DeleteNote()
{
    Console.WriteLine("Você escolheu deletar uma anotação!");
}

static void ExportNotes()
{
    Console.WriteLine("Você escolheu exportar as anotações em arquivo");
}

Menu();