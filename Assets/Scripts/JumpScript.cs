using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private GameObject jumpDisk;
    [SerializeField] private Text scoreLabel;
    [SerializeField] private JumpData jumpData;
    private Animator anim;
    private Vector3 mousePos;
    private IEnumerator activeJumpCoroutine;
    public float JumpProgress { get; private set; }
    public Animator Anim { get => anim; set => anim = value; }

    public int jumpScore;

    void Awake() 
    {
         scoreLabel.text = (PlayerPrefs.GetInt("jumpScore").ToString());
         jumpScore = PlayerPrefs.GetInt("jumpScore");
    }

    void Start() 
    {
        Anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (jumpDisk.GetComponent<JumpDiskScript>().PlayerEnter && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                mousePos = hit.point;
            }
            
            //Увеличение счета прыжков и сохранение значения
            jumpScore++;
            PlayerPrefs.SetInt("jumpScore", PlayerPrefs.GetInt("jumpScore") + 1);
            scoreLabel.text = jumpScore.ToString();

            Vector3 destinationPoint = new Vector3(mousePos.x, 1.3f, 0);
            int maxHeight = jumpDisk.GetComponent<JumpDiskScript>()._JumpHeight;
            jumpDisk.GetComponent<JumpDiskScript>().JumpSettings();

            Jump(destinationPoint, maxHeight);
            anim.SetTrigger("Jump");
            anim.SetTrigger("IDLE");
            this.GetComponent<PlayerMove>().move = true;
        }
    }
    //Код прыжка
    public void Jump(Vector3 destination, float _maxHeight) {
        if (activeJumpCoroutine != null) {
            StopCoroutine(activeJumpCoroutine);
            activeJumpCoroutine = null;
            JumpProgress = 0.0f;
        }
        activeJumpCoroutine = JumpCoroutine(destination, _maxHeight);
        this.GetComponent<PlayerMove>().move = false;
        StartCoroutine(activeJumpCoroutine);
     }

    IEnumerator JumpCoroutine(Vector3 destination, float _maxHeight) {
        Vector3 startPos = transform.position;
        while (JumpProgress <= 1.0) {
            JumpProgress += Time.deltaTime / 2.0f;
            float height = Mathf.Sin(Mathf.PI * JumpProgress) * _maxHeight;
            if (height < 0f) {
                height = 0f;
            }
            transform.position = Vector3.Lerp(startPos, destination, JumpProgress) + Vector3.up * height;
            yield return null;
        }
        transform.position = destination;
     }
}
