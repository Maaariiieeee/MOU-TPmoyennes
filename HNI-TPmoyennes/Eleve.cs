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
            if (notes.Count < 200) // On limite le nombre de notes à 200
            {
                notes.Add(note);
            }
            else
            {
                Console.Write("L'élève a trop de notes");
            }
        }



        public float moyenneMatiere(int matiere)
        {
            float sommeNotes = 0; // pour aditionner toutes les notes 
            int count = 0;  // pour compter les notes
            double moyenne = 0;

            // Boucle pour parcourir toutes les notes (au maximum 200)
            for (int i = 0; i < notes.Count; i++)
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
                return (float)Math.Round(moyenne, 2); // pour arrondir
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
            List<int> matieresTraitees = new List<int>(); //Matieres stockées

            //Boucle sur les notes de l'élève
            foreach (var note in notes)
            {


                if (!matieresTraitees.Contains(note.matiere)) // Si la matière n'a pas encore été traitée
                {
                    float moyMatiere = moyenneMatiere(note.matiere); // Appel à la méthode moyenneMatiere pour cette matière
                    if (moyMatiere > 0) // Si la moyenne de la matière  est valide
                    {
                        sommeMoyennes += moyMatiere; // On ajoute la moyenne de la matière à la somme
                        count++; // On incrémente le nombre de matire de la de leleve
                        matieresTraitees.Add(note.matiere); // On ajoute la matière à la liste des matières traitées
                    }
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
