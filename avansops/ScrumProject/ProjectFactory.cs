using System;
using System.Collections.Generic;

namespace AvansOps {
	public static class ProjectFactory 
	{
		public static Project CreateProject(int id, string name, string description, ProjectMember creator) {
			Project project = new Project(id, name, description, creator);

			var todoPhase = new SprintPhase(1, "Todo", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			});
			
			todoPhase.AddStrategyPlaceItem(new NotifyRole(new List<Role>(){Role.ScrumMaster}, project, "Item moved to todo"));
			project.AddPhase(todoPhase);

			project.AddPhase(new SprintPhase(2, "Doing", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			}));

			var testPhase = new SprintPhase(3, "Ready for testing", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			});
			testPhase.AddStrategyPlaceItem(new NotifyRole(new List<Role>() {Role.Tester}, project, "Item moved to testing"));
			project.AddPhase(testPhase);
			
			project.AddPhase(new SprintPhase(4, "Testing", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			}));

			var doneFase = new SprintPhase(5, "Tested and done", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			});
			doneFase.AddStrategyPlaceItem(new SetBackLogItemToDone());
			project.AddPhase(doneFase);

			return project;
		}
	}

}
