using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetByPlayerPos : MonoBehaviour {

    // Use this for initialization
    public Image[] m_images;
    public Player m_player;
    public Camera m_camera;
    public Canvas m_canvas;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RectTransform rt = m_images[0].gameObject.GetComponent<RectTransform>();
        float w = rt.rect.width/2;
        float l = rt.rect.height/2;
       Vector3 pos = WorldToUI(m_camera, m_player.gameObject.transform.position);
        m_images[0].gameObject.transform.position = new Vector3(pos.x,pos.y, pos.z);
        m_images[1].gameObject.transform.position = new Vector3(pos.x,pos.y+l+ m_images[1].gameObject.GetComponent<RectTransform>().rect.height/2,  pos.z);
        m_images[2].gameObject.transform.position = new Vector3(pos.x, pos.y - l - m_images[2].gameObject.GetComponent<RectTransform>().rect.height / 2, pos.z);
        m_images[3].gameObject.transform.position = new Vector3(pos.x - w - m_images[3].gameObject.GetComponent<RectTransform>().rect.width / 2, pos.y , pos.z);
        m_images[4].gameObject.transform.position = new Vector3(pos.x + w + m_images[4].gameObject.GetComponent<RectTransform>().rect.width / 2, pos.y, pos.z);
    }

    public  Vector3 WorldToUI(Camera camera, Vector3 pos)
    {
        CanvasScaler scaler = gameObject.GetComponent<CanvasScaler>();

        float resolutionX = scaler.referenceResolution.x;
        float resolutionY = scaler.referenceResolution.y;

        Vector3 viewportPos = m_camera.WorldToViewportPoint(pos);

        Vector3 uiPos = new Vector3(viewportPos.x * resolutionX - resolutionX * 0.5f,
            viewportPos.y * resolutionY - resolutionY * 0.5f, 0);
         uiPos = new Vector3(viewportPos.x * resolutionX ,
           viewportPos.y * resolutionY, 0);
       float xScale =  Screen.width / resolutionX;
        float yScale = Screen.height / resolutionY;
        uiPos.x *= xScale;
        uiPos.y *= yScale;
        return uiPos;


        //CanvasScaler canvasScaler = gameObject.GetComponent<CanvasScaler>();

     

        //float offectX = (Screen.width / canvasScaler.referenceResolution.x) * (1 - canvasScaler.matchWidthOrHeight);//
        //float offsetY = (Screen.height / canvasScaler.referenceResolution.y) * canvasScaler.matchWidthOrHeight;
        //offectX = offectX + offsetY;
        //Vector2 a = RectTransformUtility.WorldToScreenPoint(m_camera, pos);
        
        //return new Vector3(a.x / offectX, a.y / offsetY,0); ;
    }

 
}
