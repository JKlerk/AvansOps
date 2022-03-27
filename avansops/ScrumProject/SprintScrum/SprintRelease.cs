﻿using System;

namespace AvansOps.ScrumProject.SprintScrum
{
    public class SprintRelease : Sprint
    {
        public SprintRelease(int id, DateTime dateStart, DateTime dateEnd) : base(id, dateStart, dateEnd)
        { }

        public void FinishPipeline()
        {
            Finish();
        }
    }
}