﻿using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // Liste de mots pour le jeu
        string[] mots = { "programmation", "informatique", "organisation", "service", "classe" };

        // Objet pour générer des nombres aléatoires
        Random random = new Random();

        // Sélection d'un mot aléatoire de la liste
        string motSecret = mots[random.Next(mots.Length)];

        // Initialisation d'un tableau de caractères pour représenter le mot actuel
        char[] motActuel = new char[motSecret.Length];

        // Initialisation du mot actuel avec des underscores
        for (int i = 0; i < motSecret.Length; i++)
        {
            motActuel[i] = '_';
        }

        // Nombre de tentatives autorisées
        int tentativesRestantes = 6;

        // Variable pour stocker la lettre entrée par l'utilisateur
        char lettre;

        // Booléen pour indiquer si le mot a été trouvé
        bool trouve = false;

        // Message d'accueil
        Console.WriteLine("Bienvenue au jeu du Pendu!");

        // Boucle principale du jeu
        while (tentativesRestantes > 0 && !trouve)
        {
            // Efface la console pour garder l'affichage propre
            Console.Clear();

            // Affichage du pendu
            AfficherPendu(6 - tentativesRestantes);

            // Affichage du mot actuel avec les lettres découvertes
            Console.WriteLine("\nMot actuel: " + new string(motActuel));

            // Demande à l'utilisateur d'entrer une lettre
            Console.Write("Entrez une lettre : ");
            lettre = char.ToLower(Console.ReadKey().KeyChar);

            // Vérification si la lettre est dans le mot secret
            if (motSecret.Contains(lettre))
            {
                // Met à jour le mot actuel avec la lettre correcte
                for (int i = 0; i < motSecret.Length; i++)
                {
                    if (motSecret[i] == lettre)
                    {
                        motActuel[i] = lettre;
                    }
                }

                // Vérifie si le mot a été entièrement découvert
                trouve = Array.TrueForAll(motActuel, c => c != '_');
            }
            else
            {
                // Réduction du nombre de tentatives restantes si la lettre est incorrecte
                tentativesRestantes--;
                Console.WriteLine("\nLettre incorrecte. Tentatives restantes : " + tentativesRestantes);
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }

        // Efface la console avant d'afficher le résultat du jeu
        Console.Clear();

        // Affichage du résultat du jeu
        if (tentativesRestantes == 0)
        {
            // Si le joueur a épuisé toutes ses tentatives, affiche le pendu complet
            AfficherPendu(6);
            Console.WriteLine("\nDésolé, vous avez épuisé toutes vos tentatives. Le mot était : " + motSecret);
        }
        else
        {
            // Si le joueur a deviné le mot, félicite le joueur
            Console.WriteLine("\nFélicitations, vous avez deviné le mot : " + motSecret);
        }

        // Attente de la saisie d'une touche avant de fermer la console
        Console.ReadLine();
    }

    // Fonction pour afficher le pendu
    static void AfficherPendu(int erreurs)
    {
        Console.WriteLine("\n--------");

        switch (erreurs)
        {
            case 1:
                Console.WriteLine("|      |");
                break;
            case 2:
                Console.WriteLine("|      |");
                Console.WriteLine("|      O");
                break;
            case 3:
                Console.WriteLine("|      |");
                Console.WriteLine("|      O");
                Console.WriteLine("|      |");
                break;
            case 4:
                Console.WriteLine("|      |");
                Console.WriteLine("|      O");
                Console.WriteLine("|     /|\\");
                break;
            case 5:
                Console.WriteLine("|      |");
                Console.WriteLine("|      O");
                Console.WriteLine("|     /|\\");
                Console.WriteLine("|     /");
                break;
            case 6:
                Console.WriteLine("|      |");
                Console.WriteLine("|      O");
                Console.WriteLine("|     /|\\");
                Console.WriteLine("|     / \\");
                break;
            default:
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|");
                break;
        }

        Console.WriteLine("|");
        Console.WriteLine("--------");
    }
}