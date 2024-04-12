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

namespace SCP_1
{
    public class Class1 : Plugin<Config>
    {
        public override string Name => "橘橘的硬币抽奖插件";
        public override string Author => "灯火橘Channel";
        public override Version Version => new Version(1, 0, 0);

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
            Log.Info("插件启动");
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.PickingUpItem -= handler.PlayerPickup;
            Exiled.Events.Handlers.Player.UsingItemCompleted -= handler.OnUseItem;
            Exiled.Events.Handlers.Player.FlippingCoin -= handler.OnUseCoin;
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
        public void OnUseCoin(FlippingCoinEventArgs e)
        {
            Log.Info("触发扔硬币事件");
            int luck = new Random().Next(1, 101);
            string itemname = "";
            if (luck < 5)
            {
                Log.Info("启用低概率事件");
                luck = new Random().Next(0, 2);
                if (luck == 0)
                {
                    e.Player.ShowHint("<color=#fff>你被硬币砸死了!</color>", 10);
                    e.Player.Kill(DamageType.CardiacArrest);
                    itemname = "硬币砸脸！";
                }
                else if (luck == 1)//变SCP
                {
                    int scpLuck = new Random().Next(0, 7);
                    if (scpLuck <= 0)//花生
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp173, RoleChangeReason.Respawn, RoleSpawnFlags.None);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp173</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp173,运气：{scpLuck}");
                    }
                    else if (scpLuck == 1)//老头
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp106, RoleChangeReason.Respawn, RoleSpawnFlags.None);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp106</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp106，运气：{scpLuck}");
                    }
                    else if (scpLuck == 2)//狗子
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp049, RoleChangeReason.Respawn, RoleSpawnFlags.None);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp049</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp049，运气：{scpLuck}");
                    }
