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
    internal class Course_Inst_Configration : IEntityTypeConfiguration<Course_Inst>
    {
        public void Configure(EntityTypeBuilder<Course_Inst> builder)
        {
           builder.HasKey(ins=>new {ins.inst_ID,ins.Course_ID});
        }
    }
}
