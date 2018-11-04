using Xunit;

namespace WhittedRayTracer.Tests
{
    public class MatricesFeature
    {
        [Fact(DisplayName = "Constructing and inspecting a 4x4 matrix")]
        public void ConstructingInspectingMatrix()
        {
            var m = new Matrix(4, 4)
            {
                All = new[,] {{1, 2, 3, 4}, {5.5, 6.5, 7.5, 8.5}, {9, 10, 11, 12}, {13.5, 14.5, 15.5, 16.5}}
            };
            
            Assert.Equal(1, m[0,0]);
            Assert.Equal(4, m[0,3]);
            Assert.Equal(5.5, m[1,0]);
            Assert.Equal(7.5, m[1,2]);
            Assert.Equal(11, m[2,2]);
            Assert.Equal(13.5, m[3,0]);
            Assert.Equal(15.5, m[3,2]);
        }

        [Fact(DisplayName = "A 2x2 matrix ought to be representable")]
        public void A2x2MatrixRepresentable()
        {
            var m = new Matrix(2, 2)
            {
                All = new double[,] {{-3, 5}, {1, -2}}
            };
            
            Assert.Equal(-3, m[0,0]);
            Assert.Equal(5, m[0,1]);
            Assert.Equal(1, m[1,0]);
            Assert.Equal(-2, m[1,1]);
        }

        [Fact(DisplayName = "A 3x3 matrix ought to be representable")]
        public void A3x3MatrixRepresentable()
        {
            var m = new Matrix(3, 3)
            {
                All = new double[,] {{-3, 5, 0}, {1, -2, -7}, {0, 1, 1}}
            };
            
            Assert.Equal(-3, m[0,0]);
            Assert.Equal(-2, m[1,1]);
            Assert.Equal(1, m[2,2]);
        }

        [Fact(DisplayName = "Matrix equality with identical matrices")]
        public void MatrixEquality()
        {
            var a = new Matrix(4, 4)
            {
                All = new double[,] {{1,2,3,4}, {2,3,4,5}, {3,4,5,6}, {4,5,6,7}}
            };
            
            var b = new Matrix(4, 4)
            {
                All = new double[,] {{1,2,3,4}, {2,3,4,5}, {3,4,5,6}, {4,5,6,7}}
            };
            
            Assert.True(a.Equals(b));
        }

        [Fact(DisplayName = "Matrix equality with different matrices")]
        public void MatrixEqualityWithDifferentMatrices()
        {
            var a = new Matrix(4, 4)
            {
                All = new double[,] {{0,2,3,4}, {2,3,4,5}, {3,4,5,6}, {4,5,6,7}}
            };
            
            var b = new Matrix(4, 4)
            {
                All = new double[,] {{1,2,3,4}, {2,3,4,5}, {3,4,5,6}, {4,5,6,7}}
            };
            
            Assert.False(a.Equals(b));            
        }

        [Fact(DisplayName = "Multiplying two matrices")]
        public void MultiplyingTwoMatrices()
        {
            var a = new Matrix(4, 4)
            {
                All = new double[,] {{1,2,3,4}, {2,3,4,5}, {3,4,5,6}, {4,5,6,7}}
            };
            
            var b = new Matrix(4, 4)
            {
                All = new double[,] {{0,1,2,4}, {1,2,4,8}, {2,4,8,16}, {4,8,16,32}}
            };
            
            var expected = new Matrix(4, 4)
            {
                All = new double[,] {{24,49,98,196},{31,64,128,256},{38,79,158,316},{45,94,188,376}}
            };
            
            Assert.Equal(expected, a * b);
        }

        [Fact(DisplayName = "A matrix multiplied by a tuple")]
        public void MultiplyMatrixTuple()
        {
            var a = new Matrix(4,4)
            {
                All = new double[,] {{1,2,3,4},{2,4,4,2},{8,6,4,1},{0,0,0,1}}
            };
            var b = new Tuple(1,2,3,1);
            
            var expected = new Tuple(18,24,33,1);
            
            Assert.Equal(expected, a * b);
        }

        [Fact(DisplayName = "Multiplying a matrix by the identity")]
        public void MultiplyingMatrixByIdentity()
        {
            var a = new Matrix(4, 4)
            {
                All = new double[,] {{0,1,2,4},{1,2,4,8},{2,4,8,16},{4,8,16,32}}
            };

            var actual = a * Matrix.Identity;
            
            Assert.Equal(a, actual);
        }
    }
}