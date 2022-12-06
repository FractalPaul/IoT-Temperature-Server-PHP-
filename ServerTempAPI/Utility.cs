using ServerTemp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServerTempAPI
{
    public class Utility
    {
        public static String[] ReadFileContents()
        {
            String tempFile = Constants.CreateFileName();
            String[] lines = null;

            if (File.Exists(tempFile))
            {
                lines = File.ReadAllLines(tempFile);
            }

            return lines;
        }

        public static List<KeyValuePair<string, string>> ConvertToKeyValuePair(string[] keys, string[] vals)
        {
            List< KeyValuePair<String,String>> keyVals = new List<KeyValuePair<String, String>>();

            for (int i=0; i < keys.Length; i++) {
                keyVals.Add(new KeyValuePair<String, String>(keys[i], vals[i]));
            }

            return keyVals;
        }


        public static void PersistData(List< KeyValuePair<String, String>> keyVals)
        {
            if (Constants.IsNullKeys(keyVals))
            {
                String line = Constants.ExtractValsFrom(keyVals, new String[] { DateTime.UtcNow.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss") });
                
                String tempFileName = Constants.CreateFileName();

                if (File.Exists(tempFileName))
                {
                    line = String.Concat(line, Environment.NewLine);
                    File.AppendAllText(tempFileName, line);
                }
                else
                {
                    String header = Constants.ExtractKeysFrom(keyVals, new String[] { "DateTimeUTC" });

                    File.WriteAllText(tempFileName, String.Concat(header, Environment.NewLine, line));
                }
            }
        }
    }
}