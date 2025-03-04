﻿namespace TypeTreeConversion;

public class Plugin : ConversionPlugin
{
	public Plugin()
	{
		Program.RegisterFieldConverters += RegisterFieldConverters;
		Program.RegisterTypeTreeReplacers += RegisterTypeTreeReplacers;
	}

	private static void RegisterFieldConverters(FieldConverterRegistry registry)
	{
		IndexObject.FieldConverter indexObjectConverter = new IndexObject.FieldConverter(registry.ClassDatabase);
		registry.Converters.Add(ClassIDType.IndexObject, indexObjectConverter);
		registry.Converters.Add(ClassIDType.MiHoYoBinData, new MiHoYoBinData.FieldConverter(registry.ClassDatabase, indexObjectConverter));
		registry.Converters.Add(ClassIDType.MiHoYoGrassBlock, new MiHoYoGrassBlock.FieldConverter(registry.ClassDatabase));
		registry.Converters.Add(ClassIDType.MiHoYoGrassData, new MiHoYoGrassData.FieldConverter(registry.ClassDatabase));
		registry.Converters.Add(ClassIDType.MiHoYoGrassLand, new MiHoYoGrassLand.FieldConverter(registry.ClassDatabase));
		registry.Converters.Add(ClassIDType.NavMeshHeightFieldData, new NavMeshHeightFieldData.FieldConverter(registry.ClassDatabase));
	}

	private static void RegisterTypeTreeReplacers(TypeTreeReplacerRegistry registry)
	{
		registry.Replacers.Add(ClassIDType.MiHoYoBinData, new MiHoYoBinData.TypeTreeReplacer(registry.ClassDatabase));
		registry.Replacers.Add(ClassIDType.IndexObject, new IndexObject.TypeTreeReplacer(registry.ClassDatabase));
		registry.Replacers.Add(ClassIDType.MiHoYoGrassBlock, new MiHoYoGrassBlock.TypeTreeReplacer(registry.ClassDatabase));
		registry.Replacers.Add(ClassIDType.MiHoYoGrassData, new MiHoYoGrassData.TypeTreeReplacer(registry.ClassDatabase));
		registry.Replacers.Add(ClassIDType.MiHoYoGrassLand, new MiHoYoGrassLand.TypeTreeReplacer(registry.ClassDatabase));
		registry.Replacers.Add(ClassIDType.NavMeshHeightFieldData, new NavMeshHeightFieldData.TypeTreeReplacer(registry.ClassDatabase));
	}
}
