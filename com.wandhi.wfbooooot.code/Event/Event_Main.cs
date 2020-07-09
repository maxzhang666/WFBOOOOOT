using com.wandhi.wfbooooot.code.Extention;
using com.wandhi.wfbooooot.code.Interface;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.Utilities;

namespace com.wandhi.wfbooooot.code.Event
{
    /// <summary>
    /// �¼��ַ���
    /// ���ڿ���Դ���IOC�ַ���������һ���¼�
    /// ���������װһ���ַ�����ʹ��Ӧ���¼��ַ���ע���ÿ����Ӧ����
    /// </summary>
    public class Event_Main : IGroupMessage
    {
        /// <summary>
        /// Ⱥ��Ϣ�¼��ַ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            AppData.UnityContainer.ResolveAll<IWFGroupMessage>().ForEach(a =>
            {
                Task.Factory.StartNew(() =>
                {
                    a.GroupMessage(sender, e);
                });
            });
        }

        /// <summary>
        /// ע����Ӧ�¼�
        /// </summary>
        public Event_Main()
        {
            Log.Info("ע����Ӧ�¼�");
            //ע��Ⱥ��Ϣ�¼�
            AppData.UnityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_CHP>("Ⱥ��Ϣ-�ʺ�ƨ");
            AppData.UnityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_ProWord>("Ⱥ��Ϣ-�ڻ�");
            AppData.UnityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_WIKI>("Ⱥ��Ϣ-WIki");
        }
    }
}