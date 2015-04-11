using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStitcher {
    class Processor {
        Image image;
        const int KEY_POINT_RADIUS = 30;

        public String LastOperationStatus { get; set; }

        public Processor(Image image) {
            this.image = image;
        }

        public Image Process() {
            var key_points = DefineKeyPoints();
            image = MarkKeyPoints(image as Bitmap, key_points, Color.Red);
            LastOperationStatus = "All done";
            return image;
        }

        Point[] DefineKeyPoints() {
            return new Point[] { new Point(image.Width / 2, image.Height / 2) };
        }

        Image MarkKeyPoints(Bitmap image, Point[] key_points, Color color) {
            foreach (var point in key_points)
                MarkKeyPoint(image, point, color);
            return image;
        }

        void MarkKeyPoint(Bitmap image, Point point, Color color) {
            var pen = new Pen(color, 5);
            Graphics.FromImage(image).DrawEllipse(pen, point.X - KEY_POINT_RADIUS, point.Y - KEY_POINT_RADIUS, 
                KEY_POINT_RADIUS * 2, KEY_POINT_RADIUS * 2);
        }
    }
}
