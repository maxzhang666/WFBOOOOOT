using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WFBooooot.IOT.Extension;

namespace WFBooooot.IOT.Service.Warframe
{
    public class WFTranslator
    {
        private Dictionary<string /*type*/, Translator> dictTranslators = new Dictionary<string, Translator>();
        private Dictionary<string, Translator> searchwordTranslator = new Dictionary<string, Translator>();
        private Translator invasionTranslator = new Translator();
        private Translator alertTranslator = new Translator();
        private List<string> weapons = new List<string>();
        private WFApi translateApi = GetTranslateApi();

        public WFTranslator()
        {
            dictTranslators.Add("All", new Translator());
            dictTranslators.Add("WM", new Translator());

            foreach (var dict in translateApi.Dict)
            {
                var type = dict.Type;
                if (!dictTranslators.ContainsKey(type))
                {
                    dictTranslators.Add(type, new Translator());
                }

                dictTranslators["All"].AddEntry(dict.En, dict.Zh);
                dictTranslators[type].AddEntry(dict.En, dict.Zh);
            }

            foreach (var sale in translateApi.Sale)
            {
                if (!searchwordTranslator.ContainsKey("Word"))
                {
                    searchwordTranslator.Add("Word", new Translator());
                }

                if (!searchwordTranslator.ContainsKey("Item"))
                {
                    searchwordTranslator.Add("Item", new Translator());
                }

                searchwordTranslator["Word"].AddEntry(sale.Zh.Format(), sale.Search);
                searchwordTranslator["Item"].AddEntry(sale.Search, sale.Zh);
            }

            foreach (var invasion in translateApi.Invasion)
            {
                invasionTranslator.AddEntry(invasion.En, invasion.Zh);
            }

            foreach (var alert in translateApi.Alert)
            {
                alertTranslator.AddEntry(alert.En, alert.Zh);
            }

            foreach (var riven in translateApi.Riven)
            {
                weapons.Add(riven.Name.Format());
            }

            foreach (var modifier in translateApi.Modifier)
            {
                if (!dictTranslators.ContainsKey("Modifier"))
                {
                    dictTranslators.Add("Modifier", new Translator());
                }

                dictTranslators["Modifier"].AddEntry(modifier.en, modifier.zh);
            }
        }

        private static WFApi GetTranslateApi()
        {
            var alerts = GHttpHelper.Http.Get<Alert[]>(
                "https://cdn.jsdelivr.net/gh/Richasy/WFA_Lexicon/WF_Alert.json");
            var dicts = GHttpHelper.Http.Get<Dict[]>(
                "https://cdn.jsdelivr.net/gh/Richasy/WFA_Lexicon/WF_Dict.json");
            var invasions = GHttpHelper.Http.Get<Invasion[]>(
                "https://cdn.jsdelivr.net/gh/Richasy/WFA_Lexicon/WF_Invasion.json");
            var sales = GHttpHelper.Http.Get<Sale[]>(
                "https://cdn.jsdelivr.net/gh/Richasy/WFA_Lexicon/WF_Sale.json");
            var riven = GHttpHelper.Http.Get<Riven[]>(
                "https://cdn.jsdelivr.net/gh/Richasy/WFA_Lexicon/WF_Riven.json");
            var relic = GHttpHelper.Http.Get<Relic[]>(
                "https://cdn.jsdelivr.net/gh/Richasy/WFA_Lexicon/WF_Relic.json");
            var modifier = GHttpHelper.Http.Get<Modifier[]>(
                "https://cdn.jsdelivr.net/gh/Richasy/WFA_Lexicon/WF_Modifier.json");
            var translateApi = new WFApi
            {
                Alert = alerts, Dict = dicts, Invasion = invasions, Relic = relic, Riven = riven, Sale = sales, Modifier = modifier
            };
            return translateApi;
        }

        public List<string> GetSimilarItem(string word)
        {
            Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(word);
            var distancelist = new SortedSet<StringInfo>();
            foreach (var sale in translateApi.Sale)
            {
                var distance = lev.DistanceFrom(sale.Zh.Format());
                distancelist.Add(new StringInfo { LevDistance = distance, Name = sale.Zh});
            }
            
            return distancelist.Where(dis => dis.LevDistance != 0).Take(5).Select(info => info.Name).ToList();
        }

        public List<Relic> GetRelicInfo(string word)
        {
            return translateApi.Relic.Where(relic => relic.Name.Format().Contains(word)).ToList();
        }

        public void TranslateEvents(List<Event> events)
        {
            foreach (var @event in events)
            {
                @event.description = dictTranslators["All"].Translate(@event.description);
            }
        }

        public string TranslateSearchWord(string source)
        {
            return searchwordTranslator["Word"].Translate(source);
        }

        public void TranslateInvasion(WFInvasion invasion)
        {
            TranslateReward(invasion.attackerReward);
            TranslateReward(invasion.defenderReward);
            invasion.node = TranslateNode(invasion.node);
        }

        private void TranslateReward(Defenderreward reward)
        {
            foreach (var item in reward.countedItems)
            {
                item.type = invasionTranslator.Translate(item.type);
            }

            foreach (var t in reward.countedItems)
            {
                t.type = alertTranslator.Translate(t.type);
            }
        }

