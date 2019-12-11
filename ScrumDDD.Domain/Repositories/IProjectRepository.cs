using ScrumDDD.Domain.Entities;
using System;

namespace ScrumDDD.Domain.Repositories
{
    public interface IProjectRepository
    {
        Project GetById(int id);
    }
}
