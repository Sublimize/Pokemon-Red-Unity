using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
//Save/Loader for Tile Pool
public class Serializer
{
    public static T[] Load<T>(string filename) where T : class
    {
        if (File.Exists(filename))
        {
            try
            {
                using (Stream stream = File.OpenRead(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(stream) as T[];
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        return default(T[]);
    }

    public static void Save<T>(string filename, T[] data) where T : class
    {
        using (Stream stream = File.OpenWrite(filename))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }
}
//Properties of tile, including collision, and others
[System.Serializable]
public class Tile {
    public int layer;
    public string sprite;
    public string tag;
    public bool isAnimated;
   


}

[ExecuteInEditMode]
public class MapEditor : MonoBehaviour {
    public enum Mode
    {
       Edit,
        Delete,
        Select
    };
    public TextMeshProUGUI modetext;
    public GameObject container;
    public Toggle onlyonce, hasText;
    public TMP_InputField textId, itemname, wildgroupid;
    public int currentTileIndex = 0;
    public GameObject template;
    public Camera editorcamera;
    public Image editchangesprite, editoriginalsprite, previewCreateSprite;
    public bool hasPropertyComponent, hasWarpComponent, hasTallGrassComponent;
    public GameObject propertyoverlay, warpoverlay, tallgrassoverlay;
    public GameObject currenttile;
    public bool placingWarp;
    public GameObject warpmarker, tilecursor;
    public GameObject selectmarker;
    public GameObject hoveredtile;
    public List<GameObject> multisselectsprites, selectedtiles; 
    public List<Tile> tilepool = new List<Tile>();
    public Mode currentmode;
    Vector2 lastselectedpos,lastdeletedpos;
    public bool canselectagain,candeleteagain;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentmode == Mode.Delete)
            {
                currentmode = Mode.Edit;
                goto ChangeModeEnd;
            }
            if (currentmode == Mode.Edit)
            {
                currentmode = Mode.Select;

                goto ChangeModeEnd;
            }
            if (currentmode == Mode.Select)
            {
                currentmode = Mode.Delete;
                candeleteagain = true;
                foreach(GameObject sprite in multisselectsprites){
                    multisselectsprites.Remove(sprite);
                    Destroy(sprite);
                }
                foreach (GameObject sprite in selectedtiles)
                {
                    selectedtiles.Remove(sprite);
                }
                goto ChangeModeEnd;
            }


                
        }    
        ChangeModeEnd:
        switch(currentmode){
            case Mode.Edit:
                modetext.text = "Mode: Draw/Edit";
                break;
            case Mode.Delete:
                modetext.text = "Mode: Delete";
                break;
            case Mode.Select:
                modetext.text = "Mode: Multi-Edit";
                break;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            currentTileIndex--;
            if (currentTileIndex < 0) currentTileIndex = tilepool.Count - 1;

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentTileIndex++;
            if (currentTileIndex == tilepool.Count) currentTileIndex = 0;

        }
        if(currentmode == Mode.Select){
            hasWarpComponent = true;
            hasPropertyComponent = true;
            hasTallGrassComponent = true;
            foreach(GameObject selectedtile in selectedtiles){
                if(!selectedtile.GetComponent<itemData>()){
                    hasPropertyComponent = false;


                }
                if (!selectedtile.GetComponent<TileWarp>())
                {
                    hasWarpComponent = false;


                }
                if (!selectedtile.GetComponent<TallGrass>())
                {
                    hasTallGrassComponent = false;


                }
            }
        }else if(currenttile != null){
            hasPropertyComponent = currenttile.GetComponent<itemData>();
            hasWarpComponent = currenttile.GetComponent<TileWarp>();
            hasTallGrassComponent = currenttile.GetComponent<TallGrass>();

        }

        editchangesprite.sprite = Resources.Load<Sprite>("interiortiles/"+ tilepool[currentTileIndex].sprite);
        previewCreateSprite.sprite = Resources.Load<Sprite>("interiortiles/" + tilepool[currentTileIndex].sprite);

        transform.Translate(new Vector2(-Input.mouseScrollDelta.x,Input.mouseScrollDelta.y));
        Vector3 mousepos = editorcamera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        mousepos = editorcamera.ViewportToWorldPoint(mousepos);
        Vector2 snappos = new Vector2(Mathf.Round(mousepos.x), Mathf.Round(mousepos.y));
        RaycastHit2D hit = Physics2D.Raycast(snappos, Vector2.zero);
        if (hit.collider != null) hoveredtile = hit.collider.gameObject;
        if (!placingWarp)
        {
            tilecursor.transform.position = new Vector2(Mathf.Round(mousepos.x), Mathf.Round(mousepos.y));
        }else{
            warpmarker.transform.position = new Vector2(Mathf.Round(mousepos.x), Mathf.Round(mousepos.y));
        }
        if (Input.mousePosition.x < Screen.width * 0.775f)
        {
            if (Input.GetMouseButtonDown(0)  && currentmode == Mode.Edit)
            {
                if (!placingWarp )
                {
                    if (hit.collider != null)
                    {
                        currenttile = hit.collider.gameObject;
                        if (currenttile.GetComponent<itemData>())
                        {
                            itemData itemdata = currenttile.GetComponent<itemData>();

                            onlyonce.isOn = itemdata.onlyonce;
                            hasText.isOn = itemdata.hasText;
                            textId.text = itemdata.TextID.ToString();
                            itemname.text = itemdata.itemName;
                        }
                        if (currenttile.GetComponent<TileWarp>())
                        {
                            TileWarp warp = currenttile.GetComponent<TileWarp>();
                            warpmarker.transform.position = warp.warppos;
                        }
                    }

                }
            }
            if (Input.GetMouseButton(0) && !placingWarp && currentmode == Mode.Select && hit.collider != null && ( snappos != lastselectedpos || canselectagain))
            {
                if(!selectedtiles.Contains(hoveredtile)){
                    canselectagain = false;
                    selectedtiles.Add(hoveredtile);
                    GameObject go = Instantiate(selectmarker, snappos,Quaternion.identity);
                    multisselectsprites.Add(go);
                    lastselectedpos = snappos;
                }else{
                    canselectagain = false;
                    Destroy(multisselectsprites[selectedtiles.IndexOf(hoveredtile)]);
                    multisselectsprites.RemoveAt(selectedtiles.IndexOf(hoveredtile));
                    selectedtiles.Remove(hoveredtile);
                    lastselectedpos = snappos;
                }
            }
            if(Input.GetMouseButtonUp(0) && !placingWarp && currentmode == Mode.Select && lastselectedpos == snappos){
               
                canselectagain = true;
            }
            if (Input.GetMouseButtonUp(0) && !placingWarp && currentmode == Mode.Delete && lastdeletedpos == snappos)
            {
                candeleteagain = true;
            }
            if(Input.GetMouseButton(0) && !placingWarp && currentmode == Mode.Delete && hit.collider != null && (snappos != lastdeletedpos || candeleteagain)){
                Destroy(hoveredtile);
                candeleteagain = false;
                lastdeletedpos = snappos;
            }
            if(Input.GetMouseButtonUp(0) && placingWarp){
                placingWarp = false;
            }
            if (Input.GetMouseButton(0) && !placingWarp && currentmode == Mode.Edit && tilepool[currentTileIndex].tag == "TallGrass")
            {
                if(hoveredtile.tag == "TallGrass"){
                    goto SkipTallGrassRule;
                }
                GameObject gameObject = Instantiate(template, container.transform, true);
                gameObject.transform.position = snappos;
                gameObject.tag = tilepool[currentTileIndex].tag;
                gameObject.layer = tilepool[currentTileIndex].layer;
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("interiortiles/" + tilepool[currentTileIndex].sprite );
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                if (gameObject.tag == "TallGrass") gameObject.AddComponent<TallGrass>();
                if (tilepool[currentTileIndex].isAnimated)
                {

                    gameObject.AddComponent<AnimatedTile>();
                    gameObject.GetComponent<AnimatedTile>().tileanimsprites = Resources.LoadAll<Sprite>("interiortiles/" + tilepool[currentTileIndex].sprite );
                }

            }
            SkipTallGrassRule:
            if(Input.GetMouseButton(0) && hit.collider == null && !placingWarp && currentmode == Mode.Edit){
                GameObject gameObject = Instantiate(template, container.transform, true);
                gameObject.transform.position = snappos;
                gameObject.tag = tilepool[currentTileIndex].tag;
                gameObject.layer = tilepool[currentTileIndex].layer;
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("interiortiles/" + tilepool[currentTileIndex].sprite );
                if (gameObject.tag == "TallGrass") gameObject.AddComponent<TallGrass>();
                if (tilepool[currentTileIndex].isAnimated)
                {
                    
                    gameObject.AddComponent<AnimatedTile>();
               
                    gameObject.GetComponent<AnimatedTile>().tileanimsprites = Resources.LoadAll<Sprite>("interiortiles/" + tilepool[currentTileIndex].sprite );
                }

            }
        }

       
        if(currenttile != null){
            warpmarker.SetActive(currenttile.GetComponent<TileWarp>());
            editoriginalsprite.sprite = currenttile.GetComponent<SpriteRenderer>().sprite;

        }
        tallgrassoverlay.SetActive(!hasTallGrassComponent);
        propertyoverlay.SetActive(!hasPropertyComponent);
        warpoverlay.SetActive(!hasWarpComponent);
	}
    public void SetDestination(){
        placingWarp = true;
    }
    public void AddAComponent(string name){
        switch(name){
            case "Property":
                currenttile.AddComponent<itemData>();
                if (currenttile.layer == 5)
                {
                    currenttile.layer = 14;
                    currenttile.tag = "WallObjectInteract";
                }
                if (currenttile.layer == 9)
                {
                    currenttile.layer = 13;
                    currenttile.tag = "Interact";
                }

                break;
            case "Warp":
                currenttile.AddComponent<TileWarp>();
            
                break;
            case "TallGrass":
                foreach(GameObject selectedtile in selectedtiles){
                    if(selectedtile.GetComponent<TallGrass>())
                    selectedtile.AddComponent<TallGrass>(); 
                }

                break;

                
        }
    }
    public void ApplyChanges(string component){
        switch(component){
            case "SpriteEditor":
                SpriteRenderer renderer = currenttile.GetComponent<SpriteRenderer>();
                renderer.sprite = Resources.Load<Sprite>("interiortiles/" + tilepool[currentTileIndex].sprite );
                break;
            case "Property":
                itemData itemdata = currenttile.GetComponent<itemData>();
                itemdata.onlyonce = onlyonce.isOn;
                itemdata.hasText = hasText.isOn;
                int.TryParse(textId.text, out itemdata.TextID);
                itemdata.itemName = itemname.text;

                break;
            case "Warp":
                TileWarp warp = currenttile.GetComponent<TileWarp>();
                warp.warppos = warpmarker.transform.position;
                break;
            case "TallGrass":
                if (currentmode == Mode.Select)
                {
                    foreach (GameObject selectedtile in selectedtiles)
                    {
                        TallGrass tg = selectedtile.GetComponent<TallGrass>();
                        int.TryParse(wildgroupid.text, out tg.WildGroupID );
                    }
                }else if (currentmode == Mode.Edit){
                    TallGrass tg = currenttile.GetComponent<TallGrass>();
                    int.TryParse(wildgroupid.text, out tg.WildGroupID);
                }

                break;
        }
    }
}
[CustomEditor(typeof(MapEditor))]
public class MapTileEditor : Editor
{

public override void OnInspectorGUI()
{
  DrawDefaultInspector();
  MapEditor me = (MapEditor)target;
  if (GUILayout.Button("Add New Tile Entry"))
  {
          me.tilepool.Add(new Tile());
    
  }   
        if (GUILayout.Button("Save Tile Pool from Save Data"))
  {
            Serializer.Save<Tile>("tilepool.txt", me.tilepool.ToArray());

    
  } 
        if (GUILayout.Button("Load Tile Pool from Save Data"))
  {
            me.tilepool = new List<Tile>(Serializer.Load<Tile>("tilepool.txt"));
    
  }   
  }


}

