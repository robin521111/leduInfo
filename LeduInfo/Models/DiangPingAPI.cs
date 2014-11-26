using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace APIConnection
{
    class DianPingAPI
    {

        string appKey = "5843564855";
        string secret = "3e12a0903dcd476799f7d2ff6b1e74df";
        string value = "";
        string queryString = "";
        
       public enum Sort
	    {
            Default =1,
            Start = 2,
            P_CommentLevel=3,
            Environment=4,
            ServeiceLevel=5,
            QuantityOfComments=6,
            CloseToYou=7,
            Cheapest=8,
            MostExpensive=9
	    };
       public string searchParameter(string city, string region, string category, bool has_coupon, int sort, int limit)
       {
           Hashtable ht = new Hashtable();
           ht.Add("format", "json");
           ht.Add("city", city);
           ht.Add("region", region);
           ht.Add("category", category);
           ht.Add("has_coupon", has_coupon);
           ht.Add("sort", sort);
           ht.Add("limit", limit);


           ArrayList htkeys = new ArrayList(ht.Keys);
           htkeys.Sort();

           foreach (string key in htkeys)
           {
               value += key + ht[key].ToString();
               queryString += "&" + key + "=" + Utf8Encode(ht[key].ToString());
           }
           StringBuilder sb = new StringBuilder();
           sb.Append(appKey);
           sb.Append(value);
           sb.Append(secret);
           value = sb.ToString();

           string url = "http://api.dianping.com/v1/business/find_businesses?appkey=" + appKey + "&sign=" + SHA1(value) + queryString;
           int status = 0;
           return RequestUrl(url, out status);
            
       }




       private static string Utf8Encode(string value)
       {
           return HttpUtility.UrlEncode(value, System.Text.Encoding.UTF8);
       }

       private static string SHA1(string source)
       {
           byte[] value = Encoding.UTF8.GetBytes(source);
           SHA1 sha = new SHA1CryptoServiceProvider();
           byte[] result = sha.ComputeHash(value);

           string delimitedHexHash = BitConverter.ToString(result);
           string hexHash = delimitedHexHash.Replace("-", "");
           return hexHash;
       }
       public static string RequestUrl(string url, out int status)
       {
           string result = null;
           status = 0;
           HttpWebResponse response = null;
           try
           {
               HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
               response = (HttpWebResponse)request.GetResponse();
               Encoding responseEncoding = Encoding.GetEncoding(response.CharacterSet);
               using (StreamReader sr = new StreamReader(response.GetResponseStream(), responseEncoding))
               {
                   result = sr.ReadToEnd();
               }
               status = (int)response.StatusCode;
           }
           catch (WebException wexc1)
           {
               // any statusCode other than 200 gets caught here
               if (wexc1.Status == WebExceptionStatus.ProtocolError)
               {
                   // can also get the decription: 
                   //  ((HttpWebResponse)wexc1.Response).StatusDescription;
                   status = (int)((HttpWebResponse)wexc1.Response).StatusCode;
               }
           }
           finally
           {
               if (response != null)
                   response.Close();
           }
           return result;
       }

    }
}