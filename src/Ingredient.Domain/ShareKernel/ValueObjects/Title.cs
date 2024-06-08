using Ingredient.Domain.SeedWork;
using Ingredient.Resource;
using System.Xml.Linq;

namespace Ingredient.Domain.ShareKernel.ValueObjects
{
    public class Title : ValueObject
    {
        private const byte MaxLen = 50;

        public string Value { get; } = string.Empty;
        public static explicit operator string(Title title) => title.Value;
        private Title()
        {
        }

        private Title(string title)
        {
            this.Value = title;
        }

        public static Result<Title> Create(string? title)
        {
            if (title == null)
            {
                Result.Failure<Title>(Error.Create(
                    "ValueObjects.Title", 
                    string.Format(Validation.RegularExpression, DataDictionary.Title)));
            }

            if (title?.Length < MaxLen)
            {
                Result.Failure<Title>(Error.Create(
                    "ValueObjects.Title",
                    string.Format(Validation.MaxLenValidation, DataDictionary.Title, MaxLen)));
            }

            return new Title(title!);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
