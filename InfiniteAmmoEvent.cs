using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace LabAPI_InfiniteAmmo;

/// <summary>
/// 无限子弹事件处理器。
/// </summary>
public class InfiniteAmmoEvent : CustomEventsHandler
{
    /// <summary>
    /// 初始子弹
    /// </summary>
    /// <param name="ev">PlayerReloadingWeaponEventArgs</param>
    public override void OnPlayerChangedRole(PlayerChangedRoleEventArgs ev)
    {
        // 死人不配
        if (!ev.Player.IsAlive) return;
        // 给每种子弹类型 1 发子弹，让玩家能换弹
        ev.Player.SetAmmo(ItemType.Ammo9x19, 1);
        ev.Player.SetAmmo(ItemType.Ammo12gauge, 1);
        ev.Player.SetAmmo(ItemType.Ammo44cal, 1);
        ev.Player.SetAmmo(ItemType.Ammo556x45, 1);
        ev.Player.SetAmmo(ItemType.Ammo762x39, 1);
    }

    /// <summary>
    /// 无限子弹
    /// </summary>
    /// <param name="ev">PlayerReloadingWeaponEventArgs</param>
    public override void OnPlayerReloadingWeapon(PlayerReloadingWeaponEventArgs ev)
    {
        // 没这个判断的话玩家拿 127 就会 BOOM ！
        if (ev.FirearmItem.Type is ItemType.GunSCP127 or ItemType.ParticleDisruptor) return;
        // 枪最大子弹 + 1
        ev.Player.SetAmmo(ev.FirearmItem.AmmoType, (ushort)(ev.FirearmItem.MaxAmmo + 1));
    }

    /// <summary>
    /// 禁止玩家掉落子弹
    /// </summary>
    /// <param name="ev">PlayerDroppingAmmoEventArgs</param>
    public override void OnPlayerDroppingAmmo(PlayerDroppingAmmoEventArgs ev)
    {
        ev.IsAllowed = false;
    }

    /// <summary>
    /// 玩家拾取子弹时始终为0
    /// </summary>
    /// <param name="ev">PlayerPickingUpAmmoEventArgs</param>
    public override void OnPlayerPickingUpAmmo(PlayerPickingUpAmmoEventArgs ev)
    {
        // 缺一不可
        ev.AmmoPickup.Ammo = 0;
        ev.AmmoAmount = 0;
    }
}
