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
    public class EnergyLosses : IEntityTypeConfiguration<EnergyLosses>, IModelValidator
    {
        public DateTime Date { get; set; }
        public int RegionID { get; set; }
        public decimal VolumeOfLosses { get; set; }

        public Region Region { get; set; }

        public void Validate(IModel model, IDiagnosticsLogger<DbLoggerCategory.Model.Validation> logger)
        {

        }

        public void Configure(EntityTypeBuilder<EnergyLosses> builder)
        {
            builder.ToTable("EnergyLosses");
            builder.HasNoKey();
        }
    }
}
