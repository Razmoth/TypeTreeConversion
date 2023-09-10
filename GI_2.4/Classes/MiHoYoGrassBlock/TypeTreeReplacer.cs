using AssetsTools.NET;

namespace TypeTreeConversion.MiHoYoGrassBlock;

public class TypeTreeReplacer : DefaultTypeTreeReplacer
{
	public TypeTreeReplacer(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override TypeTreeType? CreateReplacement(int originalTypeID)
	{
		return base.CreateReplacement(218);
	}
}
