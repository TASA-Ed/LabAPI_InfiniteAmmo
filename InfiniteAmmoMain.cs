using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using System;

namespace LabAPI_InfiniteAmmo;

/// <summary>
/// 无限子弹 插件。
/// </summary>
public class InfiniteAmmoMain : Plugin
{
    /// <summary>
    /// 单例模式。
    /// </summary>
    public static InfiniteAmmoMain Singleton { get; private set; }

    /// <summary>
    /// 插件名称。
    /// </summary>
    public override string Name => "Infinite Ammo Plugin";
    /// <summary>
    /// 插件描述。
    /// </summary>
    public override string Description => "Grant players infinite ammunition";
    /// <summary>
    /// 插件作者。
    /// </summary>
    public override string Author => "TASA-Ed Studio";
    /// <summary>
    /// 插件版本。
    /// </summary>
    public override Version Version => new (1, 0, 0, 0);

    /// <summary>
    /// 需要的 LabApi 版本。
    /// </summary>
    public override Version RequiredApiVersion => new (LabApiProperties.CompiledVersion);

    /// <summary>
    /// 自定义事件处理器。
    /// </summary>
    public InfiniteAmmoEvent Events { get; private set; }

    // 启用插件。
    public override void Enable()
    {
        Singleton = this;

        Events = new InfiniteAmmoEvent();

        CustomHandlersManager.RegisterEventsHandler(Events);
    }

    // 禁用插件。
    public override void Disable()
    {
        CustomHandlersManager.UnregisterEventsHandler(Events);

        Events = null;

        Singleton = null;
    }
}
