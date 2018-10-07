﻿using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
	public class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name) : base(name)
		{
			Type = GradeBookType.Ranked;
		}

		public override char GetLetterGrade(double averageGrade)
		{
			if (Students.Count < 5)
				throw new InvalidOperationException("Ranked grading requires at least 5 students.");

				var threshold = (int)Math.Ceiling(Students.Count * .02);
				var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => averageGrade).ToList();

				if (grades[threshold-1] <= averageGrade)
					return 'A';
				if (grades[(threshold * 2) -1] <= averageGrade)  
					return 'B';
				if (grades[(threshold * 3) -1] <= averageGrade)
					return 'C';
				if (grades[(threshold * 4) -1] <= averageGrade)
					return 'D';
				else
				return ('F');
			
		}
	}
}
