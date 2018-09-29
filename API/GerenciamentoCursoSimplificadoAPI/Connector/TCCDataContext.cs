using GerenciamentoCursoSimplificadoAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursoSimplificadoAPI.Connector
{
    public class TCCDataContext : DbContext
    {
        public TCCDataContext(DbContextOptions<TCCDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Aluno> Aluno { get; set; }
    }
}
