namespace UnityForms
{
    // Added ToString override to file from Friday 15th Jan

    public struct Size
    {
        public float Width;
        public float Height;

        public static Size Zero
        {
            get
            {
                return new Size(0, 0);
            }
        }

        public Size (float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return string.Format("(W: {0:F1}, H: {1:F1})", this.Width, this.Height);
        }
    }
}
