using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;


namespace UnityForms
{

    internal class ListItemConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
		{
			if (destType == typeof(InstanceDescriptor))
				return true;

			return base.CanConvertTo(context, destType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(InstanceDescriptor))
			{
				System.Reflection.ConstructorInfo ci = typeof(ListItem).GetConstructor(System.Type.EmptyTypes);

				return new InstanceDescriptor(ci, null, false);
			}

			return base.ConvertTo(context, culture, value, destType);
		}
	}

	
}
