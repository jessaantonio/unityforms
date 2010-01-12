#if !VISUALSTUDIO


namespace System.Drawing
 {
     // Summary:
     //     Represents an ordered pair of integer x- and y-coordinates that defines a
     //     point in a two-dimensional plane.
     [Serializable]
     public struct Point
     {
         private int _x;
         private int _y;
         private bool _isEmpty;

         /// <summary>
         /// Represents a System.Drawing.Point that has System.Drawing.Point.X and System.Drawing.Point.Y
         /// values set to zero.
         /// </summary>
         public static Point Empty
         {
             get { return new Point(true); }
         }

         /// <summary>
         /// Initializes a new instance of the System.Drawing.Point class using coordinates
         /// specified by an integer value.
         /// </summary>
         /// <param name="dw">
         /// A 32-bit integer that specifies the coordinates for the new System.Drawing.Point.
         /// </param>
         public Point(int dw)
         {
             throw new NotImplementedException();
         }

         private Point(bool isEmpty)
         {
             _isEmpty = isEmpty;
             _x = 0;
             _y = 0;
         }

         /// <summary>
         /// Initializes a new instance of the System.Drawing.Point class from a System.Drawing.Size.
         /// </summary>
         /// <param name="sz">
         /// A System.Drawing.Size that specifies the coordinates for the new System.Drawing.Point.
         /// </param>
         public Point(Size sz)
         {
             _isEmpty = false;
             _x = sz.Width;
             _y = sz.Width;
         }

         /// <summary>
         /// Initializes a new instance of the System.Drawing.Point class with the specified
         /// coordinates.
         /// </summary>
         /// <param name="x">
         /// The horizontal position of the point.
         /// </param>
         /// <param name="y">
         /// The vertical position of the point.
         /// </param>
         public Point(int x, int y)
         {
             _isEmpty = false;
             _x = x;
             _y = y;
         }

         /// <summary>
         /// Translates a System.Drawing.Point by the negative of a given System.Drawing.Size.
         /// </summary>
         /// <param name="pt">The System.Drawing.Point to translate.</param>
         /// <param name="sz">A System.Drawing.Size that specifies the pair of numbers to subtract from
         /// the coordinates of pt.</param>
         /// <returns>
         /// A System.Drawing.Point structure that is translated by the negative of a
         /// given System.Drawing.Size structure.
         /// </returns>
         public static Point operator -(Point pt, Size sz)
         {
             return new Point(pt._x - sz.Width, pt._y - sz.Height);
         }

         /// <summary>
         /// Compares two System.Drawing.Point objects. The result specifies whether the
         /// values of the System.Drawing.Point.X or System.Drawing.Point.Y properties
         /// of the two System.Drawing.Point objects are unequal.
         /// </summary>
         /// <param name="left">
         /// A System.Drawing.Point to compare.
         /// </param>
         /// <param name="right">
         /// A System.Drawing.Point to compare.
         /// </param>
         /// <returns>
         /// true if the values of either the System.Drawing.Point.X properties or the
         /// System.Drawing.Point.Y properties of left and right differ; otherwise, false.
         /// </returns>
         public static bool operator !=(Point left, Point right)
         {
             return (left._x != right._x || left._y != right._y);
         }

         /// <summary>
         /// Translates a System.Drawing.Point by a given System.Drawing.Size.
         /// </summary>
         /// <param name="pt">
         /// The System.Drawing.Point to translate.
         /// </param>
         /// <param name="sz">
         /// A System.Drawing.Size that specifies the pair of numbers to add to the coordinates
         /// of pt.
         /// </param>
         /// <returns>
         /// The translated System.Drawing.Point.
         /// </returns>
         public static Point operator +(Point pt, Size sz)
         {
             return new Point(pt._x + sz.Width, pt._y + sz.Height);
         }

         /// <summary>
         /// Compares two System.Drawing.Point objects. The result specifies whether the
         /// values of the System.Drawing.Point.X and System.Drawing.Point.Y properties
         /// of the two System.Drawing.Point objects are equal.
         /// </summary>
         /// <param name="left">
         /// A System.Drawing.Point to compare.
         /// </param>
         /// <param name="right">
         /// A System.Drawing.Point to compare.
         /// </param>
         /// <returns>
         /// true if the System.Drawing.Point.X and System.Drawing.Point.Y values of left
         /// and right are equal; otherwise, false.
         /// </returns>
         public static bool operator ==(Point left, Point right)
         {
             return left._x == right._x && left._y == right._y;
         }

         /// <summary>
         /// Converts the specified System.Drawing.Point structure to a System.Drawing.Size
         /// structure.
         /// </summary>
         /// <param name="p">
         /// The System.Drawing.Point to be converted.
         /// </param>
         /// <returns>
         /// The System.Drawing.Size that results from the conversion.
         /// </returns>
         public static explicit operator Size(Point p)
         {
             return new Size(p._x, p._y);
         }

         /// <summary>
         /// Converts the specified System.Drawing.Point structure to a System.Drawing.PointF
         /// structure.
         /// </summary>
         /// <param name="p">
         /// The System.Drawing.Point to be converted.
         /// </param>
         /// <returns>
         /// The System.Drawing.PointF that results from the conversion.
         /// </returns>
         public static implicit operator PointF(Point p)
         {
             return new PointF(p._x, p._y);
         }

         /// <summary>
         /// Gets a value indicating whether this System.Drawing.Point is empty.
         /// Returns:
         ///    true if both System.Drawing.Point.X and System.Drawing.Point.Y are 0; otherwise,
         ///    false.
         /// </summary>
         public bool IsEmpty 
         {
             get { return _isEmpty; }
         }
         
         /// <summary>
         /// Gets or sets the x-coordinate of this System.Drawing.Point.
         /// Returns: 
         ///    The x-coordinate of this System.Drawing.Point.
         /// </summary>
         public int X 
         {
             get { return _x; } 
             set { _x = value; }
         }

         /// <summary>
         /// Gets or sets the y-coordinate of this System.Drawing.Point.
         /// Returns:
         ///    The y-coordinate of this System.Drawing.Point.
         /// </summary>
         public int Y 
         {
             get { return _y; }
             set { _y = value; }
         }

         /// <summary>
         /// Adds the specified System.Drawing.Size to the specified System.Drawing.Point.
         /// </summary>
         /// <param name="pt">
         /// The System.Drawing.Point to add.
         /// </param>
         /// <param name="sz">
         /// The System.Drawing.Size to add
         /// </param>
         /// <returns>
         /// The System.Drawing.Point that is the result of the addition operation.
         /// </returns>
         public static Point Add(Point pt, Size sz)
         {
             return new Point(pt._x + sz.Width, pt._y + sz.Height);
         }

        
         /// <summary>
         /// Converts the specified System.Drawing.PointF to a System.Drawing.Point by
         /// rounding the values of the System.Drawing.PointF to the next higher integer
         /// values.
         /// </summary>
         /// <param name="value">
         /// The System.Drawing.PointF to convert.
         /// </param>
         /// <returns>
         /// The System.Drawing.Point this method converts to.
         /// </returns>
         public static Point Ceiling(PointF value)
         {
             throw new NotImplementedException();
         }
        
        
         /// <summary>
         /// Specifies whether this System.Drawing.Point contains the same coordinates
         /// as the specified System.Object.
         /// </summary>
         /// <param name="obj">
         /// The System.Object to test.
         /// </param>
         /// <returns>
         /// true if obj is a System.Drawing.Point and has the same coordinates as this
         /// System.Drawing.Point.
         /// </returns>
         public override bool Equals(object obj)
         {
             return this._x == ((Point)obj)._x && this._y == ((Point)obj)._y;
         }
        

         /// <summary>
         /// Returns a hash code for this System.Drawing.Point.
         /// </summary>
         /// <returns>
         /// An integer value that specifies a hash value for this System.Drawing.Point.
         /// </returns>
         public override int GetHashCode()
         {
             return base.GetHashCode();
         }
        

         /// <summary>
         /// Translates this System.Drawing.Point by the specified System.Drawing.Point.
         /// </summary>
         /// <param name="p">
         /// The System.Drawing.Point used offset this System.Drawing.Point.
         /// </param>
         public void Offset(Point p)
         {
             _x += p._x;
             _y += p._y;
         }
        

         /// <summary>
         /// Translates this System.Drawing.Point by the specified amount.
         /// </summary>
         /// <param name="dx">
         /// The amount to offset the x-coordinate.
         /// </param>
         /// <param name="dy">
         /// The amount to offset the y-coordinate.
         /// </param>
         public void Offset(int dx, int dy)
         {
             _x += dx;
             _y += dy;
         }
       

         /// <summary>
         /// Converts the specified System.Drawing.PointF to a System.Drawing.Point object
         /// by rounding the System.Drawing.Point values to the nearest integer.
         /// </summary>
         /// <param name="value">
         /// The System.Drawing.PointF to convert.
         /// </param>
         /// <returns>
         /// The System.Drawing.Point this method converts to.
         /// </returns>
         public static Point Round(PointF value)
         {
             return new Point((int)value.X, (int)value.Y);
         }
         

         /// <summary>
         /// Returns the result of subtracting specified System.Drawing.Size from the
         /// specified System.Drawing.Point.
         /// </summary>
         /// <param name="pt">
         /// The System.Drawing.Point to be subtracted from.
         /// </param>
         /// <param name="sz">
         /// The System.Drawing.Size to subtract from the System.Drawing.Point.
         /// </param>
         /// <returns>
         /// The System.Drawing.Point that is the result of the subtraction operation.
         /// </returns>
         public static Point Subtract(Point pt, Size sz)
         {
             return new Point(pt._x - sz.Width, pt._y - sz.Height);
         }
        

         /// <summary>
         /// Converts this System.Drawing.Point to a human-readable string.
         /// </summary>
         /// <returns>
         /// A string that represents this System.Drawing.Point.
         /// </returns>
         public override string ToString()
         {
             return string.Format("{0} {1}", _x, _y);
         }
       

         /// <summary>
         /// Converts the specified System.Drawing.PointF to a System.Drawing.Point by
         /// truncating the values of the System.Drawing.Point.
         /// </summary>
         /// <param name="value">
         /// The System.Drawing.PointF to convert.
         /// </param>
         /// <returns>
         /// The System.Drawing.Point this method converts to.
         /// </returns>
         public static Point Truncate(PointF value)
         {
             return new Point((int)value.X, (int)value.Y);
         }
     }
 }

#endif
