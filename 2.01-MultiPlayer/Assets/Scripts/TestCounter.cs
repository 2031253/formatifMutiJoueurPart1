using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TestCounter : NetworkBehaviour
{
    private NetworkVariable<int> counter =  new NetworkVariable<int>(0);

    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        counter.OnValueChanged += onCounterChanged;
    }

    private void onCounterChanged(int previous, int current) {
        Debug.Log("compteur : " + counter.Value);
    }

    // Update is called once per frame
    void Update()
    {
        bool pressed = Input.GetKeyDown(KeyCode.T);
        if (pressed)
        {
            IncrementCounterServerRpc();
        }
    }

    [Rpc(SendTo.Owner)]
    private void IncrementCounterServerRpc()
    {
        counter.Value++;
    }
}
