﻿using System;
using Examensarbete.Shared.Model;

namespace Examensarbete.Client.Services.ExerciseService
{
	public interface IExerciseService
	{
		List <ExerciseModel> ExerciseList { get; set; }
		Task GetExercises();
		Task<ExerciseModel> GetSingelEx(int id);
		
	}
}