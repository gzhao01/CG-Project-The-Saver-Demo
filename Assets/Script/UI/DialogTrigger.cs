using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    private void OnShowDialog()
    {
        TriggerDialog();
    }
    public void TriggerDialog()
    {
        DialogManager.Instance.StartDialog(dialog);
    }
}
