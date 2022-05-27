using System;

namespace Démineur2017
{
    class Program
    {
        static void Main()
        {
            int[,] plateau = new int[9, 9];
            int a = 0;
            int b = 0;
            string[,] tableau = new string[9, 9];
            int drapeau = 0;
            int cases = 71;

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
            RemplirTableau(tableau);
            AfficherTableau(tableau);
            RevelerTableau(tableau, plateau, a, b, drapeau, cases);
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
        static void AfficherTableau(string[,] tableau)
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
        static void Perdu(int[,] plateau, string[,] tableau)
        {
            AfficherPlateau(plateau);
            AfficherTableau(tableau);
            Console.WriteLine("Vous avez perdu");
            Console.ReadLine();
            NouvellePartie();
        }
        static void Gagne(int[,] plateau, string[,] tableau)
        {
            AfficherPlateau(plateau);
            AfficherTableau(tableau);
            Console.WriteLine("Vous avez gagné");
            Console.ReadLine();
            NouvellePartie();
        }
        static void NouvellePartie()
        {
            int partie = 2;
            Console.WriteLine("Voulez-vous lancer une nouvelle partie ?");
            Console.WriteLine("0 = oui");
            Console.WriteLine("1 = non");
            partie = int.Parse(Console.ReadLine());

            if (partie == 0)
            {
                Main();
            }
            else if (partie == 1)
            {
                Console.WriteLine("Au revoir");
            }
            else if (partie != 1 && partie != 0)
            {
                NouvellePartie();
            }

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
        static void PoserDrapeaux(string[,] tableau, int a, int b, int drapeau, int cases, int[,] plateau)
        {
            if (tableau[a, b] == " * ")
            {
                Console.WriteLine("Il y a déjà drapeau sur cette case");
                Console.ReadLine();
                RevelerTableau(tableau, plateau, a, b, drapeau, cases);
            }
            else if (tableau[a, b] != " # ")
            {
                Console.WriteLine("Vous ne pouvez pas poser de drapeaux sur cette case");
                Console.ReadLine();
                RevelerTableau(tableau, plateau, a, b, drapeau, cases);
            }
            else if (tableau[a, b] == " # ")
            {
                tableau[a, b] = " * ";
                drapeau = drapeau + 1;
            }

            AfficherTableau(tableau);
        }
        static void RetirerDrapeaux(string[,] tableau, int a, int b, int drapeau, int[,] plateau, int cases)
        {

            if (tableau[a, b] == " * ")
            {
                tableau[a, b] = " # ";
                drapeau = drapeau - 1;
            }
            else if (tableau[a, b] != " * ")
            {
                Console.WriteLine("Il n'y a pas de drapeau sur cette case");
                Console.ReadLine();
                RevelerTableau(tableau, plateau, a, b, drapeau, cases);
            }
            AfficherTableau(tableau);
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
        static void RemplirCoinHG(int[,] plateau)
        {
            int i = 0;
            int j = 0;

            if (plateau[i, j] != 9)
            {
                if (plateau[i + 1, j] == 9)
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
        static void RemplirCoinHD(int[,] plateau)
        {
            int i = 8;
            int j = 0;

            if (plateau[i, j] != 9)
            {
                if (plateau[i - 1, j] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i, j + 1] == 9)
                {
                    plateau[i, j]++;
                }
                if (plateau[i - 1, j + 1] == 9)
                {
                    plateau[i, j]++;
                }
            }
        }
        static void RemplirCoinBG(int[,] plateau)
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
        static void RemplirCoinBD(int[,] plateau)
        {
            int i = 8;
            int j = 8;

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
        static void RemplirBordureG(int[,] plateau)
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
        static void RemplirBordureD(int[,] plateau)
        {
            int i = 8;
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
        static void RemplirBordureB(int[,] plateau)
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
        static void RemplirTableau(string[,] tableau)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    tableau[i, j] = " # ";
                }
            }
        }
        static void RevelerTableau(string[,] tableau, int[,] plateau, int a, int b, int drapeau, int cases)
        {
            int bombeMinee = 0;

            while (bombeMinee < 1)
            {
                Console.WriteLine("Dans quelle ligne se trouve la case que vous voulez révéler ?");
                a = int.Parse(Console.ReadLine()) - 1;
                if (a > 9)
                {
                    Console.ReadLine();
                    RevelerTableau(tableau, plateau, a, b, drapeau, cases);
                }
                Console.WriteLine("Dans quelle colonne se trouve la case que vous voulez révéler ?");
                b = int.Parse(Console.ReadLine()) - 1;
                if (b > 9)
                {
                    Console.ReadLine();
                    RevelerTableau(tableau, plateau, a, b, drapeau, cases);
                }
                Console.WriteLine("0 : Révéler la case");
                Console.WriteLine("1 : Mettre un drapeau");
                Console.WriteLine("2 : Enlever le drapeau");
                string choix = Console.ReadLine();

                if (choix == "0" && plateau[a, b] == 9)
                {
                    Console.WriteLine("0  et boum");
                    tableau[a, b] = " " + plateau[a, b] + " ";
                    Perdu(plateau, tableau);
                    bombeMinee = 1;
                }
                else if (choix == "0" && plateau[a, b] != 9)
                {
                    tableau[a, b] = " " + plateau[a, b] + " ";
                    AfficherTableau(tableau);
                    cases = cases - 1;

                    if (cases == 0)
                    {
                        Gagne(plateau, tableau);
                    }
                }
                else if (choix == "1")
                {
                    PoserDrapeaux(tableau, a, b, drapeau, cases, plateau);
                }
                else if (choix == "2")
                {
                    RetirerDrapeaux(tableau, a, b, drapeau, plateau, cases);
                }
                else
                {
                    RevelerTableau(tableau, plateau, a, b, drapeau, cases);
                }
            }
        }
    }
}
