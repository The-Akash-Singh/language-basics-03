using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int minValue = int.MaxValue;
            for (int i = 0; i < mealArray.Length; i++)
            {
                if (indexArray[i] == 0 && mealArray[i] < minValue)
                {
                    minValue = mealArray[i];
                }
            }
            for (int i = 0; i < mealArray.Length; i++)
            {
                if (mealArray[i] != minValue)
                {
                    indexArray[i] = 1;
                }
            }
        }
        public static void findMaxArrayValue(int[] mealArray, int[] indexArray)
        {
            int maxValue = -1;
            for (int i = 0; i < mealArray.Length; i++)
            {
                if (indexArray[i] == 0 && mealArray[i] > maxValue)
                {
                    maxValue = mealArray[i];
                }
            }
            for (int i = 0; i < mealArray.Length; i++)
            {
                if (mealArray[i] != maxValue)
                {
                    indexArray[i] = 1;
                }
            }

        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fats, string[] dietplan)
        {
            int[] returnMeal = new int[dietplan.Length];
            int[] calories = new int[protein.Length];
            int[] indexArray = new int[protein.Length];
            for (int i = 0; i < protein.Length; i++)
            {
                calories[i] = protein[i] * 5 + carbs[i] * 5 + fats[i] * 9;
            }

            for (int i = 0; i < dietplan.Length; i++)
            {
                for (int j = 0; j < protein.Length; j++)
                    indexArray[j] = 0;
                foreach (var item in dietplan[i])
                {
                    switch (item)
                    {
                        case 't':
                            findMinArrayIndex(calories, indexArray);
                            break;
                        case 'T':
                            findMaxArrayValue(calories, indexArray);
                            break;
                        case 'f':
                            findMinArrayIndex(fats, indexArray);
                            break;
                        case 'F':
                            findMaxArrayValue(fats, indexArray);
                            break;
                        case 'p':
                            findMinArrayIndex(protein, indexArray);
                            break;
                        case 'P':
                            findMaxArrayValue(protein, indexArray);
                            break;
                        case 'c':
                            findMinArrayIndex(carbs, indexArray);
                            break;
                        case 'C':
                            findMaxArrayValue(carbs, indexArray);
                            break;
                    }
                }
                returnMeal[i] = Array.IndexOf(indexArray, 0);
            }
            return returnMeal;
        }
    }
}
