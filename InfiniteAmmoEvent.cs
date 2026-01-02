using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace LabAPI_InfiniteAmmo
{
    public class InfiniteAmmoEvent : CustomEventsHandler
    {
        public override void OnPlayerDryFiringWeapon(PlayerDryFiringWeaponEventArgs ev)
        {
            ev.Player.SetAmmo(ev.FirearmItem.AmmoType, (ushort)(ev.Player.GetAmmo(ev.FirearmItem.AmmoType) + 1));
        }
        /// <summary>
        /// 禁止玩家掉落子弹
        /// </summary>
        /// <param name="ev">PlayerDroppingAmmoEventArgs</param>
        public override void OnPlayerDroppingAmmo(PlayerDroppingAmmoEventArgs ev)
        {
            ev.IsAllowed = false;
        }
    }
}
