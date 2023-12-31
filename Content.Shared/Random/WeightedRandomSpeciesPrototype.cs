using Content.Shared.Humanoid.Prototypes;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.Dictionary;

namespace Content.Shared.Random;

/// <summary>
/// Linter-friendly version of weightedRandom for Species prototypes.
/// </summary>
[Prototype("weightedRandomSpecies")]
public sealed class WeightedRandomSpeciesPrototype : IWeightedRandomPrototype
{
    [IdDataField]
    public string ID { get; } = default!;

    [DataField("weights", customTypeSerializer: typeof(PrototypeIdDictionarySerializer<float, SpeciesPrototype>))]
    public Dictionary<string, float> Weights { get; } = new();
}
