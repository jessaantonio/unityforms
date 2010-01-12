#if !VISUALSTUDIO

namespace System.Drawing
{
    /// <summary>
    /// Stores an ordered pair of floating-point numbers, typically the width and
    /// height of a rectangle.
    /// </summary>
    [Serializable]
    public struct SizeF
    {
        private bool _isEmpty;
        private float _width;
        private float _height;

        /// <summary>
        /// Initializes a new instance of the System.Drawing.SizeF class.
        /// </summary>
        public static readonly SizeF Empty;

        /// <summary>
        /// Initializes a new instance of the System.Drawing.SizeF class from the specified
        /// System.Drawing.PointF.
        /// </summary>
        /// <param name="pt">
        /// The System.Drawing.PointF from which to initialize this System.Drawing.SizeF.
        /// </param>
        public SizeF(PointF pt)
        {
            _isEmpty = pt.IsEmpty;
            _width = pt.X;
            _height = pt.Y;
        }

        /// <summary>
        /// Initializes a new instance of the System.Drawing.SizeF class from the specified
        /// existing System.Drawing.SizeF.
        /// </summary>
        /// <param name="size">
        /// The System.Drawing.SizeF from which to create the new System.Drawing.SizeF.
        /// </param>
        public SizeF(SizeF size)
        {
            _isEmpty = size._isEmpty;
            _width = size._width;
            _height = size._height;
        }

        /// <summary>
        /// Initializes a new instance of the System.Drawing.SizeF class from the specified
        ///  dimensions.
        /// </summary>
        /// <param name="width">
        /// The width component of the new System.Drawing.SizeF.
        /// </param>
        /// <param name="height">
        /// The height component of the new System.Drawing.SizeF.
        /// </param>
        public SizeF(float width, float height)
        {
            _isEmpty = false;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Subtracts the width and height of one System.Drawing.SizeF structure from
        /// the width and height of another System.Drawing.SizeF structure.
        /// </summary>
        /// <param name="sz1">
        /// The System.Drawing.SizeF on the left side of the subtraction operator.
        /// </param>
        /// <param name="sz2">
        /// The System.Drawing.SizeF on the right side of the subtraction operator.
        /// </param>
        /// <returns>
        /// A System.Drawing.SizeF that is the result of the subtraction operation.
        /// </returns>
        public static SizeF operator -(SizeF sz1, SizeF sz2)
        {
            return new SizeF(sz1._width - sz2._width, sz1._height - sz2._height);
        }

        /// <summary>
        /// Tests whether two System.Drawing.SizeF structures are different.
        /// </summary>
        /// <param name="sz1">
        /// The System.Drawing.SizeF structure on the left of the inequality operator.
        /// </param>
        /// <param name="sz2">
        /// The System.Drawing.SizeF structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// This operator returns true if sz1 and sz2 differ either in width or height;
        /// false if sz1 and sz2 are equal.
        /// </returns>
        public static bool operator !=(SizeF sz1, SizeF sz2)
        {
            return sz1._isEmpty != sz2._isEmpty 
                || sz1._width != sz2._width 
                || sz1._height!= sz2._height;
        }

        /// <summary>
        /// Adds the width and height of one System.Drawing.SizeF structure to the width
        /// and height of another System.Drawing.SizeF structure.
        /// </summary>
        /// <param name="sz1">
        /// The first System.Drawing.SizeF to add.
        /// </param>
        /// <param name="sz2">
        /// The second System.Drawing.SizeF to add.
        /// </param>
        /// <returns>
        /// A System.Drawing.Size structure that is the result of the addition operation.
        /// </returns>
        public static SizeF operator +(SizeF sz1, SizeF sz2)
        {
            return new SizeF(sz1._width + sz2._width, sz1._height + sz2._height);
        }

        /// <summary>
        /// Tests whether two System.Drawing.SizeF structures are equal.
        /// </summary>
        /// <param name="sz1">
        /// The System.Drawing.SizeF structure on the left side of the equality operator.
        /// </param>
        /// <param name="sz2">
        /// The System.Drawing.SizeF structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// This operator returns true if sz1 and sz2 have equal width and height; otherwise,
        /// false.
        /// </returns>
        public static bool operator ==(SizeF sz1, SizeF sz2)
        {
            return sz1._isEmpty == sz2._isEmpty
                && sz1._width == sz2._width 
                && sz1._height == sz2._height;
        }

        /// <summary>
        /// Converts the specified System.Drawing.SizeF to a System.Drawing.PointF.
        /// </summary>
        /// <param name="size">
        /// The System.Drawing.SizeF structure to be converted
        /// </param>
        /// <returns>
        /// The System.Drawing.PointF structure to which this operator converts.
        /// </returns>
        public static explicit operator PointF(SizeF size)
        {
            //todo
            return new PointF(size._width, size._height);
        }

        /// <summary>
        /// Gets or sets the vertical component of this System.Drawing.SizeF.
        /// Returns:
        ///     The vertical component of this System.Drawing.SizeF, typically measured in
        ///     pixels.
        /// </summary>
        public float Height 
        {
            get { return _height; }
            set { _height = value; }
        }
      

        /// <summary>
        /// Gets a value indicating whether this System.Drawing.SizeF has zero width
        /// and height.
        /// Returns:
        ///     This property returns true when this System.Drawing.SizeF has both a width
        ///     and height of zero; otherwise, false.
        /// </summary>
        public bool IsEmpty 
        {
            get { return _isEmpty; }
        }

        /// <summary>
        /// Gets or sets the horizontal component of this System.Drawing.SizeF.
        /// Returns:
        ///     The horizontal component of this System.Drawing.SizeF, typically measured
        ///     in pixels.
        /// </summary>
        public float Width 
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Adds the width and height of one System.Drawing.SizeF structure to the width
        /// and height of another System.Drawing.SizeF structure.
        /// </summary>
        /// <param name="sz1">
        /// The first System.Drawing.SizeF to add.
        /// </param>
        /// <param name="sz2">
        /// The second System.Drawing.SizeF to add.
        /// </param>
        /// <returns>
        /// A System.Drawing.SizeF structure that is the result of the addition operation.
        /// </returns>
        public static SizeF Add(SizeF sz1, SizeF sz2)
        {
            return new SizeF(sz1._width + sz2._width, sz1._height + sz2._height);
        }

        /// <summary>
        /// Tests to see whether the specified object is a System.Drawing.SizeF with
        /// the same dimensions as this System.Drawing.SizeF.
        /// </summary>
        /// <param name="obj">
        /// The System.Object to test.
        /// </param>
        /// <returns>
        /// This method returns true if obj is a System.Drawing.SizeF and has the same
        /// width and height as this System.Drawing.SizeF; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return _width == ((SizeF)obj)._width
                && _height == ((SizeF)obj)._height;
        }

