using FluentScheduler;
using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace CDesktopWallper.Frontend
{
    class SettingWebViewWS : WebSocketSharp.Server.WebSocketBehavior
    {
        private readonly ISetting setting;
        public SettingWebViewWS()
        {
            setting = Kernel.Resolve<ISetting>();
        }
        protected override void OnClose(CloseEventArgs e)
        {
            setting.Save();
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            var cmd = WsCommandProc.Parse(e.Data);
            switch (cmd.Command)
            {
                case "GET":
                    var settingCommand = JsonConvert.DeserializeObject<SettingCommand>(cmd.JsonData);
                    var field = typeof(SettingData).GetMember(settingCommand.Name).First();
                    var value = GetValue(field, setting.Data);

                    settingCommand.Value = value;
                    var returnCommand = new WsCommand()
                    {
                        Command = "SET",
                        JsonData = JsonConvert.SerializeObject(settingCommand)
                    };

                    Send(WsCommandProc.ToString(returnCommand));
                    break;
                case "SET":
                    settingCommand = JsonConvert.DeserializeObject<SettingCommand>(cmd.JsonData);
                    field = typeof(SettingData).GetMember(settingCommand.Name).First();
                    SetMemberValue(field, setting.Data, settingCommand.Value);

                    returnCommand = new WsCommand()
                    {
                        Command = "Status",
                        JsonData = "Success"
                    };

                    Send(WsCommandProc.ToString(returnCommand));
                    break;

                case "READ":
                    returnCommand = new WsCommand()
                    {
                         Command ="READ",
                         JsonData = JsonConvert.SerializeObject(setting.Data)
                    };
                    Send(WsCommandProc.ToString(returnCommand));
                    break;
                default:
                    break;
            }
        }

        public static void SetMemberValue(MemberInfo member, object target, object value)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    ((FieldInfo)member).SetValue(target, value);
                    break;
                case MemberTypes.Property:
                    ((PropertyInfo)member).SetValue(target, value, null);
                    break;
                default:
                    throw new ArgumentException("MemberInfo must be if type FieldInfo or PropertyInfo", "member");
            }
        }

        public object GetValue(MemberInfo memberInfo, object forObject)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(forObject);
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).GetValue(forObject);
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
