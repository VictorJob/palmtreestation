using Content.Shared.FixedPoint;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Shared.Bed.Sleep;

/// <summary>
/// Added to entities when they go to sleep.
/// </summary>
[NetworkedComponent, RegisterComponent, AutoGenerateComponentPause(Dirty = true)]
public sealed partial class SleepingComponent : Component
{
    /// <summary>
    /// How much damage of any type it takes to wake this entity.
    /// </summary>
    [DataField("wakeThreshold")]
    public FixedPoint2 WakeThreshold = FixedPoint2.New(4); // Palmtree change - crit patients should be operable

    /// <summary>
    ///     Cooldown time between users hand interaction.
    /// </summary>
    [DataField("cooldown")]
    [ViewVariables(VVAccess.ReadWrite)]
    public TimeSpan Cooldown = TimeSpan.FromSeconds(60f); // Palmtree change - sleeping now requires the user to wait a minute, no one sleeps instantly.

    [DataField("cooldownEnd", customTypeSerializer:typeof(TimeOffsetSerializer))]
    [AutoPausedField]
    public TimeSpan CoolDownEnd;

    [DataField("wakeAction")] public EntityUid? WakeAction;
}
