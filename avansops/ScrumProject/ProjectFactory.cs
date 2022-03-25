using System;
using System.Collections.Generic;

namespace AvansOps {
	public class ProjectFactory {
		public Project CreateProject(int id, string name, string description, ProjectMember creator) {
			Project project =  new Project(id, name, description, creator);

			var todoPhase = new SprintPhase(1, "TODO", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			});
			
			todoPhase.AddStrategyPlaceItem(new NotifyRole(new List<Role>(){Role.ScrumMaster}, project, "Item moved to todo"));
			project.AddPhase(todoPhase);
			
			project.AddPhase(new SprintPhase(2, "Todo", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			}));
			
			project.AddPhase(new SprintPhase(3, "Doing", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			}));
			
			project.AddPhase(new SprintPhase(4, "Ready for testing", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			}));
			
			project.AddPhase(new SprintPhase(5, "Testing", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			}));
			
			project.AddPhase(new SprintPhase(6, "Tested and done", new List<Role>()
			{
				Role.ScrumMaster,
				Role.Developer,
				Role.Tester
			}));

			return project;
		}
	}

}
