using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCubeState : MonoBehaviour
{
    public GameObject myCube, takingCollision;
    public int heigh;
    public static bool dead;

    void Update()
    {
        myCube.transform.position = new Vector3(transform.position.x, heigh + 1, transform.position.z); //повышает высоту MyCube при взятии
        takingCollision.transform.localPosition = new Vector3(0, -heigh, 0); //снижает коллизию поднятия по высоте "Taking Collision", так как после поднятия куба она повышается
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Takable" && other.gameObject.GetComponent<TakeCube>().GetTakeState() == false) //&& проверяет если у меня уже был взят куб и возвращает false 
        {
            heigh += 1;
            other.gameObject.GetComponent<TakeCube>().Take(); //Говорит классу TakeCube что куб был взят
            other.gameObject.GetComponent<TakeCube>().TakeIndex(heigh); //Говорит классу TakeCube, что TakeIndex должен добавить значение heigh
            other.gameObject.transform.parent = myCube.transform; //Делает иерархию в персонаже MyCybe, перемещая в него новый, поднятый объект с тэгом Takable
        }
        if (other.gameObject.tag == "Wall")
        {
            if (heigh <= 0)
            {
                print("DEAD WALL COLLISION MyCubeState");
                dead = true;
            }
        }
    }
}