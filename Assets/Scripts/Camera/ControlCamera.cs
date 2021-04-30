using UnityEngine;

public class ControlCamera : MonoBehaviour
{

    [SerializeField] private float _zoomMin = 1;
    [SerializeField] private float _zoomMax = 8;
    [SerializeField] private float _zoomSpeed;

    [SerializeField] private GameObject _Map;

    private Camera _mainCamera;
    private Vector3 _touch;

    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Time.timeScale < 1)
            return;

        if (Input.GetMouseButtonDown(0))
            _touch = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = _touch - _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _mainCamera.transform.position += direction;
        }
        Zoom(Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed);
        ClampPosition();
    }

    private void Zoom(float increment)
    {
        _mainCamera.orthographicSize = Mathf.Clamp(_mainCamera.orthographicSize - increment, _zoomMin, _zoomMax);
    }

    private void ClampPosition()
    {
        float offset = _mainCamera.pixelWidth;
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, getGameObjectMinX(_Map), getGameObjectMaxX(_Map));
        clampedPos.y = Mathf.Clamp(clampedPos.y, getGameObjectMinY(_Map), getGameObjectMaxY(_Map));
        transform.position = clampedPos;
    }


    private  float getGameObjectWidth(GameObject obj)
    {
        float minX = float.MaxValue;
        float maxX = float.MinValue;

        SpriteRenderer[] sprites = obj.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sr in sprites)
        {

            float tmpMinX = sr.transform.position.x + sr.sprite.bounds.center.x - sr.sprite.bounds.size.x * sr.transform.lossyScale.x / 2f;
            float tmpMaxX = sr.transform.position.x + sr.sprite.bounds.center.x + sr.sprite.bounds.size.x * sr.transform.lossyScale.x / 2f;

            if (tmpMinX < minX)
            {
                minX = tmpMinX;
            }
            if (tmpMaxX > maxX)
            {
                maxX = tmpMaxX;
            }
        }
        return (maxX - minX);
    }

    private float getGameObjectMinX(GameObject obj)
    {
        float minX = float.MaxValue;

        SpriteRenderer[] sprites = obj.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sr in sprites)
        {
            float tmpMinX = sr.transform.position.x + sr.sprite.bounds.center.x - sr.sprite.bounds.size.x * sr.transform.lossyScale.x / 2f;

            if (tmpMinX < minX)
            {
                minX = tmpMinX;
            }
        }
        return minX + transform.position.x - _mainCamera.ViewportToWorldPoint(Vector2.zero).x;
    }

    private float getGameObjectMaxX(GameObject obj)
    {
        return getGameObjectMinX(obj) + getGameObjectWidth(obj) - (transform.position.x - _mainCamera.ViewportToWorldPoint(Vector2.zero).x) * 2;
    }


    private float getGameObjectMinY(GameObject obj)
    {
        float minY = float.MaxValue;

        SpriteRenderer[] sprites = obj.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sr in sprites)
        {
            float tmpMinY = sr.transform.position.y + sr.sprite.bounds.center.y - sr.sprite.bounds.size.y * sr.transform.lossyScale.y / 2f;

            if (tmpMinY < minY)
            {
                minY = tmpMinY;
            }
        }
        return minY + transform.position.y - _mainCamera.ViewportToWorldPoint(Vector2.zero).y;
    }

    private float getGameObjectMaxY(GameObject obj)
    {
        return getGameObjectMinY(obj) + getGameObjectHeight(obj) - (transform.position.y - _mainCamera.ViewportToWorldPoint(Vector2.zero).y) * 2;
    }


    private float getGameObjectHeight(GameObject obj)
    {
        float minY = float.MaxValue;
        float maxY = float.MinValue;

        SpriteRenderer[] sprites = obj.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sr in sprites)
        {
            float tmpMinY = sr.transform.position.y + sr.sprite.bounds.center.y - sr.sprite.bounds.size.y * sr.transform.lossyScale.y / 2f;
            float tmpMaxY = sr.transform.position.y + sr.sprite.bounds.center.y + sr.sprite.bounds.size.y * sr.transform.lossyScale.y / 2f;

            if (tmpMinY < minY)
            {
                minY = tmpMinY;
            }
            if (tmpMaxY > maxY)
            {
                maxY = tmpMaxY;
            }
        }
        return (maxY - minY);
    }
}
