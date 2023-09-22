using LibAC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TP.CS.EventsBus;

namespace PassTool.GUI
{
    public class ApplicationActivation
    {
        struct LicKeyCheck
        {
            public string key;
        }

        struct LicKeyCheckReply
        {
            public int found;
        }
        /// <summary>
        /// This method is called to validate activation. It will be cancelled if server rejects activation
        /// </summary>
        /// <param name="ev"></param>
        [Subscribe(Priority.Severe)]
        public static void onActivation(ActivationEvent ev)
        {
            HTTPReplyData HRD = HTTP.performRequest("https://api.zontreck.dev/zni/LicCheck.php", JsonConvert.SerializeObject(new LicKeyCheck()
            {
                key = ev.license.ToString()
            }));

            LicKeyCheckReply response = JsonConvert.DeserializeObject<LicKeyCheckReply>(HRD.MessageAsString);

            ev.setCancelled((response.found == 0));


        }


        [Subscribe(Priority.Medium)]
        public static void onFinalActivation(ActivationEvent ev)
        {
            if (ev.isCancelled) return;

            GUISettings.Instance.codec.Activated.setBool(true);
            GUISettings.Instance.codec.ActivatedTo.setWord(ev.license.Name);
            GUISettings.Instance.codec.ActivatedKeyType.setByte((byte)ev.license.TypeOfKey);

            
        }
    }
}
