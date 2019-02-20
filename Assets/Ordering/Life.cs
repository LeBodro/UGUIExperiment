using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Life : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] float dangerThreshold = 0.25f;
    [SerializeField] Color danger = Color.red;
    [SerializeField] Image fill;

    [Header("Unity Event!")]
    [SerializeField] UnityEvent onDeath;

    bool isDead;

    void Reset()
    {
        fill = GetComponent<Image>();
    }

    public void Hurt(float damage)
    {
        if (isDead)
            return;

        fill.fillAmount = Mathf.Max(0, fill.fillAmount - damage);
        if (fill.fillAmount <= dangerThreshold)
            fill.color = danger;

        isDead = fill.fillAmount <= 0;

        if (isDead)
            onDeath.Invoke();
    }
}
