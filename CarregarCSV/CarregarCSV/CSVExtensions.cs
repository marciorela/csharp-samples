using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CSVExtensions
{
    static class CSVExtensions
    {
        public static T FromCSV<T>(this string csv) where T : new()
        {
            //csv = ConverterStringAcentuada(850, csv);

            var result = new T();
            var values = Regex.Split(csv, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            Type type = result.GetType();
            var props = type.GetProperties();
            for (var i = 0; i < values.Length; i++)
            {
                props[i].SetValue(result, values[i].Replace("\"", ""));
            }

            return result;

        }

        // CodePage - 850
        public static string ConverterStringAcentuada(int codepage, string texto)
        {
            return System.Text.Encoding.ASCII.GetString(System.Text.Encoding.GetEncoding(codepage).GetBytes(texto));
        }

        public static T FromPositional<T>(this string csv) where T : new()
        {
            var result = new T();

            var type = result.GetType();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<PositionalAttribute>();
                if (attr != null)
                {
                    prop.SetValue(result, csv.Substring(attr.Start-1, attr.Length));
                }
            }

            return result;
        }

    }

    public sealed class PositionalAttribute : Attribute
    {
        public readonly int Start;
        public readonly int Length;

        public PositionalAttribute(int start, int length)
        {
            this.Start = start;
            this.Length = length;
        }
    }
}
