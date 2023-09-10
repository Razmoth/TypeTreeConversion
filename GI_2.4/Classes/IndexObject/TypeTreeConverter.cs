using AssetsTools.NET;

namespace TypeTreeConversion.IndexObject;

public class TypeTreeConverter : DefaultTypeTreeReplacer
{
	public TypeTreeConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override TypeTreeType? CreateReplacement(int originalTypeID)
	{
		return base.CreateReplacement(142);
	}
}
