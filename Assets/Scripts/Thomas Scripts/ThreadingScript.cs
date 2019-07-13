using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ThreadingScript : MonoBehaviour
{
    Thread childThread = null;
    EventWaitHandle childThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);
    EventWaitHandle mainThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);

    // Start is called before the first frame update
    void Awake()
    {
        childThread = new Thread(ChildThreadLoop);
        childThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        mainThreadWait.Reset();
        WaitHandle.SignalAndWait(childThreadWait, mainThreadWait);
    }

    void ChildThreadLoop()
    {
        childThreadWait.Reset();
        childThreadWait.WaitOne();
        while (true)
        {
            childThreadWait.Reset();

            WaitHandle.SignalAndWait(mainThreadWait, childThreadWait);
        }
    }
}
