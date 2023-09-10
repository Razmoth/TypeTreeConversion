namespace TypeTreeConversion;

public class Plugin : ConversionPlugin
{
	public Plugin()
	{
		Program.RegisterFieldConverters += RegisterFieldConverters;
		Program.RegisterTypeTreeReplacers += RegisterTypeTreeReplacers;
	}

	private static void RegisterFieldConverters(FieldConverterRegistry registry)
	{
		registry.Converters.Clear();
		registry.Converters.Add(ClassIDType.MiHoYoBinData, new MiHoYoBinData.FieldConverter(registry.ClassDatabase));
		registry.Converters.Add(ClassIDType.IndexObject, new IndexObject.FieldConverter(registry.ClassDatabase));
		registry.Converters.Add(ClassIDType.MiHoYoGrassBlock, new MiHoYoGrassBlock.FieldConverter(registry.ClassDatabase));
		registry.Converters.Add(ClassIDType.MiHoYoGrassData, new MiHoYoGrassData.FieldConverter(registry.ClassDatabase));
		registry.DefaultConverter = new DefaultFieldConverter(registry.ClassDatabase);
	}

	private static void RegisterTypeTreeReplacers(TypeTreeReplacerRegistry registry)
	{
		registry.Replacers.Clear();
		registry.Replacers.Add(ClassIDType.MiHoYoBinData, new MiHoYoBinData.TypeTreeConverter(registry.ClassDatabase));
		registry.Replacers.Add(ClassIDType.IndexObject, new IndexObject.TypeTreeConverter(registry.ClassDatabase));
		registry.Replacers.Add(ClassIDType.MiHoYoGrassBlock, new MiHoYoGrassBlock.TypeTreeConverter(registry.ClassDatabase));
		registry.Replacers.Add(ClassIDType.MiHoYoGrassData, new MiHoYoGrassData.TypeTreeConverter(registry.ClassDatabase));
		registry.DefaultReplacer = new DefaultTypeTreeReplacer(registry.ClassDatabase);
	}
}
