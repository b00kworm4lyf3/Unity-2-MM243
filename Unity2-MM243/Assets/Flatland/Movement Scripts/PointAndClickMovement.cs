// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Tilemaps;

// public class PointAndClickMovement : MonoBehaviour
// {
//     CrabCityActions crabCityActions;
//     public Tilemap map;

//     public float speed = 5;

//     private Vector3 destination;

//     void Awake()
//     {
//         crabCityActions = new CrabCityActions();
//     }
//     void OnEnable()
//     {
//         crabCityActions.Enable();
//     }

//     void OnDisable()
//     {
//         crabCityActions.Disable();
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
//         destination = transform.position;
//         crabCityActions.Mouse.MouseClick.performed += _ => MouseClick();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Vector3.Distance(transform.position, destination) > 0.1f)
//         transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
//     }

//     void MouseClick()
//     {
//         Vector2 mousePosition = crabCityActions.Mouse.MousePosition.ReadValue<Vector2>();
//         mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
//         Vector3Int gridPosition = map.WorldToCell(mousePosition);
//         if(map.HasTile(gridPosition))
//         {
//             destination = mousePosition;
//         }
//     }
// }
