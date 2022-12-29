using DesktopWidgets.SerializationSchema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWidgets {
    internal class Utilities {
        public static Point JsonToPoint(SerializationSchema.Vector2 vector) {
            return new Point(vector.X, vector.Y);
        }

        public static Size JsonToSize(SerializationSchema.Vector2 vector) {
            return new Size(vector.X, vector.Y);
        }

        public static Vector2 PointToJson(Point point) {
            var vec = new Vector2();
            
            vec.X = point.X;
            vec.Y = point.Y;

            return vec;
        }

        public static Vector2 SizeToJson(Size size) {
            var vec = new Vector2();

            vec.X = size.Width;
            vec.Y = size.Height;

            return vec;
        }
    }
}
