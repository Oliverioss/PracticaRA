using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : PressInputBase
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        public GameObject m_PlacedPrefab;
        public GameObject m_PlacedPrefab2;
        public GameObject m_PlacedPrefab3;
        private GameObject choosedPrefab;

        public static PlaceOnPlane Instance;
        public TMP_Dropdown dropdown;
        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>

        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject { get; private set; }

        bool m_Pressed;
        private void Start()
        {
            ChangePrefab();
        }
        protected override void Awake()
        {
            base.Awake();
            m_RaycastManager = GetComponent<ARRaycastManager>();
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        void Update()
        {

            if (Pointer.current == null || m_Pressed == false)
                return;

            var touchPosition = Pointer.current.position.ReadValue();

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(choosedPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
        public void OnDropdownChanged(int index)
        {
            ChangePrefab();

            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
                spawnedObject = null;
            }
        }
        public void ChangePrefab()
        {
            if (dropdown.value == 0)
            {
                choosedPrefab = m_PlacedPrefab;
            }
            if (dropdown.value == 1)
            {
                choosedPrefab = m_PlacedPrefab2;
            }
            if (dropdown.value == 2)
            {
                choosedPrefab = m_PlacedPrefab3;
            }
        }
        public void DeleteSpawnedObject()
        {
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
                spawnedObject = null;
            }
        }

        public void ReturnToScene()
        {
            ARSession arSession = FindFirstObjectByType<ARSession>();
            if (arSession != null)
            {
                arSession.Reset();  
            }

            // Cambia a la escena de menú
            SceneManager.LoadScene("EscenaMenu");
        }

        protected override void OnPress(Vector3 position) => m_Pressed = true;

        protected override void OnPressCancel() => m_Pressed = false;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}