        private void TranslateReward(Attackerreward reward)
        {
            foreach (var item in reward.countedItems)
            {
                item.type = invasionTranslator.Translate(item.type);
            }

            foreach (var t in reward.countedItems)
            {
                t.type = alertTranslator.Translate(t.type);
            }
        }

        private string TranslateNode(string node)
        {
            var strings = node.Split('(');
            var nodeRegion = strings[1].Split(')')[0];
            return strings[0] + dictTranslators["Star"].Translate(nodeRegion);
        }

        public bool ContainsWeapon(string weapon)
        {
            return weapons.Contains(weapon);
        }

        public void TranslateAlert(WFAlert alert)
        {
            var mission = alert.Mission;
            mission.Node = TranslateNode(mission.Node);
            mission.Type = dictTranslators["Mission"].Translate(mission.Type);
            TranslateReward(mission.Reward);

            void TranslateReward(Reward reward)
            {
                foreach (var item in reward.CountedItems)
                {
                    item.Type = alertTranslator.Translate(item.Type);
                }

                for (var i = 0; i < reward.Items.Length; i++)
                {
                    reward.Items[i] = alertTranslator.Translate(reward.Items[i]);
                }
            }
        }

        public void TranslateSyndicateMission(List<SyndicateMission> missions)
        {
            foreach (var mission in missions)
            {
                if (mission.jobs.Length == 0)
                {
                    if (mission.nodes.Length != 0)
                    {
                        for (var i = 0; i < mission.nodes.Length; i++)
                        {
                            mission.nodes[i] = TranslateNode(mission.nodes[i]);
                        }
                    }
                }
                else
                {
                    if (mission.syndicate == "Ostrons" || mission.syndicate == "Solaris United")
                    {
                        foreach (var job in mission.jobs)
                        {
                            for (int i = 0; i < job.rewardPool.Length; i++)
                            {
                                var reward = job.rewardPool[i];
                                var item = reward;
                                var count = "";
                                if (!reward.Contains("Relic"))
                                {
                                    item = Regex.Replace(reward, @"\d", "").Replace("X", "").Replace(",", "").Replace("BP", "Blueprint").Trim();
                                    count = Regex.Replace(reward, @"[^\d]*", "");
                                }
                                else
                                {
                                    item = item.Replace("Relic", "").Replace("Lith", "古纪").Replace("Meso", "前纪").Replace("Neo", "中纪").Replace("Axi", "后纪"); // 这是暴力写法 我懒了 真的
                                }

                                var sb = new StringBuilder();
                                if (count.Length != 0)
                                {
                                    sb.Append($"{count}X");
                                }

                                sb.Append(dictTranslators["All"].Translate(item));
                                job.rewardPool[i] = sb.ToString();
                            }
                        }
                    }
                }
            }
        }

        public void TranslateSortie(Sortie sortie)
        {
            foreach (var variant in sortie.variants)
            {
                variant.node = TranslateNode(variant.node).Replace("Plains of Eidolon", "夜灵平野"); // 这个不在翻译api里
                variant.missionType = dictTranslators["Mission"].Translate(variant.missionType);
                variant.modifier = dictTranslators["Modifier"].Translate(variant.modifier);
            }

            sortie.boss = dictTranslators["Word"].Translate(sortie.boss);
        }

        public void TranslateFissures(List<Fissure> fissures)
        {
            foreach (var fissure in fissures)
            {
                fissure.node = TranslateNode(fissure.node);
                fissure.tier = dictTranslators["Word"].Translate(fissure.tier);
                fissure.missionType = dictTranslators["Mission"].Translate(fissure.missionType);
            }
        }

        public void TranslateVoidTrader(VoidTrader trader)
        {
            trader.location = TranslateNode(trader.location).Replace("Relay", "中继站");
            foreach (var inventory in trader.inventory)
            {
                inventory.item = dictTranslators["All"].Translate(inventory.item);
            }
        }

        public void TranslateWMOrder(WMInfo info, string searchword)
        {
            foreach (var iteminset in info.include.item.items_in_set.Where(word => word.url_name == searchword))
            {
                iteminset.zh.item_name = searchwordTranslator["Item"].Translate(searchword);
            }

            foreach (var order in info.payload.orders)
            {
                switch (order.order_type)
                {
                    case "buy":
                        order.order_type = "收购";
                        break;
                    case "sell":
                        order.order_type = "出售";
                        break;
                }

                switch (order.user.status)
                {
                    case "ingame":
                        order.user.status = "游戏内在线";
                        break;
                    case "online":
                        order.user.status = "WM在线";
                        break;
                    case "offline":
                        order.user.status = "离线";
                        break;
                }
            }
        }

        public void TranslateWMOrderEx(WMInfoEx info, string searchword)
        {
            info.info.enName = info.orders.First().itemName;
            info.info.zhName = searchwordTranslator["Item"].Translate(searchword);

            foreach (var order in info.orders)
            {
                switch (order.order_Type)
                {
                    case "buy":
                        order.order_Type = "收购";
                        break;
                    case "sell":
                        order.order_Type = "出售";
                        break;
                }

                switch (order.status)
                {
                    case "ingame":
                        order.status = "游戏内在线";
                        break;
                    case "online":
                        order.status = "WM在线";
                        break;
                    case "offline":
                        order.status = "离线";
                        break;
                }
            }
        }
    }
}