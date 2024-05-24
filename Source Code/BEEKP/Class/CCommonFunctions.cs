using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Text.RegularExpressions;

namespace BEEKP.Class
{
    public class CCommonFunctions
    {
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable JsonStringToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsName.Add(ColumnsNameString);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[RowColumns] = RowDataString;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
        }



        ////Get DATE from database(datatable) and convert to System DATE Format - Used in GET Function
        //public String GetSystemDateToDisplayFormat(String date)
        //{
        //    String _ShortDateTime = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
        //    String _Date = DateTime.ParseExact(date, _ShortDateTime, CultureInfo.InvariantCulture).ToString(GetDisplayDateFormat(), CultureInfo.InvariantCulture);
        //    return _Date;
        //}

        //// Get DATE TIME from database(datatable) and convert to System DATE TIME  Format - Used in GET Function
        //public String GetSystemDateTimeToDisplayFormat(String date)
        //{
        //    String _ShortDateTime = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
        //    String _Date = DateTime.ParseExact(date, _ShortDateTime, CultureInfo.InvariantCulture).ToString(GetDisplayDateTimeFormat(), CultureInfo.InvariantCulture);
        //    return _Date;
        //}

        ////Convert Display DATE To Database Format - used in SAVE Function
        //public String ConvertDisplayDateToDatabaseFormat(String date)
        //{
        //    String _Date = DateTime.ParseExact(date, GetDisplayDateFormat(), CultureInfo.InvariantCulture).ToString(GetDatabaseFormat(), CultureInfo.InvariantCulture);
        //    return _Date;
        //}

        ////Convert Display DATE TIME To Database Format - used in SAVE Function
        //public String ConvertDisplayDateTimeToDatabaseFormat(String datetime)
        //{
        //    String _DateTime = DateTime.ParseExact(datetime, GetDisplayDateTimeFormat(), CultureInfo.InvariantCulture).ToString(GetDatabaseDateTimeFormat(), CultureInfo.InvariantCulture);
        //    return _DateTime;
        //}
        //public String GetDisplayDateFormat()
        //{
        //    String _ShortDatePattern = "dd/MM/yyyy";
        //    return _ShortDatePattern;
        //}
        //public String GetDisplayDateTimeFormat()
        //{
        //    String _ShortDatePattern = "dd/MM/yyyy HH:mm";
        //    return _ShortDatePattern;
        //}
        //public String GetDatabaseFormat()
        //{
        //    String _ShortDatePattern = "MM/dd/yyyy";
        //    return _ShortDatePattern;
        //}

        //public String GetDatabaseDateTimeFormat()
        //{
        //    String _ShortDatePattern = "MM/dd/yyyy HH:mm";
        //    return _ShortDatePattern;
        //}

        //Get DATE from database(datatable) and convert to System DATE Format - Used in GET Function
        public static String GetSystemDateToDisplayFormat(String date)
        {
            String _ShortDateTime = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
            String _Date = DateTime.ParseExact(date, _ShortDateTime, CultureInfo.InvariantCulture).ToString(GetDisplayDateFormat(), CultureInfo.InvariantCulture);
            return _Date;
        }

        // Get DATE TIME from database(datatable) and convert to System DATE TIME  Format - Used in GET Function
        public static String GetSystemDateTimeToDisplayFormat(String date)
        {
            String _ShortDateTime = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
            String _Date = DateTime.ParseExact(date, _ShortDateTime, CultureInfo.InvariantCulture).ToString(GetDisplayDateTimeFormat(), CultureInfo.InvariantCulture);
            return _Date;
        }

        //Convert Display DATE To Database Format - used in SAVE Function
        public static String ConvertDisplayDateToDatabaseFormat(String date)
        {
            String _Date = DateTime.ParseExact(date, GetDisplayDateFormat(), CultureInfo.InvariantCulture).ToString(GetDatabaseFormat(), CultureInfo.InvariantCulture);
            return _Date;
        }

        //Convert Display DATE TIME To Database Format - used in SAVE Function
        public static String ConvertDisplayDateTimeToDatabaseFormat(String datetime)
        {
            String _DateTime = DateTime.ParseExact(datetime, GetDisplayDateTimeFormat(), CultureInfo.InvariantCulture).ToString(GetDatabaseDateTimeFormat(), CultureInfo.InvariantCulture);
            return _DateTime;
        }
        public static String GetDisplayDateFormat()
        {
            String _ShortDatePattern = "dd/MM/yyyy";
            return _ShortDatePattern;
        }
        public static String GetDisplayDateTimeFormat()
        {
            String _ShortDatePattern = "dd/MM/yyyy HH:mm";
            return _ShortDatePattern;
        }
        public static String GetDatabaseFormat()
        {
            String _ShortDatePattern = "MM/dd/yyyy";
            return _ShortDatePattern;
        }

        public static String GetDatabaseDateTimeFormat()
        {
            String _ShortDatePattern = "MM/dd/yyyy HH:mm";
            return _ShortDatePattern;
        }

        public static String GeSystemDateFormat()
        {
            String _ShortDatePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            return _ShortDatePattern;
        }
        public static String GeSystemDateTimeFormat()
        {
            String _LongDateTimePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
            return _LongDateTimePattern;
        }
    }



    public class OutputMessage
    {
        public Int32 MessageId { get; set; }
        public String Message { get; set; }
    }

    public class ErrorMessage
    {
        public String ErrorId { get; set; }
        public String ErrorMessages { get; set; }
        public String ErrorType { get; set; }
    }

}