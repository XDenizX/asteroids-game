using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteFitter : MonoBehaviour
    {
        private void Start()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            
            Camera mainCamera = Camera.main;
            if (mainCamera == null)
                return;
            
            float worldScreenHeight = mainCamera.orthographicSize * 2.0f;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            spriteRenderer.size = new Vector2(worldScreenWidth, worldScreenHeight);
        }
    }
}