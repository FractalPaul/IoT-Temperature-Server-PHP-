using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTemp
{
    public class Constants
    {
        public static String _tempFileName = "ServerTempData.csv";

        public static String CreateFileName()
        {
            return String.Concat(GetPublicDirectory(), "\\", _tempFileName);
        }

        public static String ExtractKeysFrom(List<KeyValuePair<String, String>> keyVals, String[] preCols)
        {
            List<String> kSet = new List<string>();

            if (preCols != null && preCols.Length > 0)
            {
                for (int i = 0; i < preCols.Length; i++)
                {
                    kSet.Add(preCols[i]);
                }
            }
            foreach (KeyValuePair<String, String> eachKey in keyVals)
            {
                kSet.Add(eachKey.Key);
            }

            return String.Join(",", kSet);
        }

        public static String ExtractValsFrom(List<KeyValuePair<String, String>> keyVals, String[] preCols)
        {
            List<String> kSet = new List<string>();

            if (preCols != null && preCols.Length > 0)
            {
                for (int i = 0; i < preCols.Length; i++)
                {
                    kSet.Add(preCols[i]);
                }
            }
            foreach (KeyValuePair<String, String> eachKey in keyVals)
            {
                kSet.Add(eachKey.Value);
            }

            return String.Join(",", kSet);
        }

        public static String GetPublicDirectory()
        {
            IDictionary envVars = Environment.GetEnvironmentVariables();
            return envVars["PUBLIC"].ToString();
        }

        internal static bool IsNullKeys(List<KeyValuePair<string, string>> keyVals)
        {
            for (int i = 0; i < keyVals.Count; i++)
            {
                if (keyVals[i].Key == null)
                    return false;
            }

            return true;
        }
    }
}