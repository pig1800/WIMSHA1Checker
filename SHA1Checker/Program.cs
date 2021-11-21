using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SHA1Checker
{
    class Program
    {
        static void Main()
        {
            var files = new Dictionary<String, String>() {
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCHINA_RET_x64FRE_zh-cn.esd","5cc396c50e2edbe5371aed3a53e4e5039d788eb0"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCHINA_RET_x86FRE_zh-cn.esd","b95f1d18cad6c48faec1454d9061af0c9885ca77"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_zh-tw.esd","4e25af863d1cbd0201210a5c1314b4a5e47315da"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_ru-ru.esd","0acee703dd17e33b661714b5db3bf871f711e2ec"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_zh-cn.esd","d2ae9231e164579f582ca902a703de92cf9b8734"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_ru-ru.esd","432d2d70fb81a02812b2e1cd8c564e00d77ba749"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_ko-kr.esd","6a5f4da1d07589ff7ce1c8dcb8062be26d16a84f"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_zh-cn.esd","9a1106bb733b1ba44de4ca909a1f633b3da423ff"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_ja-jp.esd","bf5e2fa3b3163073259fdd5967e5bb268df0700e"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_zh-tw.esd","d3abf5244f0687dda01ade7706fc4ac704f10313"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_de-de.esd","7564fa22561d5d0bd9dcecda7f116d8b5036e438"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_de-de.esd","4a098053ebeced2d05e92bba7ab0b341f977b382"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_ja-jp.esd","77b6507beac5b56066cbe5e87d6ece1f0601e054"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_en-us.esd","48a08a1efe85475054072ffc492df3088eca67df"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_es-es.esd","4c2f2c7bc6a87defab72c9626a4d5cdfa63a903d"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_ko-kr.esd","beb6c0ffa10dd5905ed7c68eae316223b0f391c4"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_es-es.esd","be30b0582a467b2438e498d2df570428a1edb795"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_ja-jp.esd","d18ed2c93a7f02907688e03007842b207cdf3a8b"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_en-us.esd","0de2dc786533b6dd72e650df84877a2e222357bb"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_zh-cn.esd","8f5fd08b35c3a29a8410bf600d18cf712ee6924f"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_es-es.esd","9f6379bfe626771d598c824cbf143a77a7982ce6"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_ko-kr.esd","cd7ccf5248f8f1bfc106fc38a9637226f7e70abf"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_fr-fr.esd","3fe6371141eeae63b3149cb2b81731bd8e3c6d2d"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_ru-ru.esd","59c23b50bbde62519c5e044af735f5d7b07042b7"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_A64FRE_fr-fr.esd","ee7a2c8d13c9fee0a0076d14c8562049d733e6d1"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_fr-fr.esd","3add4be8612289d74bb83707fbdecc0d654659bd"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_en-us.esd","6b13ede353376e882976bb79d7cf84382f628166"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x86FRE_zh-tw.esd","c9d76e3593460489cb13427eb1f9cea0d1bab43a"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTCONSUMER_RET_x64FRE_de-de.esd","e52c49ccf22c56408aeba460943f7ff36afd49f8"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_ko-kr.esd","331cb5e2c2bfa02510763b86ee90c730ebe0e024"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_es-es.esd","65687252befd2e70fe3e915b09c235683c4c0922"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_ko-kr.esd","99b2bb46187c8f0d651a286c7074c6df22027357"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_es-es.esd","7aede2a5a6aa76ae39d09aafb1f01ecbc7dce695"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_fr-fr.esd","e84a3e9e8426d7eed91abd661a2aeb080104cb3a"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_zh-tw.esd","1d9abb207fc658a10fb73fba90f2bd75e09cbd38"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_en-us.esd","a656e57983d734cdcdabd49d7ac294c7fb0df2be"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_de-de.esd","52cdc9df784b744c91304f72070f59553ca5110b"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_en-us.esd","749d2c86ba412499b94964ac87b4f19b79adaee8"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_ru-ru.esd","5af65aa58d6d94110b3f1c4f53389fc83a5d146a"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_en-us.esd","560a2c8b074483f380b0e69dc07896892413f860"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_ja-jp.esd","15562792833c4adbba389e97c9af2a1003eb06ef"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_de-de.esd","947f3a3faaf07a50d9d139e69a59dbff401a8ede"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_fr-fr.esd","3dd2c8f7df9d9d42bcc62dbc23a6f9fcdee5c40e"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_de-de.esd","a23887ad0ea0a2e3104c303fe41e700c864855a4"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_zh-cn.esd","7f4be9d18ccbd9e431c87f6f753835b86cdbd0b4"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_zh-tw.esd","12eb5aa1e0155434d01c191027eebdac779740aa"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_ru-ru.esd","bacbfba1a233ec7897259bc24b45c6cc004007db"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_ko-kr.esd","4d3cdf3cc0d83fae2a40c92f6f3445e95b8b4730"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_fr-fr.esd","651234cc797bc7d0c75fadc1cd7e805f5b2b7a2a"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_ja-jp.esd","c292cdf936a696cb8cca1e57790000b160fffcc1"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_A64FRE_zh-cn.esd","0cf6581db182dbca1b607251626289654ddd34a0"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_ja-jp.esd","f94140fb61641e0773132b8c9e69bfbef553737d"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_ru-ru.esd","08fe437f2a83c13d0369824a2f8d0b9e6a1e0915"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x86FRE_zh-cn.esd","b51ee64d7923bd6ccb5d8cce9e038f64cd339ee6"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_es-es.esd","d5506eb5211e128161b75bfb0656e11cae7d1ce1"},
                {"19043.928.210409-1212.21h1_release_svc_refresh_CLIENTBUSINESS_VOL_x64FRE_zh-tw.esd","7a73fd0a46cb7803d5aa4cc193e98a6c764c44b2"}
            };
            Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = 10 }, entry => Procfile(entry.Key, entry.Value));

            Console.Write("Press any key to close.");
            Console.ReadKey();
        }

        static int Procfile(string filename, string targetHash)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var file = File.OpenRead(filename);
                var hash = sha1.ComputeHash(file);
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                if (!sb.ToString().Equals(targetHash))
                {
                    OutMessage(string.Format("{0} mismatch\ntarget:{1}\nactual:{2}", filename, targetHash, sb.ToString()));
                }
                else
                {
                    OutMessage(string.Format("{0} OK", filename));
                }
            }

            return 0;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        static void OutMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
