using UnityEngine;

public class Bomb : InGameObjects
{

    private bool isOnCamera;

    private float time;
    private float maxTime;

    private void OnTriggerEnter(Collider other)
    {
        var blade = other.GetComponent<Blade>();
        if (blade != null)
        {
            BombPool.Instance.ReturnToPool(this);
            Actions.GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (!this.OnScreen() && this.isOnCamera)
        {
            Actions.StrikeHandler();
            this.isOnCamera = false;
            BombPool.Instance.ReturnToPool(this);

        }
        else if (this.OnScreen() && !this.isOnCamera)
        {
            isOnCamera = true;
        }

        time += Time.deltaTime;
        if(time >= maxTime)
        {
            BombPool.Instance.ReturnToPool(this);
            time = 0;
        }
    }

    private bool OnScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        return screenPoint.x > 0 && screenPoint.y > 0 && screenPoint.x < 1 && screenPoint.y < 1;
    }

}

