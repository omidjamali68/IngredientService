using Microsoft.EntityFrameworkCore;

namespace Ingredient.Persistence.EF.Ingredients
{
    internal class IngredientEntityMap : IEntityTypeConfiguration<Domain.Ingredients.Ingredient>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Ingredients.Ingredient> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasConversion(x => x.Value, x => Domain.ShareKernel.ValueObjects.Title.Create(x).Value!);
        }
    }
}
