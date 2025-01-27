using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 

public class CursorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] Texture2D cursor; 
    [SerializeField] Texture2D cursorOver;

    //Inventory inventory;

   

    private void Awake()
    {   
        
        ChangeCursor(cursor);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined; //Cursor verschwindet nicht vom Bildschirm 
    }
        
        

    public void ChangeCursor(Texture2D cursorType){
        Vector2 hotspot = new Vector2(cursorType.width/2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    void OnMouseEnter(){
        ChangeCursor(cursorOver);
    }

    void OnMouseExit(){
        ChangeCursor(cursor);
    }

    void OnMouseDown(){ 
        
        if (gameObject.GetComponent<SphereCollider>() != null ) {
            
            if (gameObject.tag == "GreenBall"){
                gameObject.GetComponent<ShowInventory>().ShowImage();
            }
            else if (gameObject.tag == "YellowBall"){
                gameObject.GetComponent<ShowInventory>().ShowImage();
            }
            else if (gameObject.tag == "BlueBall"){
                gameObject.GetComponent<ShowInventory>().ShowImage();
            }
            
        
            Destroy(gameObject);
            ChangeCursor(cursor);
        }
        

        if (gameObject.tag == "ElevatorDisplay"){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            ChangeCursor(cursor);
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);  
            
        }

        if (gameObject.tag == "Book"){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            ChangeCursor(cursor);
            SceneManager.LoadScene("InfotextVignere", LoadSceneMode.Additive);  
            
        }

        if (gameObject.tag == "Hinweise"){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            ChangeCursor(cursor);
            SceneManager.LoadScene("HinweiseKryptologie", LoadSceneMode.Additive);  
            
        }

        if (gameObject.tag == "Anleitungstext"){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);  
        }
        if (gameObject.tag == "Tuere"){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);  
        }
        if (gameObject.tag == "PuzzlePieces"){
            gameObject.GetComponent<ShowPuzzlePieces>().ShowImages(); 
            Destroy(gameObject); 
        }

        if (gameObject.tag == "Caesar"){
            gameObject.GetComponent<ShowInventory>().ShowImage(); 
            Destroy(gameObject); 
           

        }
        if (gameObject.tag == "Infotext"){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);  
        }

        if (gameObject.tag == "Hardware"){
            SceneManager.LoadScene("SettingComputer"); //, LoadSceneMode.Additive);  
        }

        if (gameObject.tag == "Boss"){
            gameObject.GetComponent<ShowInventory>().ShowImage();
            Time.timeScale = 0;            
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
        ChangeCursor(cursorOver);
    }

    
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        
        ChangeCursor(cursor);
    }
        
    }  
    
    

