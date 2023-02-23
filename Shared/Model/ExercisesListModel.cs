using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examensarbete.Shared.Model
{
	public class ExercisesListModel 
	{
		public string? exercise { get; set; }
        public int? WorkoutModelid { get; set; }
        [Key]
        public int? id { get; set; }
        public int? Repetition { get; set; }
    }
}

