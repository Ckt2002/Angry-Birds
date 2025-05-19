#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class AssignTool : MonoBehaviour
{
    [ContextMenu("Assign enum")]
    public void AssignEnum()
    {
        EObstacleType.TryParse(gameObject.name, ignoreCase: true, out EObstacleType parsedType);
        GetComponent<ObstacleController>().obstacleType = parsedType;
    }

    [ContextMenu("Assign Sprites from Folder")]
    void AssignSprites()
    {
        string folderPath = "Assets/Importation/Sprites/Obstacle";

        // Tìm tất cả sprite trong thư mục
        string[] guids = AssetDatabase.FindAssets("t:Sprite", new[] { folderPath });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);

            // Tạo object mới hoặc gán vào object có sẵn
            //GameObject obj = new GameObject(sprite.name);
            //obj.AddComponent<SpriteRenderer>().sprite = sprite;
            if (name.Equals(sprite.name))
                GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    [ContextMenu("Assign all component")]
    void AssignComponents()
    {

        if (GetComponent<Rigidbody2D>() == null)
            gameObject.AddComponent<Rigidbody2D>();
        if (GetComponent<PolygonCollider2D>() == null)
            gameObject.AddComponent<PolygonCollider2D>();
        if (GetComponent<ObstacleController>() == null)
            gameObject.AddComponent<ObstacleController>();
        if (GetComponent<ObstacleStateMachine>() == null)
            gameObject.AddComponent<ObstacleStateMachine>();
    }
}

#endif