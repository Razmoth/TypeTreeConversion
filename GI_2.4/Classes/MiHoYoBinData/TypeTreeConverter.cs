using AssetsTools.NET;

namespace TypeTreeConversion.MiHoYoBinData;

public class TypeTreeConverter : DefaultTypeTreeReplacer
{
	public TypeTreeConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override TypeTreeType? CreateReplacement(int originalTypeID)
	{
		return base.CreateReplacement(49);
	}
}
