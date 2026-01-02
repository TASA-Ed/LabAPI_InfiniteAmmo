using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using System;

namespace LabAPI_InfiniteAmmo
{
    /// <summary>
    /// 无限子弹 插件。
    /// </summary>
    public class InfiniteAmmoMain : Plugin
    {
        /// <summary>
        /// 插件信息。
        /// </summary>
        public override string Name => "Infinite Ammo Plugin";
        public override string Description => "Give Player Infinite Ammo";
        public override string Author => "TASA-Ed Studio";

        /// <summary>
        /// 插件版本。
        /// </summary>
        public override Version Version => new (0, 1, 0, 0);

        /// <summary>
        /// 需要的 LabApi 版本。
        /// </summary>
        public override Version RequiredApiVersion => new (LabApiProperties.CompiledVersion);

        /// <summary>
        /// Events handler object.
        /// </summary>
        public InfiniteAmmoEvent Events { get; } = new ();

        public override void Enable()
        {
            CustomHandlersManager.RegisterEventsHandler(Events);
        }

        public override void Disable()
        {
            CustomHandlersManager.UnregisterEventsHandler(Events);
        }
    }
}
