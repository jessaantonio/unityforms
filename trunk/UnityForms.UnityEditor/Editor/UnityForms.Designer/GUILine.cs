using UnityEngine;
using Object=UnityEngine.Object;

internal class GUILine : Object 
{
    private Texture2D _lineTexture;
    //private GUIStyle _guiStyle = GUI.skin.GetStyle("Box");

    private Color _lineColor;
    public Color LineColor
    {
        get { return _lineColor; } 
        set { _lineColor = value; }
    }

    private Rect _line;
    public Rect Line
    {
        get { return _line; } 
        set { _line = value; }
    }

    private Vector2 _start;
    public Vector2 Start
    {
        get { return _start; }
        set
        {
            _start = value;
        }
    }

    private Vector2 _end;
    public Vector2 End
    {
        get { return _end; }
        set
        {
            _end = value;
        }
    }

    public GUILine(Vector2 start, Vector2 end)
    {
        //_lineTexture = DoLineTexture();
        //_guiStyle.normal.background = DoLineTexture();

        _start = start;
        _end = end;

        DoLine();
    }

    public void DoGUI()
    {
        GUI.Box(Line, "");
    }

    public void DoUpdate()
    {
        DoLine();
    }

    private void DoLine()
    {
        Vector2 v = End - Start;
        float width;
        float height;

        if (v.x == 0)
        {
            width = 1;
            height = v.y;
        }
        else
        {
            width = v.x;
            height = 1;
        }

        Line = new Rect(Start.x, Start.y, width, height);
    }

    private Texture2D DoLineTexture()
    {
        // Color color = LineColor; 

        Texture2D texture = new Texture2D(16, 16, TextureFormat.ARGB32, false);

        for(int i = 0; i < texture.height; i++)
        {
            for(int j = 0; j < texture.width; j++)
            {
                texture.SetPixel(i, j, LineColor);
            }
        }

        texture.Apply();

        return texture;
    }

    public override string ToString()
    {
        return string.Format("(Start: ({0:F1},{1:F1})  End: ({2:F1},{3:F1})", Start.x, Start.y, End.x, End.y);
    }
}