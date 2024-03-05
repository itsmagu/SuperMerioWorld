// ReSharper disable InconsistentNaming
using System;
using System.Runtime.CompilerServices;

namespace SuperMerioWorld.sys;

public struct IVector2(int x = 0, int y = 0) : IEquatable<IVector2>
{
    public IVector2(int both) : this(both, both){ }
    public int x { get; set; } = x;
    public int y { get; set; } = y;
    public static IVector2 Zero = default;
    public static IVector2 One = new IVector2(1, 1);
    public static IVector2 Up = new IVector2(1, 0);
    public static IVector2 Right = new IVector2(0, 1);
    public override string ToString(){
        return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
    }
    // Time for some deep C# witchcraft
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IVector2 operator +(IVector2 left, IVector2 right){
        left.x += right.x;
        left.y += right.y;
        return left;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IVector2 operator -(IVector2 left, IVector2 right){
        left.x -= right.x;
        left.y -= right.y;
        return left;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IVector2 operator -(IVector2 value){
        return Zero - value;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IVector2 operator *(IVector2 left, IVector2 right){
        left.x *= right.x;
        left.y *= right.y;
        return left;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IVector2 operator *(IVector2 left, int right){
        left.x *= right;
        left.y *= right;
        return left;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IVector2 operator /(IVector2 left, IVector2 right){
        left.x /= right.x;
        left.y /= right.y;
        return left;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IVector2 operator /(IVector2 left, int right){
        left.x /= right;
        left.y /= right;
        return left;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IVector2 operator %(IVector2 left, IVector2 right){
        left.x %= right.x;
        left.y %= right.y;
        return left;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(IVector2 left, IVector2 right){
        return (left.x == right.x) && (left.y == right.y);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(IVector2 left, IVector2 right){
        return !(left == right);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(IVector2 other){
        return x == other.x && y == other.y;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj){
        return obj is IVector2 other && Equals(other);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode(){
        return HashCode.Combine(x, y);
    }
}