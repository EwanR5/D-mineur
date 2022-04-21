using System;

namespace Démineur
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] plateau = new int[9, 9];
            int a = 0;
            int b = 0;
            int[,] tableau = new int[9, 9];

            AfficherPlateau(plateau);
            CreationBombes(plateau);
            RemplirCoinHG(plateau);
            RemplirCoinHD(plateau);
            RemplirCoinBG(plateau);
            RemplirCoinBD(plateau);
            RemplirBordureH(plateau);
            RemplirBordureG(plateau);
            RemplirBordureD(plateau);
            RemplirBordureB(plateau);
            RemplirCasesMilieu(plateau);
            AfficherPlateau(plateau);
            RemplirTableau(tableau);
            RevelerTableau(tableau, plateau, a, b);
            AfficherTableau(tableau);
        }

        static void AfficherPlateau(int[,] plateau)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(plateau[j, i]);
                }
                Console.WriteLine();
            }
        }
        static void AfficherTableau(int[,] tableau)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(tableau[j, i]);
                }
                Console.WriteLine();
            }
        }
        static void Perdu (int[,] plateau, int[,] tableau)
        {
            AfficherPlateau(plateau);
            AfficherTableau(tableau);
            Console.WriteLine("Vous avez perdu");
            Console.ReadLine();
            /*Devoir proposer une nouvelle partie*/
        }
        static void PoserDrapeaux (int[,] plateau, int a, int b) /*terminer ça*/
        {
            Console.WriteLine("Dans quelle ligne se trouve la case sur laquelle vous voulez mettre un drapeau ?");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dans quelle colonne se trouve la case sur laquelle vous voulez mettre un drapeau ?");
            b = int.Parse(Console.ReadLine());
        }
        static void RetirerDrapeaux (int[,] plateau, int a, int b) /*terminer ça*/
        {
            Console.WriteLine("Dans quelle ligne se trouve la case sur laquelle vous voulez mettre un drapeau ?");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dans quelle colonne se trouve la case sur laquelle vous voulez mettre un drapeau ?");
            b = int.Parse(Console.ReadLine());
        }

        static void CreationBombes(int[,] plateau)
        {
            int bombe;
            bombe = 10;

            while (bombe > 0)
            {
                var rand = new Random();
                var ligne = rand.Next(9);
                var colonne = rand.Next(9);
                if (plateau[ligne, colonne] != 9)
                {
                    plateau[ligne, colonne] = 9;
                    bombe--;
                }
            }
        }
        static void RemplirCasesMilieu(int[,] plateau)
        {
            for (int j = 1; j < 8; j++)
            {
                for (int i = 1; i < 8; i++)
                {
                    if (plateau[i, j] != 9)
                    {
                        if (plateau[i - 1, j - 1] == 9)
                        {
                            plateau[i, j]++;
                        }
                        if (plateau[i, j - 1] == 9)
                        {
                            plateau[i, j]++;
                        }
                        if (plateau[i + 1, j - 1] == 9)
                        {
                            plateau[i, j]++;
                        }
                        if (plateau[i - 1, j] == 9)
                        {
                            plateau[i, j]++;
                        }
                        if (plateau[i + 1, j] == 9)
                        {
                            plateau[i, j]++;
                        }
                        if (plateau[i - 1, j + 1] == 9)
                        {
                            plateau[i, j]++;
                        }
                        if (plateau[i, j + 1] == 9)
                        {
                            plateau[i, j]++;
                        }
                        if (plateau[i + 1, j + 1] == 9)
                        {
                            plateau[i, j]++;
                        }
                    }
                }
            }
        }
        static void RemplirCoinHG (int[,] plateau)
        {
            int i = 0;
            int j = 0;

            if (plateau[i,j] != 9)
            {
                if (plateau[i+1, j] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i, j + 1] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i + 1, j + 1] == 9)
                {
                    plateau[i, j]++;
                }
            }
        }
        static void RemplirCoinHD (int[,] plateau)
        {
            int i = 8;
            int j = 0;

            if (plateau[i, j] != 9)
            {
                if (plateau[i - 1,j] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i, j  + 1] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i - 1, j + 1] == 9)
                {
                    plateau[i, j]++;
                }
            }
        }
        static void RemplirCoinBG (int[,] plateau)
        {
            int i = 0;
            int j = 8;

            if (plateau[i, j] != 9)
            {
                if (plateau[i, j - 1] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i + 1, j - 1] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i + 1, j] == 9)
                {
                    plateau[i, j]++;
                }
            }
        }
        static void RemplirCoinBD (int[,] plateau)
        {
            int i = 8;
            int j = 8;
            
            if (plateau[i, j] != 9)
            {
                if (plateau[i - 1 ,j - 1] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i, j - 1] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i - 1, j] == 9)
                {
                    plateau[i, j]++;
                }
            }
        }
        static void RemplirBordureH(int[,] plateau)
        {
            int j = 0;
            for (int i = 1; i < 8; i++)
            {
                if (plateau[i, j] != 9)
                {
                    if (plateau[i - 1, j] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i + 1, j] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i - 1, j + 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i, j + 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i + 1, j + 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                }
            }
        }
        static void RemplirBordureG (int[,] plateau)
        {
            int i = 0;
            for (int j = 1; j < 8; j++)
            {
                if (plateau[i, j] != 9)
                {
                    if (plateau[i, j - 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i, j + 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i + 1, j - 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i + 1, j] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i + 1, j + 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                }
            }
        }
        static void RemplirBordureD (int[,] plateau)
        {
            int i = 8;
            for (int j = 1; j < 8; j++)
            {
                Console.WriteLine(i);
                if (plateau[i, j] != 9)
                {
                    if (plateau[i, j - 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i, j + 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i - 1, j - 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i - 1, j] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i - 1, j + 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                }
            }
        }
        static void RemplirBordureB (int[,] plateau)
        {
            int j = 8;
            for (int i = 1; i < 8; i++)
            {
                if (plateau[i, j] != 9)
                {
                    if (plateau[i - 1, j] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i + 1, j] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i - 1, j - 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i, j - 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                    if (plateau[i + 1, j - 1] == 9)
                    {
                        plateau[i, j]++;
                    }
                }
            }
        }
        static void RemplirTableau (int[,] tableau)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    tableau[i, j] = 10 ; /*trouver autre chose que 10 pour les cases*/
                }
            }
        }
        static void RevelerTableau (int[,] tableau, int[,] plateau, int a, int b)
        {
            int bombeMinee = 0;

            while (bombeMinee < 1)
            {
                int ChoixDrapeau = 10;

                Console.WriteLine("Dans quelle ligne se trouve la case que vous voulez révéler ?");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("Dans quelle colonne se trouve la case que vous voulez révéler ?");
                b = int.Parse(Console.ReadLine());

                tableau[a, b] = plateau[a, b];

                if (tableau[a, b] == 9)
                {
                AfficherTableau(tableau);
                Perdu(tableau, plateau);
                bombeMinee = 1;
                }
                else
                {
                AfficherTableau(tableau);
                }
                while (ChoixDrapeau == 2) /*terminer ça*/
                {
                    Console.WriteLine("Voulez-vous poser ou retirer un drapeau sur une case ? (tapez 0 pour placer et 1 pour retirer et 2 pour ne rien faire");
                    ChoixDrapeau = int.Parse(Console.ReadLine());

                    if (ChoixDrapeau == 0)
                    {
                        PoserDrapeaux(plateau, a, b);
                    }
                    else if (ChoixDrapeau == 1)
                    {
                        RetirerDrapeaux(plateau, a, b);
                    }
                }
            }
        }
    }
}
