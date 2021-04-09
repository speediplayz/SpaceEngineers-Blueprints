using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Blueprints
{
    public class Vector3
    {
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        public double x, y, z;
        public double length;
        public double thetaXY;
        public double thetaXZ;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            CalculatePolar();
        }
		
		public Vector3(Vector3 v1)
		{
			this.x = v1.x;
			this.y = v1.y;
			this.z = v1.z;
			CalculatePolar();
		}

        public void CalculatePolar()
        {
            length = Math.Sqrt((x * x) + (y * y) + (z * z));
            thetaXZ = Math.Atan2(z, x);
            thetaXY = Math.Atan2(Math.Sqrt(x*x+z*z), y);
        }

        public void CalculateCartesian()
        {
            x = length * Math.Sin(thetaXY) * Math.Cos(thetaXZ);
            y = length * Math.Sin(thetaXY) * Math.Sin(thetaXZ);
            z = length * Math.Cos(thetaXY);
        }

        public void SetCartesian(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            CalculatePolar();
        }

        public void SetPolar(double length, double thetaXY, double thetaXZ)
        {
            this.length = length;
            this.thetaXY = thetaXY;
            this.thetaXZ = thetaXZ;
            CalculateCartesian();
        }

        public void Rotate(double thetaXY, double thetaXZ)
        {
            this.thetaXY += thetaXY;
            this.thetaXZ += thetaXZ;
            CalculateCartesian();
        }

        public void Extend(double length)
        {
            this.length += length;
            CalculateCartesian();
        }

        public Vector3 Clone()
        {
            return new Vector3(x, y, z);
        }

        public double Distance(Vector3 to)
        {
            return Math.Sqrt((to.x - x) * (to.x - x) + (to.y - y) * (to.y - y) + (to.z - z) * (to.z - z));
        }

        public void Multiply(double scale)
        {
			length *= scale;
			CalculateCartesian();
        }

        public void Normalize()
        {
			length = 1;
			CalculateCartesian();
        }

        public void Translate(double x, double y, double z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
			CalculatePolar();
        }

        public void Add(Vector3 v1)
        {
            this.x += v1.x;
            this.y += v1.y;
            this.z += v1.z;
			CalculatePolar();
        }

        public void Subtract(Vector3 v1)
        {
            this.x -= v1.x;
            this.y -= v1.y;
            this.z -= v1.z;
			CalculatePolar();
        }
		
		public Vector3 Cross(Vector3 v1)
		{
			return new Vector3(this.y * v1.z - this.z * v1.y, this.z * v1.x - this.x * v1.z, this.x * v1.y - this.y * v1.x);
		}

        //Vector3 Functions

        public static double Dot(Vector3 v1, Vector3 v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        public static Vector3 Normalized(Vector3 v1)
        {
            return Vector3.FromPolar(1, v1.thetaXY, v1.thetaXZ);
        }

        public static Vector3 FromPolar(double length, double thetaXY, double thetaXZ)
        {
            return new Vector3(length * Math.Sin(thetaXY) * Math.Cos(thetaXZ), length * Math.Sin(thetaXY) * Math.Sin(thetaXZ), length * Math.Cos(thetaXY));
        }

        public static Vector3 Add(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 Subtract(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static double Distance(Vector3 v1, Vector3 v2)
        {
            return Math.Sqrt((v2.x-v1.x)*(v2.x-v1.x)+(v2.y-v1.y)*(v2.y-v1.y)+(v2.z-v1.z)*(v2.z-v1.z));
        }

        public static Vector3 Multiply(Vector3 v1, double scale)
        {
            return new Vector3(v1.x * scale, v1.y * scale, v1.z * scale);
        }
		
		public static Vector3 Cross(Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
		}
    }
}
