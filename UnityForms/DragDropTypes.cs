

namespace UnityForms
{
    /// <summary>
    /// Represents the method that will handle the ItemDrag event of a 
    /// ListView or TreeView control.
    /// The Initial Event triggered when the user starts to drag an item 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ItemDragEventHandler(Control sender, ItemDragEventArgs e);

    /// <summary>
    /// Occurs when an object is dragged over the control's bounds.
    /// This is specific to treeviews and listviews and traps the item being 
    /// dragged in the event parameter. AlsoHere is where you call DoDragDrop 
    /// The DragOver event is raised when the mouse cursor moves within 
    /// the bounds of the control during a drag-and-drop operation.
    /// </summary>
    /// <param name="sender">
    /// The container control
    /// </param>
    /// <param name="e">
    /// Data event
    /// </param>
    public delegate void DragOverEventHandler(Control sender, ItemDragEventArgs e);

    /// <summary>
    /// Occurs when an object is dragged into the control's bounds.
    /// This event occurs when the user drags over a drag and drop control with 
    /// the mouse during a drag drop operation 
    /// </summary>
    /// <param name="sender">
    /// The container control
    /// </param>
    /// <param name="e">
    /// Data event
    /// </param>
    public delegate void DragEnterEventHandler(Control sender, ItemDragEventArgs e);

    /// <summary>
    /// Occurs when an object is dragged out of the control's bounds.
    /// Occurs when the user moves the mouse onto the control when 
    /// dragging an object. 
    /// The DragLeave event is raised when the user drags the cursor out 
    /// of the control or the user cancels the current drag-and-drop operation.
    /// </summary>
    /// <param name="sender">
    /// The container control
    /// </param>
    /// <param name="e">
    /// Data event
    /// </param>
    public delegate void DragLeaveEventHandler(Control sender, ItemDragEventArgs e);

    /// <summary>
    /// Occurs when a drag-and-drop operation is completed.
    /// Occurs when the user releases the mouse over the drop target 
    /// </summary>
    /// <param name="sender">
    /// The dragged control
    /// </param>
    /// <param name="e">
    /// Data event
    /// </param>
    public delegate void DragDropEventHandler(Control sender, ItemDragEventArgs e);

    /// <summary>
    /// Occurs during a drag operation.
    /// Gives feedback about the effects and the current cursor 
    /// The GiveFeedback event is raised when a drag-and-drop operation 
    /// is started. With the GiveFeedback event, the source of a drag event 
    /// can modify the appearance of the mouse pointer in order to give the 
    /// user visual feedback during a drag-and-drop operation.
    /// </summary>
    /// <param name="sender">
    /// </param>
    /// <param name="e">
    /// </param>
    public delegate void GiveFeedbackEventHandler(Control sender, ItemDragEventArgs e);



    /// <summary>
    /// Occurs during a drag-and-drop operation and enables the drag source to 
    /// determine whether the drag-and-drop operation should be canceled.
    /// The QueryContinueDrag event is raised when there is a change in the keyboard 
    /// or mouse button state during a drag-and-drop operation. 
    /// The QueryContinueDrag event enables the drag source to determine whether the 
    /// drag-and-drop operation should be canceled.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void QueryContinueDrag(Control sender, QueryContinueEventArgs e);

    /// <summary>
    /// Specifies how and if a drag-and-drop operation should continue.
    /// </summary>
    public enum DragAction
    {
        /// <summary>
        /// The operation will continue.
        /// </summary>
        Continue,

        /// <summary>
        /// The operation will stop with a drop.
        /// </summary>
        Drop,

        /// <summary>
        /// The operation is canceled with no drop message.
        /// </summary>
        Cancel,
    }

    /// <summary>
    /// You can use DragDropEffects to display different mouse pointers for 
    /// drag-and-drop operations. For example, you can display a plus symbol for 
    /// a Copy drag-and-drop operation, an arrow symbol for a Move drag-and-drop 
    /// operation, or a red circle with a line through it symbol for a None 
    /// drag-and-drop operation.
    /// </summary>
    public enum DragDropEffects
    {
        /// <summary>
        /// The drop target does not accept the data.
        /// </summary>
        None = 0,

        /// <summary>
        /// The data from the drag source is moved to the drop target.
        /// </summary>
        Move = 1,

        /// <summary>
        /// The data from the drag source is copied to the drop target.
        /// </summary>
        Copy = 2,

        /// <summary>
        /// The target can be scrolled while dragging to locate a drop position that is not currently visible in the target.
        /// </summary>
        Scroll = 4,

        /// <summary>
        /// The data from the drag source is linked to the drop target.
        /// </summary>
        Link = 8,

        /// <summary>
        /// The combination of the Copy, Move, and Scroll effects.
        /// </summary>
        All = 16
    }
}
