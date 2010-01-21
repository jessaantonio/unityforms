using UnityEngine;

namespace UnityForms
{
    // Added ToString override to file from Friday 15th Jan

    public struct Location
    {
        public float X;
        public float Y;

        public static Location Zero
        {
            get
            {
                return new Location(0, 0);
            }
        }

        public Location (Rect rect)
        {
            this.X = rect.x;
            this.Y = rect.y;
        }

        public Location(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return string.Format("(X: {0:F1}, Y: {1:F1})", this.X, this.Y);
        }
    }
}
