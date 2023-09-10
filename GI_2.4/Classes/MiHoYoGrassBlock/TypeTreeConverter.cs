using AssetsTools.NET;

namespace TypeTreeConversion.MiHoYoGrassBlock;

public class TypeTreeConverter : DefaultTypeTreeReplacer
{
	public TypeTreeConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override TypeTreeType? CreateReplacement(int originalTypeID)
	{
		return base.CreateReplacement(218);
	}
}
