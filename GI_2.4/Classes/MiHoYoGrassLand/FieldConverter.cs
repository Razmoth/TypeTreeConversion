using AssetsTools.NET;

namespace TypeTreeConversion.MiHoYoGrassLand;

public class FieldConverter : DefaultFieldConverter
{
	public FieldConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override AssetTypeValueField? CreateNewBaseField(int originalTypeID)
	{
		return base.CreateNewBaseField(218);
	}

	protected override void CopyFields(UnityAsset asset, AssetTypeValueField source, AssetTypeValueField destination)
	{
		CopyFieldsExactly(source, destination);
		CopyFieldsExactly(source["m_GrassData"], destination["m_TerrainData"]);
	}
}
