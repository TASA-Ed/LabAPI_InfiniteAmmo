using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace LabAPI_InfiniteAmmo;

/// <summary>
/// 无限子弹事件处理器。
/// </summary>
public class InfiniteAmmoEvent : CustomEventsHandler {
    /// <inheritdoc />
    public override void OnPlayerChangedRole(PlayerChangedRoleEventArgs ev) {
        // 死人不配
        if (!ev.Player.IsAlive) return;
        // 切换角色时给每种子弹类型 10 发子弹，让玩家能换弹
        ev.Player.SetAmmo(ItemType.Ammo9x19, 10);
        ev.Player.SetAmmo(ItemType.Ammo12gauge, 10);
        ev.Player.SetAmmo(ItemType.Ammo44cal, 10);
        ev.Player.SetAmmo(ItemType.Ammo556x45, 10);
        ev.Player.SetAmmo(ItemType.Ammo762x39, 10);
    }

    /// <inheritdoc />
    public override void OnPlayerChangedItem(PlayerChangedItemEventArgs ev) {
        // 死人不配
        if (!ev.Player.IsAlive) return;
        // 更改手持物品时给每种子弹类型 10 发子弹，让玩家能换弹
        ev.Player.SetAmmo(ItemType.Ammo9x19, 10);
        ev.Player.SetAmmo(ItemType.Ammo12gauge, 10);
        ev.Player.SetAmmo(ItemType.Ammo44cal, 10);
        ev.Player.SetAmmo(ItemType.Ammo556x45, 10);
        ev.Player.SetAmmo(ItemType.Ammo762x39, 10);
    }

    /// <inheritdoc />
    public override void OnPlayerReloadingWeapon(PlayerReloadingWeaponEventArgs ev) {
        // 无限子弹
        // 没这个判断的话玩家拿 127 就会 BOOM ！
        if (ev.FirearmItem.Type is ItemType.GunSCP127 or ItemType.ParticleDisruptor) return;
        // 枪最大子弹 + 10
        ev.Player.SetAmmo(ev.FirearmItem.AmmoType, (ushort)(ev.FirearmItem.MaxAmmo + 10));
    }

    /// <inheritdoc />
    public override void OnPlayerDroppingAmmo(PlayerDroppingAmmoEventArgs ev) {
        // 禁止丢子弹
        ev.IsAllowed = false;
    }

    /// <inheritdoc />
    public override void OnPlayerPickingUpAmmo(PlayerPickingUpAmmoEventArgs ev) {
        // 玩家拾取子弹时始终为0
        // 缺一不可
        ev.AmmoPickup.Ammo = 0;
        ev.AmmoAmount = 0;
    }
}
