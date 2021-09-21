using UnityEngine;

public class ObjectsToSlice : InGameObjects
{
    private bool isCut = false;
    [SerializeField] private Transform particle;
    private Renderer render;
    private bool isOnCamera = false;

    private void Start()
    {
        render = GetComponent<Renderer>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var blade = other.GetComponent<Blade>();
        if (blade != null)
        {
            if(!isCut)
            {
                isCut = true;
                UIGame.Instance.AddScore();
                int p = Random.Range(0, 1);

                if (p > 0.7)
                {
                    UIGame.Instance.EarnCoins();
                    particle.GetComponent<ParticleSystem>().Play();
                }

                //return
                ObjectToSlicePool.Instance.ReturnToPool(this);
                
            }
        }
    }

    private void FixedUpdate()
    {
        if (!this.OnScreen() && this.isOnCamera)
        {
            Actions.StrikeHandler();
            this.isOnCamera = false;
            ObjectToSlicePool.Instance.ReturnToPool(this);
            
        }
        else if(this.OnScreen() && !this.isOnCamera)
        {
            isOnCamera = true;
        }
    }

    private bool OnScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        return screenPoint.x > 0 && screenPoint.y > 0 && screenPoint.x < 1 && screenPoint.y < 1;
    }

}
