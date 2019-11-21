using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;
    
        //static refernce to identity matrix
        public Vector3() : this(0f, 0f, 0f)
        {

        }
        public Vector3(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
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
                return z;
            }
            set
            {
                z = value;
            }
        }
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector3 operator *(float rhs, Vector3 lhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector3 operator -(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        }
        public static Vector3 operator -(Vector3 rhs, Vector3 lhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static Vector3 operator +(Vector3 rhs, Vector3 lhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }
        public float Distance(Vector3 input)
        {
            float DiffX = x - input.x;
            float DiffY = y - input.y;
            float DiffZ = z - input.z;
            return (float)Math.Sqrt(DiffX * DiffX + DiffY * DiffY + DiffZ * DiffZ);
        }
        public float DistanceSq(Vector3 input)
        {
            return (float)Math.Pow(Distance(input), 2);
        }
        public float Dot(Vector3 input)
        {

            return (x * input.x + y * input.y + z * input.z);
        }
        public Vector3 Cross(Vector3 Input)
        {
            float varOne = (y * Input.z) - (z * Input.y);
            float varTwo = (z * Input.x) - (x * Input.z);
            float varThree = (x * Input.y) - (y * Input.x);

            Vector3 Phil = new Vector3(varOne, varTwo, varThree);
            return Phil;
        }
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
        }
        public Vector3 GetNormalized()
        {
            return (this / Magnitude());
        }

        public float Angle(Vector3 input)
        {
            Vector3 a = GetNormalized();
            Vector3 b = GetNormalized();
            return (float)Math.Acos(a.Dot(b));

        }
        public override string ToString()
        {
            return "[" + x + "," + y + "," + z + "]";
        }
    }
}
