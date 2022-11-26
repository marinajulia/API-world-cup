﻿using System;
using System.ComponentModel;

namespace WorldCup.SharedKernel.Helper
{
    public static class Helper
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length == 0 ? value.ToString() : (attr[0] as DescriptionAttribute).Description;

        }
    }
}
