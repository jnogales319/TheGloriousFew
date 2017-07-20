using UnityEngine;

namespace Assets
{
    [RequireComponent(typeof(TileMap))]
    public class TileMapMouse : MonoBehaviour
    {
        private TileMap _tileMap;
        private Vector3 _currentTileCoord;
        public Transform SelectionObject;

        // Use this for initialization
        void Start ()
        {
            _tileMap = GetComponent<TileMap>();
        }
	
        // Update is called once per frame
        void Update ()
        {
            var mainCamera = Camera.main;
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var collider = GetComponent<Collider>();

            RaycastHit hitInfo;

            if (collider.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                var x = Mathf.FloorToInt(hitInfo.point.x / _tileMap._tileSize);
                var z = Mathf.FloorToInt(hitInfo.point.z / _tileMap._tileSize);

                _currentTileCoord.x = x;
                _currentTileCoord.z = z;

                SelectionObject.transform.position = _currentTileCoord;
            }


        }
    }
}
