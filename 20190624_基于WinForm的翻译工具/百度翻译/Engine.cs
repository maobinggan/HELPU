using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace _20190624_基于WinForm的翻译工具.百度翻译
{
    /// <summary>
    /// 定义枚举保存一些常用语言
    /// </summary>
    public enum Language
    {
        //百度翻译API官网提供了多种语言，这里只列了几种
        auto = 0,
        zh = 1,
        en = 2,
        cht = 3,
    }


    class Engine
    {

        /// <summary>
        /// 因为百度翻译要求对发送数据中的一部分做md加密，所以对字符串做md5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMD5WithString(string input)
        {
            if (input == null) {
                return null;
            }
            MD5 md5Hash = MD5.Create();
            //将输入字符串转换为字节数组并计算哈希数据  
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            //创建一个 Stringbuilder 来收集字节并创建字符串  
            StringBuilder sBuilder = new StringBuilder();
            //循环遍历哈希数据的每一个字节并格式化为十六进制字符串  
            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append(data[i].ToString("x2"));
            }
            //返回十六进制字符串  
            return sBuilder.ToString();
        }

        /// <summary>
        /// 调用百度翻译API进行翻译
        /// 详情可参考http://api.fanyi.baidu.com/api/trans/product/apidoc
        /// </summary>
        /// <param name="q">待翻译字符</param>
        /// <param name="from">源语言</param>
        /// <param name="to">目标语言</param>
        /// <returns></returns>
        private static TranslationResult GetTranslationFromBaiduFanyi(string q, Language from, Language to)
        {
            //可以直接到百度翻译API的官网申请
            //一定要去申请，不然程序的翻译功能不能使用
            string appId = "20190624000309849";
            string password = "esgd2aNva_YJgCAZRs_h";

            string jsonResult = String.Empty;
            //源语言
            string languageFrom = from.ToString().ToLower();
            //目标语言
            string languageTo = to.ToString().ToLower();
            //随机数
            string randomNum = System.DateTime.Now.Millisecond.ToString();
            //md5加密
            string md5Sign = GetMD5WithString(appId + q + randomNum + password);
            //url
            string url = String.Format("http://api.fanyi.baidu.com/api/trans/vip/translate?q={0}&from={1}&to={2}&appid={3}&salt={4}&sign={5}",
                HttpUtility.UrlEncode(q, Encoding.UTF8),
                languageFrom,
                languageTo,
                appId,
                randomNum,
                md5Sign
                );
            WebClient wc = new WebClient();
            try {
                jsonResult = wc.DownloadString(url);
            }
            catch {
                jsonResult = string.Empty;
            }
            //解析json
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TranslationResult result = jss.Deserialize<TranslationResult>(jsonResult);
            return result;
        }

        /// <summary>
        /// 将中文翻译为英文
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string translation_Zh_En(string source)
        {
            TranslationResult result = GetTranslationFromBaiduFanyi(source, Language.zh, Language.en);
            //判断是否出错
            if (result.Error_code == null) {
                return result.Trans_result[0].Dst;
            }
            else {
                //检查appid和密钥是否正确
                return "翻译出错，错误码：" + result.Error_code + "，错误信息：" + result.Error_msg;
            }
        }

        /// <summary>
        /// 英译汉
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string translation_En_Ch(string source)
        {
            TranslationResult result = GetTranslationFromBaiduFanyi(source, Language.en, Language.zh);
            //判断是否出错
            if (result.Error_code == null) {
                return result.Trans_result[0].Dst;
            }
            else {
                //检查appid和密钥是否正确
                return "翻译出错，错误码：" + result.Error_code + "，错误信息：" + result.Error_msg;
            }
        }
    }
}
