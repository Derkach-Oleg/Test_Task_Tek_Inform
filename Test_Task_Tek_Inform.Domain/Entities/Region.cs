using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_Tek_Inform.Domain.Entities
{
    public class Region : IEntityTypeConfiguration<Region>, IModelValidator
    {
        public int ID { get; set; } 
        public string Name { get; set; }

        public void Validate(IModel model, IDiagnosticsLogger<DbLoggerCategory.Model.Validation> logger)
        {

        }  

        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region");
            builder.HasKey(k => k.ID);
        }
    }
}
