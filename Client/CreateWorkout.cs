using System;
using Examensarbete.Shared.Model;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Examensarbete.Client
{
    public class CreateWorkout
    {
        public ExerciseModel RandomExercise(List<ExerciseModel> pickExercise)
        {
            Random random = new();
            var randomInt = random.Next(pickExercise.Count);
            ExerciseModel randomExercise = pickExercise[randomInt];
            return randomExercise;
        }

        public List<ExerciseModel> ShuffelList(List<ExerciseModel> pickExercise)
        {
            Random random = new();
            pickExercise.Count();
            var shuffled = pickExercise.OrderBy(_ => random.Next()).ToList();
            return shuffled;
        }

        public int RandomRepetitions(int min, int max)
        {
            Random random = new();
            var randomRepetitions = random.Next(min, max);
            return randomRepetitions;
        }

        public WorkoutModel Intervall()
        {
            WorkoutModel workout = new();
            workout.Rounds = RandomRepetitions(1, 20);
            workout.IntervallOn = RandomRepetitions(3, 10);
            workout.IntervallOff = RandomRepetitions(1, 3);
            return workout;
        }

        public WorkoutModel Steady()
        {
            WorkoutModel workout = new();
            var rounds = RandomRepetitions(1, 10);
            workout.Rounds = rounds;
            return workout;
        }

        public WorkoutModel Strength()
        {
            WorkoutModel workout = new();
            var rounds = RandomRepetitions(1,5);
            workout.Rounds = rounds;
            return workout;
        }

        public WorkoutModel GetFocusArea(string focus)
        {
            WorkoutModel workout = new();
            switch (focus)
            {
                case "Interval":
                    workout = Intervall();
                    break;
                case "Steady":
                    workout = Steady();
                    break;
                case "Strength":
                    workout = Strength();
                    break;
                default:
                    workout = Steady();
                    break;
            }
            return workout;
        }

    }
}
