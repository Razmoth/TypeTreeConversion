using AssetsTools.NET;

namespace TypeTreeConversion.IndexObject;

public class FieldConverter : DefaultFieldConverter
{
	public FieldConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override AssetTypeValueField? CreateNewBaseField(int originalTypeID)
	{
		return base.CreateNewBaseField(114);
	}

	protected override void CopyFields(UnityAsset asset, AssetTypeValueField source, AssetTypeValueField destination)
	{
		//CopyFieldsExactly(source, destination);
	}
}
