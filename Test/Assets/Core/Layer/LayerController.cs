using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LayerController", menuName = "SO/LayerController", order = 0)]
public class LayerController : ScriptableObject
{
    [SerializeField]
    private LayerTagPair[] layerTagPairs;

    public string GetNameLayer(LayerTag layerTag)
    {
        for (int i = 0; i < layerTagPairs.Length; i++)
        {
            if (layerTagPairs[i].Equal(layerTag))
            {
                return layerTagPairs[i].LayerName;
            }
        }

        return null;
    }

    private static LayerController instance;
    public static LayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.FindObjectsOfTypeAll<LayerController>().First();
            }
            return instance;
        }
    }
}