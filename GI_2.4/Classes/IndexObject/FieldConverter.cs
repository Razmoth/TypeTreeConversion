using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System.Linq.Expressions;

namespace TypeTreeConversion.IndexObject;

public class FieldConverter : DefaultFieldConverter
{
	public FieldConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override AssetTypeValueField? CreateNewBaseField(int originalTypeID)
	{
		return base.CreateNewBaseField(142);
	}

	protected override void CopyFields(UnityAsset asset, AssetTypeValueField source, AssetTypeValueField destination)
	{
		//CopyFieldsExactly(source, destination);
		destination["m_Name"].AsString = "IndexObject";
		destination["m_AssetBundleName"].AsString = "IndexObject";
		if (source.TryGetChild("m_AssetIndex", out var assetIndex))
		{
			foreach(var index in assetIndex["Array"])
			{
				var assetInfo = ValueBuilder.DefaultValueFieldFromTemplate(destination["m_Container.Array"].TemplateField.Children[1].Children[1]);

				assetInfo["preloadIndex"].AsInt = destination["m_PreloadTable.Array"].Children.Count;

				var data = ValueBuilder.DefaultValueFieldFromArrayTemplate(destination["m_PreloadTable.Array"]);
				CopyFieldsExactly(index["second"], data);
				destination["m_PreloadTable.Array"].Children.Add(data);

				assetInfo["preloadSize"].AsInt = destination["m_PreloadTable.Array"].Children.Count;

				CopyFieldsExactly(index["second"], assetInfo["asset"]);
				destination["m_Container.Array"].Children.Add(assetInfo);
			}
		}
	}
}
