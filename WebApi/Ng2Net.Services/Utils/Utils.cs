using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net;
using System.Web;
using System.Configuration;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Data.OleDb;
using System.Xml.Linq;

namespace Ng2Net.Services
{
    public class Utils
    {
        public static string DataTableToCsv(DataTable dt, bool includeColumnNames)
        {
            return DataTableToCsv(dt, includeColumnNames, "\"", ",", "\r\n");
        }

        public static string DataTableToCsv(DataTable dt, bool includeColumnNames, string itemQualifier, string itemSeparator, string rowSeparator)
        {
            string result = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (i == 0 && includeColumnNames)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        result += itemQualifier + dc.ColumnName + itemQualifier + itemSeparator;
                    }

                    result = result.Substring(0, result.Length - itemSeparator.Length) + rowSeparator;

                }

                foreach (DataColumn dc in dt.Columns)
                {
                    result += itemQualifier + Regex.Replace(itemQualifier.Length > 0 ? dr[dc.ColumnName].ToString().Replace(itemQualifier, itemQualifier + itemQualifier) : dr[dc.ColumnName].ToString(), "<.*?>", string.Empty).Replace("\n", " ") + itemQualifier + itemSeparator;
                }
                result = result.Substring(0, result.Length - itemSeparator.Length) + rowSeparator;
            }
            return result;
        }

        public static string GetFirstWords(string strInput, int wordCount)
        {
            string strOutput = "";
            string[] words = Regex.Replace(strInput, "<.*?>", string.Empty).Split();
            if (wordCount > 0)
                words = words.Take(wordCount).ToArray();
            words.ToList().ForEach(t => strOutput += " " + t);
            return strOutput;
        }


        public static string GetUniqueFileName(string path, string fileName)
        {
            if (!File.Exists(path + "\\" + fileName))
                return fileName;
            string name = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            int counter = 1;
            string currentFilename = "";
            do
            {
                currentFilename = name + "(" + counter + ")" + extension;
                counter++;
            }
            while (File.Exists(path + "\\" + currentFilename));
            return currentFilename;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }


        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }


        public static string DownloadHttpString(string url, int timeout)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Headers.Add("Accept-Encoding", "utf-8");
            webrequest.Timeout = timeout;
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Stream receiveStream = webresponse.GetResponseStream();


            Encoding enc = System.Text.Encoding.UTF8;//1252
            StreamReader loResponseStream = new
              StreamReader(receiveStream, enc);

            string Response = loResponseStream.ReadToEnd();

            loResponseStream.Close();
            webresponse.Close();

            return Response;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }

  
        public static string ProcessReplacements(string s, Dictionary<string, string> replacements)
        {
            if (s == null)
                return null;
            if (replacements != null)
            {
                if (!replacements.ContainsKey("ROOT_URL"))
                    replacements.Add("ROOT_URL", "");

                foreach (string key in replacements.Keys)
                {
                    s = s.Replace("{{" + key + "}}", replacements[key]);
                }
            }
            return s;
        }

    }
}
