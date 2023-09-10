using AssetsTools.NET;

namespace TypeTreeConversion.MiHoYoBinData;

public class TypeTreeReplacer : DefaultTypeTreeReplacer
{
	public TypeTreeReplacer(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override TypeTreeType? CreateReplacement(int originalTypeID)
	{
		return base.CreateReplacement(49);
	}
}
