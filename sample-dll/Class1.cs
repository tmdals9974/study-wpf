using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sample_dll.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace sample_dll
{
    public class Class1
    {

        /// <summary>
        /// login method
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>
        /// 0 : 성공
        /// -1 : 실패
        /// 기타 : 에러
        /// </returns>
        public static JObject Login(string email, string password)
        {
            JObject jobj = new JObject();
            jobj.Add("userId", email);
            jobj.Add("password", Common.Encrypt(password, key));
            string result = Post(uri + "login", jobj);
            try
            {
                return JObject.Parse(result);
            }
            catch
            {
                return JObject.Parse("{ \"error\" : \"" + result + "\" }");
            }
        }

        /// <summary>
        /// post method
        /// </summary>
        /// <param name="uri">http url</param>
        /// <param name="pairs">body params</param>
        /// <returns></returns>
        private static string Post(string uri, JObject jobj)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream())) //전송
            {
                streamWriter.Write(jobj.ToString(Newtonsoft.Json.Formatting.None));
            }

            var response = (HttpWebResponse)request.GetResponse(); //응답
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                try
                {
                    return streamReader.ReadToEnd();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR [ {0} ] => {1}", uri, ex.Message);
                    return ex.Message;
                }
            }
        }
    }
}
