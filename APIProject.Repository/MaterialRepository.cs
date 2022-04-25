using APIProject.Domain;
using APIProject.Domain.Models;
using APIProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Repository
{
  public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
