using System;

public sealed class Rational
{
    public Rational(Int32 num)
    {

    }

    // Single 타입에서 Rational 타입으로 변환한다.
    public Rational(Single num) { }

    // Rational 타입에서 Int32 타입으로 변환한다.
    public Int32 ToInt32() {
        return new Int32();
    }

    // Rational 타입에서 Single 타입으로 변환한다.
    public Single ToSingle()
    {
        return new Single();
    }

    // Int32 타입으로부터 Rational 타입을 암묵적으로 만들도록 한다.
    public static implicit operator Rational(Int32 num)
    {
        return new Rational(num);
    }

    // Single 타입으로부터 Rational 타입을 암묵적으로 만들도록 한다.
    public static implicit operator Rational(Single num)
    {
        return new Rational(num);
    }

    // Rational 타입에서 Int32 타입으로 명시적 캐스팅을 할 수 있게 한다.
    public static explicit operator Int32(Rational r)
    {
        return r.ToInt32();
    }

    // Rational 타입에서 Single 타입으로 명시적 캐스팅을 할 수 있게 한다.
    public static explicit operator Single(Rational r)
    {
        return r.ToSingle();
    }
}