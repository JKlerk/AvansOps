using System;
using System.Collections.Generic;
using System.Linq;

namespace AvansOps {
	public class Project
	{
		private int id;
		public string Name { get; }
		public string Description { get; }
		public List<BackLogItem> BackLogItems { get; }
		public List<Sprint> Sprints { get; }
		private Repository repository;
		public List<SprintPhase> SprintPhases { get; }
		private ProjectMember creator;

		public Project(int id, string name, string description, ProjectMember creator)
		{
			this.id = id;
			Name = name;
			Description = description;
			this.creator = creator;
			BackLogItems = new List<BackLogItem>();
			Sprints = new List<Sprint>();
			SprintPhases = new List<SprintPhase>();
			repository = new Repository(this);
		}

		public void AddBackLogItem(BackLogItem backLogItem)
		{
			BackLogItems.Add(backLogItem);
		}

		public Sprint AddSprint(SprintType sprintType, DateTime start, DateTime end, ProjectMember creator)
		{
			Sprint sprint = null;

            switch (sprintType)
            {
                case SprintType.Review:
					sprint = SprintFactory.CreateReviewSprint(start, end, creator);
					break;
                case SprintType.Release:
					sprint = SprintFactory.CreateReleaseSprint(repository, start, end, creator);
					break;
            }

			Sprints.Add(sprint);
			return sprint;
		}

		public SprintBackLogItem AddBackLogItemToSprintBackLog(BackLogItem backLogItem, Sprint sprint)
		{
			SprintBackLogItem item = sprint.AddSprintBacklogItem(backLogItem);
			SprintPhases[0].PlaceItem(item, null);
			backLogItem.SetSprintBackLogItem(item);
			return item;
		}

		public void AddPhase(SprintPhase phase)
		{
			SprintPhases.Add(phase);
		}

		public SprintPhase GetPhase(string name)
		{
			return SprintPhases.First(x => x.Name.ToLower() == name.ToLower());
		}

		public SprintPhase GetPhase(int id)
		{
			return SprintPhases.First(x => x.Id == id);
		}

		public void MoveSprintBackLogItemToPhase(ProjectMember projectMember, SprintBackLogItem sprintBackLogItem, SprintPhase phase)
		{
			if (!phase.RolesAuthorized.Any(x => projectMember.Roles.Any(y => y == x)))
			{
				Console.WriteLine("Not authorized");
				return;
			}

			SprintPhase sprintPhaseFrom = null;

			foreach (var x in SprintPhases.Where(x => x.SprintBackLogItems.Contains(sprintBackLogItem)))
			{
				sprintPhaseFrom = x;
				x.RemoveItem(sprintBackLogItem);
			}

			phase.PlaceItem(sprintBackLogItem, sprintPhaseFrom);
		}

		public Sprint GetCurrentSprint()
		{
			return Sprints.First(sprint => sprint.SprintState == SprintState.OnGoing);
		}

		public Repository GetRepository()
		{
			return repository;
		}
	}
}
