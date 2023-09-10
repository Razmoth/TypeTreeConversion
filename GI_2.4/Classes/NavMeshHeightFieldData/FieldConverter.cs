using AssetsTools.NET;
using AssetsTools.NET.Extra;

namespace TypeTreeConversion.NavMeshHeightFieldData;

public class FieldConverter : DefaultFieldConverter
{
	public FieldConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override AssetTypeValueField? CreateNewBaseField(int originalTypeID)
	{
		return base.CreateNewBaseField(238);
	}

	protected override void CopyFields(UnityAsset asset, AssetTypeValueField source, AssetTypeValueField destination)
	{
		CopyFieldsExactly(source, destination);
		CopyFieldsExactly(source["m_NavMeshHeightFieldBuildSettings"], destination["m_NavMeshBuildSettings"]);

		CopyTiles(source["m_NavMeshTileHeightFields"]["Array"], destination["m_NavMeshTiles"]["Array"]);
	}
	private static void CopyTiles(AssetTypeValueField source, AssetTypeValueField destination)
	{
		AssetTypeArrayInfo sourceArrayInfo = source.AsArray;
		destination.AsArray = sourceArrayInfo;
		for (int i = 0; i < sourceArrayInfo.size; i++)
		{
			AssetTypeValueField destinationElement = ValueBuilder.DefaultValueFieldFromArrayTemplate(source.TemplateField);
			destination.Children.Add(destinationElement);
			AssetTypeValueField sourceElement = source[i];
			CopyFieldsExactly(sourceElement["m_HeightFieldData"], destinationElement["m_MeshData"]);
			CopyFieldsExactly(sourceElement["m_Hash"], destinationElement["m_Hash"]);
		}
	}
}
