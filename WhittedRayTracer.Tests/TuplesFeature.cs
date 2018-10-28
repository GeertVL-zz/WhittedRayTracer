using System;
using WhittedRayTracer.Tests.Helpers;
using Xunit;

namespace WhittedRayTracer.Tests
{
    public class TuplesFeature
    {
        [Fact(DisplayName = "A tuple with w=1.0 is a point")]        
        public void ATupleIsAPoint()
        {
            var a = (x: 4.3, y: -4.2, z: 3.1, w: 1.0);
            
            Assert.Equal(4.3, a.x);
            Assert.Equal(-4.2, a.y);
            Assert.Equal(3.1, a.z);
            Assert.Equal(1.0, a.w);
            
            Assert.True(a.IsAPoint());
            Assert.False(a.IsAVector());
        }

        [Fact(DisplayName = "A tuple with w=0.0 is a vector")]
        public void ATupleIsAVector()
        {
            var a = (x: 4.3, y: -4.2, z: 3.1, w: 0.0);
            
            Assert.Equal(4.3, a.x);
            Assert.Equal(-4.2, a.y);
            Assert.Equal(3.1, a.z);
            Assert.Equal(0.0, a.w);
            
            Assert.False(a.IsAPoint());
            Assert.True(a.IsAVector());
        }

        [Fact(DisplayName = "point describes tuple with w=1")]
        public void CreatingPoint()
        {
            var p = new Point(4, -4, 3);
            
            Assert.Equal(new Tuple(4, -4, 3, 1.0), p);
        }

        [Fact(DisplayName = "vector describes tuples with w=0")]
        public void CreatingVector()
        {
            var v = new Vector(4, -4, 3);
            
            Assert.Equal(new Tuple(4, -4, 3, 0.0), v);
        }

        [Fact(DisplayName = "Adding two tuples")]
        public void AddingTwoTuples()
        {
            var a1 = new Tuple(3, -2, 5, 1);
            var a2 = new Tuple(-2, 3, 1, 0);
            
            Assert.Equal(new Tuple(1, 1, 6, 1), a1 + a2);
        }

        [Fact(DisplayName = "Adding point with vector")]
        public void AddingPointerToAVector()
        {
            var p = new Point(2, -2, 4);
            var v = new Vector(1, -1, 3);

            var sum = p + v;
            
            Assert.True(sum.Value.IsAPoint());
        }

        [Fact(DisplayName = "Sum of two vectors is a vector")]
        public void SumTwoVectors()
        {
            var v1 = new Vector(1, -1, 3);
            var v2 = new Vector(2, -2, 1);

            var sum = v1 + v2;
            
            Assert.True(sum.Value.IsAVector());
        }

        [Fact(DisplayName = "Subtract Two Points")]
        public void SubtractTwoPoints()
        {
            var p1 = new Point(3, 2, 1);
            var p2 = new Point(5, 6, 7);
            
            Assert.Equal(new Vector(-2, -4, -6), p1 - p2);
        }

        [Fact(DisplayName = "Subtracting a vector from a point")]
        public void SubtractPointAndVector()
        {
            var p = new Point(3, 2, 1);
            var v = new Vector(5, 6, 7);
            
            Assert.Equal(new Point(-2, -4, -6), p - v);
        }

        [Fact(DisplayName = "Subtracting two vectors")]
        public void SubtractTwoVectors()
        {
            var v1 = new Vector(3, 2, 1);
            var v2 = new Vector(5, 6, 7);
            
            Assert.Equal(new Vector(-2, -4, -6), v1 - v2);
        }

        [Fact(DisplayName = "Subtracting a vector from the zero vector")]
        public void SubtractVectorAndZeroVector()
        {
            var zero = new Vector(0, 0, 0);
            var v = new Vector(1, -2, 3);
            
            Assert.Equal(new Vector(-1, 2, -3), zero - v);
        }

        [Fact(DisplayName = "Negating a tuple")]
        public void NegateTuple()
        {
            var a = new Tuple(1, -2, 3, -4);
            
            Assert.Equal(new Tuple(-1, 2, -3, 4), -a);
        }

        [Fact(DisplayName = "Multiplying a tuple by a scalar")]
        public void MultiplyTupleByScalar()
        {
            var a = new Tuple(1, -2, 3, -4);
            
            Assert.Equal(new Tuple(3.5, -7, 10.5, -14), a * 3.5);
        }

        [Fact(DisplayName = "Multiplying a tuple by a fraction")]
        public void MultiplyTupleByFraction()
        {
            var a = new Tuple(1, -2, 3, -4);
            
            Assert.Equal(new Tuple(0.5, -1, 1.5, -2), a * 0.5);
        }

        [Fact(DisplayName = "Dividing a tuple by a scalar")]
        public void DividingTupleByScalar()
        {
            var a = new Tuple(1, -2, 3, -4);
            
            Assert.Equal(new Tuple(0.5, -1, 1.5, -2), a / 2);
        }

