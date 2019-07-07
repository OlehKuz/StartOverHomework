using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace EfCoreSample.Infrastructure.Extensions
{
    public static class EnumExtention
    {
        public static string ToDescriptionString<TEnum>(this TEnum em)
        {
            FieldInfo info = em.GetType().GetField(em.ToString());
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?[0].Description ?? em.ToString();
        }
    }
}
