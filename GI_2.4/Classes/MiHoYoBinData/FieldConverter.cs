using AssetsTools.NET;

namespace TypeTreeConversion.MiHoYoBinData;

public class FieldConverter : DefaultFieldConverter
{
	private readonly IReadOnlyDictionary<UnityAsset, AssetTypeValueField> infoMap;
	public FieldConverter(ClassDatabaseFile classDatabase, IndexObject.FieldConverter indexObjectConverter) : base(classDatabase)
	{
		this.infoMap = indexObjectConverter.InfoMap;
	}

	protected override AssetTypeValueField? CreateNewBaseField(int originalTypeID)
	{
		return base.CreateNewBaseField(49);
	}

	protected override void CopyFields(UnityAsset asset, AssetTypeValueField source, AssetTypeValueField destination)
	{
		UnityAsset IndexObjectAsset = asset.File.Assets.FirstOrDefault(x => x.TypeID == ClassIDType.IndexObject);
		if (infoMap.TryGetValue(IndexObjectAsset, out AssetTypeValueField IndexObjectBaseValue))
		{
			if (IndexObjectBaseValue.TryGetChild("m_AssetIndex", out AssetTypeValueField? assetIndex))
			{
				AssetTypeValueField? index = assetIndex["Array"].FirstOrDefault(x => x["second.m_PathID"].AsLong == asset.FileInfo.PathId);
				if (index != null)
				{
					destination["m_Name"].AsString = index["first"].AsString;
				}
			}
		}
		destination["m_Script"].AsByteArray = source["m_bytes.Array"].AsByteArray;
	}
}