        /// <summary>
        /// Returns a hash code for this System.Drawing.Size structure.
        /// </summary>
        /// <returns>
        /// An integer value that specifies a hash value for this System.Drawing.Size
        /// structure.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Subtracts the width and height of one System.Drawing.SizeF structure from
        /// the width and height of another System.Drawing.SizeF structure.
        /// </summary>
        /// <param name="sz1">
        /// The System.Drawing.SizeF structure on the left side of the subtraction operator.
        /// </param>
        /// <param name="sz2">
        /// The System.Drawing.SizeF structure on the right side of the subtraction operator.
        /// </param>
        /// <returns>
        /// The System.Drawing.SizeF that is a result of the subtraction operation.
        /// </returns>
        public static SizeF Subtract(SizeF sz1, SizeF sz2)
        {
            return new SizeF(sz1._width - sz2._width, sz1._height - sz2._height);
        }

        /// <summary>
        /// Converts a System.Drawing.SizeF to a System.Drawing.PointF.
        /// </summary>
        /// <returns>
        /// Returns a System.Drawing.PointF structure.
        /// </returns>
        public PointF ToPointF()
        {
            return new PointF(_width, _height);
        }

        /// <summary>
        /// Converts a System.Drawing.SizeF to a System.Drawing.Size.
        /// </summary>
        /// <returns>
        /// Returns a System.Drawing.Size structure.
        /// </returns>
        public Size ToSize()
        {
            return new Size((int)_width, (int)_height);
        }

        /// <summary>
        /// Creates a human-readable string that represents this System.Drawing.SizeF.
        /// </summary>
        /// <returns>
        /// A string that represents this System.Drawing.SizeF.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", _width, _height);
        }
    }
}

#endif