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

        // Use this for initialization
        void Start ()
        {
            BuildMesh();
        }

        private void BuildMesh()
        {
            GenerateMeshData();
            InitializeMesh();

            var meshFilter = GetComponent<MeshFilter>();
            var meshRenderer = GetComponent<MeshRenderer>();
            var meshCollider = GetComponent<MeshCollider>();

            meshFilter.mesh = _mesh;
        }

        private void GenerateMeshData()
        {
            const int numTriangles = 2;
            const int pointsPerTriangle = 3;
            const int totalTrianglePoints = numTriangles * pointsPerTriangle;

            _vertices = new Vector3[4];
            _triangles = new int[totalTrianglePoints];
            _normals = new Vector3[4];
            _uv = new Vector2[4];

            _vertices[0] = new Vector3(0,0,0);
            _vertices[1] = new Vector3(1,0,0);
            _vertices[2] = new Vector3(0,0,-1);
            _vertices[3] = new Vector3(1,0,-1);

            _triangles[0] = 0;
            _triangles[1] = 3;
            _triangles[2] = 2;

            _triangles[3] = 0;
            _triangles[4] = 1;
            _triangles[5] = 3;

            for(var i = 0; i < _normals.Length; i++)
            {
                _normals[i] = Vector3.up;
            }

            _uv[0] = new Vector2(1, 1);
            _uv[1] = new Vector2(0, 1);
            _uv[2] = new Vector2(1, 0);
            _uv[3] = new Vector2(1, 1);
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
