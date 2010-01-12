namespace UnityForms
{
    using System.Drawing;

    public static class SystemInformation
    {
        private static readonly Size dragSize = new Size(5, 5);

        /// <summary>
        /// Gets the width and height of a rectangle centered on the point the 
        /// mouse button was pressed, within which a drag operation will not 
        /// begin.
        /// </summary>
        public static Size DragSize
        {
          get
          {
              return dragSize;
          }
        }
    }
}
