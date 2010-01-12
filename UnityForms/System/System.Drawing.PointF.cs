#if !VISUALSTUDIO

namespace System.Drawing
{
    /// <summary>
    /// Represents an ordered pair of floating-point x- and y-coordinates that defines
    /// a point in a two-dimensional plane.
    /// </summary>
    [Serializable]
    public struct PointF
    {
        private bool _isEmpty;
        private float _x;
        private float _y;

        /// <summary>
        /// Represents a new instance of the System.Drawing.PointF class with member
        /// data left uninitialized.
        /// </summary>
        public static readonly PointF Empty;

        /// <summary>
        /// Initializes a new instance of the System.Drawing.PointF class with the specified
        /// coordinates.
        /// </summary>
        /// <param name="x">
        /// The horizontal position of the point.
        /// </param>
        /// <param name="y">
        /// The vertical position of the point.
        /// </param>
        public PointF(float x, float y)
        {
            _isEmpty = false;
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Translates a System.Drawing.PointF by the negative of a given System.Drawing.Size.
        /// </summary>
        /// <param name="pt">
        /// A System.Drawing.PointF to compare.
        /// </param>
        /// <param name="sz">
        /// A System.Drawing.PointF to compare.
        /// </param>
        /// <returns>
        /// The translated System.Drawing.PointF.
        /// </returns>
        public static PointF operator -(PointF pt, Size sz)
        {
            return new PointF(pt._x - sz.Width, pt._y - sz.Height);
        }

        /// <summary>
        /// Translates a System.Drawing.PointF by the negative of a specified System.Drawing.SizeF.
        /// </summary>
        /// <param name="pt">
        /// The System.Drawing.PointF to translate.
        /// </param>
        /// <param name="sz">
        /// The System.Drawing.SizeF that specifies the numbers to subtract from the
        /// coordinates of pt.
        /// </param>
        /// <returns>
        /// The translated System.Drawing.PointF.
        /// </returns>
        public static PointF operator -(PointF pt, SizeF sz)
        {
            return new PointF(pt._x - sz.Width, pt._y - sz.Height);
        }

        /// <summary>
        /// Determines whether the coordinates of the specified points are not equal.
        /// </summary>
        /// <param name="left">
        /// A System.Drawing.PointF to compare.
        /// </param>
        /// <param name="right">
        /// A System.Drawing.PointF to compare.
        /// </param>
        /// <returns>
        /// true to indicate the System.Drawing.PointF.X and System.Drawing.PointF.Y
        /// values of left and right are not equal; otherwise, false.
        /// </returns>
        public static bool operator !=(PointF left, PointF right)
        {
            return left._isEmpty != right._isEmpty
                || left._x != right._x
                || left._y != right._y;
        }

        /// <summary>
        /// Translates a System.Drawing.PointF by a given System.Drawing.Size.
        /// </summary>
        /// <param name="pt">
        /// The System.Drawing.PointF to translate.
        /// </param>
        /// <param name="sz">
        /// A System.Drawing.Size that specifies the pair of numbers to add to the coordinates
        /// of pt.
        /// </param>
        /// <returns>
        /// Returns the translated System.Drawing.PointF.
        /// </returns>
        public static PointF operator +(PointF pt, Size sz)
        {
            return new PointF(pt._x + sz.Width, pt._y + sz.Height);
        }

        /// <summary>
        /// Translates the System.Drawing.PointF by the specified System.Drawing.SizeF.
        /// </summary>
        /// <param name="pt">
        /// The System.Drawing.PointF to translate.
        /// </param>
        /// <param name="sz">
        /// The System.Drawing.SizeF that specifies the numbers to add to the x- and
        /// y-coordinates of the System.Drawing.PointF.
        /// </param>
        /// <returns>
        /// The translated System.Drawing.PointF.
        /// </returns>
        public static PointF operator +(PointF pt, SizeF sz)
        {
            return new PointF(pt._x + sz.Width, pt._y + sz.Height);
        }

        /// <summary>
        /// Compares two System.Drawing.PointF structures. The result specifies whether
        /// the values of the System.Drawing.PointF.X and System.Drawing.PointF.Y properties
        /// of the two System.Drawing.PointF structures are equal.
        /// </summary>
        /// <param name="left">
        /// A System.Drawing.PointF to compare.
        /// </param>
        /// <param name="right">
        /// A System.Drawing.PointF to compare.
        /// </param>
        /// <returns>
        /// true if the System.Drawing.PointF.X and System.Drawing.PointF.Y values of
        /// the left and right System.Drawing.PointF structures are equal; otherwise,
        /// false.
        /// </returns>
        public static bool operator ==(PointF left, PointF right)
        {
            return left._isEmpty == right._isEmpty
                && left._x == right._x
                && left._y == right._y;
        }

        /// <summary>
        /// Gets a value indicating whether this System.Drawing.PointF is empty.
        /// Returns:
        ///     true if both System.Drawing.PointF.X and System.Drawing.PointF.Y are 0; otherwise,
        ///     false.
        /// </summary>
        public bool IsEmpty 
        {
            get { return _isEmpty; }
        }

        /// <summary>
        /// Gets or sets the x-coordinate of this System.Drawing.PointF.
        /// Returns:
        ///     The x-coordinate of this System.Drawing.PointF.
        /// </summary>
        public float X 
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of this System.Drawing.PointF.
        /// Returns:
        ///     The y-coordinate of this System.Drawing.PointF.
        /// </summary>
        public float Y 
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Translates a given System.Drawing.PointF by the specified System.Drawing.Size.
        /// </summary>
        /// <param name="pt">
        /// The System.Drawing.PointF to translate.
        /// </param>
        /// <param name="sz">
        /// The System.Drawing.Size that specifies the numbers to add to the coordinates
        /// of pt.</param>
        /// <returns>
        /// The translated System.Drawing.PointF.
        /// </returns>
        public static PointF Add(PointF pt, Size sz)
        {
            return new PointF(pt._x + sz.Width, pt._y + sz.Height);
        }

        /// <summary>
        /// Translates a given System.Drawing.PointF by a specified System.Drawing.SizeF.
        /// </summary>
        /// <param name="pt">
        /// The System.Drawing.PointF to translate.
        /// </param>
        /// <param name="sz">
        /// The System.Drawing.SizeF that specifies the numbers to add to the coordinates
        ///     of pt.
        /// </param>
        /// <returns>The translated System.Drawing.PointF.</returns>
        public static PointF Add(PointF pt, SizeF sz)
        {
            return new PointF(pt._x + sz.Width, pt._y + sz.Height);
        }

        /// <summary>
        /// Specifies whether this System.Drawing.PointF contains the same coordinates
        /// as the specified System.Object.
        /// </summary>
        /// <param name="obj">
        /// The System.Object to test.
        /// </param>
        /// <returns>
        /// This method returns true if obj is a System.Drawing.PointF and has the same
        /// coordinates as this System.Drawing.Point.
        /// </returns>
        public override bool Equals(object obj)
        {
            return _isEmpty == ((PointF)obj)._isEmpty
               && _x == ((PointF)obj)._x
               && _y == ((PointF)obj)._y;
        }

        /// <summary>
        /// Returns a hash code for this System.Drawing.PointF structure.
        /// </summary>
        /// <returns>
        /// An integer value that specifies a hash value for this System.Drawing.PointF
        /// structure.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Translates a System.Drawing.PointF by the negative of a specified size.
        /// </summary>
        /// <param name="pt">
        /// The System.Drawing.PointF to translate.
        /// </param>
        /// <param name="sz">
        /// The System.Drawing.Size that specifies the numbers to subtract from the coordinates
        /// of pt.
        /// </param>
        /// <returns>The translated System.Drawing.PointF.</returns>
        public static PointF Subtract(PointF pt, Size sz)
        {
            return new PointF(pt._x - sz.Width, pt._y - sz.Height);
        }

        /// <summary>
        /// Translates a System.Drawing.PointF by the negative of a specified size.
        /// </summary>
        /// <param name="pt">
        /// The System.Drawing.PointF to translate.
        /// </param>
        /// <param name="sz">
        /// The System.Drawing.SizeF that specifies the numbers to subtract from the
        /// coordinates of pt.
        /// </param>
        /// <returns>
        /// The translated System.Drawing.PointF.
        /// </returns>
        public static PointF Subtract(PointF pt, SizeF sz)
        {
            return new PointF(pt._x - sz.Width, pt._y - sz.Height);
        }

        /// <summary>
        /// Converts this System.Drawing.PointF to a human readable string.
        /// </summary>
        /// <returns>
        /// A string that represents this System.Drawing.PointF.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", _x, _y);
        }
    }
}

#endif