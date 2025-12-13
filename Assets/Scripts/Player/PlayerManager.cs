using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public GameObject builder;
   public GameObject breaker;
   public GameObject body;

   private GameObject current;

   private ICharacterAction currentAction;

   void Start()
   {
      SwitchTo(builder);
   }

   void Update()
   {
      HandleSwitching();
      HandleAction();

      if (current == builder)
      {
         builder.GetComponent<PlayerMovement>().enabled = true;
         body.GetComponent<PlayerMovement>().enabled = false;
         breaker.GetComponent<PlayerMovement>().enabled = false;
      }
      
      if (current == body)
      {
         body.GetComponent<PlayerMovement>().enabled = true;
         
         builder.GetComponent<PlayerMovement>().enabled = false;
         breaker.GetComponent<PlayerMovement>().enabled = false;
      }
      
      if (current == breaker)
      { 
         breaker.GetComponent<PlayerMovement>().enabled = true;
         
         body.GetComponent<PlayerMovement>().enabled = false;
         builder.GetComponent<PlayerMovement>().enabled = false;
      }
      
      //Debug.Log("PlayerManager Update running");

   }

   /*void HandleSwitching()
   {
      if (Input.GetKeyDown(KeyCode.Q)) CycleLeft();
      
      if (Input.GetKeyDown(KeyCode.E)) CycleRight();
   }*/
   
   void HandleSwitching()
   {
      if (Input.GetKeyDown(KeyCode.Q))
      {
         Debug.Log("Q pressed");
         Debug.Log($"builder: {builder}");
         Debug.Log($"breaker: {breaker}");
         Debug.Log($"body: {body}");
         Debug.Log($"current: {current}");
         CycleLeft();
      }

      if (Input.GetKeyDown(KeyCode.E))
      {
         Debug.Log("E pressed");
         Debug.Log($"builder: {builder}");
         Debug.Log($"breaker: {breaker}");
         Debug.Log($"body: {body}");
         Debug.Log($"current: {current}");
         CycleRight();
      }
   }


   void HandleAction()
   {
      if (Input.GetKeyDown(KeyCode.F)) currentAction?.DoAction();
   }

   void SwitchTo(GameObject target)
   {
      // Disable movement on all characters
      builder.GetComponent<PlayerMovement>().enabled = false;
      breaker.GetComponent<PlayerMovement>().enabled = false;
      body.GetComponent<PlayerMovement>().enabled = false;

      // Set current player
      current = target;
      currentAction = current.GetComponent<ICharacterAction>();
      current.GetComponent<PlayerMovement>().enabled = true;

      // --- FOLLOW LOGIC (chained) ---
      if (current == builder)
      {
         builder.GetComponent<FollowTarget>().target = null;
         breaker.GetComponent<FollowTarget>().target = builder.transform;
         body.GetComponent<FollowTarget>().target = breaker.transform;
      }
      else if (current == breaker)
      {
         breaker.GetComponent<FollowTarget>().target = null;
         builder.GetComponent<FollowTarget>().target = breaker.transform;
         body.GetComponent<FollowTarget>().target = builder.transform;
      }
      else // current == body
      {
         body.GetComponent<FollowTarget>().target = null;
         builder.GetComponent<FollowTarget>().target = body.transform;
         breaker.GetComponent<FollowTarget>().target = builder.transform;
      }

      // --- DEBUGS ---
      if (current == builder)
         Debug.Log("Builder is currently moving");
      if (current == breaker)
         Debug.Log("Breaker is currently moving");
      if (current == body)
         Debug.Log("Body is currently moving");
   }

   void CycleLeft()
   {
      if (current == builder) SwitchTo(body);
      else if (current == breaker) SwitchTo(builder);
      else SwitchTo(breaker);
   }

   void CycleRight()
   {
      if (current == builder) SwitchTo(breaker);
      else if (current == breaker) SwitchTo(body);
      else SwitchTo(builder);
   }
}
