using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Move : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0f, 0f);
    protected Rigidbody2D rid2D;
    public float pressHori = 0f;
    public float pressVerti = 0f;
    public float speedUp = 0.5f;
    public float speedDown = 0.5f;
    public float speedMax = 4f;
    public float speedHorizontal = 3f;

    public GameObject bullet,posshoot;
    public int nbullet,turn;
    public int armor;
    public GameObject posspaw,panelgover;
    public GameObject[] item;

    public Text tarmor;
    private void Awake()
    {
        this.rid2D = GetComponent<Rigidbody2D>();

        InvokeRepeating("shoot", 1, 0.3f);

       
        InvokeRepeating("spawitem", 1, 4);
    }

    void spawitem() {
        Vector2 temp = posspaw.transform.position;
        temp.x = Random.Range(-2, 3);
        temp.y+= Random.Range(1, 3);

        int rd = Random.Range(0, item.Length);
        GameObject items = Instantiate(item[rd], temp, Quaternion.identity);

        Destroy(items, 5);
    }
    void Update()
    {
        tarmor.text = "" + armor;
        this.pressHori = Input.GetAxis("Horizontal");

        //this.pressVerti = Input.GetAxis("Vertical");
        if (transform.position.x >= 2.6f||transform.position.x<=-2.6f) {
            panelgover.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void FixedUpdate()
    {
        if (Linker.isStopped == false)
        {
            this.updateSpeed();
        }

    }
    protected virtual void updateSpeed()
    {
        this.velocity.x = this.pressHori * speedHorizontal;
        this.updateSpeedUp();
        //this.updateSpeedDown();


        if (this.velocity.y > this.speedMax) this.velocity.y = this.speedMax;

        this.rid2D.MovePosition(this.rid2D.position + this.velocity * Time.deltaTime);
    }
    protected virtual void updateSpeedUp()
    {
        if (this.pressVerti > 0)
        {
            this.velocity.y += this.speedUp;
            if (transform.position.x < -7 || transform.position.x > 7)
            {
                this.velocity.y -= 1f;
                if (this.velocity.y < 3f) this.velocity.y = 3f;
            }

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Police")
        {
            if (armor > 0)
            {
                armor--;
                Destroy(other.gameObject);
                Boom.Play();
            }
            else {
                panelgover.SetActive(true);
                Destroy(other.gameObject);
                Boom.Play();
                CheckGameOver.check = true;
                Time.timeScale = 0;
            }
            
        }

        if (other.gameObject.tag == "armor") {
            armor++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "bullet")
        {
            nbullet = 10;
            Destroy(other.gameObject);
        }
    }

    void shoot() {

        

            if (nbullet > 0)
            {
                nbullet--;
                Instantiate(bullet, posshoot.transform.position, Quaternion.identity);
            }
        
    }

    

    [SerializeField] private AudioSource Boom;
    //protected virtual void updateSpeedDown()
    //{
    //    if (this.pressVerti == 0)
    //    {
    //        this.velocity.y -= this.speedDown;
    //        if (this.velocity.y < 0) this.velocity.y = 0;
    //    }
    //}
}
