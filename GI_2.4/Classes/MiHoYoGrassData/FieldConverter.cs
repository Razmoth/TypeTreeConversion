using AssetsTools.NET;
using AssetsTools.NET.Extra;

namespace TypeTreeConversion.MiHoYoGrassData;

public class FieldConverter : DefaultFieldConverter
{
	public FieldConverter(ClassDatabaseFile classDatabase) : base(classDatabase)
	{
	}

	protected override AssetTypeValueField? CreateNewBaseField(int originalTypeID)
	{
		return base.CreateNewBaseField(156);
	}

	protected override void CopyFields(UnityAsset asset, AssetTypeValueField source, AssetTypeValueField destination)
	{
		CopyFieldsExactly(source, destination);
		int offsetX = source["m_OffsetX"].AsInt;
		int offsetY = source["m_OffsetY"].AsInt;
		float scale = source["m_HeightMapScale"].AsFloat;
		int width = source["m_HeightMapWidth"].AsInt;
		int height = source["m_HeightMapHeight"].AsInt;
		float[] heightData = GetFloatArray(source["m_HeightMapData"]);

		AssetTypeValueField heightmapField = destination["m_Heightmap"];
		heightmapField["m_Width"].AsInt = width;
		heightmapField["m_Height"].AsInt = height;
		SetInt16Array(heightmapField["m_Heights"], ConvertToInt16Array(heightData));
		heightmapField["m_Scale"]["x"].AsFloat = 1;
		heightmapField["m_Scale"]["y"].AsFloat = 1;
		heightmapField["m_Scale"]["z"].AsFloat = 1;
	}
	private static float[] GetFloatArray(AssetTypeValueField field)
	{
		AssetTypeValueField arrayField = field["Array"];
		int count = arrayField.AsArray.size;
		float[] result = new float[count];
		for (int i = 0; i < count; i++)
		{
			result[i] = arrayField[i].AsFloat;
		}
		return result;
	}

	private static void SetInt16Array(AssetTypeValueField field, short[] array)
	{
		AssetTypeValueField arrayField = field["Array"];
		arrayField.AsArray = new() { size = array.Length };
		for (int i = 0; i < array.Length; i++)
		{
			AssetTypeValueField element = ValueBuilder.DefaultValueFieldFromArrayTemplate(arrayField.TemplateField);
			arrayField.Children.Add(element);
			element.AsShort = array[i];
		}
	}

	private static short[] ConvertToInt16Array(float[] array)
	{
		GetBounds(array, out float minimum, out float maximum);
		short[] result = new short[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ushort unsignedValue = (ushort)(ushort.MaxValue * (array[i] - minimum) / (maximum - minimum));
			result[i] = (short)(unsignedValue + short.MinValue);
		}
		return result;
	}

	private static void GetBounds(float[] array, out float minimum, out float maximum)
	{
		minimum = float.MaxValue;
		maximum = float.MinValue;
		foreach (float value in array)
		{
			if (value < minimum)
			{
				minimum = value;
			}
			if (value > maximum)
			{
				maximum = value;
			}
		}
	}
}
