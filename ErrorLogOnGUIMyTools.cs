using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorLogOnGUIMyTools : MonoBehaviour
{
    private List<string> m_logEntries = new List<string>();

    private bool m_IsVisible = false;

    private Rect m_WindowRect = new Rect(0, 0, Screen.width, Screen.height);

    private Vector2 m_scrollPositionText = Vector2.zero;

    public TextMeshProUGUI text;

    public Transform parent;
    public Transform root;


    private void Start()
    {
        Application.logMessageReceived += (string condition, string stackTrace, LogType type) =>
        {
            if (type == LogType.Exception || type == LogType.Error)
            {
             
                m_logEntries.Add(string.Format("{0}\n{1}", condition, stackTrace));
            }
        };

        //for (int i = 0; i < 30; i++)
        //{
        //    Debug.LogError("test error!");
        //}
    }

    private void Update()
    {
        foreach (var item in m_logEntries)
        {
            text.text = item;
        }
    }

    private void FunckHandle(List<Transform> objs)
    {
        Messenger.Broadcast(MessengerEventDef.COLOSE_QR);
        
        
        
        ObjectManager.instance.go = objs[0].gameObject;
        ObjectManager.instance.InitObject();
    }

   

    //void ConsoleWindow(int windowID)
    //{
    //    GUILayout.BeginHorizontal();
    //    if (GUILayout.Button("Clear", GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
    //    {
    //        m_logEntries.Clear();
    //    }
    //    if (GUILayout.Button("Close", GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
    //    {
    //        m_IsVisible = false;
    //    }
    //    GUILayout.EndHorizontal();

    //    m_scrollPositionText = GUILayout.BeginScrollView(m_scrollPositionText);

    //    foreach (var entry in m_logEntries)
    //    {
    //        Color color = GUI.contentColor;
    //        GUI.contentColor = Color.red;
    //        GUILayout.TextArea(entry);
    //        GUI.contentColor = color;
    //    }
    //    GUILayout.EndScrollView();
    //}

    //private void OnGUI()
    //{
    //    if (m_IsVisible)
    //    {
    //        m_WindowRect = GUILayout.Window(0, m_WindowRect, ConsoleWindow, "Console");
    //    }
    //}

}
