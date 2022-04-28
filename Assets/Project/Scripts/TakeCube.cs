using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCube : MonoBehaviour
{
    private bool takeState;
    int index;
    public MyCubeState myCubeState;
    //public WallScript wallScript;

    void Update()
    {
        if(takeState == true) //провекрка если куб был взят
        {
            if (transform.parent != null) //проверка чтобы сброшенный куб не вернулся на нулевую позицию
            {
                transform.localPosition = new Vector3(0, -index, 0); //Перемещает поднятый куб под MyCube
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if(myCubeState.heigh >= 1)
            {
                print("BEFORE Decrease" + myCubeState.heigh);
                print("WALL COLLISION TakeCube");
                myCubeState.heigh--;
                transform.parent = null; //сбрасывает куб, который ударился об препятствие
                GetComponent<BoxCollider>().enabled = false; //отключат коллизию кубу которы сбрасывается при столкновении с препятсвием
                other.gameObject.GetComponent<BoxCollider>().enabled = false; //отключат коллизию препятствию
            }
        }
    }
    public void Take()
    {
        takeState = true;
    }
    public bool GetTakeState()
    {
        return takeState;
    }
    public void TakeIndex(int index) //нужно для определения количества кубов
    {
        this.index = index;
    }
}
