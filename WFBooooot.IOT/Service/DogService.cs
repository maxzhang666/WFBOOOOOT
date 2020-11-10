using System;
using System.Collections.Generic;

namespace WFBooooot.IOT.Service
{
    public class DogService : BaseService, IBaseService
    {
        public override string GetMsg()
        {
            var msg = string.Empty;
            if (AppData.AppConfig.DebugGroup.Contains(GroupId.ToString()))
            {
                msg = Words[new Random().Next(0, Words.Count)];
            }

            return msg;
        }

        public override string GetMsg(string KeyWord)
        {
            return GetMsg();
        }

        private readonly List<string> Words = new List<string>
        {
            "今天，你把我删了，说玩玩我罢了，还说了，对不起把我删了，你人真好，犯了错还会和我道歉啊，我真的是越来越喜欢你了。",
            "你说憧憬过以后的生活，可你也没有说，憧憬过离开我的生活。",
            "今天天气很暖和，想偷你的心却还是没有成功。在床上的我现在的心情就像天气预报，说明天有雨，我都听成明天有你。",
            "今天发工资了给女神转了3000，她一直以为我一一个月织挣三千，其实不是的，我捡垃圾一个月挣一万八，给她转三千，剩下一万五给女神雇了五个舔狗，我只是害怕她只有我一个人舔会不开。",
            "今天我的女神终于跟我提“亲嘴”这两个字啦，她让我给她去买点亲嘴烧送过去，她老公想吃。",
            "听网上说今天的月亮最大最亮，我说我想和你一起看月亮，你却回我你看你妈，我听你的话看了我妈一晚上。",
            "今天我又想你了宝宝。但是没有你的联系方式。我只能用我的第10086个QQ小号添加你。和我的第12345个微信加你。还有通过以前我在你家修马桶时偷偷安装的摄像头注视你。",
            "昨天你把我删了 我看着红色感叹号陷入了久久的沉思 我想这其中一定有什么含义 红色红色 我明白了 红色代表热情 你对我很热情 你想和我结婚 我愿意",
            "说不想你是假的，说爱你是真的，昨天他们骂我是你的舔狗，我不相信，因为我知道你肯定也是爱我的，你一定是在考验我对你的感情，只要我坚持下去你一定会被我的真诚所打动，昨晚你说去酒店跟人斗地主，我寻思两个人也玩不了呀，算了不想了，毕竟打牌是赌博行为，不太好。嘿嘿嘿",
            "你跟他已经醒了吧？我今天捡垃圾挣了一百多 明天给你打过去 你快点休息吧 我明天叫你起床 给你点外卖买烤韭菜 给你点你最喜欢的抹茶星冰乐 晚上我会继续去摆地摊的 你不用担心我烦你 床只有那么大 睡不下三个 你要好好照顾好自己不要让他抢你被子 我永远爱你",
            "你跟她已经醒了吧？我今天捡垃圾挣了一百多 明天给你打过去 你快点休息吧 我明天叫你起床 给你点外卖买烟 给你点你最喜欢的奶茶 晚上我会继续去摆地摊的 你不用担心我烦你 床只有那么大 睡不下三个 你要好好照顾好自己不要让她抢你被子 我永远爱你",
            "我身体很好抗得了米袋子 抗得了煤气罐 却扛不住想你",
            "听说你朋友说今天出门了，我打扮成精神小伙来找你，没想到你竟然对我说“给我爬，别过来”我当场就哭了，原来真心真的会感动人，你一定是知道，穿豆豆鞋走路脚会很累，让我爬是因为这样不会累着脚，其实你是喜欢我的吧",
            "我不知道怎么跟你相处 你有游戏要打 有小说要看 有觉要睡 朋友喊了还要去 而我的生活只有想你想你想你 我怎么配得上跟你谈恋爱呢 我只是一个得不到爱情的小笨蛋罢了",
            "今天在微博发现了好好笑的事情，想分享给你，可是当我发给你的时候迎接我的只有一个大大的红色感叹号，对啊，今天是你把我删了的第九十六天呀。真的太真实了吧，我翻看了一下我们的聊天记录，喜欢和爱你都没有给我说过，我知道我不好看还有斑但是我真的喜欢你啊，太心酸了。",
            "我存了半年的钱，给你买了一辆摩托，你对我说了一句谢谢，我好开心。这是你第一次对我说两个字，以前你都只对我说滚。今天晚上逛闲鱼，看到你把我送你的摩托发布上去了。我想，你一定是在考验我，于是我用借贝里的钱把它买了下来，再次送给你，给你一个惊喜，我爱你",
            "今天我观战了一天你带别人打游戏，你们玩的很开心，我给你发了200多条消息，你说你没流量了就不回了，晚上你发了条说说没有人爱你，我连滚带爬评论了句有我在。你把我拉黑了，我给你打电话也无人接听。对不起我不该打扰到你的。我求求你再给我一次当你好友的机会吧！",
            "天气很暖和 但是风有点大 在小区绿化区搬砖的时候眼睛不小心进了沙子 我委屈 我想你 想让你给我呼呼",
            "昨晚你终于回我信息了，你回了一句谢谢还加了一个爱心。当时我在工地上激动的差点把隔壁的吊塔阿姨给亲了。不过我想了想你笑起来的样子我还是忍住了。你给我发爱心，一定是已经爱上我了吧，放心，我连咱们的孩子名字都想好了。XX等我，我一定会继续努力挣钱，给你买更多的化妆品，发更多的红包！！",
            "在我不懈努力下，你终于回了我三个字 “你滚啊”之后出现了红色的感叹号。我知道农村网络不好消息发不出去了，但是我还是坚持每天一个99+。我不觉得卑微，反而很开心。虽然你每次都会叫我滚开，但是我知道你是在欲擒故纵。",
            "昨天你把我删了，我陷入了久久的沉思。我想这其中一定有什么含义，原来你是在欲擒故纵，嫌我不够爱你。无理取闹的你变得更加可爱了。我会坚守我对你的爱的，你放心好啦！么么哒！今天发工资了 发了1839，给你微信转了520 ，支付宝1314 ，还剩下5。 给你发了很多消息你没回，剩下5块我在小卖部买了你爱吃的老坛酸菜牛肉面，给你寄过去了。希望你保护好食欲，我去上班了，爱你～",
            "你昨天晚上回我一个晚安我却看见你的游戏在线 在我再一次孜孜不倦的骚扰你的情况下 你终于跟我说了一句最长的话“晚安”我又陷入了沉思这一定有什么含义 我想了很久 你竟然提到了睡觉 是不是终于熬出了头 能听到你每天得最后的情话",
            "你昨天晚上又没回我的消息 在我孜孜不倦地骚扰下你终于舍得回我了 你说“滚” 这其中一定有什么含义 我想了很久 滚是三点水这代表你对我的思念也如滚滚流水一样汹涌 我感动哭了 不知道你现在在干嘛 我很想你",
            "今天你把我的微信删了，这下我终于解放了！以前我总担心太多消息会打扰你，现在我终于不用顾忌，不管我怎么给你发消息，都不会让你不开心了。等我攒够5201314条我就给你看，你一定会震惊得说不出话然后哭着说会爱我一辈子。哈哈。",
            "今早睡觉前一直幻想起床后能收到你的“早安”，醒后打开手机，聊天框一片空白，我按耐不住想你的心情，激动的打出一个“早”。你说我昼伏夜出，是猪。oh 猪是多么可爱的生物啊~你一定是在夸我吧。我愿意！我愿意做你的猪宝宝。",
            "你老是以为我有很大的鱼塘 聊不完的小哥哥 其实一整天我除了刷朋友圈 就是看着你的对话框发呆 什么时候 你也能对我这个小笨蛋心动一回",
            "心动日记，今天女神发pyq了，我保存了她的照片 说要当壁纸使用 因为我想离她更近一点。结果她说“滚远点！”然后就把我拉黑了。她好贴心，好善良，我真的好感动！疫情期间她怕我被感染 才让我离她远一点 处处为我着想 我真是越来越爱她了！",
            "女神发朋友圈发了一款新手机，我立马用我捡瓶子赚来的钱买的手机下了订单，看见女神朋友圈发了一条，是哪个傻逼给我订的手机货到付款，我开心的笑了，女神为我发朋友圈了，我放下手中的空瓶，默默的发誓我要舔她一辈子",
            "你想我了吧？可以回我消息了吗？我买了万通筋骨贴 你运动一个晚上腰很疼吧？今晚早点回家 我炖了排骨汤 累了一个晚上吧 没事我永远在家等你",
            "今天在你们家门口等了五个小时 你发朋友圈说想吃小笼包 我今早五点半起来就买好了 一直在门口等你来拿 东北的天气太冷了 我冻的直打哆嗦 心里想不能让你吃冷的 就把包子放在怀里揣了几个小时 直到中午十一点你才醒来开门 你说了声谢谢 就把包子取走了 关上了门 你可真好看啊 刚睡醒都那么美 我看呆了却忘了告诉你 其实我还买了豆浆",
            "今天和他玩吃鸡，他要去捡空投，载上其他两个人就走了，我在后面使劲地追，他好像是故意不让我上车，他知道我的技术，怕我一起去被打死，真是太懂我了，我更爱他了",
            "我的嘴真笨 总能把天聊死了！跟你找话题好难 何况我又这么喜欢你 连发个表情包都要挑拣半天呢 我最近开始期待夜晚了 其实我在说 今天我也很喜欢你 也想你了",
            "我的嘴真笨，跟别人能说出花，嘴巴会像开过光，唯独跟你，怎么说都不太对。每天都要看很多遍微博，你稳居我微博经常访问第一的宝座，有什么好玩的都想分享给你只为逗你一笑。你的抑郁你的不快我都看在眼里急在心头，我想默默陪着你让你开心。天快亮了，又一包烟抽完。你是我最孤独的心事，能不能偶尔低下头看看我。",
            "网课新换了位老师讲授这个章节，他的每一条语音和录播视频我都反反复复听了七八遍，那十几、几十个字其实没有很难懂，就是他的声音有点像你。",
            "你已经十三个小时两分钟57秒没有回我消息了，一支晨光的水性笔可以把你的名字写两千四百三十五遍，这是我等你回消息时候发现的。",
            "昨天给你发了晚安，你没有回我，我知道你是害怕打扰我休息，于是就在朋友圈群发的晚安。你肯定也看见，我很开心。",
            "今天你给了我一拳，因为我在你回宿舍的路上叫了一声honey，你不顾周围的劝阻也想揍我，虽然最后失败了，但我还是看到了你为我对抗世界的决心和勇气！嘻嘻嘻，你真帅！",
            "你好像成熟了，你学会隐忍，开始压抑自己对我的感情。这很好...可是我觉得自己被你忽略了...你好像看不见我。这不可能，对吗？",
            "今天他终于约我出去吃饭了，好开心，到了火锅店我发现，他正和另一个女孩子坐一起，他想得真周到，叫上其他人不会容易冷场，我走过去发现他们好像已经吃完了，他说你别吃了去买一下单，他真贴心，知道我最近减肥不能吃太多。我更爱他了……",
            "你跟他已经啪完了吧应该很累吧我给你煮了粥送到你那里你待会喝好补充体力昨天晚上我听到你前半夜叫的声音很大后半夜应该是有点哑了我跑了好远给你买了润喉糖下次让他温柔一点好吗我真的很心疼昨天发传单挣了一百多今天给你打过去你多休息啦我晚点叫你起床给你点外卖给你点最喜欢喝的奶茶到晚.上的话我还要去厂里上晚班你要好好照顾自己不要让他老抢你的被子记得戴套我永远都爱你",
            "刚刚我偷东西的时候被抓了，我本来想反抗，警察说了一句老实点别动，我立刻就放弃了抵抗，因为我记得你说过 你喜欢老实人。",
            "今天我起床起晚了，连忙看手机，看到了你对我还没有起床的担心，你说:“nmsl还不给 打钱吃早餐，我给你妈两面烤的焦黄就酱吃了”我很感动，立马打了两倍的早饭钱给他，心里不太舒服，觉得愧对于他，又多加一百“记得喝奶茶”我说到。",
            "今天上线看到你把我删了，没关系。我进了你的军团，哈哈哈我聪明吧？！我一直在大厅看着你们俩组队双排，等你们结束后再看看你的战绩，心里无限甜蜜。看看吧，带妹就是比和我玩时弱吧。虽然你从未和我开麦过，可没关系。我能感受到你的温柔，和你每次刚不过时发的那句，你在那不动，在干嘛啊？你的关心总是那么突然",
            "外面下了好大的雨，我家里只有一把伞， 我拿给了他，他和她一起撑着伞走远了， 留下我一个人在屋檐下躲雨。 我知道他怕我淋雨，所以才没叫我一起走的，他真贴心！我更爱他了……",
            "我发消息问你在干嘛 你没回我消息。切到游戏客户端 发现你已经开局15分钟了 我觉得那等着你玩完这一局就好了。结果我就看着你一直在组队开局 又组队开局。没什么 就是想告诉你要少玩手机 不想理我就不用理我 没关系的。",
            "今天的我排位输了好多把，我将这些事情分享给您，但是你一个字都没有讲，我在想你是不是在忙？我头痛欲裂，终于在我给你发了几十条消息之后，你终于回了我一个脑子是不是有病？原来你还是关心我的，看到这句话，我的脑子一下就不疼了，今天也是爱你的一天",
            "你一个小时没回我的消息 在我孜孜不倦地骚扰下你终于舍得回我了 你说“去死” 这其中一定有什么含义 我想了很久 去死这简简单单的两个字肯定代表你有与我殉情的想法 为了和我永远在一起即使死也无畏 我感动哭了 不知道你现在在干嘛 我很想你",
            "昨晚你和朋友打了一晚上游戏，你破天荒的给我看了战绩。虽然我看不懂但是我相信你一定是最厉害的最棒的，我给你发了好多消息夸你，告诉你我多崇拜你，你回了我一句“傻 b ”我翻来覆去思考这是什么意思 sh-a 傻噢你是说我傻那 b 就是 baby 的意思了吧。原来你是在叫我傻宝贝，这么宠溺的语气我竟一时不敢相信，其实你也是喜欢我的对",
            "今天别人骂我了，说舔狗不配写日记，其实这个不算最难受的，最难受的是“你觉得他很有趣，他的一卡车舔狗也觉得”，突然好想问你我是第几号，但我害怕问了你就把我删了",
            "今天我终于攒够了99条消息，在过去你没有骂我的八个小时，我每回忆你最后骂我的样子一次，就发一条。到现在早上八点，终于攒够了。你可能睡了，但你早上看到我的消息一定会大吃一惊，被我的爱意打动。嘿嘿。",
            "都明白的。我一直都懂你，今天是四月的最后一天，你一直想跟我开一个愚人节玩笑，对吧？",
            "你说生孩子本来就够痛苦了 还管是谁的干嘛呢  我可以跟你的孩子姓",
            "玲珑骰子安红豆，入骨相思知不知。 蒋介石因为宋美龄的一句喜欢梧桐，他便种满了整个南京。而我因为你的一句不喜欢小偷，我便放过了整个朝阳区电瓶车。",
            "你一个小时没回我的消息。在我孜孜不倦地骚扰下你终于舍得回我了 你说“去死”。这其中一定有什么含义，我想了很久 去死这简简单单的两个字肯定代表你有与我殉情的想法，为了和我永远在一起即使死也无畏。我感动哭了(┬＿┬)。不知道你现在在干嘛。我很想你。",
            "他好像从来没有主动说过爱我，我搜索了一下关键字“爱”。在我们的聊天记录里，他只说过一次：你爱怎么想就怎么想",
            "我坐在窗边给你发了99条消息，你终于肯回我了，你说“发你妈啊” 我一下子就哭了，原来努力真的有用，你已经开始考虑想见我的妈妈了，你也是挺喜欢我的。",
            "从我起床到晚上一直在给你分享我的生活碎片并关心你的衣食住行 直到深夜你终于回我了 累了 睡了 原来你是爱我的 这么晚了还在担心我累并嘱咐我早点睡",
            "今天你终于主动找我了，你甩给了我一个tb链接让我帮你付款，这是你让我给你买的第一个东西，我付了款你对我说“谢谢”，这让我感觉我们的关系更进一步了，真的是越来越爱你了。",
            "现在已经凌晨一点多了，我望着手机屏幕迟迟没有他的消息：你知道吗？我等了一晚上你的消息。他终于回复我了：是我让你等的？",
            "你三天没回我的消息 在我孜孜不倦地骚扰下你终于舍得回我了 你说“nmsl” 我想 这一定是有什么含义吧 噢！我恍然大悟 原来是尼美舒利颗粒 她知道我关节炎 让我吃尼美舒利颗粒 你还是关心我的但是又不想显现的那么热情的 天啊 你好高冷 我好像更喜欢你了",
            "今天我鼓起勇气问她是喜欢狼狗还是喜欢奶狗 她说她喜欢狼狗 我问她觉得我是哪一种 她说我是土狗",
            "今天你破天荒的给我发了个早，我开心极了，难道这就是恋爱的感觉吗。我一看时间，十二点整，你一醒来就在想我，我流下了激动的眼泪。又想到你到现在都没有吃饭，我给你发了两百块钱红包。你快速的领取了，却迟迟没有回我。我想你可能也沉浸感动当中吧，我给你发了句去吃点东西吧。回复我的却是一个红色感叹号，红色代表爱情，你一定是不好意思说出口，才用这么委婉的方式表达你对我的爱，我也爱你。",
            "天一亮我就给你发消息 你说你\"嗓子痛\" 我一下子就着急了 我很关心的说道 买药没有 是衣服穿太薄了吗 这几天别吃辛辣食物 零食也别吃了 多喝点热水 早晚天气比较冷 衣服一定要注意 早上可以喝一杯热牛奶 换季的时候是容易感冒 是我没有叮嘱好你对不起 你说不是 是昨晚给别人口了 我心想原来不是感冒啊吓我一跳 答应我以后别给别人口了好吗 爱你么么么么哒", "今天给一个女生发了十一条消息，她还是没有回我，我知道她在跟男生聊天，但我就是想用消息的数量刷一下存在感 。我做不了你微信聊天的主人公那我只能做你和他聊天的背景提示音。",
            "今天是我第一天当电焊工 天气很暖和 风也吹的很舒服 我站在树下点了一根烟 我不想再做电焊工了 我把自己的心关起来锁在了一个很深的地方 我是一个不称职的电焊工 我电不到你 也焊不牢你的心.",
            "我爸说再敢网恋就打断我的腿 幸好不是胳膊 这样我还能继续和你打字聊天，就算连胳膊也打断了，我的心里也会有你位置。",
            "今天你终于对我说晚安了，虽然你不在我身边，但是我知道，你要说的是wanan。嘻嘻，我就知道你还是爱我的，等我再努把力，我一定要把你留在我身边，不让你去夜店了。",
            "经过两个多月疫情终于结束了，我给你发消息显示被拉黑了 你还是这么贴心，怕疫情通过网络传播给我，原来你一直在默默保护着我。",
            "今天没怎么和你说话，我找了半个小时的文案，发了条朋友圈，仅你可见，是想让你知道我喜欢你，私聊我咱们谈恋爱吧，结果你在底下评论：偷了",
            "这是我用我奶奶的手机给你发的信息 不要再拉黑我了 我真的没有手机联系你了",
            "别的妹妹叫你打游戏 你让人家语音给你发了句哥哥 你就陪她打一天 我叫你打游戏 你回了我一句 70/h",
            "看到你和一个帅哥吃饭，看起来关系很亲密的样子，你从来没有告诉我你还有这么好的朋友，一定是怕我多想，你总是为我着想，你对我真好。",
            "昨晚本王和朋友打了一晚上游戏，我破天荒的的给17号舔狗看了战绩，虽然他看不懂但是他相信本王一定是最厉害的，最棒的！他给本王发了好多消息，告诉我有多崇拜我，我回了他一句“啥b”。并不是因为什么，只是刚刚男神给我打电话，叫我去宾馆。哎一晚上整的我死去活来，第二天就给他打电话叫他来接我，才发现他竟然改了ID，“我是你的啥b啊”",
            "今天你跟我说我很恶心，让我不要骚扰你了。我听了很高兴，小说里的主角都像你这样，最开始表现的很厌恶，但最后总会被我的真心打动。你越讨厌我，以后就会越愧疚，越爱我。嘻嘻。",
            "今天问你中午打算吃什么，你说吃NM，我仔细思考了一下，NM是柠檬的缩写，你是因为我昨天在你闺蜜的评论下留言而感到酸，吃我醋了对吧？小傻瓜，我只爱你一个呀！",
            "今天你说了要和我打电话，我等了一天，马上十二点了才打过来，我有点不高兴就挂了，你骂了句给脸不要脸。我想了一下，哎呀你还会关心我的脸，多么善良的男孩子，我发誓还能再等一天电话[太開心]",
            "你说你情头是一个人用的 空间上锁是因为你不喜欢玩空间 情侣空间是和闺蜜开的 找你连麦时你说你在忙工作 每次聊天你都说在忙 你真是一个上进的好女孩 你真好 我好喜欢你",
            "今天你跟我说了很多，有对我感情的理解，对之前行为的道歉，还有对这一切的感谢。你说我让你加深了对世界的理解，锤炼了自己的心智。你最后说，谢谢你对我的喜欢，但我不喜欢同性，从过去到未来都不会，请你离开我的生活。你说这是你唯一的请求，其实我都明白的。我一直都懂你，今天是四月的最后一天，你一直想跟我开一个愚人节玩笑，对吧？",
            "我发了条朋友圈 他去点赞了 我高兴的把他截屏并发给他 问他：你是不是有啥想对我说的 ，他下一秒 把点赞取消，告诉我 ，你看我没点赞 我也没看到",
            "今天一个女孩子对我表白说喜欢我，可是我的心里只有你啊，我立马拒绝了她，她说她不会放弃的，我的心里只有你一个人啊，不会答应她的，话说今天发工资了，五千，你猜猜看我会给你多少？四千多？不对，我把我的卡给你，密码你的生日。今天也会给你做好吃的，早上你和我说你腰酸死了，昨天晚上累坏了吧，我还是会给你做好吃的，果然你什么时候都是好看的，你今天让我交钱的时候发的字是最多的啊，我想你一定更爱我了，都粘着我了，我一定努力赚钱的。",
            "女神发朋友圈发了一款新手机 我立马用我捡瓶子赚来的钱买的手机下了订单 看见女神朋友圈发了一条 是哪个傻逼给我订的手机货到付款 我开心的笑了 女神为我发朋友圈了 我放下手中的空瓶 默默的发誓我要舔她一辈子",
            "今天晚上好冷，本来以为街上没人，结果剛剛偷电动车的時候被抓了，本來想反抗，警察說了一句老實點別動，我立刻就放棄了抵抗，因為我記得你說過，你喜歡老實人。",
            "时隔30个小时 你终于发了信息给我 你说 宝贝 我想你了 我很开心 我终于以为我的舔狗日子到了 可没想到信息发出来两秒都没有 你就撤回了 你说发错了 说我老是发信息给你 烦不烦啊 当我说准备要回没关系的时候 我看见了红色的感叹号 但这不影响我去微博烦你",
            "今天你在群里问有没有人打游戏，我说我们双排吧，你对我说：“滚，sb”,我当时就开心了，因为我知道sb是sweet baby的缩写，原来你也喜欢我。",
            "我存了两个月钱，给你买了一双北卡蓝，你对我说一句谢谢，我好开心。这是你第一次对我说两个字，以前你都只对我说滚。今天晚上逛咸鱼，看到了你把我送你的北卡蓝发布上去了。我想你一定是在考验我，再次送给你，给你一个惊喜，我爱你。",
            "今天打单子赚了56 给你转了52自己留了4块钱 我花两块买了两包泡面 用剩下的两块钱买了一瓶矿泉水 自己烧水泡面吃 而你用那52块钱想都没想的给你别的哥哥买了皮肤 我太开心了 因为你用上我的钱了 以后我要赚更多的钱给你",
            "你现在在干嘛？吃饭了嘛？想我了嘛？你已经5小时没理我了，我一直在等你。宝贝你知道吗，我刚下楼倒垃圾时看到门口保安写的日记，看到他说\"他委屈他想她\"的时候我笑了出来，哈哈哈他真的好像一条舔狗啊，还好我不是，嘿嘿嘿嘿嘿嘿！他真可怜。",
            "我爸说再敢写舔狗日记就打断我的腿 幸好不是胳膊 这样我还能继续和你打字聊天，就算连胳膊也打断了，我的心里也只会有你的位置。",
            "今天我观战了一天你带别人打游戏，你们玩的很开心，我给你发了200多条消息，你说你没流量了就不回了，晚上你发了条说说没有人爱你，我连滚带爬评论了句有我在。你把我拉黑了，我给你打电话也无人接听，对不起我不该打扰到你的，我哭着要你把我移除黑名单，然后你给我发了句\"nmsI?\"我惊喜的发现结尾有个问号是疑问句，原来你一直在关心我的家人，看来你真的喜欢我!", "今天打王者输了好多把，我将这些事情私信分享给你，但是你一个字都没有讲，我在想你是不是在忙?我头痛欲裂,终于在我给你发了几十条消息之后，你终于回了我一个脑子是不是有病?原来你还是关心我的，看到这句话，我的脑子一下就不疼了，今天也是爱你的一天~",
            "你十分钟没有回我的消息在我孜孜不倦的骚扰下你终于舍得回我了 你说“憨憨”这其中一定有什么含义 可能说在夸我傻傻很可爱吧 我上百度搜了 也许你话没有说全 是不是你偷我这个憨憨的心所以变成敢敢呢 我感动哭了 原来是我自己感动了我自己 不知道你现在在干嘛呢 我很想你",
            "你说你想买AJ，今天我去了叔叔的口罩厂做了一天的打包。拿到了两百块钱，加上我这几天省下的钱刚好能给你买一个鞋盒。即没有给我自己剩下一分钱，但你不用担心，因为厂里包吃包住。对了打包的时候，满脑子都是你，想着你哪天突然就接受我的橄榄枝了呢。而且今天我很棒呢，主管表扬我很能干，其实也有你的功劳啦，是你给了我无穷的力量。今天我比昨天多想你一点，比明天少想你一点。",
            "今天发工资了，发了2000，给你微信转了520 支付宝1314，还剩下166，中午给你发了很多消息你没回，总是正在通话中。你让我别烦，别打扰你和你的宝贝连麦，好吧没关系，宝宝我爱你，所以我不生气，剩下166块我在网上买了你爱吃的零食，还有一盒咽喉片给你寄过去了，希望你保护好嗓子，我爱你。",
            "我坐在窗边给你发了99条消息 你终于肯回我了 你说“发你妈啊” 我一下子就哭了 原来努力真的有用 你已经开始考虑想见我的妈妈了 你其实也是挺喜欢我的",
            "这是我最后一篇保安日记了 刚刚给队长说了不干了 行李收拾好了 准备走人了。蒋介石为了宋美龄放弃了南京我为了你辞职 ,放弃了整个小区的治安只是因为你一句不喜欢保安。我松开了牵狗的手,也牵不到你的手,我脱下了保安制服,最后也祝你幸福,告诉你一个秘密,其实我是一个痴汉,我来做保安是为了监视你,最后,案子没破, 我的心被你破了",
            "今天我什么也没有得手，我有点心累，回家时路过一条街，街上的小姐姐热情的拉着我的手对我说 小哥哥快来玩啊~ 我本想拒绝，可是我还是放弃了抵抗，因为想到你曾说过 太早回家的男人没前途。",
            "以前我问你怎样才能跟我处对象，你说等火舞橘子出皮肤就处，我以为这辈子没机会了，直到今天我才明白，原来你是爱我的",
            "今天我还是照常给你发消息，汇报日常工作，你终于回了我四个字：“嗯嗯，好的”你开始愿意敷衍我了，我太感动了受宠若惊。我愿意天天给你发消息。就算你天天骂我，我也不觉得烦。",
            "今天我还是日常给你发早安午安问你吃了没，你想吃什么，你说了句sb，我特别开心你回我一个字以上的消息了，sb一定是随便的意思吧，我喜欢的人就是这样不挑食，我感觉她更完美了，今天我也在非常喜欢她",
            "蒋介石因为宋美龄的一句喜欢梧桐，他便种满了整个南京。而我因为你的一句不喜欢小偷，我便放过了整个上海的电动车。",
            "和你找话题好难 我总是不知道说什么 每次都是在聊天栏里删了又删 才颤颤巍巍地发出去 里面每一个字都包含我对你的爱 我最近越来越期待夜晚了 因为白天不敢去找你 怕吵醒你睡觉 晚上还可以和你说晚安 今天我好想你",
            "哥哥刚刚说去洗澡了，我等了他3个小时。我问他玩不玩，他说要睡觉了。可当我上线看了他的战绩，原来已经有别的璇璇了。没关系，明天我也会舔你。",
            "今天啊珍跟啊蓁去逛街了，并叫我不要跟上，你们应该是在考验我吧，于是我把那条街买了下来，你们回家后果然都亲了我一口，唉，我简直是太聪明了",
            "宝宝 刚刚睡醒没看到你回我的消息 昨天睡觉梦到你换了情头 吓醒才意识过来是做梦 所以你为什么不回我的消息呢 这次不回我我下次要找什么理由再去找你呢 我委屈 我好想你",
            "不能删除微信，即使不聊天，即使你只会给我发表情包，因为删了就连聊天的机会都没有了",
            "今天发工资了，发了2000，给你微信转了520 支付宝1314 还剩下166，中午给你发了很多消息你没回，刚弹你正在通话中，你让我别烦，别打扰你给你宝贝口，好吧没关系，宝宝我爱你，所以我不生气，剩下166块我在网上买了你爱吃的零食，还有一盒咽喉片给你寄过去了，希望你保护好嗓子，我爱你",
            "我爸爸说，如果我再写舔狗日记就打断我的腿 。我想了想，还好不是胳膊，这样我还能继续和你打字聊天。其实就算连胳膊也打断了，我的心里也只会有你的位置。",
            "我存了两个月的钱，给你买了一双北卡蓝，你对我说了一句谢谢，我好开心。这是你第一次对我说两个字，以前你都只对我说滚。今天晚上逛闲鱼，看到了你把我送你的北卡蓝发布上去了。我想，你一定是在考验我，于是我用借呗里的钱把它买了下来，再次送给你，给你一个惊喜。",
            "你没回我的消息，我发了一条仅你可见也没任何回应，我想你应该是在忙所以没时间理我，应该是我等的还不够久。",
            "今天女神给我发信息问我有没有稻壳会员，我说没有，她说好吧，为了维护在她心的形象，我马上打开支付宝充值了一个月的会员，我把账号发过去，我能想象到她对我的肯定，我离女神的距离越来越近了",
            "今天没有巡逻 在小区里看漂亮的女孩子们戴着口罩去上班 向她们打招呼 她们却不理我 可能因为我只是个保安 保安亭没有暖气 值班一夜的我精疲力尽 只有想起你才会让我有一丝温暖 想做你的保安 保你一生平安!",
            "你和他连睡吧 磕完盖好被子别着凉 今天搬砖赚300我给你转过去了 我睡啦 继续努力赚钱给你 可以的话多回我几句 今天你回了我三句 在磕 好爽 别烦 比昨天多了一句好爽 我好开心爱你",
            "我爸说再敢写舔狗日记就打断我的腿 幸好不是胳膊 这样我还能继续和你打字聊天，就算连胳膊也打断了，我的心里也只会有你的位置",
            "我今天送了你一支口红，你拿到之后很开心，在他的嘴巴上亲了一下，或许他送你口红的时候，你也会在我的嘴巴上亲一下",
            "我暗恋的人说眼睛疼，所以我买了瓶眼药水寄过去，但他却告诉我他有喜欢的人了，让我别再打扰，距离遥远顺丰都要两天才能到，可他为什么只用了一秒就把眼药水滴进了我眼睛里。",
            "打雷了 我担心你害怕打雷声 就一早跑到你家楼下 可能是心灵的呼唤使你打开了窗户 那一刻我感觉我是世界少最幸福的人 你打开窗户对我喊：惊雷 这通天修为天塌地陷紫晶锤 虽然我不知道是什么意思 我就当作你向我表白吧 ?。",
            "今天我对他说： 我想问一下 ， 爱奇艺会员， 你有吗？ 他没发现是我爱你的藏头诗，还叫我穷鬼，让我滚。我看不了青春有你，我的青春也没有你",
            "打雷了 我担心你害怕打雷声 就一早跑到你家楼下 可能是心灵的呼唤使你打开了窗户 那一刻我感觉我是世界少最幸福的人 你打开窗户对我喊：惊雷 这通天修为天塌地陷紫晶锤 虽然我不知道是什么意思 我就当作你向我表白吧",
            "你半天没理我了，我忍不住给你打了好几个电话，你终于接通了，跟我说“草”我觉得这肯定不是字面意思，我考虑的很久，草的下面是早，代表着你对我的爱犹如旭日东升的太阳绵绵不断。我不禁忍不住，流下了感动的泪水，我知道你肯定也喜欢我的吧。",
            "自从你把我的微信删除了之后，我经常去你宿舍楼下等你，早上偶尔去，晚上一定在。平时你都故意不看我，因为你比较害羞腼腆，但今天你终于忍不住对我的在乎，把我叫到小树林里独处。你说了什么我忘了，好像是让我老是找你免得你把持不住吧。嘻嘻，你真可爱。",
            "今天你终于都我说了“喜欢”这个词 我等了好久了 你对我说:我喜欢的人不是你。我知道你是在考验我 宝贝我会一直等你的",
            "我还是很喜欢你，就像，我如果有一百块钱，我愿意花30打车去找你，然后花60去找狗胖子买两张惊奇队长，然后花八块钱给你买一杯冰阔乐。看完电影，我会用最后两块钱，去坐公交，去银行取两万自己去吃螃蟹龙虾三文鱼蛋糕松塔章鱼丸子酸菜鱼香辣鸡翅麦旋风芒果布丁金丝面羊肉串火锅。",
            "你已经好几分钟没回我的消息在我孜孜不倦地骚扰下你终于舍得回我了你说”滚”这其中一定有什么含义 我想了很久滚是三水这代表你对我的思念也如滚滚流水一样汹涌 我感动哭了不知道你现在在干嘛我很想你 。",
            "春天的阳光穿过树叶的缝隙，我知道那是太阳经过小孔成像到在我身上的影。我抬头望去只觉一阵恍惚，看见了黑色长发的你。我知道那是你穿过我的心留下的影，但我却不知道这是什么成像原理",
            "今天考了一天的试，很疲惫但是看见你的朋友圈，原来你去吃了肯德基，真想和你一起去吃一次。",
            "你知道晚安的拼音吗，是wanan哦，也就是我爱你爱你。嘻嘻，每次我给你发这两个字你都猜不到吧，也许是我信号不好，给你发的消息都带有红色感叹号，这一点也是你爱我的表现吧。和他同居的日子要好好的哦，不要妨碍到别人了，我上次打电话给你，听你哭的好惨，一直喊不要，我当时真的气炸了，他怎么可以这样对你。你一个女孩子在外面要坚强啊，外面真冷，要记得保暖哦，我会继续赚钱的。",
            "今天你说了要和我打电话，我等了一天，马上十二点了才打过来，我有点不高兴就挂了，你骂了句给脸不要脸。我想了一下，哎呀你还会关心我的脸，多么善良的男孩子，我发誓还能再等一天电话",
            "她从来不说想我，聊天记录搜索了一下“想你”两个字全都是：“那波你怎么不上啊 你在想你妈呢”",
            "今天发工资了 我一个月工资1500 你猜我会给你多少 是不是觉得我会给你1200 自己留300吃饭 哈哈 我1500都给你 因为厂里包吃包住",
            "今天没有巡逻 在小区里看漂亮的女孩子们戴着口罩去上班 向她们打招呼 她们却不理我 可能因为我只是个保安 保安亭没有暖气 值班一夜的我精疲力尽 只有想起你才会让我有一丝温暖 想做你的保安 保你一生平安",
            "听着窗外稀稀拉拉的雨声 我忽然想到你对我说的话 对啊 生孩子本来就够痛苦了 还管是谁的干嘛呢",
            "今天表白被拒绝了，她对我说能不能脱下裤子撒泡尿照照自己，当我脱下裤子的时候，她咽了下口水，说我们可以试一下。",
            "你终于喊我双排了 让我拿胜率最高的英雄，我一般都不玩安琪拉的，因为胜率太高怕掉，可是为了你我还是选了，你好像很开心，给我发了句fw，我懂了，你是想夸夸我，说我法王，你真好，我越来越喜欢你了",
            "我骗了我爸妈，买了张机票去见你，在你的城市我被骗了8000块钱，独自一人吃泡面时看到你在街边和一个大叔热吻了5分钟，在那5分钟里，我很想家，很想爸妈，很想玩王者荣耀，玩的扣1。",
            "今天我观战了一天你和别人打游戏，你们玩的很开心，我给你发了200多条消息，你说没流量就不回了，晚上发说说没有人爱你，我连滚带爬评论了句有我在。你把我拉黑了，我给你打电话也无人接听。对不起我不该打扰你。我求求你再给我一次当好友的机会吧！",
            "骗了父母，买了车票只身一人去见你，在你的城市我被骗了2000块钱。找到你一起吃了饭，看了电影。你说你要回寝室写要交的东西，我送你回去，找了个50块钱的小旅馆。当我下楼买东西的时候，我看到你上了一辆车。车没开，你和他热吻了5分钟。在那5分钟里，我想家想父母想打王者。玩的扣1",
            "你好像从来没有对我说过晚安，我在我们的聊天记录里搜索了关键字：“晚安”，你说过一次：我早晚安排人弄死你。",
            "今天外面的天气不是很好，甚至说非常的差，我给你打了一个电话，你没有接，我再打，你还是没有接，我想你应该在睡觉吧，于是我带上口罩跑到你家门口，刚要敲门，一个男人打开了你家的房门",
            "我生怕打扰到你周末早睡，然后非常纠结的给你发了“早上好宝宝，在干嘛?”的信息。你开心地回复到:“正和男朋友腻在一起呢，他在喂我吃早餐，嘻嘻嘻”。看你这么开心，心里也替你高兴。",
            "她好像从来没有主动说过爱我，我搜索了一下关键字“爱”。在我们的聊天记录里，她只说过一次：爱奇艺会员借我一下",
            "听说你朋友说今天出门了，我打扮成精神小伙来找你，没想到你竟然对我说“给我爬，别过来”我当场就哭了，原来真心真的会感动人，你一定是知道，穿豆豆鞋走路脚会很累，让我爬是因为这样不会累着脚，其实你是喜欢我的吧",
            "今天有点口腔溃疡 不太想舔了 和你的旧爱好好的啊 不要不开心了",
            "我存了两个月的钱，给你买了一双北卡蓝，你对我说了一句谢谢，我好开心。这是你第一次对我说两个字，以前你都只对我说滚。今天晚上逛闲鱼，看到了你把我送你的北卡蓝发布上去了。我想，你一定是在考验我，于是我用借呗里的钱把它买了下来，再次送给你，给你一个惊喜，爱你！",
            "你一个小时没回我的消息 在我孜孜不倦地骚扰下你终于舍得回我了 你说“在做爱”这其中一定有什么含义 我想了很久 在做爱这简简单单的三个字肯定是三句话，分别是，我在忙，做你女朋友，我爱你  想到这里我不禁流下了眼泪，我这么长时间的喜欢没有白费，不知道你现在忙干嘛  我很想你",
            "你十分钟没有回我的消息在我孜孜不倦的骚扰下你终于舍得回我了 你说“憨憨”这其中一定有什么含义 可能说在夸我傻傻很可爱吧 我上百度搜了 也许你话没有说全 是不是你偷我这个憨憨的心所以变成敢敢呢 我感动哭了 原来是我自己感动了我自己 不知道你现在在干嘛呢 我很想你～",
            "昨天我还是照常给你发了好多消息 今天你终于回了我五个字“烦不烦啊你”。我稍加思索，才明白你的话。 你开始关心我觉不觉得烦了， 我太感动了，受宠若惊的。不烦不烦 ，你天天骂我我都不会觉得你烦，我永远是我的小心肝，爱你～(^з^)-?么么哒!",
            "最近我暗恋的女生每天都和不同的男生约会，我想总有一天会轮到我吧 我问她什么时候能见见我 她说下辈子吧 她真好 下辈子还要和我在一起",
            "我爸说再敢网恋就打断我的腿，幸好不是胳膊，这样我还能继续和你打字聊天，就算连胳膊也打断了，我的心里也会有你位置。",
            "你跟他已经啪完了吧？我今天搬砖挣了一百多，明天给你打过去。你快点休息啦，我明天早上叫你起床，给你点外卖，给你点最喜欢喝的奶茶。到晚上的话我会继续去捡垃圾的，你不用担心我烦你。床只有这么大，睡不下三个人，你要好好照顾自己，不要让他老抢你的被子。我永远都爱你。",
            "今天你依旧高冷，给你发了好多消息，都没回。可 你越是这样，我越是喜欢你。在我不断的嘘寒问暖下，你终于不再矜持了，你回了一个sb。在我查遍了英语词典后，我终于明白了这两个字母的意思。s是sweet，b是baby，那么你一定是在叫我sweet baby了，我很感动。",
            "你跟他已经醒了吧?我今天捡垃圾挣了一百多明天给你打过去你快点休息吧我明天叫你起床给你点外卖买烟给你点你最喜欢的奶茶晚上我会继续去摆地摊的你不用担心我烦你床只有那么大睡不下三个你要好好照顾好自己不要让他抢你被子我永远爱你",
            "昨天给你发了99条约你一起植树的消息，今天你终于肯回我了， 你说“你先去植发吧，死秃子。”  我一下子就哭了 ，原来努力真的有用 ，你已经开始关心我了，你也是挺喜欢我的吧。",
            "今天保安队长心情不好拿我撒气，因为他不会唱惊雷，他的女神很生气的骂他说他不懂潮流不懂时尚，所以队长冲我吼了一天惊雷，这通天修为天塌地陷紫金锤我委屈，我想你",
            "抢银行的时候被抓了 我本来想反抗 **说了一句老实点别动 我立刻就放弃了抵抗 因为我记得你说过你喜欢老实人",
            "我打游戏太菜了 偶尔跌跌撞撞摘了几颗星星 总是又掉下来 我守不住上一把摘掉的星星 也守不住你",
            "你想我了吧？可以回我消息了吗？我买了万通筋骨贴 你运动一个晚上腰很疼吧？今晚早点回家 我炖了排骨汤，累了一个晚上吧 没事我永远在家等你",
            "我给你打了一通电话，你终于接了。听到了你发出啊啊啊啊的声音，你说你脚痛，我想你一定是很难受吧。电话那边还有个男的对你说“来换个姿势”，一定是在做理疗了。期待你早日康复。",
            "今天的我排位输了好多把，我将这些事情分享给你，但是你一个字都没有讲，我在想你是不是在忙?我头痛欲裂，终于在我给你发了几十条消息之后，你终于回了我一个脑子是不是有病?原来你还是关心我的, 看到这句话，我的脑子一下就不疼了，今天也是爱你的一天。",
            "今天天气有点冷，想偷你的心却还是没有成功，在床上的我现在的心情就像天气预报，说明天有雨 我都听成明天有你",
            "你三天没回我的消息在我孜孜不倦地骚扰下你终于舍得回我了你说'nmsl我想这一定是有什么含义吧噢!我恍然大悟原来是尼美舒利颗粒他知道我关节炎让我吃尼美舒利颗粒他还是关心我的但是又不想显现的那么热情的天啊他好高冷我好像更喜欢他了?",
            "我退了无关紧要的群，唯独这个群我没有退，因为这里有一个对我来说很特别的女孩子，我们不是好友，我每天只能通过群名片看看她，虽然一张照片也看不到，我也知足了，我不敢说她的名字，但我知道她是群里面最美的女孩子，她说我们这样会距离产生美~ 我想想发现她说的挺对的，我心里很开心",
            "今天我观战了你一天带别人打游戏，你们玩得很开心，我给你发了两百多条信息，你说你没流量就不回了。晚上你发了条说说，抱怨没有人爱你。我连滚带爬评论了句有我在，你把我拉黑了。我夜里给你打电话无人接听。对不起，我不该打扰到你。我求你再给我一次当你好友的机会吧！心碎 我委屈，我想你，我会坚持我对你的爱的，你放心好啦，么么哒～我很喜欢你！",
            "今天发工资了，我一个月工资1500，你猜我会给你多少？是不是觉得我会给你1200，自己留300吃饭？哈哈，我1500都给你，因为我们包吃包住。",
            "你就像楼下没开门的理发店一样冷漠，它不理发，你不理我。",
            "我暗恋的人说眼睛疼 所以我买了瓶眼药水寄过去，但他却告诉我他有喜欢的人了 让我别再打扰，距离遥远，顺丰都要两天才能到，可他为什么只用了一秒就把眼药水滴进了我眼睛里",
            "你昨天晚上又没回我信息，我却看见你的游戏在线，在我再一次孜孜不倦的骚扰你的情况下,你终于跟我说了一句最长的话 “你他妈是不是有病” 我又陷入了沉思，这一定有什么含义,我想了很久你竟然提到了我的妈妈，原来你已经想得那么长远了，想和我结婚见我的父母，我太感动了真的，真的，那你现在在干嘛，我好想你，我妈妈说她也很喜欢你。",
            "疫情已经持续了几个月 你发了朋友圈 说想吃火锅 我想着现在外面没法吃火锅 跑去超市给你采购了一些火锅食材还有你最喜欢的海底捞底料 给你发消息说我在你小区门口 给你买了些东西 天气有点冷 我等了半天你都没有出现 也没有回我消息 我想你大概是睡觉呢 点开朋友圈看到你正在和别的女生双排王者 我把东西寄存在门卫 给你留言说我走了 你不爱我没关系 不可以饿着自己",
            "你说你情头是一个人用的，空间上锁是因为你不喜欢玩空间，情侣空间是和闺蜜开的，找你连麦时你说你在忙工作，每次聊天你都说在忙，你真是一个上进的好女孩，你真好，我好喜欢你！",
            "今天我是夜班值班人员 去小区宵夜店买馒头做早餐，买了三个馒头加一碗免费的稀饭感觉很幸福，付钱的时候老板娘对我笑了笑，她可能觉得保安很有安全感吧。",
            "今天早上我告诉你我想你了，你没理我。今天中午我给你打电话，你不接，打第二个你就关机。晚上我在你公司楼下等你，你对我说的第一句话就是滚&quot;滚，别烦我，别浪费时间了&quot;，我真的好感动，你居然为我考虑了，怕我浪费时间。呜呜呜，这是我爱你的第74天。",
            "昨晚你和朋友打了一晚上游戏，你破天荒的给我看了战绩，虽然我看不懂但是我相信你一定是最厉害的，最棒的，我给你发了好多消息夸你，告诉你我多崇拜你，你回了我一句“傻b”，我翻来覆去思考这是什么意思, 噢你是说我傻，那b就是baby的意思了吧，原来你是在叫我傻宝，这么宠溺的语气，我竟一时不敢相信，其实你也是喜欢我的对吧",
            "你hello忘闭麦了，我听见你跟你爸爸在打你，啪啪啪的一直打的可凶了，你哭唧唧的说爸爸， 不要，不....听见你被他打，我很着急，听着你央求着他喊，啊啊，....我心里也很心....就这样听着你被打了好久，你竟然开始賭气的嘴硬的喊着再大力点，弄死我乖啊，你爸太不是人了，你这样喊他真的会虐待死你的!果然，你突然哭着喊着求你别....不要.....我突然紧张起来!他竟然要拿枪打死你!我赶忙拿起手机拨打110。电话刚拨打出去,你那边传来了啊啊啊啊凄惨的喊叫.声....之后，你的hello掉了，只剩下我听到**叔叔喂?喂?这里是110报警电....，我握紧拳头，咬牙切齿,发誓一定要杀了你爸，为你报仇!",
            "今天我看到你给我发消息了，我还以为你不会给我发消息，虽然只是一个王者荣耀送金币的消息，但我也感到非常荣幸，因为你记得给我送金币，其实你也是挺喜欢我的对吧，今天也是你爱我的一天。昨天你把我删了，我陷入了久久的沉思，我想这其中一定有什么含义，原来你是在欲擒故纵，嫌我不够爱你，无理取闹的你变得更加可爱了，我会坚守我对你的爱的，你放心好啦！么么哒！昨晚从8点等到凌晨3点，没有等来你的一句晚安，早晨7点你发来信息，特别关心提示音吵醒了我，我秒回，你说我起的挺早的，我说因为我很早就睡了。",
            "你终于喊我双排了 让我拿我胜率最高的英雄 我一般都不玩的 因为胜率太高了怕掉 可是为了你我还是选了 你好像很开心给我发了句fw，我懂了 你是想夸夸我说我法王 你真好 我越来越喜欢你了",
            "这是我们分手后的第我不知道多少天，我还是忘不了你，我默默的打开你的聊天界面，我想让你发现我，可又不敢太过的打扰你，我发了13个抖一抖代表着一生我想你会懂我，我等了半小时，我懂了发的太少你的手机还没抖就停止了，接着我就只连着发了520个，你终于回我了，你发了一句wcnmb，我懂了，我终于懂了，你喜欢的是我妈，你个死同性恋，我妈是不会喜欢你的！",
            "你昨天晚上又没回我信息 我却看见你的游戏在线 在我再一次孜孜不倦的骚扰你的情况下 你终于跟我说了一句最长的话 “你他妈是不是有病” 我又陷入了沉思 这一定有什么含义 我想了很久你竟然提到了我的妈妈 原来你已经想得那么长远了 想和我结婚见我的父母 我太感动了真的 真的 那你现在在干嘛 我好想你 我妈妈说她也很喜欢你～",
            "今天舔了一口狗，毛挺多，味道并不是很好，有一丝丝咸，毛有点硬，口感不是很好，应该是该洗澡了，然后被狗也舔了一口，他好像 吃了点特别的东西，味道挺怪，不过还是要感谢它，如果没有它，我今天又怎么会被漂亮护士照顾了半个小时呢",
            "今天我看见她好像特别难受，不知道为什么，我好想安慰一下，可是当我问的那一下，她叫我滚开，或许我真的有打扰到你吧，我想让她开心，所以我走开了",
            "昨晚你和朋友打了一晚上游戏，你破天荒的给我看了战绩，虽然我看不懂但是我相信你一定是最厉害的，最棒的，我给你发了好多消息夸你，告诉你我多崇拜你，你回了我一句“傻b”，我翻来覆去思考这是什么意思，sh-a傻，噢你是说我傻，那b就是baby的意思了吧，原来你是在叫我傻宝，这么宠溺的语气，我竟一时不敢相信，其实你也是喜欢我的对吧",
            "你还有钱吗？没有我给你打点。",
            "今天好开心啊，和你一起在峡谷嬉戏，打完一波团战之后看到你在打大龙，残血的我跳过去直接被龙爪拍死，但这一刻我觉得好浪漫，死在你的脚旁边，这是我离你最近的一次。 ??? ?",
            "她好像从来没有主动找过我，我看了一下我们的聊天记录， 只有情人节这天给我发的入住酒店叫我帮她砍一刀。",
            "今天降温了，风吹的我很冷，我站在树下点了一根烟，我抽了三分一，风抽了三分之二，我把自己的心关起来锁在了一个很深的地方。我是一个不称职的电焊工，我电不到你，也焊不牢你的心。",
            "你很久没回我的消息，在我孜孜不倦的骚扰之下你终于舍得回我了，你说“滚”这其中一定有什么含义，我想了很久，滚是三点水，这代表你对我的思念也如滚滚流水一样汹涌，我感动哭了，不知道你现在在干嘛！我很想你。 ?",
            "你回他消息吧！他开心了你就会理我了。",
            "今天别人骂我了，说舔狗不配写日记，其实这个不算最难受的，最难受的是“你觉得他很有趣，他的一卡车舔狗也觉得”，突然好想问你我是第几号，但我害怕问了你就把我删了 ?、",
            "你扇了我一巴掌 我握着你的手说“怎么这么凉”",
            "今天的彩虹桥格外的迷人，可是当你站在彩虹桥下，它便暗淡了许多，原来你才是最迷人的。",
            "我的嘴真笨 总能把天聊死了！跟你找话题好难，何况我又这么喜欢你，连发个表情包都要挑拣半天呢！我最近开始期待夜晚了，其实我在说：“今天我也很喜欢你，也想你了！”",
            "我给你打了一通电话，你终于接了。听到了你发出啊啊啊啊的声音，你说你脚痛，我想你一定是很难受吧。电话还有个男的对你说“来换个姿势”，一定是在做理疗了。期待你早日康复。",
            "天气晴  今天表白被拒绝了，她对我说能不能脱下裤子撒泡尿照照自己，当我脱下裤子的时候，她咽了下口水，说我们可以试一下。",
            "找你时你说你在忙工作，每次聊天你都说在忙，你真是一个上进的好男孩，你真好，发现我越来越喜欢这样优秀的你。",
            "“下雨了，雨伞借给你”",
            "你终于喊我双排了，让我拿我胜率最高的英雄，我一般都不玩王昭君的，因为胜率太高了怕掉，可是为了你我还是选了，你好像很开心给我发了句fw，我懂了，你是想夸夸我说我法王，你真好，我越来越喜欢你了！",
            "雷阵雨打雷了，我担心你害怕打雷声，就一早跑到你家楼下，可能是心灵的呼唤使你打开了窗户，那一刻我感觉我是世界少最幸福的人，你打开窗户对我喊：惊雷，这通天修为天塌地陷紫晶锤，虽然我不知道是什么意思，我就当作你向我表白吧！",
            "我可以再见你一面吗，我可以站远一点，不让你同事发现我。",
            "你跟他打完游戏了吧，也不知道他有没有在游戏里凶你。如果你不高兴了一定要告诉我哦，我会一直陪伴你的。今天厂长看我表现好，奖了我一百块钱奖金，我现在就给你打过去，给你买小乔的青蛇皮肤，别人有的你也会有。 ?",
            "你三天没回我的消息 在我孜孜不倦地骚扰下你终于舍得回我了 你说‘nmsl'我想 这一定是有什么含义吧 噢！我恍然大悟 原来是尼美舒利颗粒 他知道我关节炎 让我吃尼美舒利颗粒 他还是关心我的但是又不想显现的那么热情的 天啊他好高冷我好像更喜欢他了。",
            "你没再来找我了，我发了一条仅你可见也没任何回应，你的朋友圈每一条我都点了赞，也没引起你的注意，我不知道你有没有再想起我，是不是我等的还不够久。",
            "今天发工资了，我一个月工资1500，你猜我会给你多少？是不是觉得我会给你1200，自己留300吃饭？哈哈我1500都给你，因为厂里包吃包住。",
            "今早你又拉黑了我的微信，我很难过，还好我还有小号可以继续舔你，你没想到吧，你总得意的觉得自己有很多舔狗，不少我一个，但其实都只是我一个人而已。",
            "昨晚发现你用上了情侣头像，你的头像是一个女孩手牵着左边是一条秋田犬，犬=狗，而我是一条舔狗，是不是代表你的小手在牵着我呢？ ?",
            "今天你约我去陪你买衣服，尽管我知道只是因为我的身形像你异地的男朋友，比较好试衣服而已。买完衣服，寄快递写他名字的时候，看见你嘴角翘起幸福的笑来。那一刻，我多希望我可以也叫那个名字，哪怕只有一分钟！！",
            "你和他接吻的时候可以涂我送给你的口红吗？",
            "给你发了几千条消息，你终于把我拉黑了。我好开心，那是你对我的唯一回应。我哭了好久，终于等到你的回应了，你放心，我会继续爱你。",
            "哥们，求你和她说句话吧，这样她就不会那么难过了。",
            "今天把你的备注改成了对方正在输入...这样我就知道你不是不想回我，刚又给你发了消息，看到你在思考怎么回我，我就知道你和我一样，心里有我 ?。",
            "我存了半年的工资，给你买了一只lv，你对我说了一句你真好，我好开心。这是你第一次这么认可我，以前你都只对我说滚。今天晚上逛闲鱼，看到你把我送你的lv发布上去了。我想，你一定是在考验我，于是我用借呗里的钱把它买了下来，再次送给你，给你一个惊喜，我爱你。",
            "今天一早起来 想给你发信息 跟你分享了今天的早餐 今天的穿搭 还有今天的好心情，发了很多条信息给你，你回了我一个“滚”字我在想你一定是希望我们的感情像长江一样“不尽长江滚滚来”。",
            "在我一如既往的每天跟她问早安的时候，她今天终于回我了 我激动地问她我是不是今天第一个跟她说话的人 她说不是，是她男朋友把她叫起来退房的",
            "今天你没回我的消息，难得晴天，我翻你倒的垃圾，被我找到了一个避孕套，我知道，他来过，我赶紧把套套拿出来泡水喝，我知道，里面有你的味道。",
            "昨天你把我删了，我陷入了久久的沉思，我想这其中一定有什么含义，原来你是在欲擒故纵，嫌我不够爱你，无理取闹的你变得更加可爱了，我会坚守我对你的爱的，你放心好啦！么么哒！今天发工资了 发了1839  给你微信转了520  支付宝1314  还剩下5  傍晚给你发了很多消息你没回 刚弹你正在通话中 你让我别烦 别打扰你跟别人k  好吧没关系宝宝我爱你 所以我不生气 剩下5块我在小卖部买了你爱吃的老坛酸菜牛肉面 给你寄过去了 希望你保护好食欲 我去上班了爱你",
            "骗了父母，买了车票只身一人去见你，在你的城市我被骗了2000块钱。找到你一起吃了饭，看了电影。你说你要回寝室写要交的东西，我送你回去，找了个50块钱的小旅馆。当我下楼买东西的时候，我看到你上了一辆车。车没开，你和他热吻了5分钟。在那5分钟里，我想家想父母想打王者。",
            "你从来不说想我，聊天记录搜索了一下“想你”两个字全都是:“那波你怎么不上啊 你在想你妈呢”",
            "我最近越来越期待夜晚了，因为白天都没什么机会和你说话，只能憋到晚上和你说句晚安",
            "昨天我还是照常给你发了好多消息 今天你终于回了我五个字“烦不烦啊你” 你开始关心我觉不觉得烦了 我太感动了 受宠若惊的 不烦不烦 你天天骂我我都不会觉得你烦",
            "我用这一个月在小区当保安赚的2000元，给你买了一双dunk雪城，你对我说了一句谢谢，我好开心。这是你第一次对我说两个字，以前你都只对我说滚。今天早上逛闲鱼，看到了你把我送你的雪城发布上去了。我想，你一定是在考验我，于是我用花呗里的钱把它买了下来，再次送给你，给你一个惊喜，爱你。",
            "昨天你把我删了，我陷入了久久的沉思我想这其中一定有什么含义，原来你是在欲擒故纵，嫌我不够爱你，无理取闹的你变得更加可爱了，我会坚守我对你的爱的 你放心好啦！么么哒！",
            "你终于喊我双排了 让我拿我胜率最高的英雄 我一般都不玩嬴政的 因为胜率太高了怕掉 可是为了你我还是选了 你好像很开心给我发了句fw，我懂了 你是想夸夸我说我法王 你真好 我越来越喜欢你了！",
            "今天晚上玩ow，本来以为国王大道上没人，结果刚出出生点的时候被铁拳抓了，本来想反抗，铁拳说了一句老实点别动，我立刻就放弃了抵抗。因为我记得你说过，你喜欢老实人",
            "她好像从来没有主动说过爱我，我搜索了一下关键字“爱”，在我们的聊天记录里她只说过一次：你有爱奇艺会员吗？",
            "今天一大早就去帮她海底捞排队，她男朋友想吃海底捞，我要是去晚了的话排不上队，她男朋友吃不上海底捞的话又该骂她，我怕她扛不住，她男朋友骂人很凶的.",
            "今天你给了我一拳，因为我在你回宿舍的路上叫了一声honey，你不顾周围的劝阻也想揍我，虽然最后失败了，但我还是看到了你为我对抗世界的决心和勇气！",
            "宝宝 刚刚睡醒没看到你回我的消息 昨天睡觉梦到你换了情头 吓醒才意识过来是做梦 所以你为什么不回我的消息呢 这次不回我我下次要找什么理由再去找你呢 我委屈 我想你",
            "现在已经凌晨12点了，我望着手机屏幕迟迟没有她的消息：你知道吗？我等了一晚上你的消息。她终于回复我了：是我让你等的？",
            "我爸说再敢写舔狗日记就打断我的腿 幸好不是胳膊 这样我还能继续和你打字聊天 就算连胳膊也打断了 我的心里也只会有你的位置",
            "虽然很累，但是明天后天大后天我都喜欢你",
            "今天你依旧高冷，给你发了好多消息，都没回。可你越是这样，我越是喜欢你。在我不断的嘘寒问暖下，你终于不再矜持了，告诉我你拍照不好看了，骂sb。在我查遍了英语词典后，我终于明白了这两个字母的意思。s是sweet，b是baby，那么你一定是在叫我sweet baby了，我很感动。决定不跟你分手了。",
            "我坐在窗边一直发了三天 终于忍不住问为什么从来不回我消息 你秒回“也不想想你算什么东西”看到“想你”，我一下子就哭了 原来你心里是有我的",
            "每次我发了好几行的文字，你只回复了嗯，哦，啊，好的。我太感动了，无论我说什么你总这样对我百依百顺的，我怎么会有其他的要求呢。尤其每个夜晚，我说晚安，宝贝，总是等不到没有回复的晚安，原来你就这样让我彻夜难眠想你，欲擒故纵这招高明，一直拴住我的心，让我无法摆脱你，我离不开你的。",
            "今天没怎么说话，我找了半个小时的文案，发了条朋友圈，仅你可见，是想让你知道我喜欢你，私聊我咱们谈恋爱吧，结果你在底下评论：偷了偷了",
            "今天你来上班了，我抢着给你测体温，体温计居然坏了，这让我和你多呆了20秒钟，害得你迟到了，你很生气地走了，一句话都没留下。刚刚微信上给你道歉还给你发了200块钱红包，你很快速地领取了，但迟迟不回我一个字。我想你可能沉浸在感动中吧，我给你发了个句中午吃点好的。回复我的却是一个红色感叹号，红色代表爱情，你一定是不好意思说出口，才用这么温婉的方式表达你对我的爱，我也爱你。",
            "你醒了吧？可以回我消息了吗？我买了万通筋骨贴，你运动一个晚上腰很疼吧？今晚早点回家 我炖了排骨汤 累了一个晚上吧 没事我永远在家等你",
            "明天就周六了我知道你不上班，但是我怕你睡懒觉不吃早饭饿坏自己，我早晨4点去菜市场买了新鲜活鸡给你炖鸡汤，阿姨给我用箱子装了起来，我骑上我280买的电动车哼着小调回家，心想你一定会被我感动的，箱子半路开了，鸡跑了，拐到了一个胡同里，凌晨4点的胡同还有穿超短裙和大叔聊天的美女，不禁感叹这个世界变了，她问我找什么，…………。对不起，我爱你",
            "我好像从来没听过她对我说“爱你” 今天我搜了一下聊天记录，她只说过一次“我在做爱你等一下”",
            "想了很久终于想通了，你说孩子不是我的。没关系的宝贝，我愿意跟着你孩子姓。",
            "疫情已经持续了一个多月 你发了朋友圈 说想吃火锅 我想着现在外面没法吃火锅 跑去超市给你采购了一些火锅食材还有你最喜欢的海底捞底料 给你发消息说我在你小区门口 给你买了些东西 天气有点冷 我等了半天你都没有出现 也没有回我消息 我想你大概是睡觉呢 点开朋友圈看到你正在和别的女生双排王者 我把东西寄存在门卫 给你留言说我走了 你不爱我没关系 不可以饿着自己。",
            "我存了两个月的钱，给你买了一双倒勾，你对我说了一句谢谢，我好开心。这是你第一次对我说两个字，以前你都只对我说滚。今天晚上逛闲鱼，看到了你把我送你的倒勾发布上去了。我想，你一定是在考验我，于是我用借呗里的钱把它买了下来，再次送给你，给你一个惊喜，爱你",
            "你半天没理我了，我忍不住给你打了好几个电话，你终于接通了，跟我说“草”我觉得这肯定不是字面意思，我考虑的很久，草的下面是早，代表着你对我的爱犹如旭日东升的太阳绵绵不断。我不禁忍不住，流下了感动的泪水，我知道你肯定也喜欢我的吧！",
            "小时候抓周抓了个方向盘 爸妈都以为我长大了会当赛车手 最差也是个司机 没想到我长大了当了你的备胎",
            "她好像从来没有对我说过早安，我在我们的聊天记录里搜索了关键字：“早安”，她说过一次：我迟早安排人弄死你个逼崽子。",
            "我坐在窗边给你发了99条消息，你终于肯回我了，你说“发你妈啊”  我一下子就哭了，原来努力真的有用，你已经开始考虑想见我的妈妈了，你也是挺喜欢我的！",
            "昨天给你发了晚安，你没有回我，我知道你是害怕打扰我休息，于是就在朋友圈群发的晚安。我很开心",
            "我暗恋的人说眼睛疼 所以我买了瓶眼药水寄过去，但她却告诉我她有喜欢的人了 让我别再打扰，距离遥远顺丰都要三天才能到，可她为什么只用了一秒就把眼药水滴进了我眼睛里",
            "今天发工资了，我一个月工资800，你猜我会给你多少，是不是觉得我会给你1200 ，因为厂里全勤奖还有400，错了，我会再和工友借114凑够1314转给你。",
            "你没回我的消息， 我发了一条仅你可见也没任何回应 。我想你应该是在忙所以没时间理我 应该是我等的还不够久。",
            "今天我还是照常给你发消息，汇报日常工作，你终于回了我四个字：“嗯嗯，好的”你开始愿意敷衍我了，我太感动了受宠若惊。我愿意天天给你发消息。就算你天天骂我，我也不觉得烦。",
            "你昨天晚上又没会我的消息，在我孜孜不倦的骚扰下，你终于舍得回我了，你说“滚”，这其中一定有什么含义，我想了很久，滚是三点水，这代表你对我的思念也如滚滚流水一样汹涌，我感动哭了，不知道你现在在干嘛，我很想你。",
            "你说你想买口红，今天我去了叔叔的口罩厂做了一天的打包。拿到了两百块钱，加上我这几天省下的钱刚好能给你买一根小金条。即没有给我自己剩下一分钱，但你不用担心，因为厂里包吃包住。对了打包的时候，满脑子都是你，想着你哪天突然就接受我的橄榄枝了呢。而且今天我很棒呢，主管表扬我很能干，其实也有你的功劳啦，是你给了我无穷的力量。今天我比昨天多想你一点，比明天少想你一点。",
            "你说你想买AJ，今天我去了叔叔的口罩厂做了一天的打包。拿到了两百块钱，加上我这几天省下的钱刚好能给你买一个鞋盒。即没有给我自己剩下一分钱，但你不用担心，因为厂里包吃包住。对了打包的时候，满脑子都是你，想着你哪天突然就接受我的橄榄枝了呢。而且今天我很棒呢，主管表扬我很能干，其实也有你的功劳啦，是你给了我无穷的力量。今天我比昨天多想你一点，比明天少想你一点。",
            "听说你想要一套化妆品，我算了算，明天我去公司里面扫一天厕所，就可以拿到200块钱，再加上我上个月攒下来的零花钱，刚好给你买一套迪奥。",
            "刚从派出所出来，原因前几天14号情人节，我想送你礼物，我去偷东西的时候被抓了，我本来想反抗，警察说了一句老实点别动，我立刻就放弃了反抗，因为我记得你说过，你喜欢老实人。",
            "今天舔狗发工资了，他一个月工资1500，你猜我会收到多少？是不是觉得我会收到1500？哈哈，我会收到9000，因为我有6个舔狗。",
            "疫情不能出门，现在是早上八点，你肯定饿了吧。我早起做好了早餐来到你小区。保安大哥不让进。我给你打了三个电话你终于接了有病啊，我还睡觉呢，你小区门口等着吧。啊，我高兴坏了。她终于愿意吃我做的早餐了，她让我等她，啊！啊！啊！",
            "昨天你领完红包就把我删了，我陷入久久地沉思。我想这其中一定有什么含义，原来你是在欲擒故纵，嫌我不够爱你。无理取闹的你变得更加可爱了，我会坚守我对你的爱的。你放心好啦！今天发工资了，发了1850，给你微信转了520，支付宝1314，还剩下16。给你发了很多消息你没回。剩下16块我在小卖部买了你爱吃的老坛酸菜牛肉面，给你寄过去了。希望你保护好食欲，我去上班了爱你~~",
            "今天楼下早餐店卖的豆浆比你走的时候涨了五毛钱，我突然明白你不会回来了。",
            "他好像从来没有主动说过爱我我搜索了一下关键字\"爱\"在我们的聊天记录里他只说过一次你爱怎么想就怎么想", "听说你朋友说今天出门了，我打扮成精神小伙来找你，没想到你竟然对我说“给我爬，别过来”我当场就哭了，原来真心真的会感动人，你一定是知道，穿豆豆鞋走路脚会很累，让我爬是因为这样不会累着脚，其实你是喜欢我的吧",
            "昨天你把我删了 我陷入了久久的沉思 我想这其中一定有什么含义 原来你是在欲擒故纵 嫌我不够爱你 无理取闹的你变得更加可爱了 我会坚守我对你的爱的 你放心好啦！么么哒！",
            "今天发工资了，我一个月工资1500，你猜我会给你多少？是不是觉得我会给你1200，自己留300吃饭？哈哈，我1500都给你，因为公司包吃包住。",
            "我爸说再敢写舔狗日记就打断我的腿 幸好不是胳膊 这样我还能继续和你打字聊天，就算连胳膊也打断了，我的心里也只会有你的位置。",
            "我坐在窗边给你发了99条消息。你终于肯回我了，你说“你发你妈 烦不烦” 。我一下子就哭了，原来努力真的有用。你已经开始考虑想见我的妈妈了，你也是挺喜欢我的吧。",
            "我暗恋的人说眼睛疼 所以我买了瓶眼药水寄过去，但他却告诉我他有喜欢的人了 让我别再打扰，距离遥远顺丰都要两天才能到，可他为什么只用了一秒就把眼药水滴进了我眼睛里",
            "他从来不说想我 聊天记录搜索了一下“想你”两个字 全都是:“那波你怎么不上啊 你在想你妈呢”",
            "今天没怎么和你说话，我找了半个小时的文案，发了条朋友圈，仅你可见，是想让你知道我喜欢你，私聊我咱们谈恋爱吧，结果你在底下评论：偷了",
            "今天一早起来 想给你发信息 跟你分享了今天的早餐 今天的穿搭 还有今天的好心情，发了很多条信息给你，你回了我一个“滚”字 我在想 你一定是希望我们的感情像长江一样“不尽长江滚滚来”。",
            "你好像从来没有对我说过晚安，我在我们的聊天记录里搜索了关键字：“晚安”，你说过一次：我早晚安排人弄死你。",
            "今天我还是一样 给你讲述我的生活 发完最后一条消息的时候 我才发现后面都是感叹号 我反思了一下自己恍然大悟：你是想重新认识我.. 宝贝你可真爱我.. 我再一次给你发了验证消息",
            "我给你打了一通电话，你终于接了。听到了你发出啊啊啊啊的声音，你说你脚痛，我想你一定是很难受吧。电话还有个男的对你说“来换个姿势”，一定是在做理疗了。期待你早日康复，我好想你。",
            "吃饭前登录上游戏想打一局，发现你在线，赶快邀请你打排位。系统提示“不好意思，我现在不方便”，下一秒却显示你开局一分钟。我想了想，原来你是怕拖累我掉分，小傻瓜，我的星都是为你上的，但我还是好爱你这种温柔的暗示。",
            "今天我观战了一天你带别人打游戏，你们玩的很开心，我给你发了200多条消息，你说你没流量了就不回了，晚上你发了条说说没有人爱你，我连滚带爬评论了句有我在。你把我拉黑了，我给你打电话也无人接听。对不起我不该打扰到你的。我求求你再给我次当你好友的机会吧!",
            "她好像从来没有主动说过爱我，我搜索了一下关键字“爱”。在我们的聊天记录里，她只说过一次：爱奇艺会员借我一下",
            "晚上和你聊天，10点钟不到，你就说困了去睡觉了。现在凌晨1点钟，看到你给他的朋友圈点赞评论，约他明天去吃火锅。一定是你微信被盗了吧",
            "你扇了我一巴掌 我握着你的手说“怎么这么凉”",
            "你说你情头是一个人用的 空间上锁是因为你不喜欢玩空间 情侣空间是和兄弟开的 找你连麦时你说你在忙工作 每次聊天你都说在忙 你真是一个上进的好女孩 你真好 我好喜欢你",
            "前天是情人节，我想送你礼物，但是我没有钱，我去偷东西的时候被抓了，我本来想反抗，警察说了一句老实点别动，我立刻就放弃了抵抗，因为我记得你说过你喜欢老实人",
            "你就像楼下没开门的理发店一样冷漠，它不理发，你不理我",
            "今天天气有点冷，想偷你的心却还是没有成功 在床上的我现在的心情就像天气预报。说明天有雨，我都听成明天有你。",
            "你终于喊我双排了，让我拿我胜率最高的英雄， 我一般都不玩诸葛亮的，因为胜率太高了怕掉！可是为了你我还是选了！你好像很开心给我发了句fw，我懂了 你是想夸夸我说我法王 你真好 我越来越喜欢你了！",
            "今天嗓子发炎了特别难受 没忍住又找你说话了 刚开始你没理我 我连发了99+以后 你终于肯理我了 滚 你有病吧 有病就去看医生 我好感动 原来你还是关心我的 怕我更加严重还特意让我滚去 今天也是特别爱你的一天",
            "今天有个大哥在小区里抽烟，我跟他说公共场所禁止吸烟的。他说他抽的不是烟，是雪茄。他还骂我是土鳖，说我一个月工资也买不来那一支。我委屈 我想你over。",
            "今天心情很不好 但是我听说心情不好的时候吃甜食心情就会变好 所以我吃了很多甜食 心情却还是很糟糕。早上见了你一面之后 我才发现吃甜食也比不过你 很开心。over。",
            "今天天气很不错，太阳晒得我好想睡觉，然后我蹲到保安亭下点了根烟，我不想再做保安了，我把自己的心关起来锁在了小黑屋。我是一个不称职的保安，我抱不到你，也安不牢你的心。",
            "今天街上的人逐渐多了起来 大家好像都有同伴。我只能在保安亭里吃昨天剩下的小熊饼干。不知道你在干嘛呢，和谁一起。我委屈 我想你",
            "今天在给业主登记时候因为我不认字耽误了两分钟，被队长给骂了。他扣了我一百块钱，给我了一本破烂的字典让我认字。今天我学会了写你的名字，等我学会100个字就可以给你写情书了！",
            "今天打王者输了好多把，我将这些事情私信分享给你，但是你一个字都没有讲，我在想你是不是在忙?我头痛欲裂,终于在我给你发了几十条消息之后，你终于回了我一个脑子是不是有病?原来你还是关心我的，看到这句话，我的脑子一下就不疼了，今天也是爱你的一天。",
            "我坐在窗边抽了两根烟了，都过了5点了，我喜欢的人还没找我，我在想要不要给他发消息，想想还是先抽完这根烟，觉得自己很狼狈想点开相机看看自己，手滑点到了王者，那么，有人一起timi吗？",
            "昨天你把我删了 我看着红色感叹号陷入了久久的沉思 我想这其中一定有什么含义 红色红色 我明白了 红色代表热情 你对我很热情 你想和我结婚 我愿意",
            "你这几天断断续续给我发很多话我猜这一定是你对我的试探，在我再次孜孜不倦的骚扰你的情况下你终于跟我说了一句最长的话:“让我帮你算算你买棺材需要多少钱? \"我又陷入了沉思这一定有什么含义，我想了很久你竟然提到了我的棺材，没想到原来你已经想得那么长远了，为了和我在一起竟然想要殉情并且想和我在起直到我死你，还提到你要帮我算，原来我在你心中这么重要，我太感动了，真的，那你现在在干嘛我好想你。", "你三天没回我的消息 在我孜孜不倦地骚扰下你终于舍得回我了 你说‘nmsl’我想 这一定是有什么含义吧 噢！我恍然大悟 原来是尼美舒利颗粒 他知道我关节炎 让我吃尼美舒利颗粒 他还是关心我的但是又不想显现的那么热情的 天啊他好高冷我好像更喜欢他了",
            "我暗恋的人说眼睛疼 所以我买了瓶眼药水寄过去，但他却告诉我他有喜欢的人了 让我别再打扰，距离遥远顺丰都要两天才能到，可他为什么只用了一秒就把眼药水滴进了我眼睛里。",
            "昨天你把我删了 我陷入了久久的沉思 我想这其中一定有什么含义 你应该是欲擒故纵吧 嫌我不够爱你 突然觉得无理取闹的你变得更加可爱了 我会坚守我对你的爱 你放心好啦 这么一想 突然对我俩的未来更有期望了呢",
            "今天你也没有理我 你一定是怕我昨天熬夜太久 上午很困还要回你消息 想让我好好休息 真贴心 今天也是爱你的一天",
            "今天在楼上窗户上看见你和他在公园里接吻 我看见哭了出来 并打电话给你 想问问你为什么 但你说怎么了 声音是那么好听 于是我说 以后你和他接吻的时候 能不能用我送给你的口红啊",
            "最近你一直在跟别的女孩子打游戏她们辅助你我不放心她们能有我会舔吗?她们能在你三杀反秀的时候发干得漂亮吗?你从来不跟我打游戏我知道你怕带我输了影响你在我心里的地位一个男孩在自己心爱的女生面前总是唯唯诺诺的我只想告诉你就算你带我掉到铂金我也爱你",
            "今天天气很好阳光很好 想偷你的心却还是没有成功 在床上的我现在的心情就像天气预报 说明天有雨 我都听成明天有你",
            "今早你又拉黑了我的微信，我很难过，还好我还有小号可以继续舔你，你没想到吧，你总得意的觉得自己有很多舔狗，不少我一个，但其实都只是我一个人而已。 ",
            "今天又是无缘无故对我一顿大骂继续消失烦我我有病我闹我吵我一直给你打电话不停的打你永远都是挂断然后继续冷漠我想可能是我太主动了或许换个方法比较好下次我直接打你手机号吧可能没有时间看微信qq可能你也很忙吧没关系我还在等你.",
            "春天的阳光穿过树叶的缝隙，我知道那是太阳经过小孔成像到在我身上的影。我抬头望去只觉一阵恍惚，看见了黑色长发的你。我知道那是你穿过我的心留下的影，但我却不知道这是什么成像原理",
            "今天别人骂我了，说舔狗不配写日记，其实这个不算最难受的，最难受的是“你觉得他很有趣，他的一卡车舔狗也觉得”，突然好想问你我是第几号，但我害怕问了你就把我删了",
            "经过三个多月疫情终于结束了，我给你发消息显示被拉黑了 你还是这么贴心，怕疫情通过网络传播给我，原来你一直在默默保护着我。",
            "现在已经凌晨一点多了，我望着手机屏幕迟迟没有他的消息：你知道吗？我等了一晚上你的消息。他终于回复我了：是我让你等的？",
            "今天一早起来 想给你发信息 跟你分享了今天的早餐 今天的穿搭 还有今天的好心情，发了很多条信息给你，你回了我一个“滚”字 我在想 你一定是希望我们的感情像长江一样“不尽长江滚滚来”。",
            "今早睡觉前一直幻想起床后能收到你的“早安”，醒后打开手机，聊天框一片空白，我按耐不住想你的心情，激动的打出一个“早”。你说我昼伏夜出，是猪。oh 猪是多么可爱的生物啊~你一定是在夸我吧。我愿意！我愿意做你的猪宝宝。",
            "今天我鼓起勇气问她是喜欢狼狗还是喜欢奶狗 她说她喜欢狼狗 我问她觉得我是哪一种 她说我是土狗",
            "听着窗外稀稀拉拉的雨声 我忽然想到你对我说的话 对啊 生孩子本来就够痛苦了 还管是谁的干嘛呢",
            "今天天气阴雨绵绵 我的心情也不美丽 射手我怎么也跟不上你 你要我去跟着打野 打野我怎么也猜不透你 上路总是传来死亡讯息 法师总是姗姗来迟 团战的时候我应该在哪里 星星坠入海底 我不再喜欢你",
            "为了多挣点钱给你买喜欢的口红，昨天夜班，今天白班，36小时没睡的我想你想的睡不着觉，闭上眼睛全都是你的样子，我这才明白，原来动情的人，不配当保安。今天花一天工资买了安神补脑液，明天加班赚回来！over。",
            "昨天我还是照常给你发了好多消息 今天你终于回了我五个字“烦不烦啊你” 你开始关心我觉不觉得烦了 我太感动了 受宠若惊的 不烦不烦 你天天骂我我都不会觉得你烦",
            "你半天没理我了，我忍不住给你打了好几个电话，你终于接通了，跟我说“草”我觉得这肯定不是字面意思，我考虑的很久，草的下面是早，代表着你对我的爱犹如旭日东升的太阳绵绵不断。我不禁忍不住，流下了感动的泪水，我知道你肯定也喜欢我的吧！",
            "她好像从来没有主动找过我，我看了一下我们的聊天记录， 只有情人节那天给我发的入住酒店叫我帮她砍一刀。",
            "今天我早起了 终于可以帮你上分了 打了半天你早上醒了第一句话就是问我为什么输了一把 我连忙给你道歉认错 不过做你的工具人 真的太快乐了 以后我也要继续努力 争取做一个不漏油的工具人",
            "第一次，第一次，给你打50个电话就接了，然后我激动的一下给挂了，我委屈，我想你。",
            "今天，你把我删了，说玩玩我罢了，还说了，对不起把我删了，你人真好，犯了错还会和我道歉啊，我真的是越来越喜欢你了。",
            "你想我了吧？可以回我消息了吗？我买了万通筋骨贴 你运动一个晚上腰很疼吧？今晚早点回家 我炖了排骨汤 累了一个晚上吧 没事我永远在家等你",
            "今天和他玩吃鸡，他要去捡空投，载上其他两个人就走了，我在后面使劲地追，他好像是故意不让我上车，他知道我的技术，怕我一起去被打死，真是太懂我了，我更爱他了",
            "今天的我排位输了好多把，我将这些事情分享给你，但是你一个字都没有讲，我在想你是不是在忙?我头痛欲裂，终于在我给你发了几十条消息之后，你终于回了我一个脑子是不是有病?原来你还是关心我的, 看到这句话，我的脑子一下就不疼了，今天也是爱你的一天",
            "今天给一个女生发了十一条消息，她还是没有回我，我知道她在跟男生聊天，但我就是想用消息的数量刷一下存在感 。我做不了你微信聊天的主人公那我只能做你和他聊天的背景提示音。",
            "今天早上去你家楼下喊你你没理我我趴在你家窗户上看到你和别的女孩子一起睡在床上，我担心你没盖被子感冒急忙跑去买了感冒药，你把我喊住我以为你要让我进屋没想到你却让我再带一盒避孕药。",
            "有个女孩追了我三年 ，表白了两次我都给拒绝了，前几天她说她很想我，没想到今天居然大老远从坐飞机过来看我，这一次我没有拒绝她，她哭了，哭得像一个孩子，这也许就是大家所说的吹牛逼吧。",
            "中，恁真中，发消息嫩不回，真是冷酷嘞人，俺马上走，让恁看不到俺，骑上俺嘞洋车得，像俺这样嘞人，果然消失都中了。白佛了，保安俺也辞了，我能想到嫩喜多很，呵，毁灭吧，靠嫩娘。",
            "吃午饭前登录上王者荣耀想打一局，发现你在线，赶快邀请你打排位。系统提示“不好意思，我现在不方便约”，下一秒却显示你开局一分钟。我想了想，原来你是怕拖累我掉分，小傻瓜，我的星都是为你上的，但我还是好爱你这种温柔的暗示。 ",
            "今天我的女神终于跟我提“亲嘴”这两个字啦，她让我给她去买点亲嘴烧送过去，她老公想吃。",
            "我不知道怎么跟你相处 你有游戏要打 有觉要睡 朋友喊了还要去 帅哥找了你还要秒回 而我的生活只有想你想你想你 我怎么配得上跟你谈恋爱呢 我只是一个得不到爱情的小笨蛋罢了 ? ????",
            "今天很烦躁，走在街上以为没人，结果偷电瓶车被抓了，警察问我幕后主使是谁，我毫不犹豫地说出了你的名字，因为你说喜欢我常常把你挂在嘴边。",
            "今天下大雨，麦当劳39元可以吃金桶套餐，我为了占点便宜打着伞去了，最后在路上摔倒了，汉堡和鸡腿都湿了，真的想哭，社会边缘人的命运就是这样吗",
            "跟你网恋被我爸发现了，我爸说在发现我网恋就打断我的腿，幸好不是胳膊还可以继续和你聊天，就算连胳膊都打断了，我的心里还有你的位置",
            "外面下了好大的雨，我家里只有一把伞， 我拿给了他，他和她一起撑着伞走远了， 留下我一个人在屋檐下躲雨。 我知道他怕我淋雨，所以才没叫我一起走的，他真贴心！我更爱他了……",
            "昨天我还是照常给你发了好多消息 你回了我五个字“烦不烦啊你” 你开始关心我觉不觉得烦了 我太感动了 受宠若惊的 不烦不烦 你天天骂我我都不会觉得你烦",
            "夜深我给你打了一通电话，你终于接了。听到了你发出啊啊啊啊的声音，你说你脚痛，我想你一定是很难受吧。电话那边还有个男的对你说“来换个姿势”，一定是在做理疗了。期待你早日康复。",
        };

        public DogService(long GroupId) : base(GroupId)
        {
        }

        public DogService(long GroupId, long MemberId, string Keyword) : base(GroupId, MemberId, Keyword)
        {
        }

        public DogService(long GroupId, long MemberId, string Keyword, string Msg) : base(GroupId, MemberId, Keyword, Msg)
        {
        }
    }
}