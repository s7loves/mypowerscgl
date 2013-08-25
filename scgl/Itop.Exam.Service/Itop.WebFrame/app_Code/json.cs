/**********************************************
系统:教学信息管理系统
模块: JSON数据处理
功能：JSON格式和dataTable之间的字符形式转换处理
作者:于冬
创建时间:2012-8-24
最后一次修改:2012-8-24
***********************************************/

using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace XD
{
    public class jsonDb
    {
        /// <summary>
        /// 把dataTable对像转换成JSON字串
        /// </summary>
        /// <returns></returns>
        public static string dataTableToJson(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartArray();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonWriter.WriteStartObject();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        jsonWriter.WritePropertyName(dc.ColumnName);
                        jsonWriter.WriteValue(dt.Rows[i][dc.ColumnName]);
                    }
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
            }
            return Convert.ToString(sb);
        }

        /// <summary>
        /// 数据集(DataSet)转DataJSON  一般用于显示查询结果。
        /// </summary>
        public static String dataTableToDataJson(DataTable dt,int pCount)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartArray();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    jsonWriter.WriteStartObject();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        jsonWriter.WritePropertyName(dc.ColumnName);
                        jsonWriter.WriteValue(dt.Rows[i][dc.ColumnName]);
                    }
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();

            }
            string hand = "{\"totalProperty\": " + pCount.ToString() + " , \"root\": ";
            return Convert.ToString(hand + sb + "}");
        }

        /// <summary>
        /// 返回一个代表正确完成的字符串
        /// </summary>
        /// <returns></returns>
        public static string result_OK()
        {
            return "{success:true,msg:'ok',code:100}";
        }
        /// <summary>
        /// 返回一个代表正确完成的字符串
        /// </summary>
        /// <returns></returns>
        public static string result_OK(System.Collections.Hashtable valueTable)
        {
            string result = "";
            string jsonTemplete = "{name}:'{value}'";
            foreach(System.Collections.DictionaryEntry de in valueTable)
            {
                result += "," + jsonTemplete.Replace("{name}", de.Key.ToString()).Replace("{value}", de.Value.ToString());
            }

            return "{success:true,msg:'ok',code:100"+result+"}";
        }
        /// <summary>
        /// 返回一个代表发生错误的消息字符串
        /// </summary>
        /// <returns></returns>
        public static string result_ERROR(string msg, int code)
        {
            return "{success:true,msg:'" + msg.Replace("'", "") + "',code:" + code.ToString() + "}";
        }
    }
}