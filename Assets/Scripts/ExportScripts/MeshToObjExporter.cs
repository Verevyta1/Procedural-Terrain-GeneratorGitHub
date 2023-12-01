using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;

public class MeshToObjExporter
{

    public static void ExportMesh(Mesh mesh, string filePath)
    {
        using (StreamWriter streamWriter = new StreamWriter(filePath))
        {
            StringBuilder streamBuilder = new StringBuilder();

            // Write vertices
            foreach (Vector3 vertex in mesh.vertices)
            {
                streamBuilder.Append("v ")
                  .Append(vertex.x).Append(" ")
                  .Append(vertex.y).Append(" ")
                  .Append(vertex.z).Append("\n");
            }

            // Write UVs
            foreach (Vector3 uv in mesh.uv)
            {
                streamBuilder.Append("vt ")
                  .Append(uv.x).Append(" ")
                  .Append(uv.y).Append("\n");
            }

            // Write normals
            foreach (Vector3 normal in mesh.normals)
            {
                streamBuilder.Append("vn ")
                  .Append(normal.x).Append(" ")
                  .Append(normal.y).Append(" ")
                  .Append(normal.z).Append("\n");
            }

            // Write triangles (faces)
            for (int i = 0; i < mesh.subMeshCount; i++)
            {
                int[] triangles = mesh.GetTriangles(i);
                for (int j = 0; j < triangles.Length; j += 3)
                {
                    streamBuilder.Append("f ")
                      .Append(triangles[j] + 1).Append("/").Append(triangles[j] + 1).Append("/").Append(triangles[j] + 1).Append(" ")
                      .Append(triangles[j + 1] + 1).Append("/").Append(triangles[j + 1] + 1).Append("/").Append(triangles[j + 1] + 1).Append(" ")
                      .Append(triangles[j + 2] + 1).Append("/").Append(triangles[j + 2] + 1).Append("/").Append(triangles[j + 2] + 1).Append("\n");
                }
            }

            streamWriter.Write(streamBuilder.ToString());
        }
    }


    
}


