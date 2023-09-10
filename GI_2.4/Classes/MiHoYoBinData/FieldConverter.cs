using AssetsTools.NET;

namespace TypeTreeConversion.MiHoYoBinData;

public class FieldConverter : DefaultFieldConverter
{
	public static AssetFileInfo IndexObjectInfo;
	public static AssetTypeValueField IndexObjectBaseValue;
	public FieldConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override AssetTypeValueField? CreateNewBaseField(int originalTypeID)
	{
		return base.CreateNewBaseField(49);
	}

	protected override void CopyFields(UnityAsset asset, AssetTypeValueField source, AssetTypeValueField destination)
	{
		IndexObjectInfo ??= asset.File.file.AssetInfos.FirstOrDefault(x => x.PathId == 2 && x.TypeId == ClassIDType.IndexObject);
		if (IndexObject.FieldConverter.InfoMap.TryGetValue(IndexObjectInfo, out IndexObjectBaseValue))
		{
			if (IndexObjectBaseValue.TryGetChild("m_AssetIndex", out var assetIndex))
			{
				var index = assetIndex["Array"].FirstOrDefault(x => x["second.m_PathID"].AsLong == asset.Info.PathId);
				if (index != null)
				{
					destination["m_Name"].AsString = index["first"].AsString;
				}
			}
		}
		destination["m_Script"].AsByteArray = source["m_bytes.Array"].AsByteArray;
	}
}
