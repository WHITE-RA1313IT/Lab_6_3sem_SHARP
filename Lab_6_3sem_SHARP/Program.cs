using IError_namespace;
using Complex_namespace;
using FunnyGame_namespace;

static void print_error_list(List<IError> err)
{
    foreach (IError error in err)
    {
        error.print();
    }
    Console.WriteLine();
}

COMPLEXMENU COMPLEXMENU = new COMPLEXMENU();
FUNNYGAMEMENU FUNNYGAMEMENU = new FUNNYGAMEMENU();
List<IError> err = new List<IError>();
string logger = "";

while (true)
{
    Console.Write("Select a task:\n");
    Console.Write("1) Complex numbers;\n");
    Console.Write("2) Funny Game;\n");
    Console.Write("3) Output a list of errors;\n");
    Console.Write("4) Exit.\n");
    Console.Write("Your choice: ");

    try
    {
        GETINT gETINT = new GETINT();
        int choice;
        choice = gETINT.getInt();
        if (choice < 1 || choice > 4)
        {
            throw new IncorrectInput();
        }
        else
        {
            Console.WriteLine();
            if (choice == 1)
            {
                COMPLEXMENU.ComplexMenu(logger, err);
            }
            if (choice == 2)
            {
                FUNNYGAMEMENU.FunnyGameMenu(err);
            }
            if (choice == 3)
            {
                print_error_list(err);
            }
            if (choice == 4)
            {
                Environment.Exit(0);
            }
        }
    }

    catch (CriticalIncorrectInput e)
    {
        err.Add(e);
        e.print();
        Console.WriteLine();
    }
    catch (IncorrectInput e)
    {
        err.Add(e);
        e.print();
        Console.WriteLine();
    }
}