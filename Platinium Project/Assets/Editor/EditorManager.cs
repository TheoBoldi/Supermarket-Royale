using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GameManager))]
public class EditorManager : Editor
{
    private GameManager _gameManager;
    private bool debugISEnabled;
    private int playerInspectorTarget = 0;
    private string[] playerIntList = { "Player 1", "Player 2", "Player 3", "Player 4" };
    private string debugMessage = "Enable Debug Mode";
    public override void OnInspectorGUI()
    {
        _gameManager = (GameManager)target;
        if (GUILayout.Button(debugMessage) && !_gameManager.isDebug)
        {
            _gameManager.isDebug = true;
            debugMessage = "Debug Enabled";
        }
        base.OnInspectorGUI();
        if (EditorApplication.isPlaying) {
            
            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Select player");
            playerInspectorTarget = EditorGUILayout.Popup(playerInspectorTarget, playerIntList);
            if (GUILayout.Button("Generate selected player list"))
            {
                switch (playerInspectorTarget)
                {
                    case 0:
                        {
                            _gameManager.GenerateItemLists(_gameManager.player1Itemlist);
                        }
                        break;
                    case 1:
                        {
                            _gameManager.GenerateItemLists(_gameManager.player2Itemlist);
                        }
                        break;
                    case 2:
                        {
                            _gameManager.GenerateItemLists(_gameManager.player3Itemlist);
                        }
                        break;
                    case 3:
                        {
                            _gameManager.GenerateItemLists(_gameManager.player4Itemlist);
                        }
                        break;
                }
            }
            if (GUILayout.Button("Generate all objective lists"))
            {
                _gameManager.GenerateItemLists(_gameManager.player1Itemlist);
                _gameManager.GenerateItemLists(_gameManager.player2Itemlist);
                _gameManager.GenerateItemLists(_gameManager.player3Itemlist);
                _gameManager.GenerateItemLists(_gameManager.player4Itemlist);
            }
            if (GUILayout.Button("Force Check Lists"))
            {
                if(_gameManager.CheckCart(_gameManager.player1Itemlist, 1))
                {
                    Debug.Log("P1Correct");
                }
                if (_gameManager.CheckCart(_gameManager.player2Itemlist, 2))
                {
                    Debug.Log("P2Correct");
                }
                if (_gameManager.CheckCart(_gameManager.player3Itemlist, 3))
                {
                    Debug.Log("P3Correct");
                }
                if (_gameManager.CheckCart(_gameManager.player4Itemlist, 4))
                {
                    Debug.Log("P4Correct");
                }
            }
        }
    }
}
