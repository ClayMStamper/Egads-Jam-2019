using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.XR.MagicLeap;

namespace MagicLeap
{

    [RequireComponent(typeof(Planes))]
    [RequireComponent(typeof(PlaneVisualizer))]
    public class GravePlacer : MonoBehaviour
    {
        #region Private Variables
        private Planes _planesComponent;
        private PlaneVisualizer _planesVisualizer;
        private List<GameObject> _graves = new List<GameObject>();
        private List<GameObject> _lava = new List<GameObject>();
        public GameObject wisp;

        public GameObject GravePrefab;
        public GameObject LavaPrefab;
        public float GraveSpawnDistance = 1.0f;
        public int GraveCount = 5;

        // Distance close to sensor's maximum recognition distance.
        private static readonly Vector3 _boundlessExtentsSize = new Vector3(10.0f, 10.0f, 10.0f);
        
        private Camera _camera;

        public bool GravesPlaced()
        {
            if (_graves.Count >= GraveCount)
            {
                foreach (GameObject grave in _graves)
                {
                    grave.SetActive(true);
                    GraveManager.instance.graves.Add(grave.transform);
                    wisp.SetActive(false);
                }
                return true; 
            }

            return false;
        }

        void Awake()
        {
            MagicLeapDevice.RegisterOnHeadTrackingMapEvent(OnHeadTrackingMapEvent);

            _planesComponent = GetComponent<Planes>();
            _planesVisualizer = GetComponent<PlaneVisualizer>();
            
            _camera = Camera.main;

        }

        /// <summary>
        /// Start bounds based on _bounded state.
        /// </summary>
        void Start()
        {
            _planesComponent.transform.localScale = _boundlessExtentsSize;
        }

        /// <summary>
        /// Update position of the planes component to camera position.
        /// Planes query center is based on this position.
        /// </summary>
        void Update()
        {
            if (GravesPlaced())
            {
                return;
            }
            
            float distance = 2.0f;
            Vector3 rayOriginDirection = _camera.transform.forward;
            rayOriginDirection.y = 0;
            rayOriginDirection = Vector3.Normalize(rayOriginDirection);
            
            Vector3 rayOrigin = _camera.transform.position + (rayOriginDirection * distance);
            
            Ray ray = new Ray(rayOrigin, Vector3.down);

            
            _planesComponent.gameObject.transform.position = _camera.transform.position;

            GameObject planesParent = _planesVisualizer.PlanesParent();
            foreach (Transform child in planesParent.transform)
            {
                
                
                
                Collider planeCollider = child.gameObject.GetComponent<Collider>();
                
                RaycastHit hit;
                if (planeCollider.Raycast(ray, out hit, 7.0f))
                {
                    bool instantiate = true;
                    foreach (GameObject prevGrave in _graves)
                    {
                        if (Vector3.Distance(prevGrave.transform.position, hit.point) < GraveSpawnDistance)
                        {
                            instantiate = false;
                            break;
                        }
                        
                    }

                    if (instantiate)
                    {
                        GameObject instance = Instantiate(GravePrefab) as GameObject;
                        instance.SetActive(false);
                        instance.transform.position = hit.point;
                        

                        var lookPos = _camera.transform.position - instance.transform.position;
                        lookPos.y = 0;
                        var rotation = Quaternion.LookRotation(lookPos);
                        instance.transform.rotation = rotation;
                        _graves.Add(instance);
                    }
                    else
                        SpawnLava(hit);
                }

            }
        }

        private void SpawnLava(RaycastHit hit)
        {
            bool instantiate = true;
            foreach (GameObject prevLava in _lava)
            {
                if (Vector3.Distance(prevLava.transform.position, hit.point) < GraveSpawnDistance)
                {
                    instantiate = false;
                    break;
                }
                        
            }

            if (instantiate)
            {
                GameObject instance = Instantiate(LavaPrefab) as GameObject;
                //instance.SetActive(false);
                instance.transform.position = hit.point;
                        

                var lookPos = _camera.transform.position - instance.transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                instance.transform.rotation = rotation;
                _lava.Add(instance);
            }
        }

        /// <summary>
        /// Cleans up the component.
        /// </summary>
        void OnDestroy()
        {
            MagicLeapDevice.UnregisterOnHeadTrackingMapEvent(OnHeadTrackingMapEvent);
        }
        #endregion
        
        #region Event Handlers

        /// <summary>
        /// Handle in charge of clearing all planes if map gets lost.
        /// </summary>
        /// <param name="mapEvents"> Map Events that happened. </param>
        private void OnHeadTrackingMapEvent(MLHeadTrackingMapEvent mapEvents)
        {
            if (mapEvents.IsLost())
            {
                // TODO may need to do something if we lose headpose but not yet
            }
        }
        #endregion

    }
}
