using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

internal class EditorCanvas : EditorWindow
{
    // This will take care of grids, guides (like PS), etc.
    // TODO: Add pivot/origin

    private Grid _grid;
    private int _gridSize = 16;
    private Color _gridColor = new Color(0, 0, 0, 0.1f);
    private Grid.GridParams _gridParams;

    [MenuItem("UnityTools/Window/Editor Canvas")]
    public static void Init()
    {
        EditorCanvas window = (EditorCanvas)EditorWindow.GetWindow(typeof(EditorCanvas));

        window.Initialize();
        window.Show();
    }

    public void Initialize()
    {
        _gridParams = new Grid.GridParams(_gridSize, _gridColor);

        _grid = new Grid(_gridParams);
    }

    public void OnGUI()
    {
        _grid.GridBounds = position;
        _grid.DoGUI();
    }
}