using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOU_TPmoyennes
{
    // Classes fournies par HNI Institut
    class Eleve
    {
        public string nom { get; private set; }
        public string prenom { get; private set; }
        public List<Note> notes; // Liste des notes pour chaque matière

        public Eleve(string nom, string prenom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
        }

        public void ajouterNote(Note note)
        {
            notes.Add(note);
        }

        public float moyenneMatiere(int matiere)
        {
            float sommeNotes = 0; // pour aditionner toutes les notes 
            int count = 0;  // pour compter les notes
            double moyenne = 0; 

            // Boucle pour parcourir toutes les notes (au maximum 200)
            for (int i = 0; i < 200; i++)
            {
                if (notes[i].matiere == matiere) // si la note est dans la matière concernée, on l'ajoute
                {
                    sommeNotes += notes[i].note; // Ajoute la note à la somme
                    count++; // Compte le nombre de notes
                }
            }
            if (count > 0) //si il y a au moins une note on fait le calcul
            {
                moyenne = sommeNotes / count;
                return (float)Math.Round(moyenne,2); // pour arrondir
            }
            else //sinon on retourne 0
            {
                return 0.0f;
            }
        }


        public float moyenneGeneral()
        {
            float sommeMoyennes = 0; // Pour additionner les moyennes des matières
            int count = 0;  // Pour compter le nombre de matières

            // Boucle sur les 10 matières possibles (ou jusqu'à la dernière matière de l'élève)
            for (int matiere = 1; matiere <= 10; matiere++)
            {
                float moyMatiere = moyenneMatiere(matiere); // Appel à la méthode moyenneMatiere pour chaque matière

                if (moyMatiere > 0) // Si la moyenne de la matière est valide (i.e. l'élève a des notes dans cette matière)
                {
                    sommeMoyennes += moyMatiere; // On ajoute la moyenne de la matière à la somme
                    count++; // On incrémente le nombre de matières ayant une note
                }
            }

            // Si l'élève a des matières avec des notes, on calcule la moyenne générale
            if (count > 0)
            {
                return (float)Math.Round(sommeMoyennes / count, 2); // Moyenne générale arrondie à 2 décimales
            }
            else
            {
                return 0.0f; // Aucun résultat si aucune matière n'a de notes
            }
        }


    }
}
