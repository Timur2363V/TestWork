using System;
using UnityEngine;

[Serializable]
public class LayerTagPair
{
    [SerializeField]
    private LayerTag LayerTag;
    [SerializeField]
    private string layerName;

    public string LayerName => layerName;

    public bool Equal(LayerTag LayerTag) => this.LayerTag == LayerTag;
}