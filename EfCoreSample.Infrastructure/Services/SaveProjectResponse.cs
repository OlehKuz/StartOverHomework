using EfCoreSample.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreSample.Infrastructure.Services
{
    public class SaveProjectResponse : BaseResponse
    {
        public Project Project { get; private set; }

        private SaveProjectResponse(bool success, string message, Project project) : base(success, message)
        {
            Project = project;
        }
        public SaveProjectResponse(Project project) : this(true, string.Empty, project)
        { }
        public SaveProjectResponse(string message) : this(false, message, null)
        { }
    }
}
