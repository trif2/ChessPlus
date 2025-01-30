using System.Text.Json.Serialization;

namespace ChessPlus.Positions
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    [JsonDerivedType(typeof(ClassicPosition), "classic")]
    [JsonDerivedType(typeof(HexPosition), "hex")]
    public abstract class Position
    {
        public abstract int Y { get; set; }
        public abstract int X { get; set; }
        public abstract int Q { get; set; }
        public abstract int R { get; set; }
        public abstract int S { get; set; }
        public abstract Position AddDirection(object direction, int scalar);
    }
}
