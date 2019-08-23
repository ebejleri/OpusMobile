using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Scrolling_Background : MonoBehaviour
{

    //target can be rigidbody2d component of a player or some object
    public Rigidbody2D target;
    //speed of scrolling
    public float speed;

    private float initPos;

    void Start()
    {
        initPos = transform.localPosition.x;
        //Create a clone for filling rest of the screen
        GameObject objectCopy = GameObject.Instantiate(this.gameObject);
        //Destroy ScrollBackground component in clone
        Destroy(objectCopy.GetComponent<Scrolling_Background>());
        //Set clone parent and position
        objectCopy.transform.SetParent(this.transform);
        objectCopy.transform.localPosition = new Vector3(getWidth(), 0, 0);
    }

    void FixedUpdate()
    {
        //get target velocity
        //if you wish to replace target with a non-rigidbody object, this is the place
        float targetVelocity = target.velocity.x;
        //translate sprite according to target velocity
        this.transform.Translate(new Vector3(-speed * targetVelocity, 0, 0) * Time.deltaTime);
        //set sprite is moving out of screen shift it to put clone in its place
        float width = getWidth();
        if (targetVelocity > 0)
        {
            //shift right if player is moving right
            if (initPos - this.transform.localPosition.x > width)
            {
                this.transform.Translate(new Vector3(width, 0, 0));
            }
        }
        else
        {
            //shift left if player moving left
            if (initPos - this.transform.localPosition.x < 0)
            {
                this.transform.Translate(new Vector3(-width, 0, 0));
            }
        }
    }

    float getWidth()
    {
        //Get sprite width
        return this.GetComponent<SpriteRenderer>().bounds.size.x;
    }
}