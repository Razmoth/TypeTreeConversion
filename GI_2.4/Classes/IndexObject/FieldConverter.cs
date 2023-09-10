using AssetsTools.NET;
using AssetsTools.NET.Extra;

namespace TypeTreeConversion.IndexObject;

public class FieldConverter : DefaultFieldConverter
{
	public static readonly Dictionary<AssetFileInfo, AssetTypeValueField> InfoMap = new Dictionary<AssetFileInfo, AssetTypeValueField>();
	public FieldConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override AssetTypeValueField? CreateNewBaseField(int originalTypeID)
	{
		return base.CreateNewBaseField(142);
	}

	protected override void CopyFields(UnityAsset asset, AssetTypeValueField source, AssetTypeValueField destination)
	{
		if (!InfoMap.ContainsKey(asset.Info))
		{
			var baseValue = asset.Manager.GetBaseField(asset.File, asset.Info);
			InfoMap.Add(asset.Info, baseValue);
		}
		destination["m_Name"].AsString = "IndexObject";
		destination["m_AssetBundleName"].AsString = "IndexObject";
		if (source.TryGetChild("m_AssetIndex", out var assetIndex))
		{
			foreach(var index in assetIndex["Array"])
			{
				var containerData = ValueBuilder.DefaultValueFieldFromArrayTemplate(destination["m_Container.Array"]);

				containerData["first"].AsString = index["first"].AsString;

				containerData["second.preloadIndex"].AsInt = destination["m_PreloadTable.Array"].Children.Count;
				containerData["second.preloadSize"].AsInt = 1;
				CopyFieldsExactly(index["second"], containerData["second.asset"]);
				destination["m_Container.Array"].Children.Add(containerData);

				var preloadTabledata = ValueBuilder.DefaultValueFieldFromArrayTemplate(destination["m_PreloadTable.Array"]);
				CopyFieldsExactly(index["second"], preloadTabledata);
				destination["m_PreloadTable.Array"].Children.Add(preloadTabledata);
			}
		}
	}
}
