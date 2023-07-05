using System;

namespace AllergyTest
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class with test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        private int finalScore;

        public Allergies(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException("Score is less than zero");
            }

            this.finalScore = score % 256;
        }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            bool b = false;
            if (allergens.HasFlag(Allergens.Eggs) && this.finalScore >= 1)
            {
                this.finalScore -= 1;
                b = true;
            }

            if (allergens.HasFlag(Allergens.Peanuts) && this.finalScore >= 2)
            {
                this.finalScore -= 2;
                b = true;
            }

            if (allergens.HasFlag(Allergens.Shellfish) && this.finalScore >= 4)
            {
                this.finalScore -= 4;
                b = true;
            }

            if (allergens.HasFlag(Allergens.Strawberries) && this.finalScore >= 8)
            {
                this.finalScore -= 8;
                b = true;
            }

            if (allergens.HasFlag(Allergens.Tomatoes) && this.finalScore >= 16)
            {
                this.finalScore -= 16;
                b = true;
            }

            if (allergens.HasFlag(Allergens.Chocolate) && this.finalScore >= 32)
            {
                this.finalScore -= 32;
                b = true;
            }

            if (allergens.HasFlag(Allergens.Pollen) && this.finalScore >= 64)
            {
                this.finalScore -= 64;
                b = true;
            }

            if (allergens.HasFlag(Allergens.Cats) && this.finalScore >= 128)
            {
                this.finalScore -= 128;
                b = true;
            }

            if (b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            List<Allergens> allergensList = new List<Allergens>();
            if (this.IsAllergicTo(Allergens.Cats))
            {
                allergensList.Add(Allergens.Cats);
            }

            if (this.IsAllergicTo(Allergens.Pollen))
            {
                allergensList.Add(Allergens.Pollen);
            }

            if (this.IsAllergicTo(Allergens.Chocolate))
            {
                allergensList.Add(Allergens.Chocolate);
            }

            if (this.IsAllergicTo(Allergens.Tomatoes))
            {
                allergensList.Add(Allergens.Tomatoes);
            }

            if (this.IsAllergicTo(Allergens.Strawberries))
            {
                allergensList.Add(Allergens.Strawberries);
            }

            if (this.IsAllergicTo(Allergens.Shellfish))
            {
                allergensList.Add(Allergens.Shellfish);
            }

            if (this.IsAllergicTo(Allergens.Peanuts))
            {
                allergensList.Add(Allergens.Peanuts);
            }

            if (this.IsAllergicTo(Allergens.Eggs))
            {
                allergensList.Add(Allergens.Eggs);
            }

            Allergens[] newArray = allergensList.ToArray();
            for (int i = 0; i < allergensList.ToArray().Length; i++)
            {
                newArray[i] = allergensList.ToArray()[allergensList.ToArray().Length - 1 - i];
            }

            return newArray;
        }
    }
}