        [Fact(DisplayName = "Magnitude of vector(1, 0, 0)")]
        public void MagnitudeOfVector100()
        {
            var v = new Vector(1, 0, 0);
            
            Assert.Equal(1, v.Magnitude());
        }
        
        [Fact(DisplayName = "Magnitude of vector(0, 1, 0)")]
        public void MagnitudeOfVector010()
        {
            var v = new Vector(0, 1, 0);
            
            Assert.Equal(1, v.Magnitude());
        }
        
        [Fact(DisplayName = "Magnitude of vector(0, 0, 1)")]
        public void MagnitudeOfVector001()
        {
            var v = new Vector(0, 0, 1);
            
            Assert.Equal(1, v.Magnitude());
        }
        
        [Fact(DisplayName = "Magnitude of vector(1, 2, 3)")]
        public void MagnitudeOfVector123()
        {
            var v = new Vector(1, 2, 3);
            
            Assert.Equal(Math.Sqrt(14), v.Magnitude());
        }
        
        [Fact(DisplayName = "Magnitude of vector(-1, -2, -3)")]
        public void MagnitudeOfVector_1_2_3()
        {
            var v = new Vector(-1, -2, -3);
            
            Assert.Equal(Math.Sqrt(14), v.Magnitude());
        }

        [Fact(DisplayName = "Normalizing vector(4, 0, 0) gives (1, 0, 0)")]
        public void NormalizingVector400Gives100()
        {
            var v = new Vector(4, 0, 0);
            
            Assert.Equal(new Vector(1, 0, 0), v.Normalize());
        }

        [Fact(DisplayName = "Normalizing vector(1, 2, 3)")]
        public void NormalizingVector123()
        {
            var v = new Vector(1, 2, 3);
            
            Assert.Equal(new Vector(1 / Math.Sqrt(14), 2 / Math.Sqrt(14), 3 / Math.Sqrt(14)), v.Normalize());
        }

        [Fact(DisplayName = "The magnitude of a normalized vector")]
        public void MagnitudeNormalizedVector()
        {
            var v = new Vector(1, 2, 3);
            var norm = v.Normalize();

            Assert.Equal(1, norm.Magnitude());
        }

        [Fact(DisplayName = "The dot product of two tuples")]
        public void DotProductTwoTuples()
        {
            var a = new Vector(1, 2, 3);
            var b = new Vector(2, 3, 4);
            
            Assert.Equal(20, a.Dot(b));
        }

        [Fact(DisplayName = "Cross product of two vectors")]
        public void CrossProductTwoTuples()
        {
            var a = new Vector(1, 2, 3);
            var b = new Vector(2, 3, 4);
            
            Assert.Equal(new Vector(-1, 2, -1), Vector.Cross(a, b));
            Assert.Equal(new Vector(1, -2, 1), Vector.Cross(b, a));
        }

        [Fact(DisplayName = "Projectile in the world tests")]
        public void ProjectileInWorld()
        {
            var p = new Projectile {Position = new Point(0, 1, 0), Velocity = new Vector(1, 1, 0).Normalize()};
            var w = new World {Gravity = new Vector(0, -0.1, 0), Wind = new Vector(-0.01, 0, 0)};

            var expected = new Projectile
            {
                Position = new Point(0.70710678118654746, 1.7071067811865475, 0), 
                Velocity = new Vector(0.69710678118654745, 0.60710678118654748, 0)
            };

            var actual = MotionHelper.Tick(w, p);
            
            Assert.Equal(expected.Position, actual.Position);
            Assert.Equal(expected.Velocity, actual.Velocity);
        }

        [Fact(DisplayName = "Colors are (red, green, blue) tuples")]
        public void ColorsAreRGB()
        {
            var c = new Color(-0.5, 0.4, 1.7);
            
            Assert.Equal(-0.5, c.Red);
            Assert.Equal(0.4, c.Green);
            Assert.Equal(1.7, c.Blue);
        }

        [Fact(DisplayName = "Adding colors")]
        public void AddingColors()
        {
            var a = new Color(0.9, 0.6, 0.75);
            var b = new Color(0.7, 0.1, 0.25);
            
            Assert.Equal(new Color(1.6, 0.7, 1), a + b);
        }

        [Fact(DisplayName = "Subtracting colors")]
        public void SubtractingColors()
        {
            var a = new Color(0.9, 0.6, 0.75);
            var b = new Color(0.7, 0.1, 0.25);
            
            Assert.Equal(new Color(0.2, 0.5, 0.5), a - b);
        }

        [Fact(DisplayName = "Multiplying a color by a scalar")]
        public void MultiplyingAColor()
        {
            var c = new Color(0.2, 0.3, 0.4);
            
            Assert.Equal(new Color(0.4, 0.6, 0.8), c * 2);
        }

        [Fact(DisplayName = "Multiplying colors")]
        public void MultiplyingColors()
        {
            var c1 = new Color(1, 0.2, 0.4);
            var c2 = new Color(0.9, 1, 0.1);
            
            Assert.Equal(new Color(0.9, 0.2, 0.04), c1 * c2);
        }
    }
}