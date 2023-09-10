using AssetsTools.NET;

namespace TypeTreeConversion.MiHoYoGrassLand;

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
