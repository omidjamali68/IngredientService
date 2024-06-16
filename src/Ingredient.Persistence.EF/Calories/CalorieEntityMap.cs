using Ingredient.Domain.Calories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingredient.Persistence.EF.Calories
{
    internal class CalorieEntityMap : IEntityTypeConfiguration<Calorie>
    {
        public void Configure(EntityTypeBuilder<Calorie> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasConversion(x => x.Value, x => Domain.ShareKernel.ValueObjects.Title.Create(x).Value!);
        }
    }
}
