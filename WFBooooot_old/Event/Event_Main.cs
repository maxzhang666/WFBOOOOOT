using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.Utilities;
using WFBooooot.Extention;
using WFBooooot.Interface;

namespace WFBooooot.Event
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
        public Event_Main(IUnityContainer unityContainer)
        {
            Log.Info("ע����Ӧ�¼�");
            //ע��Ⱥ��Ϣ�¼�
            unityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_CHP>("Ⱥ��Ϣ-�ʺ�ƨ");
            unityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_ProWord>("Ⱥ��Ϣ-�ڻ�");
            unityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_WIKI>("Ⱥ��Ϣ-WIki");
        }
    }
}