using Xunit;

namespace WhittedRayTracer.Tests
{
    public class TuplesFeature
    {
        [Fact(DisplayName = "A tuple with w=1.0 is a point")]        
        public void ATupleWithW1IsAPoint()
        {
            var a = (x: 4.3, y: -4.2, z: 3.1, w: 1.0);
            
            Assert.Equal(4.3, a.x);
            Assert.Equal(-4.2, a.y);
            Assert.Equal(3.1, a.z);
            Assert.Equal(1.0, a.w);
            
            Assert.True(a.IsAPoint());
            Assert.False(a.IsAVector());
        }
    }
}