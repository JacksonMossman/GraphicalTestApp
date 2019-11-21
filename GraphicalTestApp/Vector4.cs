using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;
        
      
        public Vector4(float X, float Y, float Z, float W)
        {
            x = X;
            y = Y;
            Z = Z;
            w = W;

        }
        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }


        }
        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public float Z
        {
            get
            {
                return Z;
            }
            set
            {
                Z = value;
            }
        }
        public float W
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }
        public float Magnitude(Vector4 input)
        {
            return (float)Math.Sqrt(x * input.X + y * input.Y + Z * input.Z + W * input.W);
        }
        public float Distance(Vector4 input)
        {
            float DiffX = x - input.x;
            float DiffY = y - input.y;
            float DiffZ = Z - input.Z;
            float DiffW = w - input.w;
            return (float)Math.Sqrt(DiffX * DiffX + DiffY * DiffY + DiffZ * DiffZ + DiffW * DiffW);
        }
        public float DistanceSq(Vector4 input)
        {
            return (float)Math.Pow(Distance(input), 2);
        }
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x * rhs,
                               lhs.y * rhs,
                               lhs.Z * rhs,
                               lhs.W * rhs);
        }
        public static Vector4 operator *(float rhs, Vector4 lhs)
        {
            return new Vector4(lhs.x * rhs,
                               lhs.y * rhs,
                               lhs.Z * rhs,
                               lhs.W * rhs);
        }
        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x / rhs,
                               lhs.y / rhs,
                               lhs.Z / rhs,
                               lhs.W / rhs);
        }
        public static Vector4 operator /(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs / rhs.X,
                              lhs / rhs.Y,
                              lhs / rhs.Z,
                              lhs / rhs.W);
        }
        public static Vector4 operator -(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x - rhs,
                               lhs.y - rhs,
                               lhs.Z - rhs,
                               lhs.W - rhs);
        }
        public static Vector4 operator +(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x + rhs,
                               lhs.y + rhs,
                               lhs.Z + rhs,
                               lhs.W + rhs);
        }
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.X,
                               lhs.y + rhs.Y,
                               lhs.Z + rhs.Z,
                               lhs.W + rhs.W);
        }
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.X,
                               lhs.y - rhs.Y,
                               lhs.Z - rhs.Z,
                               lhs.W - rhs.W);
        }

        public Vector4 Cross(Vector4 Input)
        {
            float varOne = (y * Input.Z) - (Z * Input.y);
            float varTwo = (Z * Input.x) - (x * Input.Z);
            float varThree = (x * Input.y) - (y * Input.x);

            Vector4 Phil = new Vector4(varOne, varTwo, varThree, 0);
            return Phil;
        }
        public float Dot(Vector4 input)
        {

            return (x * input.X + y * input.Y + Z * input.Z + W * input.W);
        }
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            Z /= m;
        }
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + Z * Z + w * w);
        }
    }
}

