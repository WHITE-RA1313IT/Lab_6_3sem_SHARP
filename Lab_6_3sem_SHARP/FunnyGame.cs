using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IError_namespace;

namespace FunnyGame_namespace
{
    public class FunnyGame
    {
        public List<List<bool>> game = new List<List<bool>>();
        public FunnyGame(in int N) {
            for (int i = 0; i < N; i++)
            {
                game.Add(new List<bool>());
                for (int j = 0; j < N; j++)
                {
                    game[i].Add(false);
                }
            }

            Random rnd = new Random();
            int true_fields = 0;
            while (true_fields < N / 2)
            {
                int i = rnd.Next(0, N), j = rnd.Next(0, N);
                if (!game[i][j])
                {
                    game[i][j] = true;
                    true_fields++;
                }
            }
        }

        public bool isWin(in List<int> answers) {
            int correct_answers = 0;
            foreach (int x in answers)
            {
                int i, j;

                if (x % game.Count != 0)
                {
                    i = x / game.Count;
                    j = x % game.Count - 1;
                }
                else
                {
                    i = x / game.Count - 1;
                    j = game.Count - 1;
                }

                if (game[i][j]) correct_answers++;
            }
            if (correct_answers == game.Count / 3)
            {
                return true;
            }
            return false;
        }
    }

    public class FUNNYGAMEMENU
    {
        public void FunnyGameMenu(List<IError> err)
        {
            Console.WriteLine("FUNNY GAME");
            Console.Write("1) Play;\n");
            Console.Write("2) Exit to main menu.\n");
            Console.Write("Your choice: ");

            try
            {
                GETINT gETINT = new GETINT();
                int game_choice;
                game_choice = gETINT.getInt();
                if (game_choice < 1 || game_choice > 2)
                {
                    throw new IncorrectInput();
                }
                Console.WriteLine();

                if (game_choice == 1)
                {
                    Console.Write("Enter the size of the playing field (3-6): ");
                    int field_size;
                    field_size = gETINT.getInt();
                    if (field_size < 3 || field_size > 6)
                    {
                        throw new IncorrectInput();
                    }

                    FunnyGame game1 = new FunnyGame(field_size);

                    List<int> answers = new List<int>();
                    for (int i = 0; i < field_size; i++)
                    {
                        int ans;
                        Console.Write($"Enter number #{i + 1}: ");
                        ans = gETINT.getInt();
                        if (ans < 1 || ans > Math.Pow(field_size, 2)) throw new IncorrectInput();
                        for (int j = 0; j < answers.Count; j++)
                        {
                            if (ans == answers[j]) throw new IncorrectInput();
                        }
                        answers.Add(ans);
                    }

                    Console.WriteLine();
                    if (game1.isWin(answers)) Console.Write("YOU WIN!\n\n");
                    FunnyGameMenu(err);
                }
                else
                {
                    return;
                }
            }

            catch (CriticalIncorrectInput e)
            {
                err.Add(e);
                e.print();
                Console.WriteLine();
                FunnyGameMenu(err);
            }

            catch (IncorrectInput e)
            {
                err.Add(e);
                e.print();
                Console.WriteLine();
                FunnyGameMenu(err);
            }
        }
    }
}
