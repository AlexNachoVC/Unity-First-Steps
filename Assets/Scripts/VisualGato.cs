using UnityEngine;

public class VisualGato : MonoBehaviour
{
    [SerializeField] GameObject XPrefab;
    [SerializeField] GameObject OPrefab;
    public Material Tablero;
    public Material Lineas;

    private LogicGato logicGato;

    void Start()
    {
        Board();
        BoardLines();
        logicGato = new LogicGato();
        string[,] matriz = logicGato.GenerateMatrix();
        GenerateMatrix(matriz);
    }

    void Board()
    {
        GameObject board = GameObject.CreatePrimitive(PrimitiveType.Cube);
        board.transform.localScale = new Vector3(10 + 5, 0.1f, 10 + 5);
        board.transform.position = new Vector3(0f, -0.1f, 0f);

        Rigidbody bRB = board.AddComponent<Rigidbody>();
        bRB.mass = 1000f;
        bRB.constraints = RigidbodyConstraints.FreezeAll;

        MeshRenderer bMR = board.GetComponent<MeshRenderer>();
        bMR.material = Tablero;

        PhysicsMaterial pm = new PhysicsMaterial();
        board.GetComponent<Collider>().material = pm;
        pm.dynamicFriction = 0;
        pm.staticFriction = 0;
        pm.bounciness = 1;
        pm.frictionCombine = PhysicsMaterialCombine.Minimum;
        pm.bounceCombine = PhysicsMaterialCombine.Maximum;
    }

    void BoardLines()
    {
        float lineThickness = 0.2f;
        float cellSpacing = 10 / 3f;
        for (int i = -1; i <= 2; i++)
        {
            GameObject verticalLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
            verticalLine.transform.localScale = new Vector3(lineThickness, 0.1f, 10 + 3);
            verticalLine.transform.position = new Vector3(-10 / 2f + i * cellSpacing + cellSpacing, 0.0f, 0);
            MeshRenderer verticalMR = verticalLine.GetComponent<MeshRenderer>();
            verticalMR.material = Lineas;

            GameObject horizontalLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
            horizontalLine.transform.localScale = new Vector3(10 + 3, 0.1f, lineThickness);
            horizontalLine.transform.position = new Vector3(0, 0.0f, -10 / 2f + i * cellSpacing + cellSpacing);
            MeshRenderer horizontalMR = horizontalLine.GetComponent<MeshRenderer>();
            horizontalMR.material = Lineas;
        }
    }

    void GenerateMatrix(string[,] matriz)
    {
        float cellSpacing = 10 / 3f;
        float xOffset = -(10 / 2f) + (cellSpacing / 2f);
        float zOffset = -(10 / 2f) + (cellSpacing / 2f);

        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                if (matriz[row, column] == "X")
                {
                    GameObject x = Instantiate(XPrefab);
                    x.transform.position = new Vector3(column * cellSpacing + xOffset, 3f, row * cellSpacing + zOffset);
                    x.transform.localScale = new Vector3(2f, 2f, 2f);
                }
                else if (matriz[row, column] == "O")
                {
                    GameObject o = Instantiate(OPrefab);
                    o.transform.position = new Vector3(column * cellSpacing + xOffset, 3f, row * cellSpacing + zOffset);
                    o.transform.localScale = new Vector3(2f, 2f, 2f);
                }
            }
        }
    }
}