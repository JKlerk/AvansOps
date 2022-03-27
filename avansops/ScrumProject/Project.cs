using System;
using System.Collections.Generic;
using System.Linq;
using AvansOps.ScrumProject.Sprint;

namespace AvansOps.ScrumProject {
	public class Project
	{
		public int Id { get; }
		public string Name { get; }
		public string Description { get; }
		public List<BackLogItem> BackLogItems { get; }
		public List<Sprint.Sprint> Sprints { get; }
		private Repository.Repository repository;
		public List<SprintPhase> SprintPhases { get; }
		private ProjectMember creator;

		public Project(int id, string name, string description, ProjectMember creator)
		{
			Id = id;
			Name = name;
			Description = description;
			this.creator = creator;
			BackLogItems = new List<BackLogItem>();
			Sprints = new List<Sprint.Sprint>();
			SprintPhases = new List<SprintPhase>();
			repository = new Repository.Repository(this);
		}

		public void AddBackLogItem(BackLogItem backLogItem)
		{
			if (BackLogItems.Exists(x => x.Id == backLogItem.Id)) throw new Exception("Backlog item already exists");
			BackLogItems.Add(backLogItem);
		}

		public Sprint.Sprint AddSprint(SprintType sprintType, DateTime start, DateTime end, ProjectMember creator)
		{
			Sprint.Sprint sprint = null;

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

		public SprintBackLogItem AddBackLogItemToSprintBackLog(BackLogItem backLogItem, Sprint.Sprint sprint)
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

		public Sprint.Sprint GetCurrentSprint()
		{
			try
			{
				return Sprints.First(sprint => sprint.SprintState == SprintState.OnGoing);
			}
			catch (Exception e)
			{
				throw new Exception("No sprint found");
			}
		}

		public Repository.Repository GetRepository()
		{
			return repository;
		}
		

		public void StartPipelineCurrentSprint()
		{
			Sprint.Sprint currentSprint = GetCurrentSprint();

			if (currentSprint.GetType() == typeof(SprintReview))
            {
				throw new Exception("Sprint is already closed");
            }

			repository.RunPipeline(currentSprint);
		}
	}
}
