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

        public int RandomRepetitions(int maxReps)
        {
            Random random = new();
            var randomRepetitions = random.Next(maxReps);
            return randomRepetitions;
        }

        public WorkoutModel Intervall()
        {
            WorkoutModel workout = new();
            var rounds = RandomRepetitions(20);
            var on = RandomRepetitions(10);
            var off = RandomRepetitions(3);
            workout.Rounds = rounds;
            workout.IntervallOn = on;
            workout.IntervallOff = off;
            return workout;
        }

        public WorkoutModel Steady()
        {
            WorkoutModel workout = new();
            var rounds = RandomRepetitions(100);
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
                    //workout = Strength();
                    break;
                default:
                    // code block
                    break;
            }
            return workout;
        }

    }
}

