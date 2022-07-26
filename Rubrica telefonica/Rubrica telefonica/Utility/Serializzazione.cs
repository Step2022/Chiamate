﻿using Newtonsoft.Json;

namespace Rubrica_telefonica.Utility
{
    public class Serializzazione
    {


        public static string Serialize<T>(T value)
        {
            try
            {
                if (EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    return string.Empty;
                }


                return JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented,
                   new JsonSerializerSettings
                   { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });


            }
            catch (Exception ex)
            {
                //TODO
                //Check scrittura LOG
                var innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = ex.InnerException.Message;



                return string.Empty;
            }
        }


        public static T DeSerialize<T>(string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                {
                    return default(T);
                }


                return JsonConvert.DeserializeObject<T>(json);



            }
            catch (Exception ex)
            {
                return default(T);

            }


        }
    }
}
