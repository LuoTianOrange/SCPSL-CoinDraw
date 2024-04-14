using Exiled.API.Features;
using Exiled;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI.Events;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;
using System;
using PlayerRoles;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Map;
using CommandSystem.Commands.RemoteAdmin;
using PluginAPI.Core.Zones;
using System.Runtime.InteropServices;
using CommandSystem;
using RemoteAdmin;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using Exiled.Events.EventArgs.Warhead;
using Exiled.Events.Patches.Events.Scp106;
using System.Threading;
using Exiled.API.Extensions;

namespace SCP_1
{
    public class Class1 : Plugin<Config>
    {
        public override string Name => "橘橘的硬币抽奖插件";
        public override string Author => "灯火橘Channel";
        public override Version Version => new Version(1, 0, 3);

        private EventHandlers handler;
        public override void OnEnabled()
        {
            base.OnEnabled();
            handler = new EventHandlers();
            //拾取物品事件
            Exiled.Events.Handlers.Player.PickingUpItem += handler.PlayerPickup;
            //使用物品事件
            Exiled.Events.Handlers.Player.UsingItemCompleted += handler.OnUseItem;
            //使用硬币事件
            Exiled.Events.Handlers.Player.FlippingCoin += handler.OnUseCoin;
            Exiled.Events.Handlers.Player.Joined += handler.OnJoinPlayers;
            Log.Info("插件启动");
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.PickingUpItem -= handler.PlayerPickup;
            Exiled.Events.Handlers.Player.UsingItemCompleted -= handler.OnUseItem;
            Exiled.Events.Handlers.Player.FlippingCoin -= handler.OnUseCoin;
            Exiled.Events.Handlers.Player.Joined -= handler.OnJoinPlayers;
            Log.Info("Error");
        }
    }
    public class EventHandlers
    {
        public void PlayerPickup(PickingUpItemEventArgs e)
        {
            if (e.Pickup.Type == ItemType.Coin)
            {

            }
        }
        public void OnUseItem(UsingItemCompletedEventArgs e)
        {
            if (e.Item.Type == ItemType.Coin)
            {

            }
        }
        public async void OnUseCoin(FlippingCoinEventArgs e)
        {
            var random = new Random();
            Log.Info("触发扔硬币事件");
            int luck = random.Next(0, 101);
            string itemname = "";
            if (luck < 3)
            {
                Log.Info("启用低概率事件");
                luck = random.Next(0, 2);
                if (luck == 0)
                {
                    e.Player.ShowHint("<color=#fff>你被硬币砸死了!</color>", 10);
                    e.Player.Kill(DamageType.Unknown);
                    itemname = "硬币砸脸！";
                }
                else if (luck == 1)//变SCP
                {
                    int scpLuck = random.Next(0, 7);
                    if (scpLuck <= 0)//花生
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp173, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp173</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp173,运气：{scpLuck}");
                    }
                    else if (scpLuck == 1)//老头
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp106, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp106</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp106，运气：{scpLuck}");
                    }
                    else if (scpLuck == 2)//狗子
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp049, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp049</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp049，运气：{scpLuck}");
                    }
                    /*                    else if (scpLuck == 3)//电脑
                                        {
                                            e.Player.DropItems();
                                            e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp079, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                                            e.Player.ShowHint("你变成了<color=#F4F245>Scp079</color>", 10);
                                            Log.Info($"{e.Player.Nickname}变成了Scp079，，运气：{scpLuck}");
                                        }*/
                    else if (scpLuck == 3)
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp939, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp939</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp939，运气：{scpLuck}");
                    }
                    else if (scpLuck == 4)
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp096, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp096</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp096，运气：{scpLuck}");
                    }
                    else if (scpLuck == 5)
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp3114, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp3114</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp3114，运气：{scpLuck}");
                    }
                    else if(scpLuck == 6)
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp0492, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp0492</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp0492，运气：{scpLuck}");
                    }
                    else
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp0492, RoleChangeReason.Respawn, RoleSpawnFlags.UseSpawnpoint);
                        // 设置player的当前物品
                        e.Player.CurrentItem = e.Player.AddItem(ItemType.GunCOM15);
                        e.Player.Health = 800;
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp0492</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了拿枪的Scp0492");
                    }

                }
                else
                {
                    Log.Info("OK");
                }
            }
            else if (luck >= 3 && luck < 36)//给物品
            {
                //Log.Info("启用给物品事件");
                int itemluck = random.Next(0, 34);
                if (itemluck <= 0)
                {
                    e.Player.AddItem(ItemType.SCP500);
                    e.Player.AddItem(ItemType.Medkit);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP500</color>和<color=#E04747>医疗包</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了SCP500和医疗包");
                }
                else if (itemluck == 1)
                {
                    e.Player.AddItem(ItemType.SCP207);
                    e.Player.AddItem(ItemType.AntiSCP207);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP207</color>和<color=#E04747>SCP207?</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了SCP207和SCP207?");
                    
                }
                else if (itemluck == 2)
                {
                    e.Player.AddItem(ItemType.GrenadeFlash);
                    e.Player.AddItem(ItemType.GrenadeHE);
                    e.Player.ShowHint("你获得了<color=#F4F245>闪光弹</color>和<color=#E04747>手雷</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了闪光弹和手雷");
                    
                }
                else if (itemluck == 3)
                {
                    e.Player.AddItem(ItemType.Jailbird);
                    e.Player.AddItem(ItemType.SCP207);
                    e.Player.ShowHint("你获得了<color=#F4F245>囚鸟</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了囚鸟");
                    
                }
                else if (itemluck == 4)
                {
                    e.Player.AddItem(ItemType.GunA7);
                    e.Player.AddItem(ItemType.SCP1853);
                    e.Player.ShowHint("你获得了<color=#F4F245>A7手枪</color>和<color=#E04747>SCP1853</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了A7手枪和SCP1853");
                    
                }
                else if (itemluck == 5)
                {
                    e.Player.AddItem(ItemType.Adrenaline);
                    e.Player.AddItem(ItemType.Adrenaline);
                    e.Player.ShowHint("你获得了<color=#F4F245>肾上腺素*2</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了肾上腺素*2");
                    
                }
                else if (itemluck == 6)
                {
                    e.Player.AddItem(ItemType.Radio);
                    e.Player.AddItem(ItemType.SCP1576);
                    e.Player.ShowHint("你获得了<color=#F4F245>对讲机</color>和<color=#E04747>SCP1576</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了对讲机和SCP1576");
                    
                }
                else if(itemluck == 7)
                {
                    e.Player.AddItem(ItemType.Lantern);
                    e.Player.ShowHint("你获得了<color=#F4F245>手提灯</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了手提灯");
                    
                }
                else if(itemluck == 8)
                {
                    e.Player.AddItem(ItemType.Flashlight);
                    e.Player.ShowHint("你获得了<color=#F4F245>手电筒</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了手电筒");
                    
                }
                else if(itemluck == 9)
                {
                    e.Player.AddItem(ItemType.Coin);
                    e.Player.AddItem(ItemType.Coin);
                    e.Player.ShowHint("真幸运！你获得了两个<color=#F4F245>硬币</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了硬币");
                    
                }
                else if (itemluck == 10)
                {
                    e.Player.AddItem(ItemType.KeycardJanitor);
                    e.Player.ShowHint("你获得了<color=#F4F245>清洁工卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了清洁工卡");
                    
                }
                else if (itemluck == 11)
                {
                    e.Player.AddItem(ItemType.KeycardScientist);
                    e.Player.ShowHint("你获得了<color=#F4F245>科学家卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了科学家卡");
                    
                }
                else if (itemluck == 12)
                {
                    e.Player.AddItem(ItemType.SCP018);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP018</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了SCP018");
                    
                }
                else if (itemluck == 13)
                {
                    e.Player.AddItem(ItemType.Painkillers);
                    e.Player.ShowHint("你获得了<color=#F4F245>止痛药</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了止痛药");
                    
                }
                else if (itemluck == 14)
                {
                    e.Player.AddItem(ItemType.SCP244a);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP244a</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了SCP244a");
                    
                }
                else if (itemluck == 15)
                {
                    e.Player.AddItem(ItemType.SCP330);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP330</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了SCP330");
                    
                }
                else if (itemluck == 16)
                {
                    e.Player.AddItem(ItemType.ArmorCombat);
                    e.Player.ShowHint("你获得了<color=#F4F245>战术护甲</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了战术护甲");
                    
                }
                else if (itemluck == 17)
                {
                    e.Player.AddItem(ItemType.ArmorLight);
                    e.Player.ShowHint("你获得了<color=#F4F245>轻型护甲</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了轻型护甲");
                    
                }
                else if (itemluck == 18)
                {
                    e.Player.AddItem(ItemType.ArmorHeavy);
                    e.Player.ShowHint("你获得了<color=#F4F245>重型护甲</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了重型护甲");
                    
                }
                else if (itemluck == 19)
                {
                    e.Player.AddItem(ItemType.GunFSP9);
                    e.Player.ShowHint("你获得了<color=#F4F245>FSP-9冲锋枪</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了FSP-9冲锋枪");
                }
                else if (itemluck == 20)
                {
                    e.Player.AddItem(ItemType.SCP2176);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP2176</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了SCP2176");
                }
                else if (itemluck == 21)
                {
                    e.Player.AddItem(ItemType.SCP268);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP268</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了SCP268");
                }
                else if (itemluck == 22)
                {
                    e.Player.AddItem(ItemType.KeycardResearchCoordinator);
                    e.Player.ShowHint("你获得了<color=#F4F245>研究主管卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了研究主管卡");
                }
                else if (itemluck == 23)
                {
                    e.Player.AddItem(ItemType.KeycardGuard);
                    e.Player.ShowHint("你获得了<color=#F4F245>警卫钥匙卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了警卫钥匙卡");
                }
                else if (itemluck == 24)
                {
                    e.Player.AddItem(ItemType.KeycardMTFPrivate);
                    e.Player.ShowHint("你获得了<color=#F4F245>MTF列兵卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了MTF列兵卡");
                }
                else if (itemluck == 25)
                {
                    e.Player.AddItem(ItemType.KeycardResearchCoordinator);
                    e.Player.ShowHint("你获得了<color=#F4F245>收容工程师卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了收容工程师卡");
                }
                else if (itemluck == 26)
                {
                    e.Player.AddItem(ItemType.KeycardMTFOperative);
                    e.Player.ShowHint("你获得了<color=#F4F245>MTF特工卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了MTF特工卡");
                }
                else if (itemluck == 27)
                {
                    e.Player.AddItem(ItemType.KeycardMTFCaptain);
                    e.Player.ShowHint("你获得了<color=#F4F245>MTF指挥官卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了MTF指挥官卡");
                }
                else if (itemluck == 28)
                {
                    e.Player.AddItem(ItemType.KeycardFacilityManager);
                    e.Player.ShowHint("你获得了<color=#F4F245>设施总监卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了设施总监卡");
                }
                else if (itemluck == 29)
                {
                    e.Player.AddItem(ItemType.KeycardO5);
                    e.Player.ShowHint("你获得了<color=#F4F245>黑卡</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了黑卡");
                }
                else if (itemluck == 30)
                {
                    e.Player.AddItem(ItemType.MicroHID);
                    e.Player.ShowHint("你获得了<color=#18E2EF>电炮</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了电炮");
                }
                else if (itemluck == 31)
                {
                    e.Player.AddItem(ItemType.GunCOM15);
                    e.Player.ShowHint("你获得了<color=#18E2EF>COM15</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了COM15");
                }
                else if (itemluck == 32)
                {
                    e.Player.AddItem(ItemType.GunCOM18);
                    e.Player.ShowHint("你获得了<color=#18E2EF>COM18</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了COM18");
                }
                else if (itemluck == 33)
                {
                    e.Player.AddItem(ItemType.Coin);
                    e.Player.ShowHint("真幸运！你获得了一个<color=#F4F245>硬币</color>", 5);
                    Log.Info($"玩家{e.Player.Nickname}获得了硬币");

                }
            }
            else if (luck >= 36 && luck < 46)
            {
                e.Player.ShowHint("什么都没有发生", 10);
            }
            else if (luck >= 46 && luck < 48)//开启核弹
            {
                int StartWarhead = random.Next(0,3);
                if(StartWarhead == 0)
                {
                    e.Player.ShowHint("启用核弹事件!(假)");
                    Log.Info("启用核弹事件");
                    Warhead.Start();
                    await Task.Delay(5000);
                    Warhead.Stop();
                }
                else if (StartWarhead == 1)
                {
                    e.Player.ShowHint("启用核弹事件!(假)");
                    Log.Info("启用核弹事件");
                    Warhead.Start();
                    await Task.Delay(10000);
                    Warhead.Stop();
                }
                else if(StartWarhead == 2)
                {
                    e.Player.ShowHint("启用核弹事件!(真)");
                    Log.Info("启用核弹事件");
                    Warhead.Start();
                }
                else
                {
                    Log.Error("核弹事件发生错误");
                }

            }
            else if (luck >= 48 && luck < 52)//启用关灯事件
            {
                Log.Info("启用关灯事件");
                var zone = (MapGeneration.FacilityZone)random.Next(1, 5);
                e.Player.ShowHint($"在<color=#E04747>{zone.DisplayName()}</color>启用关灯事件");
                foreach (RoomLightController instance in RoomLightController.Instances)
                {
                    if (instance.Room.Zone == zone)
                    {
                        instance.ServerFlickerLights(20.0f);
                    }
                }
            }
            else if (luck >= 52 && luck < 65)//启用随机事件
            {
                //Log.Info("启用随机事件");
                int dropluck = random.Next(0, 3);
                if (dropluck == 0)
                {
                    e.Player.DropItems();
                    e.Player.ShowHint("你的物品掉落了", 10);
                    Log.Info($"玩家{e.Player.Nickname}的物品掉落，dropluck={dropluck}");
                }
                else if (dropluck == 1)
                {
                    e.Player.RandomTeleport(typeof(Room));
                    e.Player.ShowHint("你被传送了", 10);
                    Log.Info($"玩家{e.Player.Nickname}被传送了，dropluck={dropluck}");
                }
                else if (dropluck == 2)
                {
                    e.Player.ClearItems();
                    e.Player.ShowHint("你的物品被清空了！", 10);
                    Log.Info($"玩家{e.Player.Nickname}的物品被清空了，dropluck={dropluck}");
                }
                else if(dropluck == 3)
                {
                    e.Player.EnableEffect(EffectType.SeveredHands);
                    e.Player.ShowHint("你的手被切掉了！", 10);
                    Log.Info($"玩家{e.Player.Nickname}的手被切掉了，dropluck={dropluck}");
                }
                else if(dropluck == 4)
                {
                    e.Player.PlaceTantrum();
                    e.Player.ShowHint("你吃了一顿华莱士！", 10);
                }
                else if(dropluck == 5)
                {
                    e.Player.Hurt(50);
                    e.Player.ShowHint("你受到了很严重的伤害！", 10);
                }
                else if (dropluck == 6)
                {
                    e.Player.Heal(100);
                    e.Player.ShowHint("你感觉很好！", 10);
                }
                else if(dropluck == 7)
                {
                    int n = random.Next(1, 100);
                    e.Player.Hurt(n);
                    e.Player.ShowHint($"你受到了{n}点伤害！", 10);
                }
            }
            else if (luck >= 65 && luck < 95)
            {
                e.Player.RemoveHeldItem();
                e.Player.ShowHint("硬币消失了！");
                Log.Info($"玩家{e.Player.Nickname}的硬币消失了！");
            }
            else
            {
                e.Player.ShowHint("什么都没有发生", 10);
                Log.Info("已启用抽奖事件");
            }
            //待写抽奖项：交换两个玩家的背包，随机传送，交换两个玩家的位置
            Log.Info($"玩家{e.Player.Nickname}抽中了{itemname},{luck}");
        }
        public async void OnJoinPlayers(JoinedEventArgs e)
        {
            await Task.Delay(5000);
            Log.Info(e.Player.UserId);
            if (e.Player.UserId == "76561198364808907@steam")
            {
                string name = e.Player.RankName = "胖乎乎的大橘猫";
                e.Player.RankColor = "orange";
                Log.Info($"已修改称号：{name}");
            }
            if (e.Player.UserId == "76561198184016687@steam")
            {
                string name = e.Player.RankName = "好吃的食物";
                e.Player.RankColor = "magenta";
                Log.Info($"已修改称号：{name}");
            }
            Log.Info("玩家加入");
        }
    }

    public static class Extend
    {
        public static string DisplayName(this MapGeneration.FacilityZone zone)
        {
            var displayName = string.Empty;
            switch (zone)
            {
                case MapGeneration.FacilityZone.LightContainment:
                    displayName = "轻收容区";
                    break;
                case MapGeneration.FacilityZone.HeavyContainment:
                    displayName = "重收容区";
                    break;
                case MapGeneration.FacilityZone.Entrance:
                    displayName = "办公区大门和广播室";
                    break;
                case MapGeneration.FacilityZone.Surface:
                    displayName = "地表";
                    break;
            }
            return displayName;
        }
    }
}
