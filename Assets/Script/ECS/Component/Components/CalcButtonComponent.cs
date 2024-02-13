using ECSCommons;
using UnityEngine.UI;

public class CalcButtonComponent : IComponent
{
    public Button Button { get; private set; }
    public string ClickedMessage { get; private set; }

    public Entity Entity { get; set; }

    public void Init()
    {
        Button = Entity.GameObject.GetComponent<Button>();

        var message = Entity.Transform.GetChild(0).gameObject.GetComponent<Text>().text;
        if (message == "C") { ClickedMessage = "Reset"; }
        else { ClickedMessage = message; }
    }
}
