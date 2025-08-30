using EF2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Convigrution
{
    internal class Stud_Course_Convegration : IEntityTypeConfiguration<Stud_Course>
    {
        public void Configure(EntityTypeBuilder<Stud_Course> builder)
        {
            builder.HasKey(sc => new {sc.stud_ID,sc.Course_ID});
        }
    }
}
