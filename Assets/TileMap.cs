using UnityEngine;

namespace Assets
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshCollider))]
    public class TileMap : MonoBehaviour
    {
        private Mesh _mesh;
        private Vector3[] _vertices;
        private int[] _triangles;
        private Vector3[] _normals;
        private Vector2[] _uv;

        // map size
        private int _xSize = 56;
        private int _zSize = 56;
        public float _tileSize = 1.0f;

        // Use this for initialization
        void Start ()
        {
            BuildMesh();
        }

        public void BuildMesh()
        {
            GenerateMeshData();
            InitializeMesh();

            var meshFilter = GetComponent<MeshFilter>();
            var meshRenderer = GetComponent<MeshRenderer>();
            var meshCollider = GetComponent<MeshCollider>();

            meshFilter.mesh = _mesh;
            meshCollider.sharedMesh = _mesh;
        }

        private void GenerateMeshData()
        {
            var xVertSize = _xSize + 1;
            var zVertSize = _zSize + 1;

            SetupVertexMetadata(xVertSize, zVertSize);
            SetupTriangles(xVertSize);
        }

        private void SetupVertexMetadata(int xVertSize, int zVertSize)
        {
            var numVerts = xVertSize * zVertSize;
            _vertices = new Vector3[numVerts];
            _normals = new Vector3[numVerts];
            _uv = new Vector2[numVerts];

            for (var z = 0; z < zVertSize; z++)
            {
                for (var x = 0; x < xVertSize; x++)
                {
                    _vertices[z * xVertSize + x] = new Vector3(x * _tileSize, 0, z * _tileSize);
                    _normals[z * xVertSize + x] = Vector3.up;
                    _uv[z * xVertSize + x] = new Vector2((float)x / _xSize, (float)z / _zSize);
                }
            }
        }

        private void SetupTriangles(int xVertSize)
        {
            const int trianglesPerTile = 2;
            const int pointsPerTriangle = 3;
            const int trianglePointsPerTile = trianglesPerTile * pointsPerTriangle;

            var numTiles = _xSize * _zSize;
            var numTriangles = numTiles * trianglesPerTile;
            var totalTrianglePoints = numTriangles * pointsPerTriangle;

            _triangles = new int[totalTrianglePoints];

            for (var z = 0; z < _zSize; z++)
            {
                for (var x = 0; x < _xSize; x++)
                {
                    var squareIndex = (z * _xSize) + x;
                    var triIndex = squareIndex * trianglePointsPerTile;

                    _triangles[triIndex + 0] = (z * xVertSize) + x;
                    _triangles[triIndex + 1] = (z * xVertSize) + x + xVertSize;
                    _triangles[triIndex + 2] = (z * xVertSize) + x + xVertSize + 1;

                    _triangles[triIndex + 3] = (z * xVertSize) + x;
                    _triangles[triIndex + 4] = (z * xVertSize) + x + xVertSize + 1;
                    _triangles[triIndex + 5] = (z * xVertSize) + x + 1;
                }
            }
        }

        private void InitializeMesh()
        {
            _mesh = new Mesh
            {
                vertices = _vertices,
                triangles = _triangles,
                normals = _normals,
                uv = _uv
            };
        }

        // Update is called once per frame
        void Update () {
		
        }
    }
}
