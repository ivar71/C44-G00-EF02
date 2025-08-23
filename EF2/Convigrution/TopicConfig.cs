using EF2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Convigrution
{
    internal class TopicConfig : IEntityTypeConfiguration<Topic>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Topic> builder)
        {

            builder.HasIndex(t => t.Name)
                   .IsUnique();

        }
    }
}