/*                    else if (scpLuck == 3)//电脑
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp079, RoleChangeReason.Respawn, RoleSpawnFlags.None);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp079</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp079，，运气：{scpLuck}");
                    }*/
                    else if (scpLuck == 3)
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp939, RoleChangeReason.Respawn, RoleSpawnFlags.None);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp939</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp939，运气：{scpLuck}");
                    }
                    else if (scpLuck == 4)
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp096, RoleChangeReason.Respawn, RoleSpawnFlags.None);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp096</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp096，运气：{scpLuck}");
                    }
                    else if (scpLuck == 5)
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp3114, RoleChangeReason.Respawn, RoleSpawnFlags.None);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp3114</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp3114，运气：{scpLuck}");
                    }
                    else
                    {
                        e.Player.DropItems();
                        e.Player.RoleManager.ServerSetRole(RoleTypeId.Scp0492, RoleChangeReason.Respawn, RoleSpawnFlags.None);
                        e.Player.ShowHint("你变成了<color=#F4F245>Scp0492</color>", 10);
                        Log.Info($"{e.Player.Nickname}变成了Scp0492，运气：{scpLuck}");
                    }

                }
                else
                {
                    Log.Info("OK");
                }
            }
            if (luck >= 5 && luck < 21)//给物品
            {
                Log.Info("启用给物品事件");
                int itemluck = new Random().Next(0, 7);
                if (itemluck <= 0)
                {
                    e.Player.AddItem(ItemType.SCP500);
                    e.Player.AddItem(ItemType.Medkit);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP500</color>和<color=#E04747>医疗包</color>", 5);
                    e.Player.RemoveHeldItem();
                }
                else if (itemluck == 1)
                {
                    e.Player.AddItem(ItemType.SCP207);
                    e.Player.AddItem(ItemType.AntiSCP207);
                    e.Player.ShowHint("你获得了<color=#F4F245>SCP207</color>和<color=#E04747>SCP207?</color>", 5);
                    e.Player.RemoveHeldItem();
                }
                else if (itemluck == 2)
                {
                    e.Player.AddItem(ItemType.GrenadeFlash);
                    e.Player.AddItem(ItemType.GrenadeHE);
                    e.Player.ShowHint("你获得了<color=#F4F245>闪光弹</color>和<color=#E04747>手雷</color>", 5);
                    e.Player.RemoveHeldItem();
                }
                else if (itemluck == 3)
                {
                    e.Player.AddItem(ItemType.Jailbird);
                    e.Player.AddItem(ItemType.SCP207);
                    e.Player.ShowHint("你获得了<color=#F4F245>囚鸟</color>和<color=#E04747>SCP207</color>", 5);
                    e.Player.RemoveHeldItem();
                }
                else if (itemluck == 4)
                {
                    e.Player.AddItem(ItemType.GunA7);
                    e.Player.AddItem(ItemType.SCP1853);
                    e.Player.ShowHint("你获得了<color=#F4F245>A7手枪</color>和<color=#E04747>SCP1853</color>", 5);
                    e.Player.RemoveHeldItem();
                }
                else if (itemluck == 5)
                {
                    e.Player.AddItem(ItemType.Adrenaline);
                    e.Player.AddItem(ItemType.Adrenaline);
                    e.Player.ShowHint("你获得了<color=#F4F245>肾上腺素*2</color>", 5);
                    e.Player.RemoveHeldItem();
                }
                else if (itemluck == 6)
                {
                    e.Player.AddItem(ItemType.Radio);
                    e.Player.AddItem(ItemType.SCP1576);
                    e.Player.ShowHint("你获得了<color=#F4F245>对讲机</color>和<color=#E04747>SCP1576</color>", 5);
                    e.Player.RemoveHeldItem();
                }
            }
            if (luck >= 20 && luck < 41)
            {
                e.Player.ShowHint("什么都没有发生", 10);
            }
            if (luck >= 40 && luck < 61)//开启核弹
            {
                e.Player.ShowHint("启用核弹事件（未完成）");
                Log.Info("启用核弹事件");//未生效
                ActivatingWarheadPanelEventArgs e1 = new ActivatingWarheadPanelEventArgs(e.Player, true);
            }
            if(luck >= 60 && luck < 81)//关灯
            {
                e.Player.ShowHint("启用关灯事件（未完成）");
                Log.Info("启用关灯事件");//未生效
                RoomLightController controller = RoomLightController.Instances[0]; 
                TurningOffLightsEventArgs e1 = new TurningOffLightsEventArgs(controller, 10.0f, true);
            }
            if(luck >= 80 && luck < 91)//启用随机事件
            {
                Log.Info("启用物品掉落+传送事件");
                int dropluck = new Random().Next(0, 3);
                if(dropluck == 0)
                {
                    e.Player.DropItems();
                    e.Player.ShowHint("你的物品掉落了", 10);
                    Log.Info($"玩家{e.Player.Nickname}的物品掉落，dropluck={dropluck}");
                }
                else if(dropluck == 1)
                {
                    e.Player.ShowHint("你被传送了！未完成）", 10);
                    Log.Info($"玩家{e.Player.Nickname}被传送了，dropluck={dropluck}");
                }
                else if (dropluck == 2)
                {
                    e.Player.ClearItems();
                    e.Player.ShowHint("你的物品被清空了！", 10);
                    Log.Info($"玩家{e.Player.Nickname}的的物品被清空了，dropluck={dropluck}");
                }

            }
            if(luck >= 91 && luck < 95)
            {
                e.Player.RemoveHeldItem();
                e.Player.ShowHint("硬币消失了！");
                Log.Info($"玩家{e.Player.Nickname}的硬币消失了！");
            }
            else
            {
                
                Log.Info("已启用抽奖事件");

            }
            //待写抽奖项：交换两个玩家的背包，随机传送，交换两个玩家的位置
            Log.Info($"玩家{e.Player.Nickname}抽中了{itemname},{luck}");
        }
    }
}
