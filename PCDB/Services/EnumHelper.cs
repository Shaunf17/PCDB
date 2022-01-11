using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PCDB.Services
{
    public static class EnumExtensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum obj)
            where TEnum : struct, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.GetDescription(),
                        Value = (Convert.ToInt32(x)).ToString()
                    }), "Value", "Text");
        }

        public static string GetDescription<TEnum>(this TEnum value)
        {
            var description = value.ToString();
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }
    }
}