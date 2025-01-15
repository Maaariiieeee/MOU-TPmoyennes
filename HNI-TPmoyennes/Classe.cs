using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOU_TPmoyennes
{
    //Une classe contient :
    // - un nom de classe ex: 6eme A
    // - une liste d'élèves
    // - une liste de matières enseignées
    class Classe
    {
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }

        //On fait référence à l'ajout d'élève dans program
        public void ajouterEleve(string prenom, string nom)
        {
            eleves.Add(new Eleve(prenom, nom)); //on ajoute à la liste le prénom+nom de l'élève
        }

        public void ajouterMatiere(string nomMatiere)
        {
            matieres.Add(nomMatiere); // on ajoute à la liste la matière
        }


        public float moyenneMatiere(int matiere)
        {
            float sommeMoyennes = 0; // Pour additionner les moyennes des élèves dans la matière
            int count = 0;  // Pour compter le nombre d'élèves ayant des notes dans cette matière

            // Boucle sur tous les élèves de la classe
            foreach (var eleve in eleves)
            {
                float moyMatiere = eleve.moyenneMatiere(matiere); // Appel à la méthode moyenneMatiere pour cet élève

                if (moyMatiere > 0) // Si la moyenne de l'élève dans cette matière est valide (si l'élève a des notes dans cette matière)
                {
                    sommeMoyennes += moyMatiere; // On ajoute la moyenne de l'élève à la somme
                    count++; // On incrémente le nombre d'élèves ayant des notes dans cette matière
                }
            }

            // Calcul de la moyenne des moyennes pour la classe dans cette matière
            if (count > 0)
            {
                return (float)Math.Round(sommeMoyennes / count, 2); // Moyenne des moyennes arrondie à 2 décimales
            }
            else
            {
                return 0.0f; // Retourne 0 si aucun élève n'a de note dans cette matière
            }
        }
        public float moyenneGeneral()
        {
            float sommeMoyennes = 0; // Pour additionner les moyennes des matières de la classe
            int count = 0;  // Pour compter le nombre de matirèes dans la classe

            // Boucle sur toutes les matières de la classe
            for (int matiere = 1; matiere <= 10; matiere++)
            {
                float moyMatiere = moyenneMatiere(matiere); // Appel à la méthode moyenneMatiere pour cette pmatière

                if (moyMatiere > 0) // Si la moyenne de la matière  est valide
                {
                    sommeMoyennes += moyMatiere; // On ajoute la moyenne de la matière à la somme
                    count++; // On incrémente le nombre de matire de la classe
                }
            }

            // Calcul de la moyenne des moyennes pour la classe 
            if (count > 0)
            {
                return (float)Math.Round(sommeMoyennes / count, 2); // Moyenne des moyennes arrondie à 2 décimales
            }
            else
            {
                return 0.0f; 
            }
        }


    }
}

